namespace LaserCalcUI
{
    /// <summary>
    /// An armor layer.  Stats given are for 4 m beams.
    /// </summary>
    /// <param name="name">Material name</param>
    /// <param name="hp">Hit points</param>
    /// <param name="fr">Armor class</param>
    public class Layer(string name, float hp, float fr)
    {
        public string Name { get; } = name;
        public float HP { get; } = hp;
        public float FireResistance { get; } = fr;

        // Fire resistances by material
        public static float AlloyFR { get; } = 50f;
        public static float HeavyFR { get; } = 60f;
        public static float MetalFR { get; } = 40f;
        public static float StoneFR { get; } = 50f;
        public static float WoodFR { get; } = 10f;


        // Initialize all supported layers
        public static Layer Air { get; } = new Layer("Air", 0, 0);
        public static Layer AlloyBeam { get; } = new Layer("Alloy 4m Beam", 1440f, AlloyFR);
        public static Layer HeavyBeam { get; } = new Layer("HA 4m Beam", 6000f, HeavyFR);
        public static Layer MetalBeam { get; } = new Layer("Metal 4m Beam", 1680f, MetalFR);
        public static Layer StoneBeam { get; } = new Layer("Stone 4m Beam", 1200f, StoneFR);
        public static Layer WoodBeam { get; } = new Layer("Wood 4m Beam", 960f, WoodFR);

        public static Layer AlloyBeamSlope { get; } = new Layer("Alloy Beam Slope", 720f, AlloyFR);
        public static Layer HeavyBeamSlope { get; } = new Layer("HA Beam Slope", 3000f, HeavyFR);
        public static Layer MetalBeamSlope { get; } = new Layer("Metal Beam Slope", 840f, MetalFR);
        public static Layer StoneBeamSlope { get; } = new Layer("Stone Beam Slope", 600f, StoneFR);
        public static Layer WoodBeamSlope { get; } = new Layer("Wood Beam Slope", 480f, WoodFR);

        public static Layer Alloy2mSlope { get; } = new Layer("Alloy 2m Slope", 330f, AlloyFR);
        public static Layer Heavy2mSlope { get; } = new Layer("HA 2m Slope", 1375f, HeavyFR);
        public static Layer Metal2mSlope { get; } = new Layer("Metal 2m Slope", 385f, MetalFR);
        public static Layer Stone2mSlope { get; } = new Layer("Stone 2m Slope", 275f, StoneFR);
        public static Layer Wood2mSlope { get; } = new Layer("Wood 2m Slope", 220f, WoodFR);

        public static Layer Alloy3mSlope { get; } = new Layer("Alloy 3m Slope", 517.5f, AlloyFR);
        public static Layer Heavy3mSlope { get; } = new Layer("HA 3m Slope", 2156.2f, HeavyFR);
        public static Layer Metal3mSlope { get; } = new Layer("Metal 3m Slope", 603.8f, MetalFR);
        public static Layer Stone3mSlope { get; } = new Layer("Stone 3m Slope", 431.2f, StoneFR);
        public static Layer Wood3mSlope { get; } = new Layer("Wood 3m Slope", 345f, WoodFR);

        public static Layer Alloy4mSlope { get; } = new Layer("Alloy 4m Slope", 720f, AlloyFR);
        public static Layer Heavy4mSlope { get; } = new Layer("HA 4m Slope", 3000f, HeavyFR);
        public static Layer Metal4mSlope { get; } = new Layer("Metal 4m Slope", 840f, MetalFR);
        public static Layer Stone4mSlope { get; } = new Layer("Stone 4m Slope", 600f, StoneFR);
        public static Layer Wood4mSlope { get; } = new Layer("Wood 4m Slope", 480f, WoodFR);

        public static Layer AlloyWedge { get; } = new Layer("Alloy Wedge", 150f, AlloyFR);
        public static Layer HeavyWedge { get; } = new Layer("HA Wedge", 625f, HeavyFR);
        public static Layer MetalWedge { get; } = new Layer("Metal Wedge", 175f, MetalFR);
        public static Layer StoneWedge { get; } = new Layer("Stone Wedge", 125f, StoneFR);
        public static Layer WoodWedge { get; } = new Layer("Wood Wedge", 100f, WoodFR);

        public static Layer Alloy2mWedge { get; } = new Layer("Alloy 2m Wedge", 330f, AlloyFR);
        public static Layer Heavy2mWedge { get; } = new Layer("HA 2m Wedge", 1375f, HeavyFR);
        public static Layer Metal2mWedge { get; } = new Layer("Metal 2m Wedge", 385f, MetalFR);
        public static Layer Stone2mWedge { get; } = new Layer("Stone 2m Wedge", 275f, StoneFR);
        public static Layer Wood2mWedge { get; } = new Layer("Wood 2m Wedge", 220f, WoodFR);

        public static Layer Alloy3mWedge { get; } = new Layer("Alloy 3m Wedge", 517.5f, AlloyFR);
        public static Layer Heavy3mWedge { get; } = new Layer("HA 3m Wedge", 2156.2f, HeavyFR);
        public static Layer Metal3mWedge { get; } = new Layer("Metal 3m Wedge", 603.8f, MetalFR);
        public static Layer Stone3mWedge { get; } = new Layer("Stone 3m Wedge", 431.2f, StoneFR);
        public static Layer Wood3mWedge { get; } = new Layer("Wood 3m Wedge", 345f, WoodFR);

        public static Layer Alloy4mWedge { get; } = new Layer("Alloy 4m Wedge", 720f, AlloyFR);
        public static Layer Heavy4mWedge { get; } = new Layer("HA 4m Wedge", 3000f, HeavyFR);
        public static Layer Metal4mWedge { get; } = new Layer("Metal 4m Wedge", 840f, MetalFR);
        public static Layer Stone4mWedge { get; } = new Layer("Stone 4m Wedge", 600f, StoneFR);
        public static Layer Wood4mWedge { get; } = new Layer("Wood 4m Wedge", 480f, WoodFR);


        // List all supported layers
        public static Layer[] AllLayers { get; } =
        [
            Air,
            AlloyBeam,
            AlloyBeamSlope,
            Alloy2mSlope,
            Alloy3mSlope,
            Alloy4mSlope,
            AlloyWedge,
            Alloy2mWedge,
            Alloy3mWedge,
            Alloy4mWedge,
            HeavyBeam,
            HeavyBeamSlope,
            Heavy2mSlope,
            Heavy3mSlope,
            Heavy4mSlope,
            HeavyWedge,
            Heavy2mWedge,
            Heavy3mWedge,
            Heavy4mWedge,
            MetalBeam,
            MetalBeamSlope,
            Metal2mSlope,
            Metal3mSlope,
            Metal4mSlope,
            MetalWedge,
            Metal2mWedge,
            Metal3mWedge,
            Metal4mWedge,
            StoneBeam,
            StoneBeamSlope,
            Stone2mSlope,
            Stone3mSlope,
            Stone4mSlope,
            StoneWedge,
            Stone2mWedge,
            Stone3mWedge,
            Stone4mWedge,
            WoodBeam,
            WoodBeamSlope,
            Wood2mSlope,
            Wood3mSlope,
            Wood4mSlope,
            WoodWedge,
            Wood2mWedge,
            Wood3mWedge,
            Wood4mWedge,
        ];
    }
}
