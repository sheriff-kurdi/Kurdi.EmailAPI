using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kurdi.EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        // GET: api/<MailController>
        [HttpGet]
        public IActionResult Get()
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress("sheriffelwany@gmail.com");
            message.To.Add("sheriff.kurdi@gmail.com");
            message.Subject = "test";
            message.Body = "Test Content";


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sheriffelwany@gmail.com", "password");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(message);
            }

            return Ok();
        }

        // GET api/<MailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
