using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GaCloudServer.Jobs.Helpers
{

    public static class TextHelpers
    {
        /// <summary>
        /// Converts this instance to delimited text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="includeHeader">
        /// if set to <c>true</c> then the header row is included.
        /// </param>
        /// <param name="trimTrailingNewLineIfExists">
        /// If set to <c>true</c> then trim trailing new line if it exists.
        /// </param>
        /// <returns></returns>
        public static string ToDelimitedText<T>(this List<T> instance,
            string delimiter,
            bool includeHeader = false,
            bool trimTrailingNewLineIfExists = false)
            where T : class, new()
        {
            int itemCount = instance.Count;
            if (itemCount == 0) return string.Empty;

            var properties = GetPropertiesOfType<T>();
            int propertyCount = properties.Length;
            var outputBuilder = new StringBuilder();

            AddHeaderIfRequired(outputBuilder, includeHeader, properties, propertyCount, delimiter);

            for (int itemIndex = 0; itemIndex < itemCount; itemIndex++)
            {
                T listItem = instance[itemIndex];
                AppendListItemToOutputBuilder
                (outputBuilder, listItem, properties, propertyCount, delimiter);

                AddNewLineIfRequired(trimTrailingNewLineIfExists, itemIndex, itemCount, outputBuilder);
            }

            var output = outputBuilder.ToString();
            return output;
        }

        private static void AddHeaderIfRequired(StringBuilder outputBuilder,
            bool includeHeader,
            PropertyInfo[] properties,
            int propertyCount,
            string delimiter)
        {
            if (!includeHeader) return;

            for (int propertyIndex = 0; propertyIndex < properties.Length; propertyIndex += 1)
            {
                var property = properties[propertyIndex];
                var propertyName = property.Name;
                outputBuilder.Append(propertyName);

                AddDelimiterIfRequired(outputBuilder, propertyCount, delimiter, propertyIndex);
            }
            outputBuilder.Append(Environment.NewLine);
        }

        private static void AddDelimiterIfRequired
        (StringBuilder outputBuilder, int propertyCount, string delimiter,
            int propertyIndex)
        {
            bool isLastProperty = (propertyIndex + 1 == propertyCount);
            if (!isLastProperty)
            {
                outputBuilder.Append(delimiter);
            }
        }

        private static void AddNewLineIfRequired
        (bool trimTrailingNewLineIfExists, int itemIndex, int itemCount,
            StringBuilder outputBuilder)
        {
            bool isLastItem = (itemIndex + 1 == itemCount);
            if (!isLastItem || !trimTrailingNewLineIfExists)
            {
                outputBuilder.Append(Environment.NewLine);
            }
        }

        private static void AppendListItemToOutputBuilder<T>(StringBuilder outputBuilder,
            T listItem,
            PropertyInfo[] properties,
            int propertyCount,
            string delimiter)
            where T : class, new()
        {

            for (int propertyIndex = 0; propertyIndex < properties.Length; propertyIndex += 1)
            {
                var property = properties[propertyIndex];
                var propertyValue = property.GetValue(listItem);
                outputBuilder.Append(propertyValue);

                AddDelimiterIfRequired(outputBuilder, propertyCount, delimiter, propertyIndex);
            }
        }

        private static PropertyInfo[] GetPropertiesOfType<T>() where T : class, new()
        {
            Type itemType = typeof(T);
            var properties = itemType.GetProperties
            (BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public);
            return properties;
        }
    }
}

