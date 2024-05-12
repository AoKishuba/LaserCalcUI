using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserCalcUI
{
    /// <summary>
    /// One segment of a laser stack
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="cost">Material cost</param>
    /// <param name="energyStorage">Laser energy storage</param>
    /// <param name="blockVolume">M^3</param>
    /// <param name="pumpVolume">M^3 taken up by laser pumps (used for intensity calculations)</param>
    class LaserComponent(string name, int cost, int energyStorage, int blockVolume, int pumpVolume)
    {
        public string Name { get; } = name;
        public int Cost { get; } = cost;
        public int EnergyStorage { get; } = energyStorage;
        public int BlockVolume { get; } = blockVolume;
        public int PumpVolume { get; } = pumpVolume;

        // Initialize all laser components
        // Raw components
        public static LaserComponent Cavity { get; } = new LaserComponent("Cavity", 50, 125, 1, 0);
        public static LaserComponent SingleInputCavity { get; } = new LaserComponent("Single input cavity", 50, 500, 1, 0);
        public static LaserComponent StorageCavity { get; } = new LaserComponent("Storage cavity", 450, 5000, 9, 0);
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
        public static LaserComponent SingleInputCavityWithSmallPump { get; } = new LaserComponent(
            "Single input with 1m pump",
            SingleInputCavity.Cost + LaserPump.Cost,
            SingleInputCavity.EnergyStorage + LaserPump.EnergyStorage,
            SingleInputCavity.BlockVolume + LaserPump.BlockVolume,
            SingleInputCavity.PumpVolume + LaserPump.PumpVolume
            );
        public static LaserComponent SingleInputCavityWithLargePump { get; } = new LaserComponent(
            "Single input with 3m pump",
            SingleInputCavity.Cost + LaserPump3M.Cost,
            SingleInputCavity.EnergyStorage + LaserPump3M.EnergyStorage,
            SingleInputCavity.BlockVolume + LaserPump3M.BlockVolume,
            SingleInputCavity.PumpVolume + LaserPump3M.PumpVolume
            );
        public static LaserComponent[] AllLaserComponents =
        [
            Cavity,
            SingleInputCavity,
            StorageCavity,
            FullPumpCavity,
            SingleInputCavityWithSmallPump,
            SingleInputCavityWithLargePump,
            Destabilizer
        ];
    }
}
