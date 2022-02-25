using System;
using System.IO;

namespace LaserCalcUI
{
    public class Laser
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
        /// <param name="targetEffectiveAC">Base AC + ring shield bonus, if any</param>
        /// <param name="smokeAPMultiplier">AP Multiplier from smoke</param>
        /// <param name="enginePpm">Engine Power Per Material</param>
        /// <param name="enginePpv">Engine Power Per Volume</param>
        /// <param name="enginePpc">Engine Power Per Cost (block cost of engine)</param>
        /// <param name="requiresFuelAccess">Whether fuel access blocks are needed (for Fuel Engines or CJE)</param>
        /// <param name="storagePerCost">Quantity of material stored per cost of storage</param>
        /// <param name="storagePerVolume">Quantity of material stored per volume of storage</param>
        /// <param name="testInterval">Test interval in minutes, for fuel calculations</param>
        public Laser(
            int[] componentCounts,
            int doublerCount,
            bool inlineDoublers,
            int stackCount,
            int combinerCount,
            bool usesQSwitch,
            float targetEffectiveAC,
            float smokeAPMultiplier,
            float enginePpm,
            float enginePpv,
            float enginePpc,
            bool requiresFuelAccess,
            float storagePerCost,
            float storagePerVolume,
            int testInterval
            )
        {
            ComponentCounts = componentCounts;
            DoublerCount = doublerCount;
            InlineDoublers = inlineDoublers;
            StackCount = stackCount;
            CombinerCount = combinerCount;
            UsesQSwitch = usesQSwitch;
            TargetEffectiveAC = targetEffectiveAC;
            SmokeAPMultiplier = smokeAPMultiplier;
            EnginePpm = enginePpm;
            EnginePpv = enginePpv;
            EnginePpc = enginePpc;
            RequiresFuelAccess = requiresFuelAccess;
            StoragePerCost = storagePerCost;
            StoragePerVolume = storagePerVolume;
            TestInterval = testInterval;
        }
        public int[] ComponentCounts { get; }
        public int DoublerCount { get; set; }
        public bool InlineDoublers { get; }
        public int StackCount { get; }
        public int CombinerCount { get; }
        public bool UsesQSwitch { get; }
        public float TargetEffectiveAC { get; }
        float SmokeAPMultiplier { get; }
        public float EnginePpm { get; }
        public float EnginePpv { get; }
        public float EnginePpc { get; }
        public bool RequiresFuelAccess { get; }
        public float StoragePerCost { get; }
        public float StoragePerVolume { get; }
        public int TestInterval { get; }

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
        public float APMod { get; set; }
        public float AP { get; set; }
        public float EffectiveAP { get; set; }
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
            CalculateAPMod();
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
                writer.WriteLine(LaserComponent.AllLaserComponents[i].Name + ": " + ComponentCounts[i]);
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
                writer.WriteLine("Frequency doublers (per stack): " + DoublerCount);
            }
            else
            {
                writer.WriteLine("Frequency doublers (separate): " + DoublerCount);
            }
            writer.WriteLine("Laser cost: " + LaserCost);
            writer.WriteLine("Engine cost: " + EngineCost);
            if (RequiresFuelAccess)
            {
                writer.WriteLine("Fuel access cost: " + FuelAccessCost);
            }
            writer.WriteLine("Fuel storage cost: " + FuelStorageCost);
            writer.WriteLine("Materials burned as fuel: " + FuelBurned);
            writer.WriteLine("Total cost: " + TotalCost);

            writer.WriteLine("Laser volume: " + LaserVolume);
            writer.WriteLine("Engine volume: " + EngineVolume);
            if (RequiresFuelAccess)
            {
                writer.WriteLine("Fuel access volume: " + FuelAccessVolume);
            }
            writer.WriteLine("Fuel storage volume: " + FuelStorageVolume);
            writer.WriteLine("Total volume: " + TotalVolume);

            writer.WriteLine("Engine power: " + EnginePower);
            writer.WriteLine("Energy recharge/sec: " + RechargeRate);
            writer.WriteLine("Energy storage: " + EnergyStorage);
            writer.WriteLine("Recharge time (sec): " + RechargeTime);
            writer.WriteLine("Energy discharge/sec: " + DischargeRate);
            writer.WriteLine("Base AP: " + AP);
            writer.WriteLine("AP after smoke: " + EffectiveAP);
            writer.WriteLine("Sustained damage per second: " + Dps);
            writer.WriteLine("DPS per cost: " + DpsPerCost);
            writer.WriteLine("DPS per volume: " + DpsPerVolume);
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
            RechargeRate = PumpVolume * 24;
            EnginePower = RechargeRate * 1.25f;
        }

        /// <summary>
        /// Calculate recharge time from empty cavities
        /// </summary>
        void CalculateRechargeTime()
        {
            RechargeTime = (float)EnergyStorage / RechargeRate;
        }


        /// <summary>
        /// Calculate AP modifier from storage and pump volume
        /// </summary>
        void CalculateAPMod()
        {
            APMod = PumpVolume + EnergyStorage / 10000f;
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
            float dischargeMultiplier = 1f - MathF.Pow(1f - 0.1f, ComponentCounts[destabIndex] + 1f);

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
        /// Calculate armour pierce and damage per second
        /// </summary>
        void CalculateDps()
        {
            int totalDoublerCount = InlineDoublers
                ? DoublerCount
                : DoublerCount * StackCount;

            AP = UsesQSwitch
                ? 40f + totalDoublerCount / APMod * 100f
                : 60f + totalDoublerCount / APMod * 150f;

            // 27 smoke strength = 100% power
            EffectiveAP = AP * SmokeAPMultiplier;

            float outputRate = MathF.Min(RechargeRate, DischargeRate);
            Dps = EffectiveAP >= TargetEffectiveAC
                ? outputRate
                : outputRate * EffectiveAP / TargetEffectiveAC;

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
