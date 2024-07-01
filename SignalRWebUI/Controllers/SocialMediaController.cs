using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class SocialMediaController : Controller
	{
		private readonly IHttpClientFactory _client;

		public SocialMediaController(IHttpClientFactory client)
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync("https://localhost:7113/api/SocialMedias");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateSocialMediaDto createSocialMediaDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7113/api/SocialMedias", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			var client = _client.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7113/api/SocialMedias/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Update(int id)
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync($"https://localhost:7113/api/SocialMedias/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7113/api/SocialMedias/", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
