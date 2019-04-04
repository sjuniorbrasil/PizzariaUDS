using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzariaUDS.Models;
using System.Web.Mvc;

namespace PizzariaUDS.Controllers
{
    
    public class SaborPizzaController : Controller
    {
        SaborPizza saborPizza = new SaborPizza();
        // GET: api/SaborPizza
        [HttpGet]
        public JsonResult Get()
        {
            var sabor = saborPizza.MetodoLista().ToList();
            return Json(sabor, JsonRequestBehavior.AllowGet);
        }

        // GET: api/TamanhoPizza/5        
        public JsonResult Get(int id)
        {
            var sabor = saborPizza.MetodoLista().Where(x => x.ID == id).ToList();
            return Json(sabor, JsonRequestBehavior.AllowGet);
        }
    }
}