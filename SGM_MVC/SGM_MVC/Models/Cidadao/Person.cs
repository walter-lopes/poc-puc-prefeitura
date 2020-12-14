using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Cidadao
{
    public class Person
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public Property Property { get; set; }
        public Contact Contact { get; set; }

    }
}
