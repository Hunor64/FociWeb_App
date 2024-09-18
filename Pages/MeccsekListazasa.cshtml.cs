using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FociWeb_App.Models;

namespace FociWeb_App.Pages
{
    public class MeccsekListazasaModel : PageModel
    {
        private readonly FociWeb_App.Models.FociDbContext _context;

        public MeccsekListazasaModel(FociWeb_App.Models.FociDbContext context)
        {
            _context = context;
        }

        public IList<Meccs> Meccs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Meccs = await _context.Meccsek.ToListAsync();
        }
    }
}
