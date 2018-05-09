using System;
using System.Web;
using AGLTest.Configuration;

namespace AGLTest.Services
{
    public interface IWebClient
    {
        string DownloadString();
    }
}