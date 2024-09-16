using FociWeb_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWeb_App.Pages
{
    public class UjMeccsFelveteleModel : PageModel
    {
        [BindProperty]
        public Meccs UjMeccs { get; set; }
        public List<Meccs> meccsekListaja { get; set; } = new();
        private readonly FociDbContext _db;
        public UjMeccsFelveteleModel(FociDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost() 
        {
            _db.Meccsek.Add(UjMeccs);
            return Page();
        }
    }
}
