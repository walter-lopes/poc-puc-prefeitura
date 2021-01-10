using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SGM_MVC.Services.ServicesUtils
{
    public static class Utils
    {
        public static StringContent getJsonStringContent(Object model) {
            return new StringContent(
                            JsonConvert.SerializeObject(model),
                            Encoding.UTF8,
                            "application/json");
        }
    }
}
