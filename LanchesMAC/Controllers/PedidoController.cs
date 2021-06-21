using LanchesMAC.Models;
using LanchesMAC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMAC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            var items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;

            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche...");
            }

            if (!ModelState.IsValid)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Pedido pedido)
        {
            decimal precoTotalPedido = 0.0m;
            int totalItensPedido = 0;

            var items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;


            //Verifica se existem itens de pedido
            if(_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche...");
            }

            //calcula o total do pedido
            foreach (var item in items)
            {
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
                totalItensPedido += item.Quantidade;
            }

            //atribui o preco total do pedido
            pedido.TotalItensPedido = totalItensPedido;

            //atribui o total dos itens do pedido
            pedido.PedidoTotal = precoTotalPedido;
            
            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);

                //TempData["Nome"] = pedido.Nome;
                //TempData["NumeroPedido"] = pedido.PedidoId;
                //TempData["DataPedido"] = pedido.PedidoEnviado;
                ViewBag.TotalPedido = ((decimal)_carrinhoCompra.GetCarrinhoCompraTotal()).ToString("C2");
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";

                _carrinhoCompra.LimparCarrinho();

                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);
        }

        public IActionResult CheckoutCompleto()
        {
            //ViewBag.Nome = TempData["Nome"];
            //ViewBag.NumeroPedido = TempData["NumeroPedido"];
            //ViewBag.DataPedido = TempData["DataPedido"];
            //ViewBag.TotalPedido = TempData["TotalPedido"];
            //ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
            return View();
        }
    }
}
