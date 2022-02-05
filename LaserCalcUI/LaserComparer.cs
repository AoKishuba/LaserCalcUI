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
        public float DesiredAP;
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
        /// <param name="maxComponentCount">Max number of laser components; also known as stack length</param>
        /// <param name="targetAC">Base AC of target</param>
        /// <param name="smokeStrength">Smoke strength, in smoke units (25 000 per max-strength dispenser)</param>
        /// <param name="variableToCompare">Whether to test for DPS per Volume or DPS per Cost</param>
        public LaserComparer(int maxComponentCount, float targetAC, int smokeStrength, TestType variableToCompare)
        {
            MaxComponentCount = maxComponentCount;
            TargetAC = targetAC;
            SmokeStrength = smokeStrength;
            VariableToCompare = variableToCompare;
        }

        int MaxComponentCount { get; }
        float TargetAC { get; }
        int SmokeStrength { get; }
        TestType VariableToCompare { get; }

        float EffectiveAC { get; set; }
        Laser TopLaser { get; set; }
        ConcurrentBag<Laser> LaserBag = new();

        /// <summary>
        /// Iterable generator for laser configurations. Generates all possible combinations of components at all possible AP values
        /// for both Q and non-Q lasers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LaserConfiguration> GenerateLaserConfigurations()
        {
            int totalCount;
            bool[] boolArr = new[] { true, false };

            for (int comp0Count = 0; comp0Count <= MaxComponentCount; comp0Count++)
            {
                totalCount = comp0Count;

                for (int comp1Count = 0; comp1Count <= MaxComponentCount - totalCount; comp1Count++)
                {
                    totalCount = comp0Count + comp1Count;

                    for (int comp2Count = 0; comp2Count <= MaxComponentCount - totalCount; comp2Count++)
                    {
                        totalCount = comp0Count + comp1Count + comp2Count;

                        for (int comp3Count = 0; comp3Count <= MaxComponentCount - totalCount; comp3Count++)
                        {
                            totalCount = comp0Count + comp1Count + comp2Count + comp3Count;

                            for (int comp4Count = 0; comp4Count <= MaxComponentCount - totalCount; comp4Count++)
                            {
                                totalCount = comp0Count + comp1Count + comp2Count + comp3Count + comp4Count;

                                for (int comp5Count = 0; comp5Count <= MaxComponentCount - totalCount; comp5Count++)
                                {
                                    totalCount = comp0Count + comp1Count + comp2Count + comp3Count + comp4Count + comp5Count;

                                    for (float desiredAP = 40f; desiredAP <= EffectiveAC; desiredAP += 0.1f)
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
                                                        comp5Count,
                                                    };

                                            yield return new LaserConfiguration
                                            {
                                                ComponentCounts = componentCounts,
                                                DesiredAP = desiredAP,
                                                UsesQSwitch = qSwitch,
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
            EffectiveAC = MathF.Max(TargetAC, TargetAC / 3 * MathF.Pow(SmokeStrength, 1 / 3f));
            Parallel.ForEach(GenerateLaserConfigurations(), laserConfig =>
            {
                Laser laserUnderTesting = new(laserConfig.ComponentCounts, laserConfig.UsesQSwitch, laserConfig.DesiredAP, EffectiveAC);
                laserUnderTesting.CalculateLaserStats();
                LaserBag.Add(laserUnderTesting);
            });

            //Find best configuration
            if (VariableToCompare == TestType.DpsPerVolume)
            {
                foreach (Laser rawLaser in LaserBag)
                {
                    if (rawLaser.DpsPerVolume > TopLaser.DpsPerVolume
                        || (rawLaser.DpsPerVolume == TopLaser.DpsPerVolume && rawLaser.DpsPerCost > TopLaser.DpsPerCost))
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
                        || (rawLaser.DpsPerCost == TopLaser.DpsPerCost && rawLaser.DpsPerVolume > TopLaser.DpsPerVolume))
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
            writer.WriteLine("Max component count: " + MaxComponentCount);
            writer.WriteLine("Target AC: " + TargetAC);
            writer.WriteLine("Smoke strength: " + SmokeStrength);
            writer.WriteLine("Target AC after smoke: " + EffectiveAC);
            if (VariableToCompare == TestType.DpsPerVolume)
            {
                writer.WriteLine("Testing for Dps per Volume");
            }
            else if (VariableToCompare == TestType.DpsPerCost)
            {
                writer.WriteLine("Testing for Dps per Cost");
            }

            writer.WriteLine("\nBest Laser Configuration\n");

            for (int i = 0; i < TopLaser.ComponentCounts.Length; i++)
            {
                writer.WriteLine(LaserComponent.AllLaserComponents[i].Name + ": " + TopLaser.ComponentCounts[i]);
            }

            if (TopLaser.UsesQSwitch)
            {
                writer.WriteLine("1-4 Q switches");
            }
            else
            {
                writer.WriteLine("Laser does NOT use Q switches");
            }

            writer.WriteLine("Frequency doublers: " + TopLaser.DoublerCount);

            writer.WriteLine("Block volume: " + TopLaser.BlockVolume);
            writer.WriteLine("Cost: " + TopLaser.Cost);
            writer.WriteLine("Engine power: " + TopLaser.EnginePower);
            writer.WriteLine("Energy discharge/sec: " + TopLaser.DischargeRate);
            writer.WriteLine("AP: " + TopLaser.AP);
            writer.WriteLine("Applied damage per second: " + TopLaser.Dps);
            writer.WriteLine("DPS per volume: " + TopLaser.DpsPerVolume);
            writer.WriteLine("DPS per cost: " + TopLaser.DpsPerCost);
        }
    }
}
