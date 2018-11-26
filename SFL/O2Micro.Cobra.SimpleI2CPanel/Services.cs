﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows;
using O2Micro.Cobra.Common;


namespace O2Micro.Cobra.SimpleI2CPanel
{
    [Export(typeof(IServices))]
    public class Services : IServices
    {
        public UIElement Insert(object pParent, string name)
        {
            return new MainControl(pParent, name);
        }
    }
}