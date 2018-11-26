﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace O2Micro.Cobra.SBS2Panel
{
    /// <summary>
    /// Interaction logic for BatteryProgressControl.xaml
    /// </summary>
    public partial class BatteryProgressControl : UserControl
    {
        private ObservableCollection<SFLModel> battery_parameterlist = new ObservableCollection<SFLModel>();
        public BatteryProgressControl()
        {
            InitializeComponent();
        }
        
        public void SetDataSource(ObservableCollection<SFLModel> parameterlist)
        {
            battery_parameterlist = parameterlist;
        }

        [Description("Battery Charger ON/OFF")]
        [Category("Simon Properties")]
        public bool IsOnCharge
        {
            get
            {
                if(Polygon_Charge.Visibility == Visibility.Visible)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                {
                    Polygon_Charge.Visibility = Visibility.Visible; 
                }
                else
                {
                    Polygon_Charge.Visibility = Visibility.Hidden;
                }
            }
        }

        [Description("Battery Charger Percent")]
        [Category("Simon Progress Properties")]
        public double ChargingProgress
        {
            get
            {
                return ChargingProgress;
            }
            set
            {
                if ((value <= 75)&&(value >= 0))
                {
                    GS_0.Color = Color.FromArgb(192, 255, Convert.ToByte((255 - 225) * (value / 75) + 225), 225);
                    GS_1.Color = Color.FromArgb(192, 255, Convert.ToByte((255 - 96) * (value / 75) + 96), 96);
                    GS_2.Color = Color.FromArgb(192, 192, Convert.ToByte((192 - 0) * (value / 75) + 0), 0);
                    GS_3.Color = Color.FromArgb(192, 128, Convert.ToByte((128 - 0) * (value / 75) + 0), 0);
                }
                else if ((value <= 100)&&(value > 75))
                {
                    GS_0.Color = Color.FromArgb(192, Convert.ToByte(225 + (255 - 225) * ((100 - value) / 25)), 255, 225);
                    GS_1.Color = Color.FromArgb(192, Convert.ToByte(96 + (255 - 96) * ((100 - value) / 25)), 255, 96);
                    GS_2.Color = Color.FromArgb(192, Convert.ToByte(0 + (192 - 0) * ((100 - value) / 25)), 192, 0);
                    GS_3.Color = Color.FromArgb(192, Convert.ToByte(0 + (128 - 0) * ((100 - value) / 25)), 128, 0);
                }
                TextBlockProgress.Text = Convert.ToString(Convert.ToInt16(Math.Floor(value))) + "%";
                BatteryProgressBar.Value = value;
            }
        }

        public void update()
        {
            SFLModel model = null;
            if (battery_parameterlist.Count == 0) return;

            model = battery_parameterlist[0];
            if (model != null) ChargingProgress = model.data;
        }
    }
}