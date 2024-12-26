using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Deneme3.Models;
using Newtonsoft.Json;

namespace Deneme3.Controllers
{
	public class Test2Controller : Controller
	{
		private readonly HttpClient _httpClient;

		public Test2Controller()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://poetrydb.org/");
		}

		// View action'ı (önceki Index yerine View olarak güncellendi)
		public async Task<ActionResult> View()
		{
			try
			{
				// API'den şiirleri al
				var response = await _httpClient.GetAsync("random/10");

				// Eğer API'den başarılı bir yanıt geldiyse
				if (response.IsSuccessStatusCode)
				{
					// JSON içeriğini oku
					var content = await response.Content.ReadAsStringAsync();
					// JSON verisini PoemModel listesine dönüştür
					var poems = JsonConvert.DeserializeObject<List<PoemModel>>(content);
					// List<PoemModel> verisini view'a gönder
					return View(poems); // View'a gönder
				}
				else
				{
					// API'den bir hata dönerse Error view'ını göster
					return View("Error", new HandleErrorInfo(
						new Exception("Şiirler yüklenemedi"),
						"Test2", // Controller adı doğru olmalı
						"View"  // Action adı doğru olmalı
					));
				}
			}
			catch (Exception ex)
			{
				// Hata durumunda Error view'ı
				return View("Error", new HandleErrorInfo(
					ex,
					"Test2", // Controller adı doğru olmalı
					"View"  // Action adı doğru olmalı
				));
			}
		}
	}
}



