namespace Linn.LinnappsUi.Domain.Repositories
{
    using System.Collections.Generic;
    using Common;

    public interface IDepartmentRepository
    {
        LinnDepartment GetByCode(string departmentCode);

        IEnumerable<LinnDepartment> GetOpenPersonnelDepartments();
    }
}