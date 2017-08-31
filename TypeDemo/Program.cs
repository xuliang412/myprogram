using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeDemo
{
    /// <summary>
    /// 演示Type的属性
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Type intType = typeof(int);
            Console.WriteLine(intType.Name);//数据类型名
            Console.WriteLine(intType.FullName);//数据类型的完全限定名
            Console.WriteLine(intType.Namespace);//数据类型的名称空间名
            Console.WriteLine(intType.BaseType);//基本类型
            Console.WriteLine(intType.IsAbstract);//是否为抽象
            Console.WriteLine(intType.IsClass);//是否为类
            Console.WriteLine(intType.IsEnum);//是否为枚举
            Console.WriteLine(intType.IsPrimitive);//是否为基元类型之一
            Console.WriteLine(intType.IsValueType);//是否为值类型
            Console.WriteLine(intType.IsPointer);//是否为指针
            Assembly assembly = intType.Assembly;
            Type[] t = assembly.GetTypes();
            foreach (Type definedType in t)
            {
                Console.WriteLine(definedType.Name);
            }
        }
    }
}
