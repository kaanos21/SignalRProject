using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.NotificationDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class NotificationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public NotificationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7234/api/Notification");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public IActionResult CreateNotification()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNotification(CreateNotificationDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7234/api/Notification", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7234/api/Notification/DeleteById?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("ghjmfhkhk");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7234/api/Notification/GetById?id="+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateNotification(UpdateNotificationDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7234/api/Notification/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
        [HttpGet]
        public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7234/api/Notification/NotificationChangeToTrue?id=" + id);
			return RedirectToAction("Index");
        }
		[HttpGet]
		public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync("https://localhost:7234/api/Notification/NotificationChangeToFalse?id=" + id);
			return RedirectToAction("Index");
		}
	}
}
