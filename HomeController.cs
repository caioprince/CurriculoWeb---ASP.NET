using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using CurriculoWeb.Models;

namespace CurriculoWeb.Controllers
{
    public class HomeController : Controller
    {

  
        [HttpPost]
        
        public ActionResult Index(string NM_DESTINATARIO,string EMAIL_DESTINATARIO,string MENSAGEM, CadastroEmail model)
        {
            try { 
            DB_ESTUDOSEntities db = new DB_ESTUDOSEntities();

            TB_CADASTRO_EMAIL emp = new TB_CADASTRO_EMAIL();
            emp.NM_DESTINATARIO = model.NM_DESTINATARIO;
            emp.EMAIL_DESTINATARIO = model.EMAIL_DESTINATARIO;
            emp.MENSAGEM = model.MENSAGEM;
            emp.DT_CONTATO = model.DT_CONTATO;

            db.TB_CADASTRO_EMAIL.Add(emp);
            db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
          

            MailAddress to = new MailAddress("DESTINO");

            MailAddress from = new MailAddress(EMAIL_DESTINATARIO);

            MailMessage mail = new MailMessage(from, to);


            mail.Subject = "ASSUNTO" + EMAIL_DESTINATARIO;


            mail.Body =  MENSAGEM;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "SMTP";
            smtp.Port = 587;

            smtp.Credentials = new NetworkCredential(
                "EMAIL", "SENHA");
            smtp.EnableSsl = true;
            Console.WriteLine("Enviando email...");
            smtp.Send(mail);

            return View();
        }
        [HttpGet]
        public ActionResult actionResult()
        {
            ViewBag.Message = "";
                return View();
        }
       
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


    }
}
