using System.Collections.Generic;
using System.Linq;
using PizzariaUDS.Models;
using System.Web.Mvc;

namespace PizzariaUDS.Controllers
{
   
    public class TamanhoPizzaController : Controller
    {
        TamanhoPizza tamanhoPizza = new TamanhoPizza();
        // GET: api/TamanhoPizza
        [HttpGet]        
        public JsonResult Get()
        {           
            var tamanho = tamanhoPizza.MetodoLista().ToList();
            return Json(tamanho, JsonRequestBehavior.AllowGet);
        }

        // GET: api/TamanhoPizza/5        
        public JsonResult Get(int id)
        {
            var tamanho = tamanhoPizza.MetodoLista().Where(x => x.ID == id).ToList();
            return Json(tamanho, JsonRequestBehavior.AllowGet);            
        }
    }
}
