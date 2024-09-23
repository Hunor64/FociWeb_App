using FociWeb_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWeb_App.Pages
{
    public class AdatTXTBolModel : PageModel
    {

        private readonly IWebHostEnvironment _env;
        private readonly FociDbContext _context;
        public AdatTXTBolModel(IWebHostEnvironment env, FociDbContext context)
        {
            _env = env;
            _context = context;
        }
        [BindProperty]
        public IFormFile? Feltoltes { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Feltoltes != null || Feltoltes.Length == 0 )
            {
                ModelState.AddModelError("Feltoltes", "Nem választott ki fájlt!");
                return Page();
            }


            var UploadDirPath = Path.Combine(_env.ContentRootPath, "Uploads");
            var UploadFilePath = Path.Combine(UploadDirPath, Feltoltes.FileName);

            using (var fileStream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await Feltoltes.CopyToAsync(fileStream);
            }

            StreamReader sr = new StreamReader(UploadFilePath);
            sr.ReadLine();

            while (sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var splittelt = line.Split(" ");

                Meccs ujMeccs = new Meccs();
                ujMeccs.Fordulo = int.Parse(splittelt[0]);
                ujMeccs.HazaiVeg = int.Parse(splittelt[1]);
                ujMeccs.VendegVeg = int.Parse(splittelt[2]);
                ujMeccs.HazaiFel = int.Parse(splittelt[3]);
                ujMeccs.VendegFel = int.Parse(splittelt[4]);
                ujMeccs.HazaiCsapat = splittelt[5];
                ujMeccs.VendegCsapat = splittelt[6];

                _context.Meccsek.Add(ujMeccs);
            }
            sr.Close();
            _context.SaveChanges();

            //System.IO.File.Delete(UploadDirPath);

            return Page();
        }
    }
}
