﻿using HeBianGu.Base.WpfBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WpfMvc
{
    internal static class MvcService
    {
        /// <summary> 自动注入标识 RegisterMvcAttribute 特性的ViewModel项 </summary>
        public static void UseMvc(this ServiceRegistry registry)
        {
            registry.UseAttribute<RouteAttribute>();

            registry.UseAttribute<ViewModelAttribute>();

            //ServiceRegistry.Instance.Register<TClass>(false);
        }

        
        /// <summary> 注入含有指定特性的项 </summary>
        public static void UseAttribute<TAttribute>(this ServiceRegistry registry) where TAttribute:Attribute
        {
            string name = Assembly.GetEntryAssembly().FullName;

            var types = Assembly.GetEntryAssembly().GetTypes();

            foreach (var item in types)
            {
                var attribute = item.GetCustomAttribute<TAttribute>();

                if (attribute == null) continue;

                MethodInfo mi = typeof(MvcService).GetMethod("RegisterMvc").MakeGenericMethod(item);

                mi.Invoke(null, new object[] { });
            } 
        }

        public static void RegisterMvc<TClass>() where TClass : class
        {
            ServiceRegistry.Instance.Register<TClass>();
        }
    }
}
