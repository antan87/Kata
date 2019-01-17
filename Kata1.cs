using System;
using NUnit.Framework;

namespace kata {

    //  Information
    //  The description is rather long but you are given all needed formulas (almost:-)

    // John has bought a bike but before going moutain biking he wants us to do a few simulations.

    // He gathered information:

    // His trip will consist of an ascent of dTot kilometers with an average slope of slope percent
    // We suppose that: there is no wind, John's mass is constant MASS = 80 (kg), his power (generated at time t by pedaling and measured in watts) at the start of the trip is WATTS0 = 225 (watts)
    // We don't take account of the rolling resistance
    // When he starts climbing at t = 0 his initial speed (pushed start) is v0 (km/h)
    // His initial acceleration gamma is 0. gamma is in km/h/min at time t. It is the number of kilometers per hour he gains or loses in the next minute.
    // Our time step is DELTA_T = 1.0 / 60.0 (in minutes)
    // Furthermore (constants in uppercase are given below):

    // Because of tiredness, he loses D_WATTS * DELTA_T of power at each DELTA_T.
    // calcul of acceleration:

    // Acceleration has three components:

    // 1) on an ascent where the slope is slope the effect of earth gravity is given by:

    // - GRAVITY_ACC * function(slope)

    // (Beware: here the slopeis a percentage, it is not an angle. You have to determine function(slope)).

    // Some help for function(slope):

    // a) slope:

    // https://en.wikipedia.org/wiki/Grade_(slope)

    // b) earth gravity:

    // https://www.bbc.co.uk/education/guides/zgbggk7/revision/7

    // 2) air drag is

    // - DRAG * abs(v) * abs(v) / MASS where v is his current speed

    // 3) if his power and his speed are both strictly positive we add the thrust (by pedaling) which is:

    // + G_THRUST * watts / (v * MASS) where watts is his current power

    // 4) if his total acceleration is <= 1e-5 we set acceleration to 0

    // If v - 3.0 <= 1e-2 John gives up
    public class Kata1 {
        private double MASS = 80.0; // biker's mass
        private double GRAVITY_ACC = 9.81 * 3.6 * 60.0; // gravity acceleration
        private double DRAG = 60.0 * 0.3 / 3.6; // force applied by air on the cyclist
        private double DELTA_T = 1.0 / 60.0; // in minutes
        private double G_THRUST = 60 * 3.6 * 3.6; // pedaling thrust
        private double WATTS0 = 225.0; // initial biker's power
        private double D_WATTS = 0.5;

        // 1. Ascent = Kilometers & Slope 
        // 2. Start Watts 225 increases by time.  
        // 3. Start Watts 225 increases by time.  

        // Func<double, double, double, double> temps;

        // 1 / 12 = 8,3%
        // watts at time t + DELTA_T is watts at time t minus D_WATTS * DELTA_T
        public static Func<double, double, double, double> CalculateAirDrag => (x, y, k) => x * Math.Abs (y) * Math.Abs (y) / k;
        public static Func<double, double, double, double, double> CalculateThrust => (x, y, k, l) => x * y / (k * l);
        public static Func<double, double, double> CalculateSlopeDegree => (x, y) => Math.Atan ((double) (x * y / 100) / y) * 180 / Math.PI;
        public static Func<double, double> CalculateSlopeDegree2 => (x) => (x / 100) * 360;
        public static Func<double, double, double> CalculateGravityPull => (x, y) => x * y;

        public int temps (double v0, double slope, double dTot) {

            double slopeDegree = CalculateSlopeDegree2 (slope);
            double gravityPull = CalculateGravityPull (GRAVITY_ACC, slopeDegree);

            double velocity = v0;
            double gamma = 0; //  His initial acceleration gamma is 0. gamma is in km/h/min at time t. It is the number of kilometers per hour he gains or loses in the next minute.
            double d = 0;
            double watts = 0;
            for (int t = 0; t < 100; t++) {
                watts = (t + DELTA_T) - (D_WATTS * DELTA_T);
            }

            return 0;
        }

    }

    [TestFixture]
    class Tests {

        [TestCase (5, 20, 2.86)]
        [TestCase (2.08, 48, 1.19)]
        public void CalculateSlopeDegree (double x, double y, double result) {
            Assert.AreEqual (result, Math.Round (Kata1.CalculateSlopeDegree (x, y), 2));
        }

        [TestCase (20, 72)]
        [TestCase (50, 180)]
        public void CalculateSlopeDegree2 (double x, double result) {
            Assert.AreEqual (result, Math.Round (Kata1.CalculateSlopeDegree2 (x), 2));
        }

    }
}