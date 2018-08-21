namespace Linn.LinnappsUi.Proxy
{
    using System.Data;

    using Linn.Common.Configuration;
    using Linn.LinnappsUi.Domain.RemoteServices;

    using Oracle.ManagedDataAccess.Client;

    public class ThingProxy : IThingService
    {
        public string GetThing()
        {
            var connection = new OracleConnection(this.GetConnectionString());
            var cmd = new OracleCommand("get_thing", connection)
                          {
                              CommandType = CommandType.StoredProcedure
                          };

            var thing = new OracleParameter(string.Empty, OracleDbType.Varchar2)
                           {
                               Direction = ParameterDirection.ReturnValue,
                               Size = 100
                           };
            cmd.Parameters.Add(thing);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return thing.Value.ToString();
        }

        private string GetConnectionString()
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];

            return $"user id={userId}; password={password}; data source={host}";
        }
    }
}
