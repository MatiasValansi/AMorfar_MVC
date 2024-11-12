﻿using AMorfar_MVC.Helpers;
using AMorfar_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMorfar_MVC.Controllers
{
    public class PedidosController : Controller 
    {
        readonly Context context = new();
        public IActionResult Index()
        {
            var pedidos = context.Pedidos.ToList();
            return View(pedidos);
        }

        [HttpGet]
        // devuelve la vista que se llame Crear dentro de las views de Pedidos (el formulario)
        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Pedido pedido)
        {
            Pedido newPedido = new()
            {
                Titulo = pedido.Titulo,
                Lugar = pedido.Lugar,
                Propina = pedido.Propina,
                AdicionalInfo = pedido.AdicionalInfo,
                Fecha = DateTime.Now
            };
            
            Response response = Helper.Guardar(context, newPedido);
            ViewData.Add("Response", response);
            // lo devuelvo a la misma vista, con la diferencia de que en la viewbag le mando la respuesta que me haya devuelto el metodo Guardar
            return View();
        }

    }
}