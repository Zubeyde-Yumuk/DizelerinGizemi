using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;


namespace Deneme3.Models
{
	public class KullaniciDB
	{

		public string KullaniciEkle(KullaniciSinifi kullanici)
		{

			string connectionString = "Data Source=ZUBEYDE18;Initial Catalog=Kisiler;User ID=sa;Password=12345";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand cmd = new SqlCommand("INSERT INTO Kullanici (kullanici_adi, kullanici_soyadi, email, sifre) VALUES (@kullanici_adi, @kullanici_soyadi, @email, @sifre)", conn);

					// Parametreleri ekle
					cmd.Parameters.Add("@kullanici_adi", SqlDbType.VarChar).Value = kullanici.kullanici_adi;
					cmd.Parameters.Add("@kullanici_soyadi", SqlDbType.VarChar).Value = kullanici.kullanici_soyadi;
					cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = kullanici.email;
					cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = kullanici.sifre;

					// Command timeout'u ayarla
					cmd.CommandTimeout = 60; // 60 saniye

					Console.WriteLine("Bağlantı açılıyor...");
					conn.Open();
					cmd.ExecuteNonQuery();
					return "Başarıyla eklendi";


				}
				catch (Exception ex)
				{
					Console.WriteLine("Hata: " + ex.Message);
					return ("Bir hata oluştu");
				}
			}
		}

		public bool KullaniciGiris(string email, string sifre)
		{
			string connectionString = "Data Source=ZUBEYDE18;Initial Catalog=Kisiler;User ID=sa;Password=12345";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Kullanici WHERE email = @email AND sifre = @sifre", conn);

					// Parametreleri ekle
					cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
					cmd.Parameters.Add("@sifre", SqlDbType.VarChar).Value = sifre;

					cmd.CommandTimeout = 60; // 60 saniye

					Console.WriteLine("Bağlantı açılıyor...");
					conn.Open();
					int count = (int)cmd.ExecuteScalar(); // Kullanıcı sayısını al

					return count > 0; // Eğer kullanıcı bulunmuşsa true döner
				}
				catch (Exception ex)
				{
					Console.WriteLine("Hata: " + ex.Message);
					return false;
				}
			}
		}
	}
}

