using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using CONTACTAPPMVC.Models;

namespace CONTACTAPPMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCF db = new MVCF();
        public IList<contactViewModel> GetContactList()
        {
            var ContactList = (from e in db.contacts
                           select new contactViewModel()
                           {
                               FirstName = e.FirstName,
                               LastName = e.LastName,
                               Email = e.Email,
                               DialCode = e.DialCode,
                               Number=e.Number,
                               Address=e.Address,
                           }).ToList();
        return ContactList;        }
    public ActionResult Index()
    {
        return View(this.GetContactList());
    }
        public ActionResult ExportToExcel()
        {
            var gv = new GridView
            {                DataSource = this.GetContactList()           };
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objstringWriter = new StringWriter();
            HtmlTextWriter objhtmlTextWriter = new HtmlTextWriter(objstringWriter);
            gv.RenderControl(objhtmlTextWriter);
            Response.Output.Write(objstringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");       }
        public ActionResult About()
        {                     return View();        }

        public ActionResult Contact()
        {                       return View();        }    }}
