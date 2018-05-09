using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;

namespace AGLTest.UnitTests
{

    public static class CompareLogicCreator
    {
        public static CompareLogic Create()
        {
            var config = new ComparisonConfig
            {
                MaxDifferences=1000
            };

            var compareLogic = new CompareLogic(config);
            return compareLogic;
        }

    }


}