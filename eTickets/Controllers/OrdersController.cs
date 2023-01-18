using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesSerivce _moviesSerivce;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IMoviesSerivce moviesSerivce, ShoppingCart shoppingCart)
        {
            _moviesSerivce = moviesSerivce;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()   
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCardItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _moviesSerivce.GetMovieByIdAsync(id);
            if(item != null)
            {
                _shoppingCart.AddItemCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemToShoppingCart(int id)
        {
            var item = await _moviesSerivce.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
