using College.Models;
using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CollegeApp.Controllers
{
    public class FacultyController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:7035/api");
        HttpClient client;
        public FacultyController()
        {
            client = new HttpClient();
            client.BaseAddress = baseUrl;
        }
        public ActionResult Index()
        {
            List<FacultyViewModel> modelList = new List<FacultyViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Faculties").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<FacultyViewModel>>(data);
            }
            return View(modelList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FacultyViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(client.BaseAddress + "/Faculties", content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            FacultyViewModel model = new FacultyViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Faculties/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<FacultyViewModel>(data);
            }
            return View("Create", model);
        }
        [HttpPost]
        public ActionResult Edit(FacultyViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PutAsync(client.BaseAddress + "/Faculties/" + model.FacultyId, content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        public ActionResult Delete(int Id)
        {

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Faculties/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");

            }
            return View();


        }
    }
}
