using NUnit.Framework;
using LaserCalcUI;

namespace LaserCalcTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroQ()
        {
            int[] testComponentCounts = new int[]{ 1, 1, 1, 1, 1, 1 };
            Laser testLaser = new(
                testComponentCounts,
                2,
                true,
                2,
                2,
                false,
                80,
                0.5f,
                676f,
                88.2f,
                6.1f,
                true,
                250,
                500,
                30
                );
            testLaser.CalculateLaserStats();

            Assert.AreEqual(25000, testLaser.EnergyStorage);
            Assert.AreEqual(22, testLaser.PumpVolume);
            Assert.AreEqual(528, testLaser.RechargeRate);
            Assert.AreEqual(47.348484848484848484848484848485f, testLaser.RechargeTime);
            Assert.AreEqual(24.5f, testLaser.APMod);
            Assert.AreEqual(528, testLaser.DischargeRate);
            Assert.AreEqual(660.0f, testLaser.EnginePower);
            Assert.AreEqual(2, testLaser.DoublerCount);
            Assert.AreEqual(3350, testLaser.LaserCost);
            Assert.AreEqual(55, testLaser.LaserVolume);
            Assert.AreEqual(108.19672131147540983606557377049f, testLaser.EngineCost);
            Assert.AreEqual(7.4829936f, testLaser.EngineVolume);
            Assert.AreEqual(1757.39648f, testLaser.FuelBurned);
            Assert.AreEqual(11.715976331360946745562130177515f, testLaser.FuelAccessCost);
            Assert.AreEqual(1.17159772f, testLaser.FuelAccessVolume);
            Assert.AreEqual(4.6863904f, testLaser.FuelStorageCost);
            Assert.AreEqual(2.343195266272189349112426035503f, testLaser.FuelStorageVolume);
            Assert.AreEqual(5231.995568042835f, testLaser.TotalCost);
            Assert.AreEqual(65.997786546f, testLaser.TotalVolume);
            Assert.AreEqual(72.2448959f, testLaser.AP);
            Assert.AreEqual(testLaser.AP * 0.5f, testLaser.EffectiveAP);
            Assert.AreEqual(178.806122f, testLaser.Dps);
            Assert.AreEqual(0.0341755114f, testLaser.DpsPerCost);
            Assert.AreEqual(2.70927453f, testLaser.DpsPerVolume);
        }
    }
}