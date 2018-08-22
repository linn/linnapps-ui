namespace Linn.LinnappsUi.Service.Reports
{
    using System.Collections.Generic;
    using System.Data;

    using Linn.Common.Configuration;
    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Reports;

    using Oracle.ManagedDataAccess.Client;

    public class SaCoreTypesReportService : ISaCoreTypesReportService
    {
        public IEnumerable<SalesArticleCoreType> GetCoreTypesBySalesArticle()
        {
            var connection = new OracleConnection(this.GetConnectionString());

            var sql =
                "select sa.article_number, sa.invoice_description, sct.description from sales_articles sa, sa_core_types sct where sa.sa_core_type = sct.core_type and sa.phase_out_date is null order by sa.article_number";
            var cmd = new OracleCommand(sql, connection) { CommandType = CommandType.Text };
            var reportValues = new List<SalesArticleCoreType>();

            var dataAdapter = new OracleDataAdapter(cmd);
            var commandBuilder = new OracleCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            var table = dataSet.Tables[0];

            foreach (DataRow tableRow in table.Rows)
            {
                reportValues.Add(
                    new SalesArticleCoreType
                        {
                            ArticleNumber = tableRow[0].ToString(),
                            ArticleDescription = tableRow[1].ToString(),
                            CoreTypeDescription = tableRow[2].ToString()
                        });
            }

            return reportValues;
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
