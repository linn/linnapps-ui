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
    public class IndexModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public IndexModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            _context = context;
        }

        public IList<Cit> Cit { get;set; }

        public string NameSort { get; set; }
        public string CodeSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CodeSort = sortOrder == "Code" ? "code_desc" : "Code";

            var cit = await _context.Cit.ToListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    cit = cit.ToList().OrderByDescending(s => s.Name).ToList();
                    break;
                case "Code":
                    cit = cit.ToList().OrderBy(s => s.Code).ToList();
                    break;
                case "code_desc":
                    cit = cit.ToList().OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    cit = cit.ToList().OrderBy(s => s.Name).ToList();
                    break;
            }

            this.Cit = cit;
        }
    }
}
