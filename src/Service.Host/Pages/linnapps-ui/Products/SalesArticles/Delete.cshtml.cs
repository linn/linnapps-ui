using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Linn.LinnappsUi.Domain.Products;
using Linn.LinnappsUi.Persistence;

namespace Service.Host.Pages.linnapps_ui.Products.SalesArticles
{
    public class DeleteModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public DeleteModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesArticle SalesArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesArticle = await _context.SalesArticle.FirstOrDefaultAsync(m => m.ArticleNumber == id);

            if (SalesArticle == null)
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

            SalesArticle = await _context.SalesArticle.FindAsync(id);

            if (SalesArticle != null)
            {
                _context.SalesArticle.Remove(SalesArticle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
