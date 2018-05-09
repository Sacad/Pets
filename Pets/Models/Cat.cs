using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGLTest.Models
{
    public class Cat
    {
        public string Name { get; set; }
        public string OwnerGender { get; set; }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Cat;
            if (toCompareWith == null)
            {
                return false;
            }
                
            return this.Name == toCompareWith.Name &&
                   this.OwnerGender == toCompareWith.OwnerGender;
        }

    }
}