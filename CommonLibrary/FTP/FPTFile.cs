using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary
{
    public class FPTFile
    {
        public static string UploadFtpFile(string folderName, string fileName)
        {
            DataSet myDataSet=new DataSet();
            myDataSet.ReadXml("FPTConfig.xml");
            DataTable mySetting = myDataSet.Tables["setting"];
            if (folderName == "")
                folderName = mySetting.Rows[0]["defaultfoler"].ToString();
            string absoluteFileName = Path.GetFileName(fileName);
            string link = string.Format(@"http://{0}/{1}/{2}",mySetting.Rows[0]["domain"], folderName, absoluteFileName);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", mySetting.Rows[0]["host"], folderName, absoluteFileName)));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            request.Credentials = new 
                NetworkCredential(mySetting.Rows[0]["username"].ToString(), mySetting.Rows[0]["password"].ToString());
            request.ConnectionGroupName = "group";
            request.Method = WebRequestMethods.Ftp.UploadFile;
            using (Stream fileStream = File.OpenRead(fileName))
            using (Stream ftpStream = request.GetRequestStream())
            {
                byte[] buffer = new byte[10240];
                int read;
                while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ftpStream.Write(buffer, 0, read);
                }
            }
            //MessageBox.Show("Upload success!");
            Clipboard.SetText(link);
            return link;
        }
    }
}
