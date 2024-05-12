using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaserCalcUI;

namespace LaserCalcTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ZeroQ()
        {
            int[] testComponentCounts = [1, 1, 1, 1, 1, 1, 1];
            int doublerCount = 2;
            bool inlineDoublers = true;
            int stackCount = 2;
            int combinerCount = 2;
            bool usesQSwitch = false;
            float targetResistance = 40;
            float smokeIntensityMultiplier = 1;
            float enginePpm = 600;
            float enginePpv = 60;
            float enginePpc = 5;
            bool requiresFuelAccess = true;
            float storagePerCost = 250;
            float storagePerVolume = 500;
            int testInterval = 30;
            char columnDelimiter = ',';

            Laser testLaser = new(
                testComponentCounts,
                doublerCount,
                inlineDoublers,
                stackCount,
                combinerCount,
                usesQSwitch,
                targetResistance,
                smokeIntensityMultiplier,
                enginePpm,
                enginePpv,
                enginePpc,
                requiresFuelAccess,
                storagePerCost,
                storagePerVolume,
                testInterval,
                columnDelimiter
                );
            testLaser.CalculateLaserStats();

            Assert.AreEqual(13_500, testLaser.EnergyStorage);
            Assert.AreEqual(24, testLaser.PumpVolume);
            Assert.AreEqual(288, testLaser.RechargeRate);
            Assert.AreEqual(46.875f, testLaser.RechargeTime);
            Assert.AreEqual(25.35f, testLaser.IntensityMod);
            Assert.AreEqual(5130.0015f, testLaser.DischargeRate);
            Assert.AreEqual(720f, testLaser.EnginePower);
            Assert.AreEqual(2, testLaser.DoublerCount);
            Assert.AreEqual(3570, testLaser.LaserCost);
            Assert.AreEqual(59, testLaser.LaserVolume);
            Assert.AreEqual(144f, testLaser.EngineCost);
            Assert.AreEqual(12f, testLaser.EngineVolume);
            Assert.AreEqual(2160f, testLaser.FuelBurned);
            Assert.AreEqual(14.400001f, testLaser.FuelAccessCost);
            Assert.AreEqual(1.44f, testLaser.FuelAccessVolume);
            Assert.AreEqual(5.76f, testLaser.FuelStorageCost);
            Assert.AreEqual(2.88f, testLaser.FuelStorageVolume);
            Assert.AreEqual(5894.16f, testLaser.TotalCost);
            Assert.AreEqual(75.32f, testLaser.TotalVolume);
            Assert.AreEqual(71.83432f, testLaser.Intensity);
            Assert.AreEqual(testLaser.Intensity * smokeIntensityMultiplier, testLaser.EffectiveIntensity);
            Assert.AreEqual(216f, testLaser.Dps);
            Assert.AreEqual(0.03664644f, testLaser.DpsPerCost);
            Assert.AreEqual(2.8677642f, testLaser.DpsPerVolume);
        }
    }
}