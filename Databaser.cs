﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BandDatabaser
{
    public static class Databaser
    {
        //used for debug purposes for now, later will act as the link class between database and UI
        public static void test()
        {
            Database.DatabaseOperations datOp = new Database.DatabaseOperations();
            Trace.WriteLine(datOp.AddBand("Alestorm"));
        }
    }
}
