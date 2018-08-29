namespace Linn.LinnappsUi.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.LinnappsUi.Domain.Products;
    using Linn.LinnappsUi.Domain.Repositories;
    using Linn.LinnappsUi.Persistence;

    public class SaCoreTypeRepository : ISaCoreTypeRepository
    {
        private readonly ServiceDbContext serviceDbContext;

        public SaCoreTypeRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SaCoreType GetById(int coreType)
        {
            return this.serviceDbContext.SaCoreType
                .SingleOrDefault(s => s.CoreType == coreType);
        }

        public IEnumerable<SaCoreType> GetCoreTypes(bool includeInvalid = false)
        {
            return includeInvalid
                       ? this.serviceDbContext.SaCoreType
                       : this.serviceDbContext.SaCoreType.Where(s => s.DateInvalid == null);
        }
    }
}