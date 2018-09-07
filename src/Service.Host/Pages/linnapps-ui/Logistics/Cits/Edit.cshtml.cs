namespace Service.Host.Pages.linnapps_ui.Logistics.Cits
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Linn.Common.Persistence;
    using Linn.LinnappsUi.Domain.Common;
    using Linn.LinnappsUi.Domain.Repositories;
    using Linn.LinnappsUi.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class EditModel : PageModel
    {
        private readonly ITransactionManager transactionManager;

        private readonly IDepartmentRepository departmentRepository;

        private readonly ICitRepository citRepository;

        private readonly IAuthUserNameRepository authUserNameRepository;

        public EditModel(IDepartmentRepository departmentRepository, ICitRepository citRepository, IAuthUserNameRepository authUserNameRepository, ITransactionManager transactionManager)
        {
            this.departmentRepository = departmentRepository;
            this.citRepository = citRepository;
            this.authUserNameRepository = authUserNameRepository;
            this.transactionManager = transactionManager;
        }

        [BindProperty]
        public Cit Cit { get; set; }

        [BindProperty]
        public string SelectedDepartment { get; set; }
        public SelectList Departments { get; set; }

        [BindProperty]
        public int? SelectedCitLeader { get; set; }
        public SelectList AuthUsers { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cit = this.citRepository.GetByCode(id);

            if (Cit == null)
            {
                return NotFound();
            }

            this.SelectedDepartment = Cit.Department?.DepartmentCode ?? string.Empty;

            this.Departments = new SelectList(
                this.departmentRepository.GetOpenPersonnelDepartments().ToList(),
                "DepartmentCode",
                "Description",
                this.SelectedDepartment);

            this.SelectedCitLeader = Cit.CitLeader?.UserNumber ?? null;

            this.AuthUsers = new SelectList(
                this.authUserNameRepository.GetValidAuthUsers().ToList(),
                "UserNumber",
                "Name",
                this.SelectedCitLeader);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var department = !string.IsNullOrEmpty(this.SelectedDepartment)
                ? this.departmentRepository.GetByCode(this.SelectedDepartment)
                : null;
            this.Cit.Department = department;

            var citLeader = this.SelectedCitLeader != null
                ? this.authUserNameRepository.GetByNumber((int) this.SelectedCitLeader)
                : null;
            this.Cit.CitLeader = citLeader;

            this.citRepository.UpdateCit(this.Cit);

            this.transactionManager.Commit();

            return RedirectToPage("./Index");
        }
    }
}
