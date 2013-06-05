using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generic.Session
{
    public class SessionSingleton
    {
        public SessionSingleton()
        {
            
        }
        public static SessionSingleton _instance = new SessionSingleton();
        public static SessionSingleton Instance
        {
            get {return _instance;}
        }
        public bool IsSetFromClient
        {
            get
            {
                return (System.Web.HttpContext.Current.Session["IsSetFromClient"] != null) ? (bool)System.Web.HttpContext.Current.Session["IsSetFromClient"] : false;
            }
            set
            {
                System.Web.HttpContext.Current.Session["IsSetFromClient"] = value;
            }
        }
    }
}