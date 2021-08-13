using INGEMMET.TableroControl.Infrastructure;
using INGEMMET.TableroControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INGEMMET.TableroControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GetListTableroControl());
        }

        public ActionResult LoadReports(string type, string key)
        {
            ViewBag.url = GetLinkById(key);
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 300)]
        public ActionResult MenuLayout()
        {
            return PartialView("_MenuLayout", GetListTableroControl());
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        // Creado por : Anderson Ruiz Rojas (27/09/2017)    
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Retora el listado de Links del tablero de control
        /// </summary>
        public List<TablaGenerica> GetListTableroControl()
        {
            List<TablaGenerica> dttQuery = null;

            if (Session["ListTableroControl"] == null)
            {
                dttQuery = (new DataAccess()).GetListMenu();
                Session["ListTableroControl"] = dttQuery;
            }
            else
            {
                dttQuery = Session["ListTableroControl"] as List<TablaGenerica>;
            }

            return dttQuery;
        }


        public string GetLinkById(string id)
        {
            var result = GetListTableroControl()
                .Where(x => x.codigo == id)
                .FirstOrDefault();

            return (result == null) ? "" : result.adicional;
        }

    }
}