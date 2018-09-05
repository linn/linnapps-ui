namespace Linn.LinnappsUi.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Common;
    using Domain.Repositories;

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ServiceDbContext serviceDbContext;

        public DepartmentRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public LinnDepartment GetByCode(string departmentCode)
        {
            return this.serviceDbContext.LinnDepartment
                .SingleOrDefault(s => s.DepartmentCode == departmentCode);
        }

        public IEnumerable<LinnDepartment> GetOpenPersonnelDepartments()
        {
            return this.serviceDbContext.LinnDepartment
                .Where(d => d.PersonnelDept == "Y" && d.DateClosed == null).OrderBy(d => d.Description);
        }
    }
}