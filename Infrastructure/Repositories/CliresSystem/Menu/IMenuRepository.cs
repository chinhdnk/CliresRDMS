using Infrastructure.Models.MenuPage;
using System.Collections.Generic;

namespace Infrastructure.Repositories.CiresSystem
{
    public interface IMenuRepository
    {
        List<MainMenu> GetMenuList(string userName);
    }
}