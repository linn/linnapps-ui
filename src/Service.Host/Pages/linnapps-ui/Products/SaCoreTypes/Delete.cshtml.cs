using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Linn.LinnappsUi.Domain.Products;
using Linn.LinnappsUi.Persistence;

namespace Service.Host.Pages.Products.SaCoreTypes
{
    public class DeleteModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public DeleteModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SaCoreType SaCoreType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SaCoreType = await _context.SaCoreType.FirstOrDefaultAsync(m => m.CoreType == id);

            if (SaCoreType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SaCoreType = await _context.SaCoreType.FindAsync(id);

            if (SaCoreType != null)
            {
                _context.SaCoreType.Remove(SaCoreType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
