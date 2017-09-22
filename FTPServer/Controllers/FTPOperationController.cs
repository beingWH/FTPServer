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
            FTPLogin login = ftplogin.QueryEntities.FirstOrDefault(x => x.FtpServerIP == "192.168.0.102:2121");
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
        public ViewResult Index(FTPModel fTPModel)
        {
            fTPModel.FTPUri=fTPModel.FTPUri == null ? "" : fTPModel.FTPUri;
            ftpBO.GotoDirectory(fTPModel.FTPUri, false);
            ViewData["IsRoot"] = fTPModel.FTPUri == "" ? true : false;
            return View(ftpBO.ListFilesAndDirectories());
        }
        [HttpPost]
        public ActionResult CreateDirectory(FTPModel fTPModel, FTPDir fTPDir) {
            ftpBO.GotoDirectory(fTPModel.FTPUri, false);
            ftpBO.CreateDirectory(fTPDir.name);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ViewResult CreateDirectory()
        {
            return View(new FTPDir());
        }
        public ActionResult UploadFile(FTPModel fTPModel) {
            foreach (string upload in Request.Files) {
                if (!Request.Files[upload].HasFile()) continue;
                string path = "E:\\FTPSERVER\\"+fTPModel.FTPUri;
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                Request.Files[upload].SaveAs(Path.Combine(path, filename));
            }
            return RedirectToActionPermanent("Index");
        }
        public ActionResult DeleteDirectory(FTPModel fTPModel,string Name)
        {
            ftpBO.RemoveDirectory(Path.Combine(fTPModel.FTPUri, Name));
            return RedirectToActionPermanent("Index");
        }
        public ActionResult DeleteFile(FTPModel fTPModel, string Name)
        {
            ftpBO.DeleteFile(Path.Combine(fTPModel.FTPUri, Name));
            return RedirectToActionPermanent("Index");
        }
        public ActionResult GoDirectory(FTPModel fTPModel,string Name)
        {
            fTPModel.FTPUri += Name + "/";
            ftpBO.GotoDirectory(fTPModel.FTPUri, false);
            return RedirectToActionPermanent("Index");
        }
        public ActionResult ReturnDirectory(FTPModel fTPModel)
        {
            string[] sArray = fTPModel.FTPUri.Split('/');
            string str = "";
            for(int i = 0; i < sArray.Length - 2; i++)
            {
                str += sArray[i] + "/";
            }
            fTPModel.FTPUri = str;
            return RedirectToActionPermanent("Index");
        }
        public FileResult DownloadFile(FTPModel fTPModel, string Name)
        {
            string root = Server.MapPath("~/App_Data");
            string fileName =Name;
            string filePath = Path.Combine(root, fileName);
            string path = "E:\\FTPSERVER\\" + fTPModel.FTPUri;
            string s = MimeMapping.GetMimeMapping(fileName);
            return File(Path.Combine(path, Name), s, Path.GetFileName(filePath));
        }
    }
}