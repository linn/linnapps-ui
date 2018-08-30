namespace Linn.LinnappsUi.Service.Host.Pages.Products.SaCoreTypes
{
    using System.Threading.Tasks;

    using Linn.LinnappsUi.Domain.Products;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CreateModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext context;

        public CreateModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public SaCoreType SaCoreType { get; set; }

        public IActionResult OnGet()
        {
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            this.context.SaCoreType.Add(this.SaCoreType);
            await this.context.SaveChangesAsync();

            return this.RedirectToPage("./Index");
        }
    }
}