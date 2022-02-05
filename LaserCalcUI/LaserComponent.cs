using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserCalcUI
{
    class LaserComponent
    {
        /// <summary>
        /// One segment of a laser stack
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="cost">Material cost</param>
        /// <param name="energyStorage">Laser energy storage</param>
        /// <param name="blockVolume">M^3</param>
        /// <param name="pumpVolume">M^3 taken up by laser pumps (used for AP calculations)</param>
        /// <param name="energyUseMultiplier"></param>
        public LaserComponent(string name, int cost, int energyStorage, int blockVolume, int pumpVolume)
        {
            Name = name;
            Cost = cost;
            EnergyStorage = energyStorage;
            BlockVolume = blockVolume;
            PumpVolume = pumpVolume;
        }

        public string Name { get; }
        public int Cost { get; }
        public int EnergyStorage { get; }
        public int BlockVolume { get; }
        public int PumpVolume { get; }

        // Initialize all laser components
        // Raw components
        public static LaserComponent Cavity { get; } = new LaserComponent("Cavity", 50, 250, 1, 0);
        public static LaserComponent SingleInputCavity { get; } = new LaserComponent("Single input cavity", 50, 1000, 1, 0);
        public static LaserComponent StorageCavity { get; } = new LaserComponent("Storage cavity", 450, 10000, 9, 0);
        public static LaserComponent LaserPump { get; } = new LaserComponent("Laser pump", 60, 0, 1, 1);
        public static LaserComponent LaserPump3M { get; } = new LaserComponent("Laser pump (3m)", 180, 0, 3, 3);
        public static LaserComponent Destabilizer { get; } = new LaserComponent("Laser destabilizer", 50, 0, 1, 0);

        // Combinations of components as used in an actual laser
        public static LaserComponent FullPumpCavity { get; } = new LaserComponent(
            "Full-pump cavity",
            Cavity.Cost + (2 * LaserPump.Cost) + (2 * LaserPump3M.Cost),
            Cavity.EnergyStorage + (2 * LaserPump.EnergyStorage) + (2 * LaserPump3M.EnergyStorage),
            Cavity.BlockVolume + (2 * LaserPump.BlockVolume) + (2 * LaserPump3M.BlockVolume),
            Cavity.PumpVolume + (2 * LaserPump.PumpVolume) + (2 * LaserPump3M.PumpVolume)
            );
        public static LaserComponent SingleInputCavityWithPump { get; } = new LaserComponent(
            "Single input with pump",
            SingleInputCavity.Cost + LaserPump3M.Cost,
            SingleInputCavity.EnergyStorage + LaserPump3M.EnergyStorage,
            SingleInputCavity.BlockVolume + LaserPump3M.BlockVolume,
            SingleInputCavity.PumpVolume + LaserPump3M.PumpVolume
            );

        public static LaserComponent[] AllLaserComponents = new LaserComponent[]
        {
            Cavity,
            SingleInputCavity,
            StorageCavity,
            FullPumpCavity,
            SingleInputCavityWithPump,
            Destabilizer
        };
    }
}
