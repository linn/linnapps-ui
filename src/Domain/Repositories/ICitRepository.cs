namespace Linn.LinnappsUi.Domain.Repositories
{
    using Common;

    public interface ICitRepository
    {
        Cit GetByCode(string code);
    }
}