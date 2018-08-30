namespace Linn.LinnappsUi.Service.Host.Pages.Products.SaCoreTypes
{
    using System.Linq;
    using System.Threading.Tasks;

    using Linn.LinnappsUi.Domain.Products;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class EditModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext context;

        public EditModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public SaCoreType SaCoreType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.SaCoreType = await this.context.SaCoreType.FirstOrDefaultAsync(m => m.CoreType == id);

            if (this.SaCoreType == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            this.context.Attach(this.SaCoreType).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SaCoreTypeExists(this.SaCoreType.CoreType))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.RedirectToPage("./Index");
        }

        private bool SaCoreTypeExists(int id)
        {
            return this.context.SaCoreType.Any(e => e.CoreType == id);
        }
    }
}
