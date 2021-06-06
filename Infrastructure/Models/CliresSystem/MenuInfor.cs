using System;
using System.Collections.Generic;
using Infrastructure.Entities.CliresSystem;

namespace Infrastructure.Models.CliresSystem
{
    public class MenuItem
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int Sort { get; set; }
        public bool Status { get; set; }
        public string Icon { get; set; }
    }
    public class MainMenu: MenuItem
    {
        public IEnumerable<MenuItem> subMenus { get; set; }
    }
}
