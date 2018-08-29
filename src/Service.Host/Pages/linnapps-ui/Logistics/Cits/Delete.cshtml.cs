using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Linn.LinnappsUi.Domain.Logistics;
using Linn.LinnappsUi.Persistence;

namespace Service.Host.Pages.linnapps_ui.Logistics.Cits
{
    public class DeleteModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public DeleteModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cit Cit { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cit = await _context.Cit.FindAsync(id);

            if (Cit != null)
            {
                _context.Cit.Remove(Cit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
