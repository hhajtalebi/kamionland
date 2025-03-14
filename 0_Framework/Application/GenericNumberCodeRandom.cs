﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAMI.CommanLayer.PublicClass
{
    public class GenericNumberCodeRandom
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            //const string chars = "0123456789AbghtT";
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
