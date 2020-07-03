﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SXLZ.OnLineEdu.Utilies
{
    public class ReflectorHelper
    {
        /// <summary>  
        /// 获取程序集中的实现类对应的多个接口
        /// </summary>  
        /// <param name="assemblyName">程序集</param>
        public static Dictionary<Type, Type[]> GetClassName(string assemblyName)
        {
            if (!String.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> ts = assembly.GetTypes().ToList();
                var result = new Dictionary<Type, Type[]>();
                foreach (var item in ts.Where(s => !s.IsInterface))
                {
                    if (!string.IsNullOrEmpty(item.Namespace) && item.Namespace.Contains(assemblyName)) //强制转换
                    {
                        var interfaceType = item.GetInterfaces();
                        result.Add(item, interfaceType);
                    }
                }
                return result;
            }
            return new Dictionary<Type, Type[]>();
        }
    }
}
