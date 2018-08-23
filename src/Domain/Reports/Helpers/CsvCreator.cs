namespace Linn.LinnappsUi.Domain.Reports.Helpers
{
    using Linn.Common.Serialization;

    public class CsvCreator : ICsvCreator
    {
        public byte[] CreateCsv(object data)
        {
            var outputStream = new System.IO.MemoryStream();
            using (var writer = new CsvStreamWriter(outputStream))
            {
                writer.WriteModel(data);
            }

            return outputStream.ToArray();
        }
    }
}
