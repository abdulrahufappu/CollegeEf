using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CollegeApp.Controllers
{
    public class DepartmentController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:7035/api");
        HttpClient client;
        public DepartmentController()
        {
            client = new HttpClient();
            client.BaseAddress = baseUrl;
        }
        public ActionResult Index()
        {
            List<DepartmentViewModel> modelList = new List<DepartmentViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Departments").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(data);
            }
            return View(modelList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(client.BaseAddress + "/Departments", content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            DepartmentViewModel model = new DepartmentViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Departments/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<DepartmentViewModel>(data);
            }
            return View("Create", model);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PutAsync(client.BaseAddress + "/Departments/" + model.Id, content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        public ActionResult Delete(int Id)
        {

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Departments/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");

            }
            return View();


        }
    }
}
