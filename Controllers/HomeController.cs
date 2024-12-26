using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Deneme3.Models;
using Deneme3.Services;
using Newtonsoft.Json;


namespace Deneme3.Controllers
{
	public class HomeController : Controller
	{

		private readonly HomeService _homeService;

		public HomeController()
		{
			_homeService = new HomeService();
		}
		public async Task<ActionResult> Index()
		{
			HomeModel Model = await _homeService.GetDailyPoemAsync();
			return View(Model);
		}

		[HttpGet]
		public ActionResult KullaniciEkle()
		{
			return View();
		}
	}


}

