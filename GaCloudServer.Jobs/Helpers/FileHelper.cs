namespace GaCloudServer.Jobs.Helpers
{
    public static class FileHelper
    {
        public static class SqlHelper
        {
            public static string LoadSqlFromFile(string relativePath)
            {
                var basePath = Directory.GetCurrentDirectory(); // root del processo
                var fullPath = Path.Combine(basePath, relativePath);

                if (!File.Exists(fullPath))
                    throw new FileNotFoundException($"SQL file not found: {fullPath}");

                return File.ReadAllText(fullPath);
            }
        }
    }
}
