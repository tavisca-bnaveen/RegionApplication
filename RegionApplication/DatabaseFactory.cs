namespace RegionApplication
{
    public static class DatabaseFactory
    {
        public static IDatabase SelectDatabase(string DbName)
        {
            switch (DbName.ToLower())
            {
                case "sql":
                    return new SqlDatabase();
                case "mongo":
                    return new MongoDatabase();
                default:
                    return new SqlDatabase();
            }
        }
    }
}
