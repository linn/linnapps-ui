namespace Linn.LinnappsUi.Persistence
{
    using Linn.Common.Configuration;

    public static class ConnectionStrings
    {
        public static string ManagedConnectionString()
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];

            return $"user id={userId}; password={password}; data source={host}";
        }
    }
}
