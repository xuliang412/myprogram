using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeAndReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomizeORM customizeORM = new CustomizeORM();
            User user = new User() { UserID = 1, UserName = "Wilber", Age = 28 };
            customizeORM.Insert(user);

            Console.Read();

        }
    }
}
