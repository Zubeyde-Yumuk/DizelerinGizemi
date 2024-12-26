using Newtonsoft.Json;
using System.Collections.Generic;


namespace Deneme3.Models
{
	public class HomeModel
	{
		[JsonProperty("title")]
		public string Title { get; set; } // Şiirin başlığı

		[JsonProperty("lines")]
		public List<string> Content { get; set; } // Şiirin içeriği

		[JsonProperty("author")]
		public string Author { get; set; } // Şiir yazarı

		[JsonProperty("linecount")]
		public string LineCount { get; set; } // Şiir satır sayısı
	}

}

