using System;
using System.Collections.Generic;
using System.Text;

namespace _201___Problema_do_diamante.entities {
    class Scanner : Device, IScanner {

        public override void ProcessDoc(string doc) {
            Console.WriteLine($"{GetType().Name}---->{doc}");
        }

        public string Scan() {
            return $"{GetType().Name}---->scanning";
        }
    }
}
