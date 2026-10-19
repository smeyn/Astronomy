using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LunaWin
{
    public partial class MainForm : Form
    {

        private TimeSpan Interval;
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// format a degree (DEG style) for printing
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string degrees(double value)
        {
            int degs = (int)value;
            value = Math.Abs(value - degs)* 60.0;
            int mins = (int)value;
            double seconds = (value - mins) * 60.0;

            return string.Format("{0} {1}' {2}\"", degs.ToString("##"), mins.ToString("0#"), seconds.ToString("#0.00"));
        }
        private void btnGo_Click(object sender, EventArgs e)
        {

            Interval = TimeSpan.FromDays((double)(nudDays.Value) + (double)(nudHours.Value) / 24.0);
            lbl1.Text = Interval.ToString();

            DateTime current = dtpFirstDate.Value;
            LunaEphemerides leph = new LunaEphemerides();
            lvEphemerides.Items.Clear();

            while (current <= dtpFinalDate.Value)
            {
                leph.Date = current;
                ListViewItem item = lvEphemerides.Items.Add(current.ToShortDateString());
                item.SubItems.Add(current.ToShortTimeString());
                item.SubItems.Add (degrees(leph.RA));
                item.SubItems.Add (degrees(leph.Dec));
                double EarthRadii = leph.Distance / APC_Lib.Physics.R_Earth;
                item.SubItems.Add(EarthRadii.ToString("f03"));
                item.SubItems.Add (degrees(leph.Parallax));
                current = current + Interval;
            }
        }

     
    }
}