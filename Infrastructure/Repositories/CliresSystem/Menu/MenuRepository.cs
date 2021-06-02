using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.MenuPage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories.CiresSystem
{
    public class MenuRepository : IMenuRepository
    {
        private readonly CliresSystemDBContext dbContext;
        public MenuRepository(CliresSystemDBContext context)
        {
            this.dbContext = context;
        }

        public List<MainMenu>GetMenuList(string userName)
        {
            IEnumerable<TblMenu> menuItems = (from ug in dbContext.TblUserGroups
                                              join gp in dbContext.TblGroupPermissions on ug.GroupId equals gp.GroupId
                                              join p in dbContext.TblPermissions on gp.PermId equals p.PermId
                                              join mn in dbContext.TblMenus on p.Menu equals mn.MenuId
                                              where ug.Username == userName
                                              select mn);
            List<MainMenu> mainMenus = getMainMenus(menuItems.Select(i => i.ParentId));
            foreach (MainMenu item in mainMenus)
            {
                item.subMenus = getMenuItems(item.MenuId, menuItems);
            }
            return mainMenus;
        }

        private List<MainMenu> getMainMenus(IEnumerable<int> menuIDs)
        {
            List<MainMenu> items = (from item in dbContext.TblMenus
                                           where menuIDs.Contains(item.MenuId)
                                           select new MainMenu
                                           {
                                               MenuId = item.MenuId,
                                               Title = item.Title,
                                               Link = item.Link,
                                               Sort = item.Sort,
                                               Status = item.Status,
                                               Icon = item.Icon
                                               
                                           }).ToList();
            return items;
        }

        private IEnumerable<MenuItem> getMenuItems(int menuID, IEnumerable<TblMenu> menuItems)
        {
            IEnumerable<MenuItem> items = (from item in menuItems
                                           where item.ParentId == menuID
                                           select new MenuItem
                                           {
                                               MenuId = item.MenuId,
                                               Title = item.Title,
                                               Link = item.Link,
                                               Sort = item.Sort,
                                               Status = item.Status,
                                               Icon = item.Icon
                                           });
            return items;
        }
    }
}
