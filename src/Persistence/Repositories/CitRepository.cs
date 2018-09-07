namespace Linn.LinnappsUi.Persistence.Repositories
{
    using System.Linq;
    using Domain.Common;
    using Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class CitRepository : ICitRepository
    {
        private readonly ServiceDbContext serviceDbContext;

        public CitRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public Cit GetByCode(string code)
        {
            return this.serviceDbContext.Cit
                .Include(a => a.CitLeader)
                .Include(a => a.Department)
                .SingleOrDefault(s => s.Code == code);
        }

        public void UpdateCit(Cit cit)
        {
            this.serviceDbContext.Attach(cit).State = EntityState.Modified;
        }
    }
}