using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _client;

		public ContactController(IHttpClientFactory client)
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync("https://localhost:7113/api/Contacts");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateContactDto createContactDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7113/api/Contacts", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			var client = _client.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7113/api/Contacts/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Update(int id)
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync($"https://localhost:7113/api/Contacts/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateContactDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7113/api/Contacts/", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
