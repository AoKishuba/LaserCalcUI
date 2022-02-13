using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace LaserCalcUI
{
    public struct LaserConfiguration
    {
        public int[] ComponentCounts;
        public int DoublerCount;
        public bool UsesQSwitch;
    }

    public enum TestType : int
    {
        DpsPerVolume,
        DpsPerCost
    }
    class LaserComparer
    {
        /// <summary>
        /// Generates and compares all possible laser configurations
        /// </summary>
        /// <param name="maxStackLength">Max number of laser components</param>
        /// <param name="stackCount">Number of parallel cavity stacks</param>
        /// <param name="inlineDoublers">Whether doublers will be mounted inline with stacks</param>
        /// <param name="combinerCount">Number of combiners and LAMS nodes</param>
        /// <param name="minRechargeTime">Minimum recharge time in seconds</param>
        /// <param name="maxRechargeTime">Maximum recharge time in seconds</param>
        /// <param name="targetAC">Target base AC</param>
        /// <param name="ringACBonus">AC bonus from ring shields</param>
        /// <param name="smokeStrength">Smoke strength, in smoke units (25 000 per max-strength dispenser)</param>
        /// <param name="planarShieldStrength">Smoke strength equivalent of planar shields</param>
        /// <param name="enginePpm">Engine Power Per Material</param>
        /// <param name="enginePpv">Engine Power Per Volume</param>
        /// <param name="enginePpc">Engine Power Per Cost (block cost of engine)</param>
        /// <param name="requiresFuelAccess">Whether fuel access blocks are required (for Fuel Engines or CJE)</param>
        /// <param name="storagePerCost">Quantity of material stored per cost of storage</param>
        /// <param name="storagePerVolume">Quantity of material stored per volume of storage</param>
        /// <param name="variableToCompare">Whether to test for DPS per Volume or DPS per Cost</param>
        /// <param name="testInterval">Test interval in minutes</param>
        public LaserComparer(
            int maxStackLength,
            int stackCount,
            bool inlineDoublers,
            int combinerCount,
            int minRechargeTime,
            int maxRechargeTime,
            float targetAC,
            float ringACBonus,
            int smokeStrength,
            int planarShieldStrength,
            float enginePpm,
            float enginePpv,
            float enginePpc,
            bool requiresFuelAccess,
            float storagePerCost,
            float storagePerVolume,
            TestType variableToCompare,
            int testInterval
            )
        {
            MaxStackLength = maxStackLength;
            StackCount = stackCount;
            InlineDoublers = inlineDoublers;
            CombinerCount = combinerCount;
            MinRechargeTime = minRechargeTime;
            MaxRechargeTime = maxRechargeTime;
            TargetAC = targetAC;
            RingACBonus = ringACBonus;
            EffectiveAC = TargetAC + RingACBonus;
            SmokeStrength = smokeStrength;
            PlanarShieldStrength = planarShieldStrength;
            SmokeAPMultiplier = MathF.Min(1, 3f / MathF.Pow(SmokeStrength + PlanarShieldStrength, (float)1 / 3));
            EnginePpm = enginePpm;
            EnginePpv = enginePpv;
            EnginePpc = enginePpc;
            RequiresFuelAccess = requiresFuelAccess;
            StoragePerCost = storagePerCost;
            StoragePerVolume = storagePerVolume;
            VariableToCompare = variableToCompare;
            TestInterval = testInterval;
        }

        int MaxStackLength { get; }
        int StackCount { get; }
        bool InlineDoublers { get; }
        int CombinerCount { get; }
        int MinRechargeTime { get; }
        int MaxRechargeTime { get; }
        float TargetAC { get; }
        float RingACBonus { get; }
        float EffectiveAC { get; }
        int SmokeStrength { get; }
        int PlanarShieldStrength { get; }
        float SmokeAPMultiplier { get; }
        float EnginePpm { get; }
        float EnginePpv { get; }
        float EnginePpc { get; }
        bool RequiresFuelAccess { get; }
        float StoragePerCost { get; }
        float StoragePerVolume { get; }
        TestType VariableToCompare { get; }
        int TestInterval { get; }

        static int[] TopLaserDefaultComponents = new int[] { 0 };
        Laser TopLaser = new(
            TopLaserDefaultComponents, 0, false, 0, 0, false, 0, 0, 0, 0, 0, false, 0, 0, 0);
        ConcurrentBag<Laser> LaserBag = new();

        /// <summary>
        /// Iterable generator for laser configurations. Generates all possible combinations of components at all possible AP values
        /// for both Q and non-Q lasers
        /// </summary>
        /// <returns></returns>
        IEnumerable<LaserConfiguration> GenerateLaserConfigurations()
        {
            int totalCount;
            bool[] boolArr = new[] { true, false };

            for (int comp0Count = 0; comp0Count <= MaxStackLength; comp0Count++)
            {
                totalCount = comp0Count;

                for (int comp1Count = 0; comp1Count <= MaxStackLength - totalCount; comp1Count++)
                {
                    totalCount = comp0Count + comp1Count;

                    for (int comp2Count = 0; comp2Count <= MaxStackLength - totalCount; comp2Count++)
                    {
                        totalCount = comp0Count + comp1Count + comp2Count;

                        for (int comp3Count = 0; comp3Count <= MaxStackLength - totalCount; comp3Count++)
                        {
                            totalCount = comp0Count + comp1Count + comp2Count + comp3Count;

                            for (int comp4Count = 0; comp4Count <= MaxStackLength - totalCount; comp4Count++)
                            {
                                totalCount = comp0Count + comp1Count + comp2Count + comp3Count + comp4Count;

                                for (int comp5Count = 0; comp5Count <= MaxStackLength - totalCount; comp5Count++)
                                {
                                    int maxDoublerCount;
                                    maxDoublerCount = InlineDoublers
                                        ? MaxStackLength - comp0Count - comp1Count - comp2Count - comp3Count - comp4Count - comp5Count
                                        : MaxStackLength;

                                    for (int doublerCount = 0; doublerCount <= maxDoublerCount; doublerCount++)
                                    {
                                        foreach (bool qSwitch in boolArr)
                                        {
                                            int[] componentCounts = new[]
                                            {
                                                comp0Count,
                                                comp1Count,
                                                comp2Count,
                                                comp3Count,
                                                comp4Count,
                                                comp5Count
                                            };

                                            yield return new LaserConfiguration
                                            {
                                                ComponentCounts = componentCounts,
                                                DoublerCount = doublerCount,
                                                UsesQSwitch = qSwitch
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Compares all possible laser configurations, storing optimal
        /// </summary>
        public void LaserTest()
        {
            //Test all possible configurations
            Parallel.ForEach(GenerateLaserConfigurations(), laserConfig =>
            {
                Laser laserUnderTesting = new(
                    laserConfig.ComponentCounts,
                    laserConfig.DoublerCount,
                    InlineDoublers,
                    StackCount,
                    CombinerCount,
                    laserConfig.UsesQSwitch,
                    EffectiveAC,
                    SmokeAPMultiplier,
                    EnginePpm,
                    EnginePpv,
                    EnginePpc,
                    RequiresFuelAccess,
                    StoragePerCost,
                    StoragePerVolume,
                    TestInterval
                    );
                laserUnderTesting.CalculateLaserStats();
                LaserBag.Add(laserUnderTesting);
            });

            //Find best configuration
            if (VariableToCompare == TestType.DpsPerVolume)
            {
                foreach (Laser rawLaser in LaserBag)
                {
                    if (rawLaser.DpsPerVolume > TopLaser.DpsPerVolume
                        || (rawLaser.DpsPerVolume == TopLaser.DpsPerVolume && rawLaser.DpsPerCost > TopLaser.DpsPerCost)
                        && rawLaser.RechargeTime >= MinRechargeTime
                        && rawLaser.RechargeTime <= MaxRechargeTime)
                    {
                        TopLaser = rawLaser;
                    }
                }
            }
            else if (VariableToCompare == TestType.DpsPerCost)
            {
                foreach (Laser rawLaser in LaserBag)
                {
                    if (rawLaser.DpsPerCost > TopLaser.DpsPerCost
                        || (rawLaser.DpsPerCost == TopLaser.DpsPerCost && rawLaser.DpsPerVolume > TopLaser.DpsPerVolume)
                        && rawLaser.RechargeTime >= MinRechargeTime
                        && rawLaser.RechargeTime <= MaxRechargeTime)
                    {
                        TopLaser = rawLaser;
                    }
                }
            }

            //Write results
            string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-ff") + ".txt";

            using var writer = new StreamWriter(fileName, append: true);
            FileStream fs = (FileStream)writer.BaseStream;

            writer.WriteLine("Test Parameters");
            writer.WriteLine("Max stack length: " + MaxStackLength);
            writer.WriteLine("Stack count: " + StackCount);
            if (InlineDoublers)
            {
                writer.WriteLine("Doublers inline with stacks");
            }
            else
            {
                writer.WriteLine("Doublers separate from stacks");
            }
            writer.WriteLine("Min recharge time (sec): " + MinRechargeTime);
            writer.WriteLine("Max recharge time (sec): " + MaxRechargeTime);
            writer.WriteLine("Target base AC: " + TargetAC);
            writer.WriteLine("AC bonus from ring shields: " + RingACBonus);
            writer.WriteLine("Target eff. AC: " + EffectiveAC);
            writer.WriteLine("Smoke strength: " + SmokeStrength);
            writer.WriteLine("Planar smoke equivalent: " + PlanarShieldStrength);
            writer.WriteLine("Eff. smoke strength: " + (SmokeStrength + PlanarShieldStrength));
            writer.WriteLine("Smoke reduces AP to " + (SmokeAPMultiplier * 100) + "%");
            writer.WriteLine("Engine PPM: " + EnginePpm);
            writer.WriteLine("Engine PPV: " + EnginePpv);
            writer.WriteLine("Engine PPC: " + EnginePpc);
            if(RequiresFuelAccess)
            {
                writer.WriteLine("Engine requires fuel access");
            }
            else
            {
                writer.WriteLine("Engine does NOT require fuel access");
            }
            if (VariableToCompare == TestType.DpsPerVolume)
            {
                writer.WriteLine("Testing for Dps per Volume " + TestInterval + " minutes.");
            }
            else if (VariableToCompare == TestType.DpsPerCost)
            {
                writer.WriteLine("Testing for Dps per Cost over " + TestInterval + " minutes.");
            }

            writer.WriteLine("\nBest Laser Configuration\n");

            TopLaser.WriteLaserInfo(writer);
        }

        /// <summary>
        /// Find optimal component counts using cascading binary search
        /// </summary>
        public void LaserTestCascade()
        {
            int[] zeroArray = new int[LaserComponent.AllLaserComponents.Length];
            List<Laser> laserList = new();

            // Zero Q
            Laser zeroQ = new(
                zeroArray,
                0,
                InlineDoublers,
                StackCount,
                CombinerCount,
                false,
                EffectiveAC,
                SmokeAPMultiplier,
                EnginePpm,
                EnginePpv,
                EnginePpc,
                RequiresFuelAccess,
                StoragePerCost,
                StoragePerVolume,
                TestInterval
                );

            // 1-4 Q
            Laser qSwitched = new(
                zeroArray,
                0,
                InlineDoublers,
                StackCount,
                CombinerCount,
                true,
                EffectiveAC,
                SmokeAPMultiplier,
                EnginePpm,
                EnginePpv,
                EnginePpc,
                RequiresFuelAccess,
                StoragePerCost,
                StoragePerVolume,
                TestInterval
                );

            laserList.Add(zeroQ);
            laserList.Add(qSwitched);

            Parallel.ForEach(laserList, laserToTest =>
            {
                OptimizeComp0Count(laserToTest, MaxStackLength);
            });


            //Write results
            string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-ff") + ".txt";

            using var writer = new StreamWriter(fileName, append: true);
            FileStream fs = (FileStream)writer.BaseStream;

            writer.WriteLine("Test Parameters");
            writer.WriteLine("Max stack length: " + MaxStackLength);
            writer.WriteLine("Stack count: " + StackCount);
            if (InlineDoublers)
            {
                writer.WriteLine("Doublers inline with stacks");
            }
            else
            {
                writer.WriteLine("Doublers separate from stacks");
            }
            writer.WriteLine("Min recharge time (sec): " + MinRechargeTime);
            writer.WriteLine("Max recharge time (sec): " + MaxRechargeTime);
            writer.WriteLine("Target base AC: " + TargetAC);
            writer.WriteLine("AC bonus from ring shields: " + RingACBonus);
            writer.WriteLine("Target eff. AC: " + EffectiveAC);
            writer.WriteLine("Smoke strength: " + SmokeStrength);
            writer.WriteLine("Planar smoke equivalent: " + PlanarShieldStrength);
            writer.WriteLine("Eff. smoke strength: " + (SmokeStrength + PlanarShieldStrength));
            writer.WriteLine("Smoke reduces AP to " + (SmokeAPMultiplier * 100) + "%");
            writer.WriteLine("Engine PPM: " + EnginePpm);
            writer.WriteLine("Engine PPV: " + EnginePpv);
            writer.WriteLine("Engine PPC: " + EnginePpc);
            if (RequiresFuelAccess)
            {
                writer.WriteLine("Engine requires fuel access");
            }
            else
            {
                writer.WriteLine("Engine does NOT require fuel access");
            }
            if (VariableToCompare == TestType.DpsPerVolume)
            {
                writer.WriteLine("Testing for Dps per Volume " + TestInterval + " minutes.");
            }
            else if (VariableToCompare == TestType.DpsPerCost)
            {
                writer.WriteLine("Testing for Dps per Cost over " + TestInterval + " minutes.");
            }

            writer.WriteLine("\nBest Laser Configurations\n");

            writer.WriteLine("Zero Q");
            zeroQ.WriteLaserInfo(writer);

            writer.WriteLine("\n1 thru 4 Q");
            qSwitched.WriteLaserInfo(writer);
        }

        /// <summary>
        /// Use binary search to calculate optimum frequency doubler count
        /// </summary>
        /// <param name="laserUnderTesting">Laser to optimize</param>
        /// <param name="doublerUpperBound">Max allowed doublers (be sure to adjust for inline)</param>
        void OptimizeDoublerCount(Laser laserUnderTesting, int doublerUpperBound)
        {
            int doublerLowerBound = 0;
            int doublerMidPoint;
            float doublerLowerScore;
            float doublerUpperScore;
            while (doublerUpperBound - doublerLowerBound > 1)
            {
                doublerMidPoint = (int)Math.Floor((decimal)(doublerLowerBound + doublerUpperBound) / 2);

                laserUnderTesting.DoublerCount = doublerLowerBound;
                laserUnderTesting.CalculateLaserStats();
                doublerLowerScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                laserUnderTesting.DoublerCount = doublerUpperBound;
                laserUnderTesting.CalculateLaserStats();
                doublerUpperScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                if (doublerLowerScore >= doublerUpperScore)
                {
                    doublerUpperBound = doublerMidPoint;
                }
                else
                {
                    doublerLowerBound = doublerMidPoint;
                }
            }

            laserUnderTesting.DoublerCount = doublerLowerBound;
            laserUnderTesting.CalculateLaserStats();
            doublerLowerScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.DoublerCount = doublerUpperBound;
            laserUnderTesting.CalculateLaserStats();
            doublerUpperScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.DoublerCount = doublerLowerScore >= doublerUpperScore
                ? doublerLowerBound
                : doublerUpperBound;
        }

        /// <summary>
        /// Use binary search to calculate optimum count of component index 5
        /// </summary>
        void OptimizeComp5Count(Laser laserUnderTesting, int comp5UpperBound)
        {
            int comp5LowerBound = 0;
            int comp5MidPoint;
            float comp5LowerScore;
            float comp5UpperScore;
            int doublerUpperBound;
            while (comp5UpperBound - comp5LowerBound > 1)
            {
                comp5MidPoint = (int)Math.Floor((decimal)(comp5LowerBound + comp5UpperBound) / 2);

                laserUnderTesting.ComponentCounts[5] = comp5LowerBound;
                doublerUpperBound = InlineDoublers
                    ? MaxStackLength - comp5LowerBound
                    : MaxStackLength;
                OptimizeDoublerCount(laserUnderTesting, doublerUpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp5LowerScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                laserUnderTesting.ComponentCounts[5] = comp5UpperBound;
                doublerUpperBound = InlineDoublers
                    ? MaxStackLength - comp5UpperBound
                    : MaxStackLength;
                OptimizeDoublerCount(laserUnderTesting, doublerUpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp5UpperScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                if (comp5LowerScore >= comp5UpperScore)
                {
                    comp5UpperBound = comp5MidPoint;
                }
                else
                {
                    comp5LowerBound = comp5MidPoint;
                }
            }

            laserUnderTesting.ComponentCounts[5] = comp5LowerBound;
            doublerUpperBound = InlineDoublers
                ? MaxStackLength - comp5LowerBound
                : MaxStackLength;
            OptimizeDoublerCount(laserUnderTesting, doublerUpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp5LowerScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[5] = comp5UpperBound;
            doublerUpperBound = InlineDoublers
                ? MaxStackLength - comp5UpperBound
                : MaxStackLength;
            OptimizeDoublerCount(laserUnderTesting, doublerUpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp5UpperScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[5] = comp5LowerScore >= comp5UpperScore
                ? comp5LowerBound
                : comp5UpperBound;
        }


        /// <summary>
        /// Use binary search to calculate optimum count of component index 4
        /// </summary>
        void OptimizeComp4Count(Laser laserUnderTesting, int comp4UpperBound)
        {
            int comp4LowerBound = 0;
            int comp4MidPoint;
            float comp4LowerScore;
            float comp4UpperScore;
            int comp5UpperBound;
            while (comp4UpperBound - comp4LowerBound > 1)
            {
                comp4MidPoint = (int)Math.Floor((decimal)(comp4LowerBound + comp4UpperBound) / 2);

                laserUnderTesting.ComponentCounts[4] = comp4LowerBound;
                comp5UpperBound = MaxStackLength - comp4LowerBound;
                OptimizeComp5Count(laserUnderTesting, comp5UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp4LowerScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                laserUnderTesting.ComponentCounts[4] = comp4UpperBound;
                comp5UpperBound = MaxStackLength - comp4UpperBound;
                OptimizeComp5Count(laserUnderTesting, comp5UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp4UpperScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                if (comp4LowerScore >= comp4UpperScore)
                {
                    comp4UpperBound = comp4MidPoint;
                }
                else
                {
                    comp4LowerBound = comp4MidPoint;
                }
            }

            laserUnderTesting.ComponentCounts[4] = comp4LowerBound;
            comp5UpperBound = MaxStackLength - comp4LowerBound;
            OptimizeComp5Count(laserUnderTesting, comp5UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp4LowerScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[4] = comp4UpperBound;
            comp5UpperBound = MaxStackLength - comp4UpperBound;
            OptimizeComp5Count(laserUnderTesting, comp5UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp4UpperScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[4] = comp4LowerScore >= comp4UpperScore
                ? comp4LowerBound
                : comp4UpperBound;
        }


        /// <summary>
        /// Use binary search to calculate optimum count of component index 3
        /// </summary>
        void OptimizeComp3Count(Laser laserUnderTesting, int comp3UpperBound)
        {
            int comp3LowerBound = 0;
            int comp3MidPoint;
            float comp3LowerScore;
            float comp3UpperScore;
            int comp4UpperBound;
            while (comp3UpperBound - comp3LowerBound > 1)
            {
                comp3MidPoint = (int)Math.Floor((decimal)(comp3LowerBound + comp3UpperBound) / 2);

                laserUnderTesting.ComponentCounts[3] = comp3LowerBound;
                comp4UpperBound = MaxStackLength - comp3LowerBound;
                OptimizeComp4Count(laserUnderTesting, comp4UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp3LowerScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                laserUnderTesting.ComponentCounts[3] = comp3UpperBound;
                comp4UpperBound = MaxStackLength - comp3UpperBound;
                OptimizeComp4Count(laserUnderTesting, comp4UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp3UpperScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                if (comp3LowerScore >= comp3UpperScore)
                {
                    comp3UpperBound = comp3MidPoint;
                }
                else
                {
                    comp3LowerBound = comp3MidPoint;
                }
            }

            laserUnderTesting.ComponentCounts[3] = comp3LowerBound;
            comp4UpperBound = MaxStackLength - comp3LowerBound;
            OptimizeComp4Count(laserUnderTesting, comp4UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp3LowerScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[3] = comp3UpperBound;
            comp4UpperBound = MaxStackLength - comp3UpperBound;
            OptimizeComp4Count(laserUnderTesting, comp4UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp3UpperScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[3] = comp3LowerScore >= comp3UpperScore
                ? comp3LowerBound
                : comp3UpperBound;
        }

        /// <summary>
        /// Use binary search to calculate optimum count of component index 2
        /// </summary>
        void OptimizeComp2Count(Laser laserUnderTesting, int comp2UpperBound)
        {
            int comp2LowerBound = 0;
            int comp2MidPoint;
            float comp2LowerScore;
            float comp2UpperScore;
            int comp3UpperBound;
            while (comp2UpperBound - comp2LowerBound > 1)
            {
                comp2MidPoint = (int)Math.Floor((decimal)(comp2LowerBound + comp2UpperBound) / 2);

                laserUnderTesting.ComponentCounts[2] = comp2LowerBound;
                comp3UpperBound = MaxStackLength - comp2LowerBound;
                OptimizeComp3Count(laserUnderTesting, comp3UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp2LowerScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                laserUnderTesting.ComponentCounts[2] = comp2UpperBound;
                comp3UpperBound = MaxStackLength - comp2UpperBound;
                OptimizeComp3Count(laserUnderTesting, comp3UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp2UpperScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                if (comp2LowerScore >= comp2UpperScore)
                {
                    comp2UpperBound = comp2MidPoint;
                }
                else
                {
                    comp2LowerBound = comp2MidPoint;
                }
            }

            laserUnderTesting.ComponentCounts[2] = comp2LowerBound;
            comp3UpperBound = MaxStackLength - comp2LowerBound;
            OptimizeComp3Count(laserUnderTesting, comp3UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp2LowerScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[2] = comp2UpperBound;
            comp3UpperBound = MaxStackLength - comp2UpperBound;
            OptimizeComp3Count(laserUnderTesting, comp3UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp2UpperScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[2] = comp2LowerScore >= comp2UpperScore
                ? comp2LowerBound
                : comp2UpperBound;
        }

        /// <summary>
        /// Use binary search to calculate optimum count of component index 1
        /// </summary>
        void OptimizeComp1Count(Laser laserUnderTesting, int comp1UpperBound)
        {
            int comp1LowerBound = 0;
            int comp1MidPoint;
            float comp1LowerScore;
            float comp1UpperScore;
            int comp2UpperBound;
            while (comp1UpperBound - comp1LowerBound > 1)
            {
                comp1MidPoint = (int)Math.Floor((decimal)(comp1LowerBound + comp1UpperBound) / 2);

                laserUnderTesting.ComponentCounts[1] = comp1LowerBound;
                comp2UpperBound = MaxStackLength - comp1LowerBound;
                OptimizeComp2Count(laserUnderTesting, comp2UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp1LowerScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                laserUnderTesting.ComponentCounts[1] = comp1UpperBound;
                comp2UpperBound = MaxStackLength - comp1UpperBound;
                OptimizeComp2Count(laserUnderTesting, comp2UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp1UpperScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                if (comp1LowerScore >= comp1UpperScore)
                {
                    comp1UpperBound = comp1MidPoint;
                }
                else
                {
                    comp1LowerBound = comp1MidPoint;
                }
            }

            laserUnderTesting.ComponentCounts[1] = comp1LowerBound;
            comp2UpperBound = MaxStackLength - comp1LowerBound;
            OptimizeComp2Count(laserUnderTesting, comp2UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp1LowerScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[1] = comp1UpperBound;
            comp2UpperBound = MaxStackLength - comp1UpperBound;
            OptimizeComp2Count(laserUnderTesting, comp2UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp1UpperScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[1] = comp1LowerScore >= comp1UpperScore
                ? comp1LowerBound
                : comp1UpperBound;
        }


        /// <summary>
        /// Use binary search to calculate optimum count of component index 0
        /// </summary>
        void OptimizeComp0Count(Laser laserUnderTesting, int comp0UpperBound)
        {
            int comp0LowerBound = 0;
            int comp0MidPoint;
            float comp0LowerScore;
            float comp0UpperScore;
            int comp1UpperBound;
            while (comp0UpperBound - comp0LowerBound > 1)
            {
                comp0MidPoint = (int)Math.Floor((decimal)(comp0LowerBound + comp0UpperBound) / 2);

                laserUnderTesting.ComponentCounts[0] = comp0LowerBound;
                comp1UpperBound = MaxStackLength - comp0LowerBound;
                OptimizeComp1Count(laserUnderTesting, comp1UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp0LowerScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                laserUnderTesting.ComponentCounts[0] = comp0UpperBound;
                comp1UpperBound = MaxStackLength - comp0UpperBound;
                OptimizeComp1Count(laserUnderTesting, comp1UpperBound);
                laserUnderTesting.CalculateLaserStats();
                comp0UpperScore = VariableToCompare == TestType.DpsPerCost
                    ? laserUnderTesting.DpsPerCost
                    : laserUnderTesting.DpsPerVolume;

                if (comp0LowerScore >= comp0UpperScore)
                {
                    comp0UpperBound = comp0MidPoint;
                }
                else
                {
                    comp0LowerBound = comp0MidPoint;
                }
            }

            laserUnderTesting.ComponentCounts[0] = comp0LowerBound;
            comp1UpperBound = MaxStackLength - comp0LowerBound;
            OptimizeComp1Count(laserUnderTesting, comp1UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp0LowerScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[0] = comp0UpperBound;
            comp1UpperBound = MaxStackLength - comp0UpperBound;
            OptimizeComp1Count(laserUnderTesting, comp1UpperBound);
            laserUnderTesting.CalculateLaserStats();
            comp0UpperScore = VariableToCompare == TestType.DpsPerCost
                ? laserUnderTesting.DpsPerCost
                : laserUnderTesting.DpsPerVolume;

            laserUnderTesting.ComponentCounts[0] = comp0LowerScore >= comp0UpperScore
                ? comp0LowerBound
                : comp0UpperBound;
        }
    }
}
