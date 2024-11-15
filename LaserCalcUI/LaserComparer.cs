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
        /// <param name="targetResistance">Target base fire resistance</param>
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
        /// <param name="columnDelimiter">Comma for US, semicolon for countries which use comma for decimal</param>
        public LaserComparer(
            int maxStackLength,
            int stackCount,
            bool inlineDoublers,
            int combinerCount,
            int minRechargeTime,
            int maxRechargeTime,
            float targetResistance,
            int smokeStrength,
            int planarShieldStrength,
            float enginePpm,
            float enginePpv,
            float enginePpc,
            bool requiresFuelAccess,
            float storagePerCost,
            float storagePerVolume,
            TestType variableToCompare,
            int testInterval,
            char columnDelimiter
            )
        {
            MaxStackLength = maxStackLength;
            StackCount = stackCount;
            InlineDoublers = inlineDoublers;
            CombinerCount = combinerCount;
            MinRechargeTime = minRechargeTime;
            MaxRechargeTime = maxRechargeTime;
            TargetResistance = targetResistance;
            SmokeStrength = smokeStrength;
            PlanarShieldStrength = planarShieldStrength;
            SmokeIntensityMultiplier = 18f / MathF.Pow(1500f + SmokeStrength + PlanarShieldStrength, 0.4f);
            EnginePpm = enginePpm;
            EnginePpv = enginePpv;
            EnginePpc = enginePpc;
            RequiresFuelAccess = requiresFuelAccess;
            StoragePerCost = storagePerCost;
            StoragePerVolume = storagePerVolume;
            VariableToCompare = variableToCompare;
            TestInterval = testInterval;
            ColumnDelimiter = columnDelimiter;
        }

        int MaxStackLength { get; }
        int StackCount { get; }
        bool InlineDoublers { get; }
        int CombinerCount { get; }
        int MinRechargeTime { get; }
        int MaxRechargeTime { get; }
        float TargetResistance { get; }
        int SmokeStrength { get; }
        int PlanarShieldStrength { get; }
        float SmokeIntensityMultiplier { get; }
        float EnginePpm { get; }
        float EnginePpv { get; }
        float EnginePpc { get; }
        bool RequiresFuelAccess { get; }
        float StoragePerCost { get; }
        float StoragePerVolume { get; }
        TestType VariableToCompare { get; }
        int TestInterval { get; }
        char ColumnDelimiter { get; }
        ConcurrentBag<Laser> LaserBag = [];

        /// <summary>
        /// Iterable generator for laser configurations. Generates all possible combinations of components 
        /// at all possible intensity values
        /// for both Q and non-Q lasers
        /// </summary>
        /// <returns></returns>
        IEnumerable<LaserConfiguration> GenerateLaserConfigurations(int comp0Count)
        {
            int totalCount;
            bool[] boolArr = [true, false];

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
                                for (int comp6Count = 0; comp6Count <= MaxStackLength - totalCount; comp6Count++)
                                {
                                    int maxDoublerCount;
                                    maxDoublerCount = InlineDoublers
                                        ? MaxStackLength - comp0Count - comp1Count - comp2Count - comp3Count - comp4Count - comp5Count
                                        : MaxStackLength;

                                    for (int doublerCount = 0; doublerCount <= maxDoublerCount; doublerCount++)
                                    {
                                        foreach (bool qSwitch in boolArr)
                                        {
                                            int[] componentCounts =
                                            [
                                                comp0Count,
                                                comp1Count,
                                                comp2Count,
                                                comp3Count,
                                                comp4Count,
                                                comp5Count,
                                                comp6Count
                                                ];

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
                TargetResistance,
                SmokeIntensityMultiplier,
                EnginePpm,
                EnginePpv,
                EnginePpc,
                RequiresFuelAccess,
                StoragePerCost,
                StoragePerVolume,
                TestInterval,
                ColumnDelimiter
                );

            // 1-4 Q
            Laser qSwitched = new(
                zeroArray,
                0,
                InlineDoublers,
                StackCount,
                CombinerCount,
                true,
                TargetResistance,
                SmokeIntensityMultiplier,
                EnginePpm,
                EnginePpv,
                EnginePpc,
                RequiresFuelAccess,
                StoragePerCost,
                StoragePerVolume,
                TestInterval,
                ColumnDelimiter
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
                        TargetResistance,
                        SmokeIntensityMultiplier,
                        EnginePpm,
                        EnginePpv,
                        EnginePpc,
                        RequiresFuelAccess,
                        StoragePerCost,
                        StoragePerVolume,
                        TestInterval,
                        ColumnDelimiter
                        );
                    laserUnderTesting.CalculateLaserStats();
                    LaserBag.Add(laserUnderTesting);
                });

                //Find best configuration in bag

                if (VariableToCompare == TestType.DpsPerVolume)
                {
                    foreach (Laser rawLaser in LaserBag)
                    {
                        if (rawLaser.RechargeTime <= MaxRechargeTime
                            && rawLaser.RechargeTime >= MinRechargeTime)
                        {
                            if (rawLaser.UsesQSwitch)
                            {
                                if (rawLaser.DpsPerVolume > qSwitched.DpsPerVolume
                                    || (rawLaser.DpsPerVolume == qSwitched.DpsPerVolume
                                        && rawLaser.DpsPerCost > qSwitched.DpsPerCost))
                                {
                                    qSwitched = rawLaser;
                                }
                            }
                            else if (rawLaser.DpsPerVolume > zeroQ.DpsPerVolume
                                || (rawLaser.DpsPerVolume == zeroQ.DpsPerVolume
                                    && rawLaser.DpsPerCost > qSwitched.DpsPerCost))
                            {
                                zeroQ = rawLaser;
                            }
                        }
                    }
                }
                else if (VariableToCompare == TestType.DpsPerCost)
                {
                    foreach (Laser rawLaser in LaserBag)
                    {
                        if (rawLaser.RechargeTime <= MaxRechargeTime
                            && rawLaser.RechargeTime >= MinRechargeTime)
                        {
                            if (rawLaser.UsesQSwitch)
                            {
                                if (rawLaser.DpsPerCost > qSwitched.DpsPerCost
                                    || (rawLaser.DpsPerCost == qSwitched.DpsPerCost
                                        && rawLaser.DpsPerVolume > qSwitched.DpsPerVolume))
                                {
                                    qSwitched = rawLaser;
                                }
                            }
                            else if (rawLaser.DpsPerCost > zeroQ.DpsPerCost
                                || (rawLaser.DpsPerCost == zeroQ.DpsPerCost
                                    && rawLaser.DpsPerVolume > zeroQ.DpsPerVolume))
                            {
                                zeroQ = rawLaser;
                            }
                        }
                    }
                }
            }

            //Write results
            string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-ff") + ".csv";

            using var writer = new StreamWriter(fileName, append: true);
            FileStream fs = (FileStream)writer.BaseStream;

            writer.WriteLine("Test Parameters");
            writer.WriteLine("Max stack length" + ColumnDelimiter + MaxStackLength);
            writer.WriteLine("Stack count" + ColumnDelimiter + StackCount);
            if (InlineDoublers)
            {
                writer.WriteLine("Doublers inline with stacks");
            }
            else
            {
                writer.WriteLine("Doublers separate from stacks");
            }
            writer.WriteLine("Min recharge time (sec)" + ColumnDelimiter + MinRechargeTime);
            writer.WriteLine("Max recharge time (sec)" + ColumnDelimiter + MaxRechargeTime);
            writer.WriteLine("Target fire resistance" + ColumnDelimiter + TargetResistance);
            writer.WriteLine("Smoke strength" + ColumnDelimiter + SmokeStrength);
            writer.WriteLine("Planar smoke equivalent" + ColumnDelimiter + PlanarShieldStrength);
            writer.WriteLine("Eff. smoke strength" + ColumnDelimiter + (SmokeStrength + PlanarShieldStrength));
            writer.WriteLine("Smoke reduces intensity to" 
                + ColumnDelimiter 
                + (SmokeIntensityMultiplier * 100) 
                + "%");
            writer.WriteLine("Engine PPM" + ColumnDelimiter + EnginePpm);
            writer.WriteLine("Engine PPV" + ColumnDelimiter + EnginePpv);
            writer.WriteLine("Engine PPC" + ColumnDelimiter + EnginePpc);
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
                writer.WriteLine("Testing for Dps per Volume over " + TestInterval + " minutes.");
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
