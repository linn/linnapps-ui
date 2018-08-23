namespace Linn.LinnappsUi.Domain.Reports.Helpers
{
    public interface ICsvCreator
    {
        byte[] CreateCsv(object data);
    }
}
