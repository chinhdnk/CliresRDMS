﻿using Infrastructure.Models.CliresSystem;
using System.Collections.Generic;

namespace ApplicationCore.Repositories.CliresSystem
{
    public interface IMenuRepository
    {
        List<MainMenu> GetMenuList(string userName);
    }
}