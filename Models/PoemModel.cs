using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Deneme3.Models
{
	public class PoemModel
	{

		//public int Id { get; set; }
		//public string Title { get; set; }
		//public string Content { get; set; }
		//public string Author { get; set; }

		[JsonProperty("authors")]
		public List<string> Authors { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; } // Şiirin benzersiz kimliği

		[JsonProperty("title")]
		public string Title { get; set; } // Şiirin başlığı

		[JsonProperty("content")]
		public List<string> Content { get; set; } // Şiirin içeriği


		[JsonProperty("tags")]
		public List<string> Tags { get; set; } // Şiirle ilgili etiketler (isteğe bağlı)

		[JsonProperty("publishedDate")]
		public string PublishedDate { get; set; } // Şiirin yayınlanma tarihi (isteğe bağlı)


	}
}