using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using Magistral40.Models;
using System.Threading.Tasks;
namespace Magistral40.ClLib
{
    public class EmailMes
    {
        public  void SentEmail(Messager Model)   
        {
        
            try
            {

                //Дублируем в базе данных
                WorkData wd = new WorkData();
                wd.AddMessageBd(Model);
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("info@magistral-40.ru", "Магистраль");
                // кому отправляем
                MailAddress to = new MailAddress("magistral40@bk.ru");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Обратная связь с сайта Магистраль";
                // текст письма
                m.Body = "<p><strong>"+ Model.UserName+ "</strong> отправил заявку </p><p><strong>Email: </strong>" + Model.EmailAdrress+ " <strong>Телефон: </strong>"+Model.Phone+ "</p><p><strong>Сообщение:</strong> " + Model.Message+"</p>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("mail.magistral-40.ru", 25);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("info@magistral-40.ru", "Dbb7a7!0");
                smtp.EnableSsl = false;
                smtp.Send(m);
                Vkontakte vk = new Vkontakte();
                vk.sentMessage(445997077, m.Body);
            }

              catch (Exception ex) { }
        }
    }
}