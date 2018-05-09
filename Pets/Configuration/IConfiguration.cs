using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGLTest.Configuration
{
    public interface IConfiguration
    {
        string PersonServiceUrl { get; }
    }
}