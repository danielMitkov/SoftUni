﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer {
    public class Engine {
        int horsePower;
        double cubicCapacity;

        public Engine(int horsePower,double cubicCapacity) {
            HorsePower=horsePower;
            CubicCapacity=cubicCapacity;
        }

        public int HorsePower { get => horsePower; set => horsePower=value; }
        public double CubicCapacity { get => cubicCapacity; set => cubicCapacity=value; }
    }
}
