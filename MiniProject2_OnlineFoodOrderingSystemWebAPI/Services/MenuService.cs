using MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Services
{
    public class MenuService : IMenuService
    {
        private static List<Menu> _menuList = new List<Menu>();

        public void AddMenu(Menu menu)
        {
            menu.Id = _menuList.Count + 1;
            menu.CreatedDate = DateTime.Now;
            _menuList.Add(menu);
        }

        public IEnumerable<Menu> GetAllMenu()
        {
            return _menuList;
        }

        public Menu GetMenuById(int id)
        {
            return _menuList.Find(cek => cek.Id == id);
        }

        public bool UpdateMenu(int id, Menu editMenu)
        {
            var existingMenu = _menuList.Find(cek => cek.Id == id);
            if (existingMenu == null)
            {
                return false;
            }
            existingMenu.Name = editMenu.Name;
            existingMenu.Price = editMenu.Price;
            existingMenu.Category = editMenu.Category;
            existingMenu.IsAvailable = editMenu.IsAvailable;
            return true;
        }

        public bool DeleteMenu(int id)
        {
            var deleteMenu = _menuList.Find(cek=> cek.Id == id);
            if (deleteMenu == null)
            {
                return false ;
            }
            _menuList.Remove(deleteMenu);
            return true;
        }

        public bool AddRating(int id, int rating)
        {
            var menu = _menuList.Find(cek => cek.Id == id);
            if (menu == null)
            {
                return false;
            }
            if (rating < 1 || rating > 5)
            {
                return false;
            }
            menu.AddRating(rating);
            return true;
        }
    }

}
