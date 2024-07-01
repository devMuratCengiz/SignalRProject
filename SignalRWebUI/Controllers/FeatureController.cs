using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.FeatureDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _client;

		public FeatureController(IHttpClientFactory client)
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync("https://localhost:7113/api/Features");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7113/api/Features", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			var client = _client.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7113/api/Features/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Update(int id)
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync($"https://localhost:7113/api/Features/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7113/api/Features/", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
