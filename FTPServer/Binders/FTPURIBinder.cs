using FTPServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FTPServer.Binders
{
    public class FTPURIBinder : IModelBinder
    {
        private const string sessionkey = "FTPURI";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            FTPModel fTPModel = (FTPModel)controllerContext.HttpContext.Session[sessionkey];
            if (fTPModel == null)
            {
                fTPModel = new FTPModel();
                controllerContext.HttpContext.Session[sessionkey] = fTPModel;
            }
            return fTPModel;
        }
    }
}