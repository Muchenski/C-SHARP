using System;

namespace Board_ns.exceptions
{
    class BoardException:Exception
    {
        public BoardException(string msg) : base(msg)
        {

        }
    }
}
