using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserCalcUI
{
    public class Laser
    {
        /// <summary>
        /// Pumps, cavities, doublers, and destabs
        /// </summary>
        /// <param name="componentCounts">Quantity of each laser component, using indices from LaserComponent.AllLaserComponents</param>
        /// <param name="usesQSwitch">Whether laser uses at least one Q-switch</param>
        /// <param name="desiredAP">Desired AP rating for laser. Not necessarily equal to target AC</param>
        /// <param name="targetEffectiveAC">Effective AC of target</param>
        public Laser(int[] componentCounts, bool usesQSwitch, float desiredAP, float targetEffectiveAC)
        {
            ComponentCounts = componentCounts;
            UsesQSwitch = usesQSwitch;
            DesiredAP = desiredAP;
            TargetAC = targetEffectiveAC;
        }
        public int[] ComponentCounts { get; }
        public bool UsesQSwitch { get; }
        float DesiredAP { get; }
        float TargetAC { get; }

        public int Cost { get; set; }
        public int EnergyStorage { get; set; }
        public int PumpVolume { get; set; }
        public int DoublerCount { get; set; }
        public float APMod { get; set; }
        public float AP { get; set; }
        public float Dps { get; set; }
        public float DpsPerCost { get; set; }
        public float DpsPerVolume { get; set; }
        public int BlockVolume { get; set; }
        public float DischargeRate { get; set; }
        public float EnginePower { get; set; }

        /// <summary>
        /// Calculate all stats
        /// </summary>
        public void CalculateLaserStats()
        {
            CalculateEnergyStorage();
            CalculatePumpVolume();
            CalculateAPMod();
            CalculateDischargeRate();
            CalculateDoublerCount();
            CalculateCost();
            CalculateBlockVolume();
            CalculateDps();
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

            DischargeRate = MathF.Min(EnergyStorage * dischargeMultiplier, PumpVolume * 24f);

            EnginePower = DischargeRate * 1.25f;
        }

        /// <summary>
        /// Calculate requried frequency doublers to reach desired AP
        /// </summary>
        void CalculateDoublerCount()
        {
            DoublerCount = UsesQSwitch
                ? (int)Math.Ceiling(MathF.Max(DesiredAP - 40, 0)
                    * APMod
                    / 100)
                : (int)Math.Ceiling(MathF.Max(DesiredAP - 60, 0)
                    * APMod
                    / 150);
        }

        /// <summary>
        /// Calculate block cost of laser
        /// </summary>
        void CalculateCost()
        {
            Cost = 0;
            for (int compIndex = 0; compIndex < ComponentCounts.Length; compIndex++)
            {
                Cost += LaserComponent.AllLaserComponents[compIndex].Cost * ComponentCounts[compIndex];
            }
            Cost += DoublerCount * 250;
        }

        /// <summary>
        /// Calculate block volume of laser
        /// </summary>
        void CalculateBlockVolume()
        {
            BlockVolume = 0;
            for (int compIndex = 0; compIndex < ComponentCounts.Length; compIndex++)
            {
                BlockVolume += LaserComponent.AllLaserComponents[compIndex].BlockVolume * ComponentCounts[compIndex];
            }

            BlockVolume += DoublerCount;
        }

        /// <summary>
        /// Calculate armour pierce and damage per second
        /// </summary>
        void CalculateDps()
        {
            if (UsesQSwitch)
            {
                AP = 40f + DoublerCount / APMod * 100f;
            }
            else
            {
                AP = 60f + DoublerCount / APMod * 150f;
            }

            if (AP >= TargetAC)
            {
                Dps = DischargeRate;
            }
            else
            {
                Dps = DischargeRate * AP / TargetAC;
            }

            if (!UsesQSwitch)
            {
                Dps *= 0.75f;
            }

            DpsPerCost = Dps / Cost;
            DpsPerVolume = Dps / BlockVolume;
        }
    }
}
