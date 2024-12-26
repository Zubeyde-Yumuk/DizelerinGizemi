using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Deneme3.Models;



namespace Deneme3.Controllers
{
    public class KullaniciEkleController : Controller
    {
		// GET: KullaniciEkle
		[HttpPost]
		public ActionResult Index(string KullaniciAdi, string KullaniciSoyadi, string Email, string Sifre)
		{
			
			try
			{
				if (ModelState.IsValid)
				{
					KullaniciDB kullaniciDB = new KullaniciDB();
					KullaniciSinifi kulanici = new KullaniciSinifi();
					kulanici.kullanici_adi = KullaniciAdi;
					kulanici.kullanici_soyadi = KullaniciSoyadi;
					kulanici.email = Email;
					kulanici.sifre = Sifre;
					string resp = kullaniciDB.KullaniciEkle(kulanici);
					
					ViewBag.Message = resp;
					return View();

				}
			}
			catch (Exception ex)
			{
				ViewBag.Message = "Bir hata oluştu";
			}
			return View();
		}
	}
}