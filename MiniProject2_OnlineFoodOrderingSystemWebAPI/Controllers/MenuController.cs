using Microsoft.AspNetCore.Mvc;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Controllers
{
    /// <summary>
    /// Controller untuk mengelola data menu.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private static IMenuService _menuService;

        /// <summary>
        /// Konstruktor untuk MenuController.
        /// </summary>
        /// <param name="menuService">menuService yang diinjeksikan.</param>
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// Menambahkan menu baru.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/Menu
        ///     {
        ///         "Name": "Bakso",
        ///         "Category": "Food",
        ///         "Price": 25000
        ///     }
        /// </remarks>
        /// <param name="menu">Objek Menu yang akan ditambahkan.</param>
        /// <returns>Pesan sukses jika menu berhasil ditambahkan.</returns>
        [HttpPost]
        public IActionResult AddMenu([FromBody] Menu menu)
        {
            _menuService.AddMenu(menu);
            return Ok("Menu berhasil ditambah.");
        }

        /// <summary>
        /// Mengambil daftar semua menu.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Menu
        /// </remarks>
        /// <returns>Daftar semua menu.</returns>
        [HttpGet]
        public IActionResult GetAllMenu()
        {
            var menuList = _menuService.GetAllMenu();
            return Ok(menuList);
        }

        /// <summary>
        /// Mengambil data menu berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Menu/1
        /// </remarks>
        /// <param name="id">ID dari menu yang akan didapatkan.</param>
        /// <returns>Objek Menu jika ditemukan, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpGet("{id}")]
        public IActionResult GetMenuById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var menu = _menuService.GetMenuById(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        /// <summary>
        /// Memperbarui data menu berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/Menu/1
        ///     {
        ///         "Name": "Bakso",
        ///         "Category": "Food",
        ///         "Price": 30000
        ///     }
        /// </remarks>
        /// <param name="id">ID dari menu yang akan diupdate.</param>
        /// <param name="editMenu">Objek Menu dengan data terbaru.</param>
        /// <returns>Pesan sukses jika data menu berhasil diupdate, jika tidak mengembalikan NotFound atau BadReqeuest.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateMenu(int id, [FromBody] Menu editMenu)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            bool updateMenu = _menuService.UpdateMenu(id, editMenu);
            if (!updateMenu)
            {
                return NotFound();
            }

            return Ok("Menu berhasil diupdate.");
        }

        /// <summary>
        /// Menghapus data menu berdasarkan ID.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     DELETE /api/Menu/1
        /// </remarks>
        /// <param name="id">ID dari menu yang akan dihapus.</param>
        /// <returns>Pesan sukses jika data menu berhasil dihapus, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            bool deleteMenu = _menuService.DeleteMenu(id);
            if (!deleteMenu)
            {
                return NotFound();
            }

            return Ok("Menu Berhasil dihapus.");
        }

        /// <summary>
        /// Menambahkan rating untuk menu tertentu.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/Menu/1/rating
        ///     {
        ///         4
        ///     }
        /// </remarks>
        /// <param name="id">ID dari menu yang akan diberi rating.</param>
        /// <param name="rating">Nilai rating antara 1 sampai 5.</param>
        /// <returns>Pesan sukses jika rating berhasil ditambahkan, jika tidak mengembalikan NotFound atau BadRequest.</returns>
        [HttpPost("{id}/rating")]
        public IActionResult AddRating(int id, [FromBody] int rating)
        {
            if (id < 0 || rating < 1 || rating > 5)
            {
                return BadRequest();
            }

            bool result = _menuService.AddRating(id, rating);
            if (!result)
            {
                return NotFound();
            }

            return Ok("Rating berhasil ditambahkan.");
        }
    }


}
