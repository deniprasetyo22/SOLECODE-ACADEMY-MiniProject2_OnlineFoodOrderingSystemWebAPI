using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces
{
    public interface IMenuService
    {
        void AddMenu(Menu menu);
        IEnumerable<Menu> GetAllMenu();
        Menu GetMenuById(int id);
        bool UpdateMenu(int id, Menu editMenu);
        bool DeleteMenu(int id);
        bool AddRating(int id, int rating);
    }
}
