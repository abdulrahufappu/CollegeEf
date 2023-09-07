using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CollegeApp.Controllers
{
    public class CourseController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:7035/api");
        HttpClient client;
        public CourseController()
        {
            client = new HttpClient();
            client.BaseAddress = baseUrl;
        }
        public ActionResult Index()
        {
            List<CourseViewModel> modelList = new List<CourseViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Courses").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<CourseViewModel>>(data);
            }
            return View(modelList);
        }
        public IActionResult Create()
        {
            return View();
        }
        // post
        [HttpPost]
        public ActionResult Create(CourseViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(client.BaseAddress + "/Courses", content).Result;
            if (responce.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            CourseViewModel model = new CourseViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Courses/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<CourseViewModel>(data);
            }
            return View("Create", model);
        }
        [HttpPost]
        public ActionResult Edit(CourseViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PutAsync(client.BaseAddress + "/Courses/" + model.CourseId, content).Result;
            if (responce.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Course Edit Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Edit Course";
            }
            return View("Create", model);
        }

        public ActionResult Delete(int Id)
        {

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Courses/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                
                string data = response.Content.ReadAsStringAsync().Result;
                TempData["SuccessMessage"] = "deleted";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Edit Course";
            }

            return View();


        }
    }
}
