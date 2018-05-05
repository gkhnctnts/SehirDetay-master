using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SehirDetay.Helpers
{
    public class Yetki: AuthorizeAttribute
    {
        public string Roller { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.Session["sc"] != null)
            {
                var sc = (SessionClass)httpContext.Session["sc"];

                if (Roller.Contains(","))
                {
                    string[] roller = Roller.Split(',');

                    for (int i = 0; i < roller.Length; i++)
                    {
                        if (sc.Roller.Contains(Convert.ToInt32(roller[i])))
                            return true;
                    }
                }
                else
                {
                   if ( sc.Roller.Contains( Convert.ToInt32( Roller)))
                        return true;
                }
            }

            
            return false;

        }

    }
}