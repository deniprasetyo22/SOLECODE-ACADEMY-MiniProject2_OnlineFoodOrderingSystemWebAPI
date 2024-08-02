using Microsoft.AspNetCore.Mvc;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Controllers
{
    /// <summary>
    /// Controller untuk mengelola data pesanan.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private static IOrderService _orderService;

        /// <summary>
        /// Konstruktor untuk OrderController.
        /// </summary>
        /// <param name="orderService">orderService yang diinjeksikan</param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Memasukkan pesanan baru.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/Order
        ///     {
        ///         "customerId": 1,
        ///         "note": "Tidak Pedas",
        ///         "orderedItems": [
        ///             {
        ///                 "id": 1,
        ///                 "name": "Bakso",
        ///                 "price": 15000,
        ///                 "category": "Food"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <param name="order">Objek Order yang akan dibuat.</param>
        /// <returns>Objek Order yang berhasil dibuat.</returns>
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            _orderService.PlaceOrder(order);
            return Ok(order);
        }

        /// <summary>
        /// Mengambil daftar semua pesanan.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Order
        /// </remarks>
        /// <returns>Daftar semua order.</returns>
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var orderList = _orderService.GetAllOrder();
            return Ok(orderList);
        }

        /// <summary>
        /// Menampilkan detail pesanan berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Order/1
        /// </remarks>
        /// <param name="orderId">ID dari order yang akan didapatkan.</param>
        /// <returns>Objek Order jika ditemukan, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpGet("{orderId}")]
        public IActionResult DisplayOrderDetail(int orderId)
        {
            if (orderId < 0)
            {
                return BadRequest();
            }

            var order = _orderService.DisplayOrderDetail(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        /// <summary>
        /// Mengambil status pesanan berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Order/order-status/5
        /// </remarks>
        /// <param name="orderId">ID dari order yang akan didapatkan statusnya.</param>
        /// <returns>Status order sesuai ID yang diberikan.</returns>
        [HttpGet("order-status/{orderId}")]
        public IActionResult GetOrderStatus(int orderId)
        {
            if (orderId < 0)
            {
                return BadRequest();
            }

            var orderStatus = _orderService.GetOrderStatus(orderId);
            return Ok(orderStatus);
        }

        /// <summary>
        /// Memperbarui status pesanan berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/Order/1
        ///     {
        ///         "status": "Delivered"
        ///     }
        /// </remarks>
        /// <param name="orderId">ID dari order yang akan diupdate statusnya.</param>
        /// <param name="status">Status terbaru dari order.</param>
        /// <returns>Pesan sukses jika status order berhasil diupdate, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpPut("{orderId}")]
        public IActionResult UpdateOrderStatus(int orderId, [FromBody] string status)
        {
            if (orderId < 0)
            {
                return BadRequest();
            }

            bool updateOrder = _orderService.UpdateOrderStatus(orderId, status);
            if (!updateOrder)
            {
                return NotFound();
            }

            return Ok("Order status berhasil diupdate.");
        }

        /// <summary>
        /// Membatalkan pesanan berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/Order/cancel-order/1
        /// </remarks>
        /// <param name="orderId">ID dari order yang akan dibatalkan.</param>
        /// <returns>Pesan sukses jika order berhasil dibatalkan, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpPut("cancel-order/{orderId}")]
        public IActionResult CancelOrder(int orderId)
        {
            if (orderId < 0)
            {
                return BadRequest();
            }

            bool cancelOrder = _orderService.CancelOrder(orderId);
            if (!cancelOrder)
            {
                return NotFound();
            }

            return Ok("Order berhasil dicancel.");
        }
    }


}
