using FTPServer.Abstract;
using FTPServer.Domain.Concrete;
using FTPServer.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FTPServer.Infrastructure
{
    public class NinjectFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBinding()
        {
            ninjectKernel.Bind<IRepository<FTPFileAttr>>().To<FileAttrRepository>();
            ninjectKernel.Bind<IRepository<FTPLogin>>().To<FTPLoginRepository>();
            
        }
    }
}