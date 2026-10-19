using System;
using System.Collections.Generic;
using System.Text;
using APC_Lib;
using APC_Lib.VecMat3D;

namespace LunaWin
{
    class LunaEphemerides
    {

        private const int Degree = 10;
        private const double Interval = 10.0/36525.0; // 10d in [cy]

        public Cheb3D ChebMoonEqu = new Cheb3D(new C3Dfunct(Moon.MoonEqu), Degree, Interval);

        private double ra;

        public double RA
        {
            get { return ra; }
        }
        private double dec;

        public double Dec
        {
            get { return dec; }
        }
        private double distance;

        public double Distance
        {
            get { return distance; }
        }
        private double parallax;

        public double Parallax
        {
            get { return parallax; }
        }
        DateTime date;


        private double MJDate;
        /// <summary>
        /// the date for the ephemerides. Updates all other values
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { Ephemerides(value); }
        }
        public void Ephemerides(DateTime date)
        {
            this.date = date;
            MJDate = APC_Lib.Physics.Mjd(date);
            double T = (MJDate - Physics.MJD_J2000) / 36525.0;
            Vec3D r_Moon = ChebMoonEqu.Value(T);
            // distance & Parallax
            distance = r_Moon[pol_index.r];
            parallax = Physics.Deg * Math.Asin(Physics.R_Earth / distance);
            ra = Physics.Deg * r_Moon[pol_index.phi] / 15.0;
            dec = Physics.Deg * r_Moon[pol_index.theta];
        }
    }
}
