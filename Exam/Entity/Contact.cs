using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entity
{
    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"Name:{Name} --- Phone:{Phone}");
        }
    }
}
