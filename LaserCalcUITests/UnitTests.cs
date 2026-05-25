using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaserCalcUI;
using System.Configuration;

namespace LaserCalcUITests
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
            int qSwitchCount = 0;
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
                qSwitchCount,
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

            List<Layer> testLayers = [
                Layer.MetalBeam
                ];
            Scheme testScheme = new(testLayers);
            float requiredDps = testScheme.CalculateRequiredDamageToPen(testLaser.Intensity);
            float expectedRequiredDps = Layer.MetalBeam.HP;

            Assert.AreEqual(13_500, testLaser.EnergyStorage);
            Assert.AreEqual(24, testLaser.PumpVolume);
            Assert.AreEqual(288, testLaser.RechargeRate);
            Assert.AreEqual(46.875f, testLaser.RechargeTime);
            Assert.AreEqual(25.35f, testLaser.IntensityMod);
            Assert.AreEqual(5130.0015f, testLaser.DischargeRate);
            Assert.AreEqual(720f, testLaser.EnginePower);
            Assert.AreEqual(2, testLaser.DoublerCount);
            Assert.AreEqual(4120, testLaser.LaserCost);
            Assert.AreEqual(62, testLaser.LaserVolume);
            Assert.AreEqual(144f, testLaser.EngineCost);
            Assert.AreEqual(12f, testLaser.EngineVolume);
            Assert.AreEqual(2160f, testLaser.FuelBurned);
            Assert.AreEqual(14.400001f, testLaser.FuelAccessCost);
            Assert.AreEqual(1.44f, testLaser.FuelAccessVolume);
            Assert.AreEqual(5.76f, testLaser.FuelStorageCost);
            Assert.AreEqual(2.88f, testLaser.FuelStorageVolume);
            Assert.AreEqual(6444.1597f, testLaser.TotalCost);
            Assert.AreEqual(78.32f, testLaser.TotalVolume);
            Assert.AreEqual(83.66864f, testLaser.Intensity);
            Assert.AreEqual(testLaser.Intensity * smokeIntensityMultiplier, testLaser.EffectiveIntensity);
            Assert.AreEqual(216f, testLaser.Dps);
            Assert.AreEqual(0.033518724f, testLaser.DpsPerCost);
            Assert.AreEqual(2.7579162f, testLaser.DpsPerVolume);
            Assert.AreEqual(expectedRequiredDps, requiredDps);
        }
    }
}