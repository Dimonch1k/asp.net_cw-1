using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.net_cw_1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Weather { get; set; }
        public DateTime Date = DateTime.Now;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Weather = "Press the button to see current weather";
        }

        public void OnPost()
        {
            string[] weathers = ["Sunny", "Rainy", "Cloudy", "Stormy", "Foggy", "Icy"];
            _logger.Log(LogLevel.Warning, Weather);

            Random random = new Random();
            Weather = weathers[random.Next(0, weathers.Length)];
            _logger.Log(LogLevel.Warning, Weather);

        }
    }
}
