using System;
using System.IO;

namespace LaserCalcUI
{
    /// <summary>
    /// Pumps, cavities, doublers, and destabs
    /// </summary>
    /// <param name="componentCounts">Quantity of each laser component, using indices from LaserComponent.AllLaserComponents</param>
    /// <param name="doublerCount">Quantity of frequency doublers, either total or per stack (if Inline Doublers is true)</param>
    /// <param name="inlineDoublers">True if doublers will be included in stacks</param>
    /// <param name="stackCount">Number of parallel cavity stacks</param>
    /// <param name="combinerCount">Number of laser combiners and LAMS nodes</param>
    /// <param name="usesQSwitch">Whether laser uses at least one Q-switch</param>
    /// <param name="targetResistance">Fire resistance of target block</param>
    /// <param name="smokeIntensityMultiplier">Intensity Multiplier from smoke</param>
    /// <param name="enginePpm">Engine Power Per Material</param>
    /// <param name="enginePpv">Engine Power Per Volume</param>
    /// <param name="enginePpc">Engine Power Per Cost (block cost of engine)</param>
    /// <param name="requiresFuelAccess">Whether fuel access blocks are needed (for Fuel Engines or CJE)</param>
    /// <param name="storagePerCost">Quantity of material stored per cost of storage</param>
    /// <param name="storagePerVolume">Quantity of material stored per volume of storage</param>
    /// <param name="testInterval">Test interval in minutes, for fuel calculations</param>
    /// <param name="columnDelimiter">Used for .csv printout. ',' for period decimal countries, ';' otherwise</param>
    public class Laser(
        int[] componentCounts,
        int doublerCount,
        bool inlineDoublers,
        int stackCount,
        int combinerCount,
        bool usesQSwitch,
        float targetResistance,
        float smokeIntensityMultiplier,
        float enginePpm,
        float enginePpv,
        float enginePpc,
        bool requiresFuelAccess,
        float storagePerCost,
        float storagePerVolume,
        int testInterval,
        char columnDelimiter
            )
    {
        public int[] ComponentCounts { get; } = componentCounts;
        public int DoublerCount { get; set; } = doublerCount;
        public bool InlineDoublers { get; } = inlineDoublers;
        public int StackCount { get; } = stackCount;
        public int CombinerCount { get; } = combinerCount;
        public bool UsesQSwitch { get; } = usesQSwitch;
        public float TargetResistance { get; } = targetResistance;
        float SmokeIntensityMultiplier { get; } = smokeIntensityMultiplier;
        public float EnginePpm { get; } = enginePpm;
        public float EnginePpv { get; } = enginePpv;
        public float EnginePpc { get; } = enginePpc;
        public bool RequiresFuelAccess { get; } = requiresFuelAccess;
        public float StoragePerCost { get; } = storagePerCost;
        public float StoragePerVolume { get; } = storagePerVolume;
        public int TestInterval { get; } = testInterval;
        char ColumnDelimiter { get; } = columnDelimiter;

        public int LaserCost { get; set; }
        public int LaserVolume { get; set; }
        public int EnergyStorage { get; set; }
        public int PumpVolume { get; set; }
        public int RechargeRate { get; set; }
        public float DischargeRate { get; set; }
        public float RechargeTime { get; set; }
        public float EnginePower { get; set; }
        public float EngineCost { get; set; }
        public float EngineVolume { get; set; }
        public float FuelBurned { get; set; }
        public float FuelAccessCost { get; set; }
        public float FuelAccessVolume { get; set; }
        public float FuelStorageCost { get; set; }
        public float FuelStorageVolume { get; set; }
        public float TotalCost { get; set; }
        public float TotalVolume { get; set; }
        public float IntensityMod { get; set; }
        public float Intensity { get; set; }
        public float EffectiveIntensity { get; set; }
        public float Dps { get; set; }
        public float DpsPerCost { get; set; }
        public float DpsPerVolume { get; set; }

        /// <summary>
        /// Calculate all stats
        /// </summary>
        public void CalculateLaserStats()
        {
            CalculateEnergyStorage();
            CalculatePumpVolume();
            CalculateRechargeTime();
            CalculateDischargeRate();
            CalculateLaserCost();
            CalculateLaserVolume();
            CalculateEngineVolumeAndCost();
            CalculateFuelVolumeAndCost();
            CalculateIntensityMod();
            CalculateDps();
        }

        /// <summary>
        /// Writes laser info to file
        /// </summary>
        /// <param name="writer">Streamwriter used for writing to file (keeps everything on same file)</param>
        public void WriteLaserInfo(StreamWriter writer)
        {
            for (int i = 0; i < ComponentCounts.Length; i++)
            {
                writer.WriteLine(LaserComponent.AllLaserComponents[i].Name + ColumnDelimiter  + ComponentCounts[i]);
            }

            if (UsesQSwitch)
            {
                writer.WriteLine("1-4 Q switches");
            }
            else
            {
                writer.WriteLine("Laser does NOT use Q switches");
            }

            if (InlineDoublers)
            {
                writer.WriteLine("Frequency doublers (per stack)" + ColumnDelimiter + DoublerCount);
            }
            else
            {
                writer.WriteLine("Frequency doublers (separate)" + ColumnDelimiter + DoublerCount);
            }
            writer.WriteLine("Laser cost" + ColumnDelimiter + LaserCost);
            writer.WriteLine("Engine cost" + ColumnDelimiter + EngineCost);
            if (RequiresFuelAccess)
            {
                writer.WriteLine("Fuel access cost" + ColumnDelimiter + FuelAccessCost);
            }
            writer.WriteLine("Fuel storage cost" + ColumnDelimiter + FuelStorageCost);
            writer.WriteLine("Materials burned as fuel" + ColumnDelimiter + FuelBurned);
            writer.WriteLine("Total cost" + ColumnDelimiter + TotalCost);

            writer.WriteLine("Laser volume" + ColumnDelimiter + LaserVolume);
            writer.WriteLine("Engine volume" + ColumnDelimiter + EngineVolume);
            if (RequiresFuelAccess)
            {
                writer.WriteLine("Fuel access volume" + ColumnDelimiter + FuelAccessVolume);
            }
            writer.WriteLine("Fuel storage volume" + ColumnDelimiter + FuelStorageVolume);
            writer.WriteLine("Total volume" + ColumnDelimiter + TotalVolume);

            writer.WriteLine("Engine power" + ColumnDelimiter + EnginePower);
            writer.WriteLine("Energy recharge/sec" + ColumnDelimiter + RechargeRate);
            writer.WriteLine("Energy storage" + ColumnDelimiter + EnergyStorage);
            writer.WriteLine("Recharge time (sec)" + ColumnDelimiter + RechargeTime);
            writer.WriteLine("Energy discharge/sec" + ColumnDelimiter + DischargeRate);
            writer.WriteLine("Base Intensity" + ColumnDelimiter + Intensity);
            writer.WriteLine("Intensity after smoke" + ColumnDelimiter + EffectiveIntensity);
            writer.WriteLine("Sustained damage per second" + ColumnDelimiter + Dps);
            writer.WriteLine("DPS per cost" + ColumnDelimiter + DpsPerCost);
            writer.WriteLine("DPS per volume" + ColumnDelimiter + DpsPerVolume);
        }

        /// <summary>
        /// Calculate energy storage of laser
        /// </summary>
        void CalculateEnergyStorage()
        {
            for (int compIndex = 0; compIndex < ComponentCounts.Length; compIndex++)
            {
                EnergyStorage += LaserComponent.AllLaserComponents[compIndex].EnergyStorage * ComponentCounts[compIndex];
            }

            EnergyStorage *= StackCount;
        }

        /// <summary>
        /// Calculate pump volume of laser
        /// </summary>
        void CalculatePumpVolume()
        {
            for (int compIndex = 0; compIndex < ComponentCounts.Length; compIndex++)
            {
                PumpVolume += LaserComponent.AllLaserComponents[compIndex].PumpVolume * ComponentCounts[compIndex];
            }

            PumpVolume *= StackCount;
            RechargeRate = PumpVolume * 12;
            EnginePower = PumpVolume *  30;
        }

        /// <summary>
        /// Calculate recharge time from empty cavities
        /// </summary>
        void CalculateRechargeTime()
        {
            RechargeTime = (float)EnergyStorage / RechargeRate;
        }


        /// <summary>
        /// Calculate Intensity modifier from storage and pump volume
        /// </summary>
        void CalculateIntensityMod()
        {
            IntensityMod = PumpVolume + EnergyStorage / 10_000f;
        }

        /// <summary>
        /// Calculate sustained discharge rate of laser
        /// </summary>
        void CalculateDischargeRate()
        {
            // Find destab index
            int destabIndex = int.MaxValue;
            for (int i = 0; i < LaserComponent.AllLaserComponents.Length; i++)
            {
                if (LaserComponent.AllLaserComponents[i] == LaserComponent.Destabilizer)
                {
                    destabIndex = i;
                }
            }
            // multiplier = 1 - (1 - regulator setting [default 0.1])^(#destabs + 1)
            float dischargeMultiplier = 1f - MathF.Pow(0.9f, ComponentCounts[destabIndex] + 1f);

            DischargeRate = EnergyStorage * dischargeMultiplier * CombinerCount;
        }

        /// <summary>
        /// Calculate block cost of laser components
        /// </summary>
        void CalculateLaserCost()
        {
            LaserCost = 0;
            for (int compIndex = 0; compIndex < ComponentCounts.Length; compIndex++)
            {
                LaserCost += LaserComponent.AllLaserComponents[compIndex].Cost * ComponentCounts[compIndex];
            }
            LaserCost *= StackCount;
            LaserCost += 
                50 // Multipurpose laser
                + 40 * StackCount // Laser coupler
                + DoublerCount * 250;
        }

        /// <summary>
        /// Calculate block volume of laser components
        /// </summary>
        void CalculateLaserVolume()
        {
            LaserVolume = 0;
            for (int compIndex = 0; compIndex < ComponentCounts.Length; compIndex++)
            {
                LaserVolume += LaserComponent.AllLaserComponents[compIndex].BlockVolume * ComponentCounts[compIndex];
            }
            LaserVolume *= StackCount;
            LaserVolume +=
                1 // Multipurpose laser
                + StackCount // Laser coupler
                + DoublerCount;
        }


        /// <summary>
        /// Calculate cost and volume stats related to engine
        /// </summary>
        void CalculateEngineVolumeAndCost()
        {
            EngineCost = EnginePower / EnginePpc;
            EngineVolume = EnginePower / EnginePpv;
        }


        void CalculateFuelVolumeAndCost()
        {
            int testIntervalSeconds = TestInterval * 60;

            float fuelStorageNeeded;
            if (RequiresFuelAccess)
            {
                // Volume and cost of special fuel access blocks
                // 1 fuel per MINUTE = 1/50 m^3 and 0.2 material cost
                // 1 fuel per SECOND = 60/50 (1.2) m^3 and 12 material cost
                float fuelAccessNeeded = EnginePower / EnginePpm;
                FuelAccessCost = fuelAccessNeeded * 12f;
                FuelAccessVolume = fuelAccessNeeded * 1.2f;

                FuelBurned = EnginePower * testIntervalSeconds / EnginePpm;
                fuelStorageNeeded = EnginePower * MathF.Max(testIntervalSeconds - 600, 0) / EnginePpm;
            }
            else
            {
                FuelBurned = EnginePower * testIntervalSeconds / EnginePpm;
                fuelStorageNeeded = FuelBurned;
            }

            FuelStorageCost = fuelStorageNeeded / StoragePerCost;
            FuelStorageVolume = fuelStorageNeeded / StoragePerVolume;
        }

        /// <summary>
        /// Calculate intensity and damage per second
        /// </summary>
        void CalculateDps()
        {
            int totalDoublerCount = InlineDoublers
                ? DoublerCount
                : DoublerCount * StackCount;

            Intensity = UsesQSwitch
                ? 40f + totalDoublerCount / IntensityMod * 100f
                : 60f + totalDoublerCount / IntensityMod * 150f;

            EffectiveIntensity = Intensity * SmokeIntensityMultiplier;

            float outputRate = MathF.Min(RechargeRate, DischargeRate);
            Dps = EffectiveIntensity >= TargetResistance
                ? outputRate
                : outputRate * EffectiveIntensity / TargetResistance;

            if (!UsesQSwitch)
            {
                Dps *= 0.75f;
            }

            TotalCost = LaserCost + EngineCost + FuelAccessCost + FuelStorageCost + FuelBurned;
            TotalVolume = LaserVolume + EngineVolume + FuelAccessVolume + FuelStorageVolume;

            DpsPerCost = Dps / TotalCost;
            DpsPerVolume = Dps / TotalVolume;
        }
    }
}
