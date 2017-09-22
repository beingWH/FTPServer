using FTPServer.Abstract;
using FTPServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPServer.Concrete
{
    public  class FTPFactory
    {
        /// <summary>
        /// FTP工厂类方法
        /// </summary>
        /// <param name="fTPLOGIN">FTP服务登录参数</param>
        /// <returns></returns>
        public static IFTPFactory<FileStruct> GetInstance(FTPLOGIN fTPLOGIN)
        {
            if (!fTPLOGIN.Equals(null))
            {
                return new FTPHelper(fTPLOGIN.ftpServerIP, fTPLOGIN.ftpRemotePath, fTPLOGIN.ftpUserID, fTPLOGIN.ftpPassword);
            }
            else { return null; }
        }
    }
    public class FTPLOGIN
    {
        /// <summary>
        /// FTP服务器IP
        /// </summary>
        public string ftpServerIP { get; set; }
        /// <summary>
        /// FTP服务器默认目录
        /// </summary>
        public string ftpRemotePath { get; set; }
        /// <summary>
        /// FTP服务器登录用户名
        /// </summary>
        public string ftpUserID { get; set; }
        /// <summary>
        /// FTP服务器登录密码
        /// </summary>
        public string ftpPassword { get; set; }
    }

}
