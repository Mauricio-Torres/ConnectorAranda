using Aranda.Rules.WebHook.Helpers;
using Aranda.Rules.WebHook.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace Aranda.Rules.WebHook
{
    /// <summary>
    /// Reglas para Service Desk V8
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class RulesService : WebService
    {
        [WebMethod]
        public bool IncidentOnchange(ASDK.Common.Entities.IncidentDescription item)
        {
            return Task.Run(async () => { return await SendMessage(item, "IncidentOnchange"); }).Result;
        }

        [WebMethod]
        public bool ProblemOnchange(ASDK.Common.Entities.ProblemDescription item)
        {
            return Task.Run(async () => { return await SendMessage(item, "ProblemOnchange"); }).Result;
        }

        [WebMethod]
        public bool ChangeOnchange(ASDK.Common.Entities.ChangeDescription item)
        {
            return Task.Run(async () => { return await SendMessage(item, "ChangeOnchange"); }).Result;
        }

        [WebMethod]
        public bool RequestOnchange(ASDK.Common.Entities.ServiceCallDescription item)
        {
            return Task.Run(async () => { return await SendMessage(item, "RequestOnchange"); }).Result;
        }

        [WebMethod]
        public bool CIOnchange(CMDB.Common.Entities.InfoCI item)
        {
            return Task.Run(async () => { return await SendMessage(item, "CIOnchange"); }).Result;
        }

        [WebMethod]
        public bool ArticleOnchange(ASS.Common.Entities.Article item)
        {
            return Task.Run(async () => { return await SendMessage(item, "ArticleOnchange"); }).Result;
        }

        [WebMethod]
        public bool IncidentOnchangeMethod(ASDK.Common.Entities.IncidentDescription item, string method)
        {
            return Task.Run(async () => { return await SendMessage(item, method); }).Result;
        }

        [WebMethod]
        public bool ProblemOnchangeMethod(ASDK.Common.Entities.ProblemDescription item, string method)
        {
            return Task.Run(async () => { return await SendMessage(item, method); }).Result;
        }

        [WebMethod]
        public bool ChangeOnchangeMethod(ASDK.Common.Entities.ChangeDescription item, string method)
        {
            return Task.Run(async () => { return await SendMessage(item, method); }).Result;
        }

        [WebMethod]
        public bool RequestOnchangeMethod(ASDK.Common.Entities.ServiceCallDescription item, string method)
        {
            return Task.Run(async () => { return await SendMessage(item, method); }).Result;

        }

        [WebMethod]
        public bool CIOnchangeMethod(CMDB.Common.Entities.InfoCI item, string method)
        {
            return Task.Run(async () => { return await SendMessage(item, method); }).Result;
        }

        [WebMethod]
        public bool ArticleOnchangeMethod(ASS.Common.Entities.Article item, string method)
        {
            return Task.Run(async () => { return await SendMessage(item, method); }).Result;
        }

        private async Task<bool> SendMessage(object data, string method)
        {
            bool result;
            
            Result obj = new Result
            {
                NameMethod = method,
                ValueObject = JsonConvert.SerializeObject(data)
            };

            try
            {
                var send = new HttpClient();

                HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                var resul = await send.PostAsync(Constants.urlWebHook, content);

                if (resul.StatusCode >= HttpStatusCode.MultipleChoices)
                {
                    throw new CustomException("Error Connection Result: " + resul.ToString());
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Logger.Logguer(method, "Exception ", ex.Message);
            }

            return result;
        }
    }
}
