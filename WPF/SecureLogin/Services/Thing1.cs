﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureLogin.Services
{
    public class Thing1 : IThingService
    {
        static int counter = 0;

        public string DoTheThing()
        {
            counter++;

            return "Thing 1 Completed " + counter.ToString() + " time" + (counter > 1 ? "s" : "") + "!";
        }
    }
}
