﻿using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Work___1
{
    class Program
    {          
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);            
        }
    }
    public class BechmarkClass
    {
        public class PointClass
        {
            public int X;
            public int Y;
        }

        public struct PointStruct
        {
            public int X;
            public int Y;
        }
        public static float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointDistanceStructDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            float Dist = (float)((x * x) + (y * y));
            return MathF.Sqrt(Dist);
        }
        public static float PointDistanceStructWithoutSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void PointDistanceClass1()
        {
            PointClass PointClass1 = new PointClass();
            PointClass1.X = 10;
            PointClass1.Y = 20;
            PointClass PointClass2 = new PointClass();
            PointClass2.X = 45;
            PointClass2.Y = 65;
            PointDistanceClass(PointClass1, PointClass2);
        }

        [Benchmark]
        public void PointDistanceStruct1()
        {
            PointStruct PointStruct1 = new PointStruct();
            PointStruct1.X = 20;
            PointStruct1.Y = 30;
            PointStruct PointStruct2 = new PointStruct();
            PointStruct2.X = 25;
            PointStruct2.Y = 60;
            PointDistanceStruct(PointStruct1, PointStruct2);
        }
        [Benchmark]
        public void PointDistanceStructDouble1()
        {
            PointStruct PointStruct1 = new PointStruct();
            PointStruct1.X = 20;
            PointStruct1.Y = 30;
            PointStruct PointStruct2 = new PointStruct();
            PointStruct2.X = 25;
            PointStruct2.Y = 60;
            PointDistanceStructDouble(PointStruct1, PointStruct2);
        }
        [Benchmark]
        public void PointDistanceStructWithoutSqrt1()
        {
            PointStruct PointStruct1 = new PointStruct();
            PointStruct1.X = 20;
            PointStruct1.Y = 30;
            PointStruct PointStruct2 = new PointStruct();
            PointStruct2.X = 25;
            PointStruct2.Y = 60;
            PointDistanceStructWithoutSqrt(PointStruct1, PointStruct2);
        }
    }
}
