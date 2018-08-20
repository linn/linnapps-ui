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
    public class IndexModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public IndexModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            _context = context;
        }

        public IList<SaCoreType> SaCoreType { get;set; }

        public async Task OnGetAsync()
        {
            SaCoreType = await _context.SaCoreType.ToListAsync();
        }
    }
}
