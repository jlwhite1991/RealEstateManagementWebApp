using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Capstone.DAL.Interfaces;
using Capstone.Providers.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class ManagerController : HomeController
    {


        public ManagerController(IApplicationDAL applicationDAL, IPropertyDAL propertyDAL, IHttpContextAccessor contextAccessor, IUserDAL userDAL, IUnitDAL unitDAL, IAuthProvider authProvider, IServiceRequestDAL serviceRequestDAL,
            IPaymentDAL paymentDAL)
            : base( applicationDAL,  propertyDAL,  contextAccessor,  userDAL, unitDAL, authProvider, serviceRequestDAL, paymentDAL) 
        {

        }

        [AuthorizationFilter("manager")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AuthorizationFilter("manager")]
        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        [AuthorizationFilter("manager")]
        public ActionResult Email(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("nicholas.paraskos@gmail.com", "Nick");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "TechElevator2019";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    }
}