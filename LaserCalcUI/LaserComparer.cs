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
        ConcurrentBag<Laser> LaserBag = new();

        /// <summary>
        /// Iterable generator for laser configurations. Generates all possible combinations of components at all possible AP values
        /// for both Q and non-Q lasers
        /// </summary>
        /// <returns></returns>
        IEnumerable<LaserConfiguration> GenerateLaserConfigurations(int comp0Count)
        {
            int totalCount;
            bool[] boolArr = new[] { true, false };

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

        /// <summary>
        /// Compares all possible laser configurations, storing optimal
        /// </summary>
        public void LaserTest()
        {
            int[] zeroArray = new int[LaserComponent.AllLaserComponents.Length];
            // Blank lasers for comparison
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

            //Test all possible configurations
            for (int comp0Count = 0; comp0Count <= MaxStackLength; comp0Count++)
            {
                LaserBag.Clear();
                Parallel.ForEach(GenerateLaserConfigurations(comp0Count), laserConfig =>
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

                //Find best configuration in bag
                if (VariableToCompare == TestType.DpsPerVolume)
                {
                    foreach (Laser rawLaser in LaserBag)
                    {
                        if (rawLaser.DpsPerVolume > qSwitched.DpsPerVolume
                            || (rawLaser.DpsPerVolume == qSwitched.DpsPerVolume && rawLaser.DpsPerCost > qSwitched.DpsPerCost)
                            && rawLaser.RechargeTime >= MinRechargeTime
                            && rawLaser.RechargeTime <= MaxRechargeTime
                            && rawLaser.UsesQSwitch)
                        {
                            qSwitched = rawLaser;
                        }
                        else if (rawLaser.DpsPerVolume > zeroQ.DpsPerVolume
                            || (rawLaser.DpsPerVolume == zeroQ.DpsPerVolume && rawLaser.DpsPerCost > zeroQ.DpsPerCost)
                            && rawLaser.RechargeTime >= MinRechargeTime
                            && rawLaser.RechargeTime <= MaxRechargeTime
                            && !rawLaser.UsesQSwitch)
                        {
                            zeroQ = rawLaser;
                        }
                    }
                }
                else if (VariableToCompare == TestType.DpsPerCost)
                {
                    foreach (Laser rawLaser in LaserBag)
                    {
                        if (rawLaser.DpsPerCost > qSwitched.DpsPerCost
                            || (rawLaser.DpsPerCost == qSwitched.DpsPerCost && rawLaser.DpsPerVolume > qSwitched.DpsPerVolume)
                            && rawLaser.RechargeTime >= MinRechargeTime
                            && rawLaser.RechargeTime <= MaxRechargeTime
                            && rawLaser.UsesQSwitch)
                        {
                            qSwitched = rawLaser;
                        }
                        else if (rawLaser.DpsPerCost > zeroQ.DpsPerCost
                            || (rawLaser.DpsPerCost == zeroQ.DpsPerCost && rawLaser.DpsPerVolume > zeroQ.DpsPerVolume)
                            && rawLaser.RechargeTime >= MinRechargeTime
                            && rawLaser.RechargeTime <= MaxRechargeTime
                            && !rawLaser.UsesQSwitch)
                        {
                            zeroQ = rawLaser;
                        }
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
    }
}
