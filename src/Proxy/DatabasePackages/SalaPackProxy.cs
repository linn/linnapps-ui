namespace Linn.LinnappsUi.Proxy.DatabasePackages
{
    using System.Data;

    using Linn.LinnappsUi.Domain.DatabasePackages;
    using Linn.LinnappsUi.Persistence;

    using Oracle.ManagedDataAccess.Client;

    public class SalaPackProxy : ISalaPack
    {
        public string LabelDescription1(string articleNumber)
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());
            var cmd = new OracleCommand("sala_pack.label_description_1", connection)
                          {
                              CommandType = CommandType.StoredProcedure
                          };

            var desc = new OracleParameter(string.Empty, OracleDbType.Varchar2)
                            {
                                Direction = ParameterDirection.ReturnValue,
                                Size = 100
                            };
            cmd.Parameters.Add(desc);

            var article = new OracleParameter(string.Empty, OracleDbType.Varchar2)
                           {
                               Direction = ParameterDirection.Input,
                               Value = articleNumber,
                               Size = 14
                           };
            cmd.Parameters.Add(article);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return desc.Value.ToString();
        }
    }
}
