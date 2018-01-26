using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magistral40.Models;
using Magistral40.ClLib;

namespace Magistral40.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {

            return View();
        }

        public ActionResult Company()
        {
            return View();
        }

        public ActionResult Sotrudnichestvo()
        {
            return View();
        }

        public ActionResult IntInfo()
        {
            return View();
        }



        public ActionResult MenuProduct(int subcategory = 0)
        {
            WorkData wd = new WorkData();
            List<MenuTop> prodmenu = wd.GetProductMenu();
            return View(prodmenu);
        }

        public ActionResult LeftMenu(int subcategory = 0)
        {
            WorkData wd = new WorkData();
            List<MenuTop> prodmenu = wd.GetLeftMenu();
            return View(prodmenu);
        }


        public ActionResult TopMenu()
        {
            WorkData wd = new WorkData();
            List<MenuTop> art = wd.GetTopMenu();
            return View(art);
        }

        public ActionResult InfoContent(int subcategory = 0)
        {
            List<CatalogArticle> Catalog = new List<CatalogArticle>();
                MagistralContext db = new MagistralContext();
              //  Catalog = db.CatalogArticls.OrderBy(x => x.Position).Select(o => o).ToList();            
          return View(Catalog);
        }

        public ActionResult ProdContext(string id = "")
        {
            WorkData wd = new WorkData();
            string zapros = wd.GetMenuProduct(id);
            ViewBag.Context = MvcHtmlString.Create(zapros);
            ViewBag.Title = wd.Title;
            ViewBag.KeyWord = wd.KeyWords;
            ViewBag.Description = wd.Description;
            ViewBag.UrlA = id;
         if (zapros!="")
            return View();
         else return HttpNotFound();

        }

        

             public ActionResult InfoArticle(string id = "")
        {
            WorkData wd = new WorkData();
            string zapros = wd.GetArticle(id);
            ViewBag.Context = MvcHtmlString.Create(zapros);
            ViewBag.Title = wd.Title;
            ViewBag.KeyWord = wd.KeyWords;
            ViewBag.Description = wd.Description;
            ViewBag.UrlA = id;
            ViewBag.Layout = wd.Layout;
            if (zapros != "")
                return View();
            else return HttpNotFound();

        }

        public ActionResult InfoContext(string id = "")
        {
            WorkData wd = new WorkData();
            List<InfoArticle> spis = wd.Get_spis_article_info(id);
            ViewBag.Title = "Раздел про " + id.ToLower();
            ViewBag.KeyWord = "Раздел про " + id.ToLower();
            ViewBag.Description = "Раздел про " + id.ToLower();
            return View(spis);

        }

        public ActionResult TopMenuContext(string id = "")
        {
            WorkData wd = new WorkData();
            string zapros= wd.GetContentTopMenu(id);
            ViewBag.Context = MvcHtmlString.Create(zapros);
            ViewBag.Title = wd.Title;
            ViewBag.KeyWord = wd.KeyWords;
            ViewBag.Description = wd.Description;
            ViewBag.UrlA = id;
            ViewBag.Layout = wd.Layout;
            if (zapros != "")
                return View();
            else return HttpNotFound();

        }

        public ActionResult PriceV()
        {
            MagistralContext db = new MagistralContext();
            var prices = db.Prices.ToList<Prices>();
            //System.Web.HttpContext.Current.Session["currentitem"] = db.CatalogMenu.First(x=>x.id == prod.id_owner).ordery;
            
            return View(prices);

        }

        public ActionResult PriceProduct(string group_name = "")
        {
            MagistralContext db = new MagistralContext();
            var price = db.Prices.Where(x => x.Group_Name == group_name).Select(o=>o);
            //System.Web.HttpContext.Current.Session["currentitem"] = db.CatalogMenu.First(x=>x.id == prod.id_owner).ordery;
            return View(price);

        }

        public ActionResult MessageSent()
        {
            Messager ct = new Messager();
            return View(ct);

        }
        [HttpPost]
        public JsonResult ASMessage(string UserName, string Message, string Phone, string EmailAdrress)
        {
            CheckField _ch = new CheckField();
            string MesEmail = "", MesPhone = "";
            bool check = true;
            if (!_ch.CheckEmail(EmailAdrress))
            {
                MesEmail = "Некорректный email";
                check = false;
            }
            if (!_ch.CheckPhone(Phone))
            {
                MesPhone = "Некорректный номер телефона";
                check = false;
            }
            if (check)
            {

                Messager ct = new Messager();
                ct.Date = DateTime.Now;
                ct.Id = 1;
                ct.UserName = UserName;
                ct.Message = Message;
                ct.Phone = Phone;
                ct.EmailAdrress = EmailAdrress;
                EmailMes em = new EmailMes();
                em.SentEmail(ct);
            }
            return Json(new { isAdded = check, isEmail = MesEmail, isPhone = MesPhone });
        }

        [HttpPost]
        public JsonResult MessIndex(string UserName, string Phone, string EmailAdrress)
        {
            CheckField _ch = new CheckField();
            string MesEmail="", MesPhone="";
            bool check = true;
            if (!_ch.CheckEmail(EmailAdrress))
            {
                MesEmail = "Некорректный email";
                check = false;
            }
            if (!_ch.CheckPhone(Phone))
            {
                MesPhone = "Некорректный номер телефона";
                check = false;
            }
            if (check) { 
            Messager ct = new Messager();
            ct.Date = DateTime.Now;
            ct.Id = 1;
            ct.UserName = UserName;
            ct.Message = "Сообщение отсутсвует";
            ct.Phone = Phone;
            ct.EmailAdrress = EmailAdrress;
            EmailMes em = new EmailMes();
            em.SentEmail(ct);
            }
            return Json(new { isAdded = check, isEmail = MesEmail, isPhone = MesPhone });
        }

        [HttpPost]
        public JsonResult MessFon( string Phone)
        {
            CheckField _ch = new CheckField();
            string  MesPhone = "";
            bool check = true;
            if (!_ch.CheckPhone(Phone))
            {
                MesPhone = "Некорректный номер телефона";
                check = false;
            }
            if (check)
            {
                Messager ct = new Messager();
                ct.Date = DateTime.Now;
                ct.Id = 1;
                ct.UserName = "";
                ct.Message = "Сообщение отсутсвует";
                ct.Phone = Phone;
                ct.EmailAdrress = "";
                EmailMes em = new EmailMes();
                em.SentEmail(ct);
            }
            return Json(new { isAdded = check, isPhone = MesPhone });
        }

    }
}