using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace longEx;
    class InvalidLine : Exception
    {
        public InvalidLine(string message) : base(message) { }
    }
    class InvalidPriority : Exception
    {
        public InvalidPriority(string message) : base(message) { }
    }


