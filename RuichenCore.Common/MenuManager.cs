using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.Common
{
    public static class MenuManager
    {
        public static List<Menu> GetMenus()
        {
            List<Menu> menus = SectionManager.GetSection<List<Menu>>("Ruichen", "Menu");
            return menus;
        }
    }

    public class Menu
    {
        public string Router { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        public string Authority { get; set; }
        public string Redirect { get; set; }
        public List<Menu> Children { get; set; } = new List<Menu>();
    }
}
