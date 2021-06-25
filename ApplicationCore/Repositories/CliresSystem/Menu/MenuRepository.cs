using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.CliresSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Repositories.CliresSystem
{
    public class MenuRepository : IMenuRepository
    {
        private readonly CliresSystemDBContext dbContext;
        private readonly IPermissionRepository permissionRepository;
        public MenuRepository(CliresSystemDBContext context, IPermissionRepository permissionRepository)
        {
            this.dbContext = context;
            this.permissionRepository = permissionRepository;
        }

        public List<MainMenu> GetMenuList(string userName)
        {
            var listPerms = permissionRepository.GetPermOfUser(userName);

            IEnumerable<TblMenu> menuItems = (from m in dbContext.TblMenus 
                                              join p in dbContext.TblPermissions on m.MenuId equals p.Menu
                                              where listPerms.Contains(p.PermId)
                                              select m).Distinct();
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
