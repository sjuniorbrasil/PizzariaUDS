using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzariaUDS.Models;
using System.Web.Mvc;

namespace PizzariaUDS.Controllers
{
    
    public class AdicionalPizzaController : Controller
    {
        AdicionalPizza adicionalPizza = new AdicionalPizza();
        // GET: api/AdiconalPizza
        [HttpGet]
        public JsonResult Get()
        {
            var adicional = adicionalPizza.MetodoLista().ToList();
            return Json(adicional, JsonRequestBehavior.AllowGet);
        }

        // GET: api/AdiconalPizza/5        
        public JsonResult Get(int id)
        {
            var adicional = adicionalPizza.MetodoLista().Where(x => x.ID == id).ToList();
            return Json(adicional, JsonRequestBehavior.AllowGet);
        }
    }
}