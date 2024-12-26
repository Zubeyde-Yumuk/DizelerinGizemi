using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using System.ComponentModel.DataAnnotations; 
namespace Deneme3.Models
{
	public class KullaniciSinifi
	{
		public int kullanici_id { get; set; }

		public string kullanici_adi { get; set; }

		public string kullanici_soyadi { get; set; }

		public string email { get; set; }

		public string sifre { get; set; }
	}
	
}

