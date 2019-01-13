using Newtonsoft.Json;
using Sistem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SistemWebApi;
using System.Net.Http.Headers;
using System.Threading;
using System.Text;
using Newtonsoft.Json.Linq;


namespace SistemDenemeUI.Controllers
{
    public class HomeController : Controller
    {
        //  public async Task<Sehir> GetSehirler()
        // {
        //     HttpClient client = new HttpClient();
        //     client.BaseAddress = new Uri("http://localhost:49623/");
        //     HttpResponseMessage response = await client.GetAsync("api/sehir");
        //     var result = await response.Content.ReadAsStringAsync();
        //     var asil = JsonConvert.DeserializeObject<Sehir>(result);
        // 
        //     //return JsonConvert.DeserializeObject<IEnumerable<Sehir>>(asil.ToString());
        //     return asil;
        // }
        // public async Task<ActionResult> Index()
        // {
        //      var data = await GetSehirler();
        //     return View(data);
        // }

        string Baseurl = "http://localhost:49623/";

        //GET ALL
        public async Task<ActionResult> Index()
        {
            List<Sehir> EmpInfo = new List<Sehir>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Sehir");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Sehir>>(EmpResponse);
                }
                return View(EmpInfo);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       //GET
        public async Task<ActionResult> Edit(int id)
        {
            Sehir EmpInfo = new Sehir ();
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Sehir/"+id);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Sehir>(EmpResponse);
                }
                return View(EmpInfo);
            }
        }
        //PUT 
        public async Task<ActionResult> Editle(Sehir sehir,int id)
        {
            sehir.SehirId = id;
           using (HttpClient client = new HttpClient())
         {
             string json = await Task.Run(() => JsonConvert.SerializeObject(sehir));
             var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
             using (HttpResponseMessage response = await client.PutAsync(Baseurl+"/api/Sehir/" + id, httpContent))
             {
                 response.EnsureSuccessStatusCode();
                 string responseBody = await response.Content.ReadAsStringAsync();
                 //return JObject.Parse(responseBody);
                 
             }
         }
            

            return View("Index");
        }
        //DELETE
        public async Task<ActionResult> Sil(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                //string json = await Task.Run(() => JsonConvert.SerializeObject(sehir));
                //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.DeleteAsync(Baseurl + "/api/Sehir/" + id))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    //return JObject.Parse(responseBody);

                }
            }
            return View("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> Contact2()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49623/");
            HttpResponseMessage response = await client.GetAsync("/api/sehir");
            string result = await response.Content.ReadAsStringAsync();
            var asil = JsonConvert.DeserializeObject<ActionResult>(result);
            return View(asil); 
        }
        //POST
        [HttpPost]
        public async Task<ActionResult> Ekle(Sehir sehir)
        {
                //Sehir postData = new Sehir(); 
                //postData.Ulkesi = sehir.Ulkesi;
                //postData.Nufusu = sehir.Nufusu;
                //postData.KurutulusYili =sehir.KurutulusYili;
                //postData.Bolgesi = sehir.Bolgesi;
                //postData.Adi = sehir.Adi;
            using (HttpClient client = new HttpClient())
            {
                string json = await Task.Run(() => JsonConvert.SerializeObject(sehir));
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync(Baseurl+"/api/Sehir/Post", httpContent))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    //return JObject.Parse(responseBody);

                    return View("Index");
                }
            }

            
            //using (var client = new HttpClient())
            //{
            //      client.BaseAddress = new Uri(Baseurl);
            //
            //      //HTTP POST
            //      var postTask = client.PostAsync("api/Sehir/Post",sehir,CancellationToken.None);
            //      postTask.Wait();
            //
            //      var result = postTask.Result;
            //      if (result.IsSuccessStatusCode)
            //      {
            //          return RedirectToAction("Index");
            //      }
            //  }

            //client.BaseAddress = new Uri(Baseurl);
            //client.DefaultRequestHeaders.Clear();
            //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //
            //string json = await Task.Run(() => JsonConvert.SerializeObject(sehir));
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            // var httpContent = new StringContent(Json, Encoding.UTF8, "application/json");
            // var stringContent = new StringContent(sehir.ToString());
            //var response = await client.PostAsync("api/Sehir/Post", stringContent);
            // int result = client.PostAsync("/api/values", httpContent).Result;
        }
       
            // var httpClient = new HttpClient();
            // httpClient.BaseAddress = new Uri(Baseurl);
            // StringContent content = new System.Net.Http.StringContent(sehir.ToString(), Encoding.UTF8, "application/json");
            // var result = httpClient.PostAsync("api/Sehir/Post", content).Result;

    }
}