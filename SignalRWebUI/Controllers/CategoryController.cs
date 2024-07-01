using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _client;

		public CategoryController(IHttpClientFactory client)
		{
			_client = client;
		}

		public async Task<IActionResult>Index()
        {
            var client = _client.CreateClient();
            var response = await client.GetAsync("https://localhost:7113/api/Categorys");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public async Task< IActionResult> Create(CreateCategoryDto createCategoryDto)
		{
            createCategoryDto.Status = true;
            var client = _client.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7113/api/Categorys", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
			return View();
		}
        public async Task<IActionResult> Delete(int id)
        {
            var client = _client.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7113/api/Categorys/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var client = _client.CreateClient();
            var response = await client.GetAsync($"https://localhost:7113/api/Categorys/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var client = _client.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData , Encoding.UTF8,"application/json");
            var response = await client.PutAsync("https://localhost:7113/api/Categorys/", stringContent);
            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
			}
            return View();
        }
	}
}
