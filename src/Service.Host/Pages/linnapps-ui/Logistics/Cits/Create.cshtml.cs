using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Linn.LinnappsUi.Domain.Logistics;
using Linn.LinnappsUi.Persistence;

namespace Service.Host.Pages.linnapps_ui.Logistics.Cits
{
    public class CreateModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public CreateModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cit Cit { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cit.Add(Cit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}