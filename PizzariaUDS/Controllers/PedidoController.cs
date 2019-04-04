using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PizzariaUDS.Models;
using System.Web.Mvc;

namespace PizzariaUDS.Controllers
{
    public class PedidoController : Controller
    {
        DataContext db = new DataContext();
        // GET: api/Pedido/EscolhaTamanho/5 
        [HttpGet]
        public  JsonResult EscolhaTamanho(int tamanho)
        {
            try
            {
                TamanhoPizza tamanhoPizza = new TamanhoPizza();
                var getDadosTamanho = tamanhoPizza.MetodoLista().Where(x => x.ID == tamanho).FirstOrDefault();
                Pedido pedido = new Pedido();
                pedido.Id = Utils.Utils.GetNewCode("Pedidoes", "Id", "");
                pedido.TamanhoId = tamanho;
                pedido.ValorPizza = getDadosTamanho.Valor;
                pedido.ValorTotal = pedido.ValorPizza;
                pedido.Adicionais = new List<PedidoAdicional>();
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return this.Json(pedido, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Erro ao Efetuar o Pedido, tente novamente");
                throw;
            }
        }

        // GET: api/Pedido/EscolhaSabor/5 
        [HttpGet]
        public JsonResult EscolhaSabor(int sabor, int pedidoId)
        {
            try
            {
                SaborPizza saborPizza = new SaborPizza();
                TamanhoPizza tamanhoPizza = new TamanhoPizza();
                var getDadosSabor = saborPizza.MetodoLista().Where(x => x.ID == sabor).FirstOrDefault();                
                var pedido = db.Pedidos.Find(pedidoId);
                var getDadosTamanho = tamanhoPizza.MetodoLista().Where(x => x.ID == pedido.TamanhoId).FirstOrDefault();
                pedido.SaborId = sabor;
                pedido.TempoPreparo = getDadosTamanho.TempoPreparo(sabor);
                pedido.Adicionais = new List<PedidoAdicional>();
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return Json(pedido, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Erro ao Efetuar o Pedido, tente novamente");
                throw;
            }
        }
        // GET: api/Pedido/EscolhaAdicionais/5 
        [HttpGet]
        public JsonResult EscolhaAdicionais(int adicionalId, int pedidoId)
        {
            try
            {   
                var pedido = db.Pedidos.Find(pedidoId);
                var getPedidoAdicional = db.Adicionais.Where(x => x.PedidoId == pedidoId).Select(s => new { s.PedidoAdicionalId }).FirstOrDefault();
                AdicionalPizza adicionalPizza = new AdicionalPizza();
                var adicional = adicionalPizza.MetodoLista().Where(x => x.ID == adicionalId).FirstOrDefault();
                PedidoAdicional pedidoAdicional = new PedidoAdicional();
                if (getPedidoAdicional == null)
                {             
                    pedidoAdicional.PedidoAdicionalId = 1;                    
                }
                else
                {
                    pedidoAdicional.PedidoAdicionalId = getPedidoAdicional.PedidoAdicionalId + 1;
                }
                pedidoAdicional.PedidoId = pedidoId;
                pedidoAdicional.AdicionalId = adicionalId;
                pedidoAdicional.Valor = adicional.Valor;
                pedidoAdicional.Tempo = adicional.Tempo;
                db.Adicionais.Add(pedidoAdicional);
                db.SaveChanges();

                var tempoPreparoTotal = db.Adicionais.Where(x => x.PedidoId == pedidoId).Sum(s => s.Tempo);
                var ValorTotal = db.Adicionais.Where(x => x.PedidoId == pedidoId).Sum(s => s.Valor);

                pedido.TempoPreparo += tempoPreparoTotal;
                pedido.ValorAdicional =  ValorTotal;
                pedido.ValorTotal = Convert.ToDecimal(pedido.ValorAdicional) + pedido.ValorPizza;

                var adicionais = db.Adicionais.Where(x => x.PedidoId == pedidoId).ToList();

                pedido.Adicionais = adicionais;            
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return Json(pedido, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Erro ao Efetuar o Pedido, tente novamente");
                throw;
            }
        }

        // GET: api/Pedido/5        
        public JsonResult Get(int id)
        {
            var pedido = db.Pedidos.Find(id);
            var adicionais = db.Adicionais.Where(x => x.PedidoId == id).ToList();
            pedido.Adicionais = adicionais;
            return Json(pedido, JsonRequestBehavior.AllowGet);
        }
    }
}