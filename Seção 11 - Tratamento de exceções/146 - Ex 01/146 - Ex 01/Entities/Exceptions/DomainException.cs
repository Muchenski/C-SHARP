using System;
using System.Collections.Generic;
using System.Text;

namespace _146___Ex_01.Entities.Exceptions {
    class DomainException:ApplicationException {

        public DomainException(string msg) : base(msg) {
        }
    }
}
