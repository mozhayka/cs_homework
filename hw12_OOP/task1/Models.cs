using System;

namespace task1
{
    class ModelA : Car
    {
        public new Gearbox gear = Gearbox.auto;
        private bool modification;

        public ModelA(int bodyNum, int motorPower, bool cyl, int stereo, bool mod)
            : base(bodyNum, motorPower, cyl, Gearbox.auto, stereo)
        {
            modification = mod;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Car ModelA, number {BodyNum}, {(modification ? "modified" : "w/o modification")}");
        }
    }

    class ModelB : Car
    {
        public new Gearbox gear = Gearbox.manual;

        public ModelB(int bodyNum, int stereo)
            : base(bodyNum, 100, true, Gearbox.auto, stereo)
        {

        }

        public override void PrintInfo()
        {
            Console.WriteLine($"ModelB has number {BodyNum}, stereo {stereoSistem}");
        }
    }
}
