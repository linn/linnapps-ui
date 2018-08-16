using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linn.LinnappsUi.Domain.Products;
using Linn.LinnappsUi.Persistence;

namespace Service.Host.Pages.Products.SaCoreTypes
{
    public class EditModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public EditModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SaCoreType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaCoreTypeExists(SaCoreType.CoreType))
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

        private bool SaCoreTypeExists(int id)
        {
            return _context.SaCoreType.Any(e => e.CoreType == id);
        }
    }
}
