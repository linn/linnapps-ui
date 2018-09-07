namespace Service.Host.Pages.linnapps_ui.Logistics.Cits
{
    using System.Threading.Tasks;
    using Linn.LinnappsUi.Domain.Common;
    using Linn.LinnappsUi.Domain.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class DetailsModel : PageModel
    {
        private readonly ICitRepository citRepository;

        public DetailsModel(ICitRepository citRepository)
        {
            this.citRepository = citRepository;
        }

        public Cit Cit { get; set; }

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
            return Page();
        }
    }
}
