using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generic
{
    public class EmbeddedResourceViewEngine : RazorViewEngine
    {
        /// <summary> ///Set up the view locations (including the temp locations we will build to) 
        /// and take the embedded views and put them in the tmp file. 
        ///NOTE: This file should not need to be updated for new Areas to become part///of the solution. 
        /// </summary> 
        public EmbeddedResourceViewEngine()
        {
            ViewLocationFormats = new[]
                {
                    "~/Views/{1}/{0}.aspx",
                    "~/Views/{1}/{0}.ascx",
                    "~/Views/Shared/{0}.aspx",
                    "~/Views/Shared/{0}.ascx",
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/{1}/{0}.vbhtml",
                    "~/Views/Shared/{0}.cshtml",
                    "~/Views/Shared/{0}.vbhtml",
                    // Code above will search the client before generic. 
                    // Improved Temp Locations 
                    // The embedded view will be copied to a tmp folder 
                    // using a similar structure to the View Folder 
                    "~/tmp/Views/{1}/{0}.cshtml",
                    "~/tmp/Views/{1}/{0}.vbhtml"
                };

            PartialViewLocationFormats = new[]
                {
                    "~/Views/Shared/{0}.cshtml", //Client first - not tested in demo 
                    "~/tmp/Views/Shared/{0}.cshtml" //Improved method. 
                };
            SaveAllViewsToTempLocation();
        }

        /// <summary> 
        ///Get the embedded views within the project and save the info to the tmp
        ///location. /// </summary>
        private static void SaveAllViewsToTempLocation()
        {
            IEnumerable<string> resources =
                typeof (EmbeddedResourceViewEngine).Assembly.GetManifestResourceNames()
                                                   .Where(name => name.EndsWith(".cshtml"));
            foreach (string res in resources)
            {
                SaveViewToTempLocation(res);
            }
        }

        /// <summary> 
        /// Save Resource To The Temp File. 
        /// </summary> 
        /// <param name="res"></param> 
        private static void SaveViewToTempLocation(string res)
        {
            // Get the file path to manipulate and the fileName for re-addition later. 
            string[] resArray = res.Split('.');
            // rebuild split to get the paths. 
            string filePath =String.Join("/", resArray, 0, resArray.Count() - 2) +"/";
            string fileName =String.Join(".", resArray, resArray.Count() - 2, 2);
            // replace name of project, with temp file to save to. 
            string rootPath = filePath.Replace("Generic", "~/tmp");
            //Set in line with the server folder... 
            rootPath = HttpContext.Current.Server.MapPath(rootPath);
            if(!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);
            
            //Save the file to the new location. 
            string saveToLocation = rootPath + fileName;
            Stream resStream = typeof(EmbeddedResourceViewEngine).Assembly.GetManifestResourceStream(res);
            System.Runtime.Remoting.MetadataServices.MetaData.SaveStreamToFile(resStream, saveToLocation);
        }
    }
}