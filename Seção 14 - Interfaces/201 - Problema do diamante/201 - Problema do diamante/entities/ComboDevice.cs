using System;
using System.Collections.Generic;
using System.Text;

namespace _201___Problema_do_diamante.entities {
    class ComboDevice: Device, IScanner, IPrinter {

        public void Print(string doc) {
            Console.WriteLine($"{GetType().Name}--->" + doc);
        }

        public override void ProcessDoc(string doc) {
            Console.WriteLine($"{GetType().Name}--->" + doc);
        }

        public string Scan() {
            return $"{GetType().Name}--->scanning";
        }
    }
}
