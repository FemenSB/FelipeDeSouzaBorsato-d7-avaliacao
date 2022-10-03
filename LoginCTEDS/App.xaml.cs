﻿using LoginCTEDS.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoginCTEDS
{
    public partial class App : Application
    {
        public App()
        {
            new DatabaseService().EnsureDatabaseIsCreated();
        }
    }
}
