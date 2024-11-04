using asp.net_cw_1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.net_cw_1.Pages
{
    public class CountriesModel : PageModel
    {
        private readonly ILogger<CountriesModel> _logger;

        public List<Country> Countries { get; set; }

        public CountriesModel(ILogger<CountriesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Countries = new List<Country>
            {
                new Country { Name = "USA", Population = 331000000, Capital = "Washington, D.C." },
                new Country { Name = "Ukraine", Population = 44130000, Capital = "Kyiv" },
                new Country { Name = "Germany", Population = 83020000, Capital = "Berlin" },
                new Country { Name = "Spain", Population = 47350000, Capital = "Madrid" },
                new Country { Name = "France", Population = 67060000, Capital = "Paris" }
            };
        }
    }
}
