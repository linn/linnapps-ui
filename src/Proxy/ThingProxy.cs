namespace Linn.LinnappsUi.Proxy
{
    using System.Data;

    using Linn.LinnappsUi.Domain.RemoteServices;
    using Linn.LinnappsUi.Persistence;

    using Oracle.ManagedDataAccess.Client;

    public class ThingProxy : IThingService
    {
        public string GetThing()
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());
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
    }
}
