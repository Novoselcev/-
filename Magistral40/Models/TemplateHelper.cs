using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magistral40.Models;

namespace Magistral40.Models
{
    public class TemplateProduct
    {

        //Загрузка прайса
        public string GetPrice()
        {
            MagistralContext db = new MagistralContext();
            var mod = db.Prices.GroupBy(x => x.SortIndex);
            TagBuilder tag = new TagBuilder("table");
            tag.AddCssClass("table");
            tag.InnerHtml += "<tr><th>Наименование</th><th>Единица измерения</th><th>Цена, руб.*</th></tr>";
            foreach (var item in mod)
            {
                tag.InnerHtml += "<tr><td colspan = \"3\" style = \"text-align:center;background-color:#D76366;color:#fff;\" >" + item.First().Group_Name + "</td></tr>";
                foreach (var t in item)
                {
                    tag.InnerHtml += "<tr><td>" + t.Name + "</td><td>" + t.IE + "</td><td>" + t.Price + "</td></tr>";
                }
            }
            return tag.ToString();
        }

        public String Prod(string group)
        {
            MagistralContext db = new MagistralContext();
            List<Prices> price;
            if (group != "Бетон")
            {
                if (group == "Щебень")
                    price = db.Prices.Where(x => x.Group_Name_Main == group).Select(o => o).ToList();
                else
                    price = db.Prices.Where(x => x.Group_Name == group).Select(o => o).ToList();

                TagBuilder tag = new TagBuilder("div");
                tag.AddCssClass("CatprodPrice");
                foreach (var z in price)
                {

                    // второй вариант
                    String str = "<div class=\"prodPrice\"><img src =\"" + z.URL + "\"/><div class=\"ProdPrText\"> " + z.Group_Name
                        + "<br>" + z.Name + "</div><span class=\"btn btn-primary btn-lg\">" + z.Price + " руб./" + z.IE + "</span></div>";
                    tag.InnerHtml += str;
                }
                return tag.ToString() + "<p style=\"color:#aa3034;font-weight:bold; \"> Цены указаны с учетом доставки в пределах города Калуги</p>";
            }
            else
            {
                var mod = db.Prices.Where(x=>x.Group_Name_Main=="Бетон").GroupBy(x => x.SortIndex);
                TagBuilder tag = new TagBuilder("table");
                tag.AddCssClass("table");
                tag.InnerHtml += "<tr><th>Марка</th><th>Осадка</th><th>Класс смеси</th><th>Цена за м3, руб.*</th></tr>";
                foreach (var item in mod)
                {
                    tag.InnerHtml += "<tr><td colspan = \"4\" style = \"text-align:center;background-color:#D76366;color:#fff;\" >" + item.First().Group_Name + "</td></tr>";
                    foreach (var t in item)
                    {
                        tag.InnerHtml += "<tr><td>" + t.Name + "</td><td>" + t.IE + "</td><td>" + t.classM + "</td><td>" + t.Price + "</td></tr>";
                    }
                }
                return tag.ToString()+ "<p style=\"color:#aa3034;font-weight:bold; \"> Цены указаны с учетом доставки в пределах города Калуги</p>";
            }
        }
    }
}