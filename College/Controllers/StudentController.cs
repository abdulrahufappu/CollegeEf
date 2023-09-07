using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using College.Models;
using System.Text.Unicode;
using System.Text;

namespace College.Controllers
{
    public class StudentController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:7035/api");
        HttpClient client;
        public StudentController()
        {
            client = new HttpClient();
            client.BaseAddress = baseUrl;
        }
        public ActionResult Index()
        {
            List<StudentViewModel> modelList = new List<StudentViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Students").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<StudentViewModel>>(data);
            }
            return View(modelList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            string data =JsonConvert.SerializeObject(model);
            StringContent content= new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(client.BaseAddress + "/Students",content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            StudentViewModel model = new StudentViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Students/"+Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<StudentViewModel>(data);
            }
            return View("Create",model);
        }
        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PutAsync(client.BaseAddress + "/Students/" + model.Id, content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create",model);
        }
        public ActionResult Delete(int Id) {

            try
            {
                StudentViewModel model = new StudentViewModel();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Students/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<StudentViewModel>(data);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"]=ex.Message;
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult delete(int Id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Students/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Student details deleted";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
                return View();
        }
       
    }
}
