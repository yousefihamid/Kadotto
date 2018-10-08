using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public ActionResult Upload(int? chunk, string name)
        {
            string Res = "error";
            try
            {
                string uploadPath = Server.MapPath("~/TempUpload/");
                var fileUpload = Request.Files[0];

                chunk = chunk ?? 0;
                using (var fs = new FileStream(Path.Combine(uploadPath, name), chunk == 0 ? FileMode.Create : FileMode.Append))
                {
                    if (fileUpload != null)
                    {
                        var buffer = new byte[fileUpload.InputStream.Length];
                        fileUpload.InputStream.Read(buffer, 0, buffer.Length);
                        fs.Write(buffer, 0, buffer.Length);
                    }
                }
                Res = "chunk uploaded";
            }
            catch (Exception ex)
            {

            }
            return Content(Res, "text/plain");
        }

        public bool Delete(string fileName)
        {
            try
            {
                string fullPath = Request.MapPath("~/TempUpload/" + fileName);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            catch { }
            return true;
        }
    }
}