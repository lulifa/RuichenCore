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
        /// <summary>
        /// 路由组件注册名称，唯一标识
        /// </summary>
        public string Router { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 路由path，可缺省，默认取路由注册名称 registerName 的值
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 路由的菜单icon，会注入到路由元数据meta中
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 路由重定向
        /// </summary>
        public string Redirect { get; set; }
        /// <summary>
        /// 是否隐藏菜单项，true 隐藏，false 不隐藏，会注入到路由元数据meta中
        /// </summary>
        public bool Invisible { get; set; }
        /// <summary>
        /// 路由权限配置，会注入到路由元数据meta中。可缺省，默认为 ‘*’, 即无权限限制
        /// </summary>
        public MenuAuthority Authority { get; set; }
        /// <summary>
        /// 路由的页面数据，会注入到路由元数据meta中
        /// </summary>
        public MenuPage Page { get; set; }
       
        public List<Menu> Children { get; set; } = new List<Menu>();
    }
    public class MenuAuthority
    {
        /// <summary>
        /// 路由需要的权限  
        /// </summary>
        public string Permission { get; set; }
        /// <summary>
        /// 路由需要的角色。当permission未设置，通过 role 检查权限
        /// </summary>
        public string Role { get; set; }
    }
    public class MenuPage
    {
        /// <summary>
        /// 页面标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 页面面包屑
        /// </summary>
        public List<string> Breadcrumb { get; set; }
    }
}
