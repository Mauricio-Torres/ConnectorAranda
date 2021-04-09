using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aranda.Rules.WebHook.Helpers
{
    public static class Constants
    {
        public const string ErrorServer = "ErrorConectionServer";
        public const string urlWebHook = @"https://prod-26.westus.logic.azure.com:443/workflows/3ae44525e24a436cacbd20323d15fb5b/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=rVWzP6QjEa-Gq_IGqOnrs9tmF_H7bvVTuYGeJanHFek";

    }
}