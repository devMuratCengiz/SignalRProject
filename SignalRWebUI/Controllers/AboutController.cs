using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IHttpClientFactory _client;

		public AboutController(IHttpClientFactory client)
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync("https://localhost:7113/api/Abouts");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createAboutDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7113/api/Abouts", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			var client = _client.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7113/api/Abouts/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Update(int id)
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync($"https://localhost:7113/api/Abouts/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateAboutDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7113/api/Abouts/", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
