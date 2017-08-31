using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeView
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(double);
            AnalyzeType(t);
        }
        static void AnalyzeType(Type t)
        {
            Console.WriteLine("Type Name:" + t.Name);
            Console.WriteLine("Full Name:" + t.FullName);
            Console.WriteLine("Namespace:" + t.Namespace);

            Type tBase = t.BaseType;
            if (tBase != null)
            {
                Console.WriteLine("Base Type:" + tBase);
            }

            Type tUnderlyingSystem = t.UnderlyingSystemType;
            if(tUnderlyingSystem != null)
            {
                Console.WriteLine("UnderlyingSystem Type:" + tUnderlyingSystem.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Public Members");
            MemberInfo[] Members = t.GetMembers();
            foreach(MemberInfo nextMember in Members)
            {
                Console.WriteLine(nextMember.DeclaringType + " " + nextMember.MemberType + " " + nextMember.Name);
            }
        }

    }
}
