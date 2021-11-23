using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using management_mvc.Helper;
using management_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace management_mvc.Controllers
{
    public class projectController : Controller
    {
        // GET: projectController
        project _api = new project();
        public async Task<IActionResult> Index()
        {
            List<Projectdetail> Datas = new List<Projectdetail>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/Projectdetails");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                Datas = JsonConvert.DeserializeObject<List<Projectdetail>>(res);
            }
            var totalcount = Datas.Count();
            ViewData["count"] = totalcount;
            var tasks = totalcount * 4;
            ViewData["taskdata"] = tasks;

            return View(Datas);
        }

        // GET: projectController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var projects = new Projectdetail();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/Projectdetails/{id}");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                projects = JsonConvert.DeserializeObject<Projectdetail>(res);
            }
            var value = (projects.UiTasksPercent + projects.ApiTasksPercent + projects.DbTasksPercent + projects.TestingTasksPercent) / 4;
            ViewData["data"] = value;
            var pending = 100 - ((projects.UiTasksPercent + projects.ApiTasksPercent + projects.DbTasksPercent +projects.TestingTasksPercent) / 4);
            ViewData["pendingdata"] = pending;
            return View(projects);
        }


        // GET: projectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: projectController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Projectdetail student)
        {
            HttpClient cli = _api.Initial();
            string authornew = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(authornew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Projectdetails", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        // GET: projectController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient cli = _api.Initial();
            Projectdetail stud = new Projectdetail();
            HttpResponseMessage response = await cli.GetAsync($"api/Projectdetails/{id}");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stud = JsonConvert.DeserializeObject<Projectdetail>(data);
            }
            return View(stud);

        }

        // POST: projectController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Username,ProjectName,Startdate,Enddate,Duration,UiTasksPercent,UiStartDate,UiEndDate,ApiTasksPercent,ApiStartDate,ApiEndDate,DbTasksPercent,DbStartDate,DbEndDate,TestingTasksPercent,TestingStartDate,TestingEndDate")] Projectdetail model)
        {
            if (id != model.ProjectId)
            {
                return NotFound();
            }
            HttpClient cli = _api.Initial();
            string stnew = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(stnew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await cli.PutAsync($"api/Projectdetails/{id}", content);
            System.Diagnostics.Debug.WriteLine("detail", response);
            if (response.IsSuccessStatusCode)
            {
                //await _api.SavechangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: projectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: projectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            HttpClient cli = _api.Initial();
            HttpResponseMessage response = cli.DeleteAsync("api/Projectdetails/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
