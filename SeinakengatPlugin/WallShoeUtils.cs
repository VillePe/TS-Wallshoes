using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Model;

namespace Seinakengat {
    public static class WallShoeUtils {


        public static double[] GetComponentVariables(Component c) {
            double[] d = new double[5] {
                0,0,0,0,135
                // 0 = Distance from startpoint to behind of vertical backplate
                // 1 = Height of the base plate
                // 2 = Height of the vertical backplate
                // 3 = Angle of the top plate
                // 4 = Distance between the vertical sideplates measured from the outer faces
            };
            switch (c.Name) {
                case "EB_ASL16":
                    d[0] = 42.0;
                    d[1] = 30.0;
                    d[2] = 101.58;
                    d[3] = 13.3047;
                    d[4] = 109.0;
                    break;
                case "EB_ASL20":
                    d[0] = 42.0;
                    d[1] = 30.0;
                    d[2] = 101.58;
                    d[3] = 13.3047;
                    d[4] = 109.0;
                    break;
                case "EB_ASL24":
                    d[0] = 47.0;
                    d[1] = 35.0;
                    d[2] = 116.64;
                    d[3] = 11.31;
                    d[4] = 119.0;
                    break;
                case "EB_ASL30":
                    d[0] = 52.0;
                    d[1] = 40.0;
                    d[2] = 121.68;
                    d[3] = 9.91;
                    d[4] = 135.0;
                    break;
                case "EB_ASL36":
                    d[0] = 67.0;
                    d[1] = 55.0;
                    d[2] = 141.73;
                    d[3] = 8.17;
                    d[4] = 139.0;
                    break;
                case "EB_ASL39":
                    d[0] = 67.0;
                    d[1] = 60.0;
                    d[2] = 151.74;
                    d[3] = 7.85;
                    d[4] = 159.0;
                    break;
                case "EB_ASL45":
                    d[0] = 72.0;
                    d[1] = 70.0;
                    d[2] = 161.77;
                    d[3] = 7.13;
                    d[4] = 174.0;
                    break;
                case "EB_ASL52":
                    d[0] = 87.0;
                    d[1] = 80.0;
                    d[2] = 181.80;
                    d[3] = 6.17;
                    d[4] = 224.5;
                    break;
            }
            return d;
        }
    }
}
