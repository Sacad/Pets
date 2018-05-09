using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGLTest.Configuration
{
    public class Configuration : IConfiguration
    {
        public string PersonServiceUrl
        {
            get
            {
                var url = System.Configuration.ConfigurationManager.AppSettings["PeopleService"];
                return url;
            }
        }
    }
}