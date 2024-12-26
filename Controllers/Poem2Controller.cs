using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Deneme3.Models;
using Newtonsoft.Json;

public class Poem2Controller : Controller
{
	private readonly HttpClient _httpClient;

	public Poem2Controller()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri("https://poetrydb.org/");
	}

	// Index action'ı
	public async Task<ActionResult> Index()
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
				return View(poems);
			}
			else
			{
				// API'den bir hata dönerse Error view'ını göster
				return View("Error", new HandleErrorInfo(
					new Exception("Şiirler yüklenemedi"),
					"Poem2", // Controller adı doğru olmalı
					"Index"  // Action adı doğru olmalı
				));
			}
		}
		catch (Exception ex)
		{
			// Hata durumunda Error view'ı
			return View("Error", new HandleErrorInfo(
				ex,
				"Poem2", // Controller adı doğru olmalı
				"Index"  // Action adı doğru olmalı
			));
		}
	}

	// RefreshPoems action'ı
	[HttpGet]
	public async Task<ActionResult> RefreshPoems()
	{
		try
		{
			// API'den yeni şiirleri al
			var response = await _httpClient.GetAsync("random/10");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var poems = JsonConvert.DeserializeObject<List<PoemModel>>(content);
				// PartialView kullanarak şiirleri güncelle
				return PartialView("_PoemList", poems);
			}
			else
			{
				return Content("Şiirler yüklenemedi");
			}
		}
		catch
		{
			return Content("Bir hata oluştu");
		}
	}
}
