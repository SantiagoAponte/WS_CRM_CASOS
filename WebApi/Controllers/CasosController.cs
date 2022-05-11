using Aplicacion;
using Aplicacion.Interfaces;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class CasosController : myControllerBase{
     private MailService _mailService;
     public CasosController(MailService mailService)
        {
       
            _mailService = mailService;
           
        }

    
[HttpGet("createdMail")]
        public async Task<IActionResult> SendmailCreateAppoinment(string email, string caso)
        {
            // if (string.IsNullOrEmpty())
            //     return NotFound();

            var result = await _mailService.SendEmailAsync(email, caso);

            if (result.IsSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }

        [HttpGet("redmine")]
        public async Task<ActionResult> GetCasos()
        {
            var url = "http://soluciones.lavital.co/issues.json?project_id=9&limit=1000";

            using (var http = new HttpClient())
            {
                var client = new HttpClient();

                http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "user", "KjwIgsgqle2B"))));

                var response = await http.GetStringAsync(url);
                Root casos = JsonConvert.DeserializeObject<Root>(response);
                return Ok(casos.issues);


            }

        }

        [HttpPost("add")]
        public async Task<ActionResult<Unit>> postCasos(PostCasos.Execute data)
        {
            var url = "http://soluciones.lavital.co/issues.json?project_id=9&limit=10";

            using (var http = new HttpClient())
            {
                var client = new HttpClient();

                http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "user", "KjwIgsgqle2B"))));

                var response = await http.GetStringAsync(url);
               // var ojala = JObject.Parse(response);

                Root casos = JsonConvert.DeserializeObject<Root>(response);
           
                foreach (var task in casos.issues)
                {
                    data.id = task.id;
                    data.projectName = task.project;
                    data.trackerName = task.tracker;
                    data.statusName = task.status;
                    data.priority = task.priority;
                    data.author = task.author;
                    data.assigned_to = task.assigned_to;
                    data.category = task.category;
                    data.subject = task.subject;
                    data.description = task.description;
                    data.start_date = task.start_date;
                    data.due_date = task.due_date;
                    data.custom_fields = task.custom_fields;
                    data.created_on = task.created_on;
                    data.updated_on = task.updated_on;
                    data.closed_on = task.closed_on;
                  
                //return await mediator.Send(data);
                }
            return await mediator.Send(data);
            }
            //return await mediator.Send(new RolList.Execute()); AQUI SE ENVIA A LA BD NUESTRA.
        }
    }
}
