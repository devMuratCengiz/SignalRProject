using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _client;

		public ProductController(IHttpClientFactory client)
		{
			_client = client;
		}

		public async Task <IActionResult>Index()
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync("https://localhost:7113/api/Products/ProductListWithCategory");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public async Task<IActionResult>Create()
		{
			var client = _client.CreateClient();
			var response = await client.GetAsync("https://localhost:7113/api/Categorys");
			var jsonData = await response.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> values2 = (from x in values 
											select new SelectListItem
											{
												Text = x.Name,
												Value = x.Id.ToString()
											}).ToList();
			ViewBag.v = values2;
				
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateProductDto createProductDto)
		{
			createProductDto.Status = true;
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7113/api/Products", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			var client = _client.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7113/api/Products/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> Update(int id)
		{
			var client1 = _client.CreateClient();
			var response1 = await client1.GetAsync("https://localhost:7113/api/Categorys");
			var jsonData1 = await response1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
			List<SelectListItem> values2 = (from x in values1
											select new SelectListItem
											{
												Text = x.Name,
												Value = x.Id.ToString()
											}).ToList();
			ViewBag.v = values2;

			var client = _client.CreateClient();
			var response = await client.GetAsync($"https://localhost:7113/api/Products/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
		{
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7113/api/Products/", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
