using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Enviar(FormCollection form)
        {
            string Nome =  Convert.ToString(form["txNome"]);     
            string Email = Convert.ToString(form["txEmail"]);
            int? Html = form["txHTML"] == "" ? (int?)null : Convert.ToInt16(form["txHTML"]);
            int? Css = form["txCSS"] == ""? (int?)null :Convert.ToInt16(form["txCSS"]);
            int? Js = form["txJS"] == ""? (int?)null :Convert.ToInt16(form["txJS"]);
            int? Python = form["txPython"] == ""? (int?)null : Convert.ToInt16(form["txPython"]);
            int? Django = form["txDjango"] == ""? (int?)null :Convert.ToInt16(form["txDjango"]);
            int? Ios = form["txiOS"] == ""? (int?)null : Convert.ToInt16(form["txiOS"]);
            int? Android = form["txAndroid"] == ""? (int?)null :Convert.ToInt16(form["txAndroid"]);
         
            string corpo = "";
            string assunto = "Obrigado por se candidatar";

            if (Html >= 7 || Css >= 7 || Js >= 7)
            {
                corpo = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Front-End entraremos em contato.";
                if (Python >= 7 || Django >= 7 || Ios >= 7 || Android >= 7) 
                {
                    corpo = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador entraremos em contato.";   
                }
            }
            else if (Python >= 7 || Django >= 7)
            {
                corpo = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Back-End entraremos em contato.";
                if (Html >= 7 || Css >= 7 || Js >= 7 || Ios >= 7 || Android >= 7) 
                {
                    corpo = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador entraremos em contato.";   
                }
            }
            else if (Ios >= 7 || Android >= 7)
            {
                corpo = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador Mobile entraremos em contato.";
                if (Html >= 7 || Css >= 7 || Js >= 7 || Python >= 7 || Django >= 7)
                {
                    corpo = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador entraremos em contato.";
                }    
            }

            string msg = EnviarEmail(Email, corpo, assunto);

            return View();
        }

        private string EnviarEmail(string destinatario, string body, string assunto)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("teste.desenvolvedor.project@gmail.com", "#teste123"),
                    EnableSsl = true
                };
                client.Send("teste.desenvolvedor.project@gmail.com", destinatario, assunto, body);
               

                return "Enviado Com Sucesso";
            }
            catch (Exception ex)
            {
                return "Seu email não foi enviado!";
            }
        }
    }
}