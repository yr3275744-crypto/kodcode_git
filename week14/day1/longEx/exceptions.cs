using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace longEx;
    class InvalidArgomentsNumber : ArgumentException
    {
        public InvalidArgomentsNumber(string message) : base(message) { }
    }
    class InvalidPriority : Exception
    {
        public InvalidPriority(string message) : base(message) { }
    }


