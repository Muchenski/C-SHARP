using System;
using System.Collections.Generic;
using System.Text;

namespace _201___Problema_do_diamante.entities {
    abstract class Device {
        public string SerialNumber { get; set; }

        public abstract void Print(string doc);
        public abstract void ProcessDoc(string doc);
        public abstract string Scan();
    }
}
