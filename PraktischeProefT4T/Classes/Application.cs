﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
   public class Application : IApplication
    {
        IPlanner planner;
        public Application(IPlanner initPlanner)
        {
            planner = initPlanner;
        }
         public void Run()
        {
           
        }
    }
}
