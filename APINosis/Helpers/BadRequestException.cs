﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINosis.Helpers
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {

        }

        public BadRequestException(string message) : base(message)
        {
        }

    }
}
