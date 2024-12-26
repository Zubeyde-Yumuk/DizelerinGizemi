using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Deneme3.Controllers
{
    public class PoemController : Controller
    {
		// GET: Poem
		private readonly PoemService _poemService;

		public PoemController()
		{
			_poemService = new PoemService();
		}

		public async Task<ActionResult> Index()
		{
			var poem = await _poemService.GetRandomPoemAsync();
			return View(poem);
		}

		
    }
}
