using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MVCIdiomas.Models;

namespace MVCIdiomas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(Persona modelPersona)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(modelPersona);

        }

        public ActionResult Correo()
        {
            return View();
        }

        [HttpPost]
        //Para usar un editor wysiwyg hay que deshabilitar la protección de .net para
        //evitar enviar código html y js
        [ValidateInput(false)]
        public ActionResult Correo(Correo modelCorreo)
        {
            var mensaje=new MailMessage();
            mensaje.Subject = modelCorreo.Asunto;
            mensaje.Body = modelCorreo.Mensaje;
            mensaje.To.Add(modelCorreo.Destino);
            mensaje.Bcc.Add(modelCorreo.Destino);
            mensaje.CC.Add(modelCorreo.Destino);
            mensaje.IsBodyHtml = true;

            var smtp=new SmtpClient();

            try
            {
                smtp.Send(mensaje);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index");
        }
    }
}