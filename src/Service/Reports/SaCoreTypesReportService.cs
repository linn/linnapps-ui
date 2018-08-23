namespace Linn.LinnappsUi.Service.Reports
{
    using System.Collections.Generic;
    using System.Data;

    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Reports;
    using Linn.LinnappsUi.Persistence;

    using Oracle.ManagedDataAccess.Client;

    public class SaCoreTypesReportService : ISaCoreTypesReportService
    {
        public IEnumerable<SalesArticleCoreType> GetCoreTypesBySalesArticle()
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());

            var sql =
                "select sa.article_number, sa.invoice_description, sct.description from sales_articles sa, sa_core_types sct where sa.sa_core_type = sct.core_type and sa.phase_out_date is null order by sa.article_number";
            var cmd = new OracleCommand(sql, connection) { CommandType = CommandType.Text };
            var reportValues = new List<SalesArticleCoreType>();

            var dataAdapter = new OracleDataAdapter(cmd);
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
    }
}
