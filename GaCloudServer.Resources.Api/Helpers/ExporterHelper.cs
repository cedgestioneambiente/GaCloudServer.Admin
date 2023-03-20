using AutoWrapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GaCloudServer.Resources.Api.Helpers
{
    public class ExporterHelper
    {
        public static string ExcelContentType
        {
            get
            { return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; }
        }

        public static DataTable ListToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dataTable = new DataTable();

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }

                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DataTable ListObjectToDataTable(List<object> data)
        {
            // Create a new DataTable
            DataTable dataTable = new DataTable();

            // Get the properties of the first object in the list
            var properties = ((IDictionary<string, object>)data.First()).Keys;

            // Add columns to the DataTable for each property
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property);
            }

            // Add rows to the DataTable for each object in the list
            foreach (var dynamicObject in data)
            {
                var row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property] = ((IDictionary<string, object>)dynamicObject)[property];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;

        }

        public static byte[] ExportExcel(DataTable dataTable, string heading = "", string extra1 = "", string extra2 = "", string type = "", bool showSrNo = false, params string[] columnsToTake)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            byte[] result = null;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add(String.Format("{0} Data", heading));
                int startRowFrom = 1;// String.IsNullOrEmpty(heading) ? 1 : 5;

                if (showSrNo)
                {
                    DataColumn dataColumn = dataTable.Columns.Add("#", typeof(int));
                    dataColumn.SetOrdinal(0);
                    int index = 1;
                    foreach (DataRow item in dataTable.Rows)
                    {
                        item[0] = index;
                        index++;
                    }
                }


                //add the content into the Excel file
                workSheet.Cells["A" + startRowFrom].LoadFromDataTable(dataTable, true);

                if (extra1 == "forceDateTime")
                {
                    int colNumber = 0;
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        colNumber++;
                        if (col.DataType == typeof(DateTime))
                        {
                            workSheet.Column(colNumber).Style.Numberformat.Format = "dd/mm/yyyy";
                        }
                    }
                }

                //autofit width of cells with small content
                int columnIndex = 1;
                foreach (DataColumn column in dataTable.Columns)
                {
                    ExcelRange columnCells = workSheet.Cells[workSheet.Dimension.Start.Row, columnIndex, workSheet.Dimension.End.Row, columnIndex];
                    int maxLength = 1;
                    try
                    {
                        maxLength = columnCells.Max(cell => cell.Value.ToString().Count());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Detail: " + ex.Message);
                    }


                    if (maxLength < 150)
                    {
                        try
                        {
                            workSheet.Column(columnIndex).AutoFit();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }


                    columnIndex++;
                }

                //format header -bold, yellow on black
                using (ExcelRange r = workSheet.Cells[startRowFrom, 1, startRowFrom, dataTable.Columns.Count])
                {
                    r.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    r.Style.Font.Bold = true;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#1fb5ad"));
                }

                //format cells -add borders
                using (ExcelRange r = workSheet.Cells[startRowFrom + 1, 1, startRowFrom + dataTable.Rows.Count, dataTable.Columns.Count])
                {
                    r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    r.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }

                //removed ignored columns
                for (int i = dataTable.Columns.Count - 1; i >= 0; i--)
                {
                    if (i == 0 && showSrNo)
                    {
                        continue;
                    }
                    if (!columnsToTake.Contains(dataTable.Columns[i].ColumnName))
                    {
                        workSheet.DeleteColumn(i + 1);
                    }
                }

                if (!String.IsNullOrEmpty(heading))
                {
                    if (type == "MAP")
                    {
                        workSheet.Cells["A1"].Value = "DESC. GIRO: " + heading;
                        workSheet.Cells["A1"].Style.Font.Size = 20;
                        workSheet.Cells["A2"].Value = "N° OPERATORI: " + extra1;
                        workSheet.Cells["A2"].Style.Font.Size = 20;
                        workSheet.Cells["A3"].Value = "PESO A DESTINO: " + extra2 + " KG.";
                        workSheet.Cells["A3"].Style.Font.Size = 20;

                        workSheet.InsertColumn(1, 1);
                        workSheet.InsertRow(1, 1);
                        workSheet.Column(1).Width = 5;
                    }
                    else if (type == "SCAD_DIP")
                    {
                        workSheet.Cells["A1"].Value = "" + heading;
                        workSheet.Cells["A1"].Style.Font.Size = 20;

                        workSheet.InsertColumn(1, 1);
                        workSheet.InsertRow(1, 1);
                        workSheet.Column(1).Width = 3;
                    }
                }

                result = package.GetAsByteArray();
            }

            return result;
        }

        public static byte[] ExportExcel<T>(List<T> data, string Heading = "", string extra1 = "", string extra2 = "", string type = "", bool showSlno = false, params string[] ColumnsToTake)
        {
            return ExportExcel(ListToDataTable<T>(data), Heading, extra1, extra2, type, showSlno, ColumnsToTake);
        }

        public static byte[] ExportObjectExcel(List<object> data, string Heading = "", string extra1 = "", string extra2 = "", string type = "", bool showSlno = false, params string[] ColumnsToTake)
        {
            return ExportExcel(ListObjectToDataTable(data), Heading, extra1, extra2, type, showSlno, ColumnsToTake);
        }

    }
}
