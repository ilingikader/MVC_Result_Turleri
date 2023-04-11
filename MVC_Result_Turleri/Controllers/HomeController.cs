using MVC_Result_Turleri.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC_Result_Turleri.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public RedirectResult Index2() 
        {
            //return RedirectToAction("Index") bunun altını ciziyor cunku redirenct donduremem dıyor
           //
            
            //return Redirect("/Home/Index");                                           ///redıretin için baska ındexe ynlendirmiş oluyor
            return Redirect("https://google.com");                                   //bu beni direct google ye yonlendiriyor.                                         //Bu rediret beni ındex2 sayfasından ındex sayfasına ynlendiredi
        }
        public JsonResult Index3()
        {
            Urun u=new Urun();
            u.Id = 1;
            u.Adi = "bilgisayar";
            u.Fiyati = 20000;
            u.Aciklama = "Yeni Ürün";
            return Json(u,JsonRequestBehavior.AllowGet);                                    
        }
        /// <summary>
        /// /bu benı tekrar routa gnderoyr xx xxx yazdım yıne benı aynı sayfaya gerı getırdı
        /// </summary>
        static List<string> veriler=new List<string>();                                ///static demezsem herseferinde bir tane değer olur

        public ActionResult AnaSayfa()
        {
            ViewBag.liste = veriler;
            return View();

        }
        [HttpPost]
        public ActionResult AnaSayfa(string ad,string soyad)
        {
            veriler.Add(ad + " " + soyad);
            return new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
            {
                action = "AnaSayfa",
                controller = "Home",
                kod = Guid.NewGuid().ToString()
                //ad=ad,
                //soyad=soyad
            }));
        }

        // dosya result için///

        //PDF dosyasını görüntüledik
        //
        public ActionResult Dosyalar() 
        {
            return View();
        }
        public FileResult PDFDosyaGoster()
        {
            string dosya = Server.MapPath("~/Dosyalar/C#Eğitim.pdf");
            return new FilePathResult(dosya, "application/pdf");
        }
        public FileStreamResult MetinDosyasiIndir()
        {
            MemoryStream memo=new MemoryStream();
            string metin = "Bu bir deneme yazısıdır.";
            byte[] bytes = Encoding.UTF8.GetBytes(metin);

            memo.Write(bytes, 0, bytes.Length);
            memo.Position= 0;

            FileStreamResult sonuc = new FileStreamResult(memo,"text/plain");
            sonuc.FileDownloadName = "deneme.txt";
            return sonuc;
        }

        public PartialViewResult KategoriGetir()
        {
            return PartialView("_KategoriPartialPage1");
        }

        public PartialViewResult KategoriGetir2()
        {
            List<string>kategoriler = new List<string>()
            {
                "Teknoloji","Giyim","Gıda","Temizlik"
            };
            return PartialView("_KategoriPartialPage2", kategoriler);
        }
        ///javascript result turu
        ///

        public JavaScriptResult Mesaj()
        {
            string mesaj = "alert('Merhaba Dünya')";
            return JavaScript(mesaj);
        }
        public JavaScriptResult ButtonMesaj()
        {
            string js = "function button_click() {alert('MERHABA DÜNYA')}";
            return JavaScript(js);
        }
    }
}