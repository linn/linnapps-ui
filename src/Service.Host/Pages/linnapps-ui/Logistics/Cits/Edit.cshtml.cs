using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linn.LinnappsUi.Domain.Logistics;
using Linn.LinnappsUi.Persistence;

namespace Service.Host.Pages.linnapps_ui.Logistics.Cits
{
    using Linn.LinnappsUi.Domain.Common;
    using Linn.LinnappsUi.Domain.Repositories;

    public class EditModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        private readonly IDepartmentRepository departmentRepository;

        public EditModel(Linn.LinnappsUi.Persistence.ServiceDbContext context, IDepartmentRepository departmentRepository)
        {
            _context = context;
            this.departmentRepository = departmentRepository;
        }

        [BindProperty]
        public Cit Cit { get; set; }

        [BindProperty]
        public string SelectedDepartment { get; set; }
        public SelectList Departments { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cit = await _context.Cit.FirstOrDefaultAsync(m => m.Code == id);

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

            _context.Attach(Cit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitExists(Cit.Code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CitExists(string id)
        {
            return _context.Cit.Any(e => e.Code == id);
        }
    }
}
