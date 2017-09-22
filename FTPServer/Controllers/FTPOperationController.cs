using FTPServer.Abstract;
using FTPServer.Concrete;
using FTPServer.Entities;
using FTPServer.Infrastructure;
using FTPServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FTPServer.Controllers
{
    public class FTPOperationController : Controller
    {
        private IRepository<FTPLogin> ftplogin;
        private IFTPFactory<FileStruct> ftpBO;
        public FTPOperationController(IRepository<FTPLogin> ftplogin) {
            this.ftplogin = ftplogin;
            FTPLogin login = ftplogin.QueryEntities.FirstOrDefault(x => x.FtpServerIP == "192.9.220.241:2121");
            FTPLOGIN fTPLOGIN = new FTPLOGIN()
            {
                ftpUserID = login.FtpUserID,
                ftpPassword = login.FtpPassword,
                ftpRemotePath = login.FtpRemotePath,
                ftpServerIP = login.FtpServerIP
            };
            ftpBO = FTPFactory.GetInstance(fTPLOGIN);
        }
        // GET: FTPOperation
        public ActionResult Index(FTPModel fTPModel)
        {
            ftpBO.GotoDirectory("wanghuan",false);
            fTPModel.FTPUri = "wanghuan";
            return View(ftpBO.ListFilesAndDirectories());
        }
        [HttpPost]
        public ActionResult CreateDirectory(FTPModel fTPModel, FTPFileAttr fTPFileAttr) {
            ftpBO.GotoDirectory(fTPModel.FTPUri,false);
            ftpBO.CreateDirectory(fTPFileAttr.Name);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ViewResult CreateDirectory()
        {
            return View(new FTPFileAttr());
        }
        public ActionResult UploadFile() 
        {
            return View();
        }
        [HttpPost,ActionName("UploadFile")]
        public ActionResult UploadFileCommit() {
            foreach (string upload in Request.Files) {
                if (!Request.Files[upload].HasFile()) continue;
                string path = "E:\\FTPSERVER\\wanghuan";
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                Request.Files[upload].SaveAs(Path.Combine(path, filename));
            }
            return View();
        }
        //public JsonResult DownloadFile()
        //{
            
        //}
    }
}