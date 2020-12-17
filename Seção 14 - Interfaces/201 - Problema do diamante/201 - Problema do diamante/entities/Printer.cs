using System;
using System.Collections.Generic;
using System.Text;

namespace _201___Problema_do_diamante.entities {
    class Printer : Device, IPrinter {

        public override void ProcessDoc(string doc) {
            Console.WriteLine($"{GetType().Name}--->" + doc);
        }

        public void Print(string doc) {
            Console.WriteLine($"{GetType().Name}---->{doc}");
        }
    }
}
