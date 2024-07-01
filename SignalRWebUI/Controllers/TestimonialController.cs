using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.TestimonialDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class TestimonialController : Controller
	{
		private readonly IHttpClientFactory _client;

		public TestimonialController(IHttpClientFactory client)
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync("https://localhost:7113/api/Testimonials");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
		{
			createTestimonialDto.Status = true;
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7113/api/Testimonials", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			var client = _client.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7113/api/Testimonials/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Update(int id)
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync($"https://localhost:7113/api/Testimonials/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7113/api/Testimonials/", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
