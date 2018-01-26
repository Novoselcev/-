using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magistral40.Models;

namespace Magistral40.Models
{
    public class WorkData
    {
        public string Title = "";
        public string KeyWords = "";
        public string Description = "";
        public string Layout ="";

        public String GetMenuProduct(string url)
        {
            string result = "";
            MagistralContext db = new MagistralContext();
            var prod = db.Products.FirstOrDefault(x => x.URL == url);
            if (prod != null)
            {

                TemplateProduct tp = new TemplateProduct();
                string price = tp.Prod(prod.Price);
                Title = prod.title;
                KeyWords = prod.keywords;
                Description = prod.Description;
                // замена шаблон
                result = prod.Context.Replace("@Shablon", price);
            }
            return result;
        }

        public String GetArticle(string url)
        {
            string result = "";
            MagistralContext db = new MagistralContext();
            var prod = db.Articl.FirstOrDefault(x =>x.Menu=="Info"  && x.URL == url);
            if (prod != null)
            {

                Title = prod.title;
                KeyWords = prod.keywords;
                Description = prod.Description;
                Layout = prod.Layout;
                // замена шаблон
                result = prod.Context;
            }
            return result;
        }



        public void addArticle()
        {
            MagistralContext db = new MagistralContext();
            Articles art = new Articles();
            art.Id = 0;
            art.Header = "О Компании";
            art.Visible = true;
            db.Articl.Add(art);
            db.SaveChanges();

        }

        public List<MenuTop> GetTopMenu()
        {
            MagistralContext db = new MagistralContext();
            List<MenuTop> menu = db.Articl.Where(x=>x.Menu=="Main").OrderBy(x => x.Position).Select(o => new MenuTop {
                Header =o.Header,
                URL = o.URL
            } ).ToList();
            return menu;
        }

        public List<MenuTop> GetProductMenu()
        {
            MagistralContext db = new MagistralContext();
            List<MenuTop> menu = db.Products.OrderBy(x => x.Position).Select(o => new MenuTop
            {
                Header = o.Header,
                URL = o.URL,
                
            }).ToList();
            return menu;
        }


        public List<MenuTop> GetLeftMenu()
        {
            MagistralContext db = new MagistralContext();
            List<MenuTop> menu = db.Articl.Where(x=>x.Menu=="Info").GroupBy(x=>x.Razdel).Select(o => new MenuTop
            {
                Header = o.Key
                
            }).ToList();
            return menu.OrderBy(x=>x.Header).ToList();
        }

        public List<InfoArticle> Get_spis_article_info(string razdel)
        {
            MagistralContext db = new MagistralContext();
            List<InfoArticle> spis = db.Articl.Where(x => x.Menu == "Info" && x.Razdel == razdel).Select(o => new InfoArticle {
                date = o.Date,
                URL = o.URL,
                Url_Image = o.UrlDescriptImg,
                Description = o.SmallDescript.Length>150 ? o.SmallDescript.Substring(0,150): o.SmallDescript,
                Header = o.Header
            }).ToList();
            return spis;
        }


        public String GetContentTopMenu(string url)
        {
            string result = "";
            MagistralContext db = new MagistralContext();
            var content = db.Articl.FirstOrDefault(x =>x.Menu=="Main" && x.URL == url);
            if (content != null)
            {
                result = content.Context;
                Title = content.title;
                KeyWords = content.keywords;
                Description = content.Description;
                Layout = content.Layout;
                if (content.Header == "Цена") {
                    TemplateProduct tp = new TemplateProduct();
                    string price = tp.GetPrice();
                    result = result.Replace("@ShablonPrice", price);
                };
            }
            return result;
        }



        public void AddMessageBd(Messager ct)
        {
            MagistralContext db = new MagistralContext();
            db.Message.Add(ct);
            try {
                db.SaveChanges();
            }
            catch (Exception ex) { }
        }
    }
}