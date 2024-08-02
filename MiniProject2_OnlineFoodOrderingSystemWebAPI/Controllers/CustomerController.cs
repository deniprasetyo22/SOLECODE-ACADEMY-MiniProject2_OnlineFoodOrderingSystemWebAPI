using Microsoft.AspNetCore.Mvc;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Controllers
{
    /// <summary>
    /// Controller untuk mengelola data pelanggan.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static ICustomerService _customerService;

        /// <summary>
        /// Konstruktor untuk CustomerController.
        /// </summary>
        /// <param name="customerService">customerService yang diinjeksikan.</param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Menambahkan data pelanggan baru.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Customer
        ///     {
        ///         "Name": "John Doe",
        ///         "Email": "john.doe@example.com",
        ///         "PhoneNumber": "1234567890"
        ///         "Address":"Jakarta"
        ///     }
        /// </remarks>
        /// <param name="customer">Objek Customer yang akan ditambahkan.</param>
        /// <returns>HTTP response yang menunjukkan keberhasilan dengan pesan.</returns>
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok("Customer berhasil ditambahkan.");
        }

        /// <summary>
        /// Mengambil daftar semua pelanggan.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Customer
        /// </remarks>
        /// <returns>Menampilkan Daftar semua data customer.</returns>
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var customerList = _customerService.GetAllCustomer();
            return Ok(customerList);
        }

        /// <summary>
        /// Mengambil data pelanggan berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Customer/1
        /// </remarks>
        /// <param name="customerId">ID unik pelanggan yang dicari.</param>
        /// <returns>Data pelanggan yang sesuai dengan ID yang diberikan, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById(int customerId)
        {
            if (customerId < 0)
            {
                return BadRequest();
            }

            Customer customer = _customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Memperbarui data pelanggan berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Contoh permintaan:
        /// 
        ///     PUT /api/Customer/1
        ///     {
        ///         "Name": "Jane Doe",
        ///         "Email": "jane.doe@example.com",
        ///         "PhoneNumber": "0987654321"
        ///         "Address":"Jakarta"
        ///     }
        /// </remarks>
        /// <param name="customerId">ID unik pelanggan yang akan diperbarui.</param>
        /// <param name="editCustomer">Objek Customer yang berisi data yang akan diperbarui.</param>
        /// <returns>Pesan sukses jika data pelanggan berhasil diupdate, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(int customerId, [FromBody] Customer editCustomer)
        {
            if (customerId < 0)
            {
                return BadRequest();
            }

            bool updateCustomer = _customerService.UpdateCustomer(customerId, editCustomer);
            if (!updateCustomer)
            {
                return NotFound();
            }

            return Ok("Data customer berhasil diupdate.");
        }

        /// <summary>
        /// Menghapus data pelanggan berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/Customer/1
        /// </remarks>
        /// <param name="customerId">ID unik pelanggan yang akan dihapus.</param>
        /// <returns>Pesan sukses jika data pelanggan berhasil dihapus, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpDelete("{customerId}")]
        public IActionResult Delete(int customerId)
        {
            if (customerId < 0)
            {
                return BadRequest();
            }

            bool deleteCustomer = _customerService.DeleteCustomer(customerId);
            if (!deleteCustomer)
            {
                return NotFound();
            }

            return Ok("Data customer berhasil dihapus.");
        }
    }

}
