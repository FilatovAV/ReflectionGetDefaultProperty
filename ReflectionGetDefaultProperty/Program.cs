using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflectionGetDefaultProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача:
            //Найти все стандартные контролы, которые может использовать разработчик WinForms, 
            //отсортировать по названию и найти для каждого DefaultProperty.

            Assembly WFControl = Assembly.GetAssembly(typeof(Control));
            foreach (var item in WFControl.GetTypes().OrderBy(x => x.Name))
            {
                if (item.IsSubclassOf(typeof(Control)) && item.IsAbstract == false && item.IsPublic == true)
                {
                    AttributeCollection attributes = TypeDescriptor.GetAttributes(item);

                    DefaultPropertyAttribute myAttribute =
                        (DefaultPropertyAttribute)attributes[typeof(DefaultPropertyAttribute)];
                    Console.WriteLine($"Control: {item.Name}, the default property is: {myAttribute.Name}");
                }
            }
        }
    }
}
