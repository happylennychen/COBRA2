﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows;
using System.Reflection;
using O2Micro.Cobra.Common;

namespace O2Micro.Cobra.CCControlPanel
{
    [Export(typeof(IServices))]
    public class Services : IServices
    {
        public UIElement Insert(object pParent, string name)
        {
            return new MainControl(pParent, name);
        }

        public Version GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
