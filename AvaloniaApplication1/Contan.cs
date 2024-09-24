using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1
{
    static class Contan
    {
       public static List<Clients> list = new List<Clients>()
       {
              new Clients()
            {
                Id = 1,
                Gender = 'ж',
                Name = "Дарья",
                Lastname = "Иост",
                PhoneNumber = "+7 (952) 456-24-34",
                Email = "Rhdu23@gmail.com",
                RegistrationDate = new System.DateOnly(2001, 12, 30)
            }
       };
    }
}
