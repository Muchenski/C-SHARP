using System;
using System.Collections.Generic;
using System.Text;

namespace _143___Criando_exceções_personalizadas.Entities.Exceptions {
    class DomainException:ApplicationException {
        public DomainException(string message) : base(message) {
        }
    }
}
