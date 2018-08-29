namespace Linn.LinnappsUi.Domain.Repositories
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.Products;

    public interface ISaCoreTypeRepository
    {
        SaCoreType GetById(int coreType);

        IEnumerable<SaCoreType> GetCoreTypes(bool includeInvalid = false);
    }
}
