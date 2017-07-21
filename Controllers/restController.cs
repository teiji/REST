using Newtonsoft.Json;
using rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace rest.Controllers
{
    public class restController : ApiController
    {

        // GET: api/rest/5
        public HttpResponseMessage Get(string value)
        {
            HttpResponseMessage response;


            try
            {
                DateTime enteredDate;
                DateTime prueba;

                if (DateTime.TryParse(value, out prueba))
                {

                    enteredDate = DateTime.Parse(value);

                var utcOffset = TimeZoneInfo.Local.GetUtcOffset(enteredDate);
                var formattedOffset = utcOffset.ToString("hh\\:mm");
                //Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss'-'" + formattedOffset));

                respuesta[] res = new respuesta[]
                    {new respuesta { code= (int)HttpStatusCode.OK, data=enteredDate.ToString("yyyy-MM-ddTHH:mm:ss'-'" + formattedOffset), description= "OK"} };
                response = Request.CreateResponse(HttpStatusCode.OK, "value");
                response.Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json");
                }
                else
                {
                    respuesta[] res = new respuesta[]
                  {new respuesta { code= (int)HttpStatusCode.BadRequest, data="", description= "Formato no valido"} };
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "value");
                    response.Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json");
                    return response;
                }

            }
            catch (Exception we)
            {
                respuesta[] res = new respuesta[]
                 {new respuesta { code= (int)HttpStatusCode.InternalServerError, data="", description= "Error de Servidor"} };
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, we);
                response.Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json");
            }

            return response;
        }

        // POST: api/rest
        public HttpResponseMessage Post(string value)
        {
            HttpResponseMessage response;

            try
            {


            Boolean error = false;
            if (Regex.IsMatch(value, @"^[^\W\d_]+$"))
            {
                error = true;
            }

                if (value.Length > 4)
                {

                    respuesta[] res = new respuesta[]
                    {new respuesta { code= (int)HttpStatusCode.BadRequest, data="", description= "Solo 4 letras"} };
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "value");
                    response.Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json");
                   

                }
                else
                {
                    if (error)
                    {
                        respuesta[] res = new respuesta[]
                   {new respuesta { code= (int)HttpStatusCode.OK, data=value.ToUpper(), description= "OK"} };
                        response = Request.CreateResponse(HttpStatusCode.OK, "value");
                        response.Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json");
                    }
                    else
                    {

                        respuesta[] res = new respuesta[]
                   {new respuesta { code= (int)HttpStatusCode.BadRequest, data="", description= "Solo letras"} };
                        response = Request.CreateResponse(HttpStatusCode.BadRequest, "value");
                        response.Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json");

                    }
                }
            }
            catch (Exception we)
            {
                respuesta[] res = new respuesta[]
                 {new respuesta { code= (int)HttpStatusCode.InternalServerError, data="", description= "Error de Servidor"} };
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, we);
                response.Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json");
            }
            return response;
        }




    }
}
