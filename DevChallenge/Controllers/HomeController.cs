using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;


namespace DeveloperChallange.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			IEnumerable<Brand> brands = GetBrand();


			return View(brands);
		}

		private IEnumerable<Brand> GetBrand()
		{
			IEnumerable<Brand> brands = null;
			using (HttpClient client = new HttpClient())
			{
				string apiUrl = "http://localhost:9111/api/brand";
				Url url = new Url(apiUrl);
				System.Threading.Tasks.Task<HttpResponseMessage> results = client.GetAsync(apiUrl);
				if (results.Result.IsSuccessStatusCode)
				{
					System.Threading.Tasks.Task<string> response = results.Result.Content.ReadAsStringAsync();
					brands = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Brand>>(response.Result);
				}

			}

			return brands;
		}

		private int IEnumerable<T>(string result)
		{
			throw new NotImplementedException();
		}
	}
}