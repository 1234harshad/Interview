using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using TimeTableGenerator.Models;

namespace TimeTableGenerator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public IActionResult TotalHoursSubjectTable(int hours,string subjectName,int totalWorkDay,int totalSubPerDay)
        {
			string[] subject = subjectName.Split(',');
			int totalSubject = subject.Length;
			var perSubHours= hours / totalSubject ;
			var data = new TimeTableDataModelView();
			data.SubjectName = subject;
			data.Hours = perSubHours;
			data.TotalWorkDay= totalWorkDay;
			data.SubjectPerDay = totalSubPerDay;
            return View(data);
        }
    }
}