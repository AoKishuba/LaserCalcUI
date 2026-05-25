namespace LaserCalcUI
{
    record struct BestPair(Laser? ZeroQ, Laser? QSwitched);
    public readonly record struct LaserConfiguration(int[] ComponentCounts, int DoublerCount, int QSwitchCount);

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
        /// <param name="maxStackLength">Max number of laser components</param>
        /// <param name="stackCount">Number of parallel cavity stacks</param>
        /// <param name="inlineDoublers">Whether doublers will be mounted inline with stacks</param>
        /// <param name="combinerCount">Number of combiners and LAMS nodes</param>
        /// <param name="qSwitchCounts">Q-switch counts to test. 0-4</param>
        /// <param name="minRechargeTime">Minimum recharge time in seconds</param>
        /// <param name="maxRechargeTime">Maximum recharge time in seconds</param>
        /// <param name="targetResistance">Target base fire resistance</param>
        /// <param name="smokeStrength">Smoke strength, in smoke units (25 000 per max-strength dispenser)</param>
        /// <param name="planarShieldStrength">Smoke strength equivalent of planar shields</param>
        /// <param name="enginePpm">Engine Power Per Material</param>
        /// <param name="enginePpv">Engine Power Per Volume</param>
        /// <param name="enginePpc">Engine Power Per Cost (block cost of engine)</param>
        /// <param name="requiresFuelAccess">Whether fuel access blocks are required (for Fuel Engines or CJE)</param>
        /// <param name="storagePerCost">Quantity of material stored per cost of storage</param>
        /// <param name="storagePerVolume">Quantity of material stored per volume of storage</param>
        /// <param name="targetArmorScheme">Armor scheme to be penetrated with each shot (or per second for 0Q)</param>
        /// <param name="testType">Whether to test for DPS per Volume or DPS per Cost</param>
        /// <param name="testInterval">Test interval in minutes</param>
        /// <param name="columnDelimiter">Comma for US, semicolon for countries which use comma for decimal</param>
        public LaserComparer(
            int maxStackLength,
            int stackCount,
            bool inlineDoublers,
            int combinerCount,
            int[] qSwitchCounts,
            int minRechargeTime,
            int maxRechargeTime,
            float targetResistance,
            int smokeStrength,
            int planarShieldStrength,
            float enginePpm,
            float enginePpv,
            float enginePpc,
            bool requiresFuelAccess,
            float storagePerCost,
            float storagePerVolume,
            Scheme targetArmorScheme,
            TestType testType,
            int testInterval,
            char columnDelimiter
            )
        {
            MaxStackLength = maxStackLength;
            StackCount = stackCount;
            InlineDoublers = inlineDoublers;
            CombinerCount = combinerCount;
            QSwitchCounts = qSwitchCounts;
            MinRechargeTime = minRechargeTime;
            MaxRechargeTime = maxRechargeTime;
            TargetResistance = targetResistance;
            SmokeStrength = smokeStrength;
            PlanarShieldStrength = planarShieldStrength;
            SmokeIntensityMultiplier = 18f / MathF.Pow(1500f + SmokeStrength + PlanarShieldStrength, 0.4f);
            EnginePpm = enginePpm;
            EnginePpv = enginePpv;
            EnginePpc = enginePpc;
            RequiresFuelAccess = requiresFuelAccess;
            StoragePerCost = storagePerCost;
            StoragePerVolume = storagePerVolume;
            TargetArmorScheme = targetArmorScheme;
            TestType = testType;
            TestInterval = testInterval;
            ColumnDelimiter = columnDelimiter;
        }

        int MaxStackLength { get; }
        int StackCount { get; }
        bool InlineDoublers { get; }
        int CombinerCount { get; }
        int[] QSwitchCounts { get; }
        int MinRechargeTime { get; }
        int MaxRechargeTime { get; }
        float TargetResistance { get; }
        int SmokeStrength { get; }
        int PlanarShieldStrength { get; }
        float SmokeIntensityMultiplier { get; }
        float EnginePpm { get; }
        float EnginePpv { get; }
        float EnginePpc { get; }
        bool RequiresFuelAccess { get; }
        float StoragePerCost { get; }
        float StoragePerVolume { get; }
        Scheme TargetArmorScheme { get; }
        TestType TestType { get; }
        int TestInterval { get; }
        char ColumnDelimiter { get; }


        /// <summary>
        /// Iterable generator for laser configurations. Generates all possible combinations of components 
        /// at all possible intensity values
        /// for both Q and non-Q lasers
        /// </summary>
        /// <returns></returns>
        IEnumerable<LaserConfiguration> GenerateLaserConfigurations(int comp0Count)
        {
            int totalCount;

            totalCount = comp0Count;

            for (int comp1Count = 0; comp1Count <= MaxStackLength - totalCount; comp1Count++)
            {
                totalCount = comp0Count + comp1Count;

                for (int comp2Count = 0; comp2Count <= MaxStackLength - totalCount; comp2Count++)
                {
                    totalCount = comp0Count + comp1Count + comp2Count;

                    for (int comp3Count = 0; comp3Count <= MaxStackLength - totalCount; comp3Count++)
                    {
                        totalCount = comp0Count + comp1Count + comp2Count + comp3Count;

                        for (int comp4Count = 0; comp4Count <= MaxStackLength - totalCount; comp4Count++)
                        {
                            totalCount = comp0Count + comp1Count + comp2Count + comp3Count + comp4Count;

                            for (int comp5Count = 0; comp5Count <= MaxStackLength - totalCount; comp5Count++)
                            {
                                totalCount = comp0Count + comp1Count + comp2Count + comp3Count + comp4Count + comp5Count;

                                for (int comp6Count = 0; comp6Count <= MaxStackLength - totalCount; comp6Count++)
                                {
                                    int maxDoublerCount;
                                    maxDoublerCount = InlineDoublers
                                        ? MaxStackLength - comp0Count - comp1Count - comp2Count - comp3Count - comp4Count - comp5Count - comp6Count
                                        : MaxStackLength;

                                    for (int doublerCount = 0; doublerCount <= maxDoublerCount; doublerCount++)
                                    {
                                        foreach (int qSwitchCount in QSwitchCounts)
                                        {
                                            int[] componentCounts =
                                            [
                                                comp0Count,
                                                comp1Count,
                                                comp2Count,
                                                comp3Count,
                                                comp4Count,
                                                comp5Count,
                                                comp6Count
                                                ];

                                            yield return new LaserConfiguration(componentCounts, doublerCount, qSwitchCount);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        Laser? Better(Laser? currentBest, Laser? candidate)
        {
            if (candidate is null) return currentBest;
            if (currentBest is null) return candidate;

            if (TestType == TestType.DpsPerVolume)
            {
                return (candidate.DpsPerVolume > currentBest.DpsPerVolume
                        || (candidate.DpsPerVolume == currentBest.DpsPerVolume
                            && candidate.DpsPerCost > currentBest.DpsPerCost))
                    ? candidate
                    : currentBest;
            }

            return (candidate.DpsPerCost > currentBest.DpsPerCost
                    || (candidate.DpsPerCost == currentBest.DpsPerCost
                        && candidate.DpsPerVolume > currentBest.DpsPerVolume))
                ? candidate
                : currentBest;
        }

        /// <summary>
        /// Compares all possible laser configurations, storing optimal
        /// </summary>
        public void BigTest()
        {
            BestPair globalBest = new(null, null);
            var mergeLock = new object();

            for (int comp0Count = 0; comp0Count <= MaxStackLength; comp0Count++)
            {
                Parallel.ForEach(
                    GenerateLaserConfigurations(comp0Count),
                    () => new BestPair(null, null),                    // localInit
                    (config, _, local) =>                              // body
                    {
                        Laser candidate = new(
                            config.ComponentCounts,
                            config.DoublerCount,
                            InlineDoublers,
                            StackCount,
                            CombinerCount,
                            config.QSwitchCount,
                            TargetResistance,
                            SmokeIntensityMultiplier,
                            EnginePpm,
                            EnginePpv,
                            EnginePpc,
                            RequiresFuelAccess,
                            StoragePerCost,
                            StoragePerVolume,
                            TestInterval,
                            ColumnDelimiter);
                        candidate.CalculateLaserStats();
                        // Filter by recharge time
                        if (float.IsNaN(candidate.RechargeTime)
                        ||  candidate.RechargeTime < MinRechargeTime
                        ||  candidate.RechargeTime > MaxRechargeTime)
                            return local;

                        // Filter by pendepth. Scheme defaults to air if nothing entered or pendepth checkbox unchecked
                        // 0Q cannot pen; 0Q-only tests should throw an error
                        if (candidate.QSwitchCount > 0)
                        {
                            float requiredDamage = TargetArmorScheme.CalculateRequiredDamageToPen(candidate.EffectiveIntensity);
                            if (candidate.DamagePerShot < requiredDamage)
                            {
                                return local;
                            }
                        }

                        return candidate.QSwitchCount > 0
                            ? local with { QSwitched = Better(local.QSwitched, candidate) }
                            : local with { ZeroQ = Better(local.ZeroQ, candidate) };
                    },
                    local =>                                           // localFinally
                    {
                        lock (mergeLock)
                        {
                            globalBest = new BestPair(
                                Better(globalBest.ZeroQ, local.ZeroQ),
                                Better(globalBest.QSwitched, local.QSwitched));
                        }
                    });
            }

            //Write results
            string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-ff") + ".csv";

            using var writer = new StreamWriter(fileName, append: true);

            writer.WriteLine("Test Parameters");
            writer.WriteLine("Max stack length" + ColumnDelimiter + MaxStackLength);
            writer.WriteLine("Stack count" + ColumnDelimiter + StackCount);
            if (InlineDoublers)
            {
                writer.WriteLine("Doublers inline with stacks");
            }
            else
            {
                writer.WriteLine("Doublers separate from stacks");
            }
            writer.WriteLine("Combiner count" + ColumnDelimiter + CombinerCount);
            if (QSwitchCounts.Length > 1)
            {
                writer.WriteLine("Q-Switch counts");
                foreach (int count in QSwitchCounts)
                {
                    writer.WriteLine($"{count}");
                }
            }
            else
            {
                writer.WriteLine("Q-Switch count" + ColumnDelimiter + QSwitchCounts[0]);
            }
            writer.WriteLine("Min recharge time (sec)" + ColumnDelimiter + MinRechargeTime);
            writer.WriteLine("Max recharge time (sec)" + ColumnDelimiter + MaxRechargeTime);
            writer.WriteLine("Target fire resistance" + ColumnDelimiter + TargetResistance);
            writer.WriteLine("Smoke strength" + ColumnDelimiter + SmokeStrength);
            writer.WriteLine("Planar smoke equivalent" + ColumnDelimiter + PlanarShieldStrength);
            writer.WriteLine("Eff. smoke strength" + ColumnDelimiter + (SmokeStrength + PlanarShieldStrength));
            writer.WriteLine("Smoke reduces intensity to" 
                + ColumnDelimiter 
                + (SmokeIntensityMultiplier * 100) 
                + "%");
            if (TargetArmorScheme.LayerList.Count > 1 || TargetArmorScheme.LayerList[0] != Layer.Air)
            {
                writer.WriteLine("Testing for pendepth. Target armor scheme:");
                foreach (Layer layer in  TargetArmorScheme.LayerList)
                {
                    writer.WriteLine($"{layer.Name}");
                }
            }
            writer.WriteLine("Engine PPM" + ColumnDelimiter + EnginePpm);
            writer.WriteLine("Engine PPV" + ColumnDelimiter + EnginePpv);
            writer.WriteLine("Engine PPC" + ColumnDelimiter + EnginePpc);
            if (RequiresFuelAccess)
            {
                writer.WriteLine("Engine requires fuel access");
            }
            else
            {
                writer.WriteLine("Engine does NOT require fuel access");
            }
            if (TestType == TestType.DpsPerVolume)
            {
                writer.WriteLine("Testing for Dps per Volume over " + TestInterval + " minutes.");
            }
            else if (TestType == TestType.DpsPerCost)
            {
                writer.WriteLine("Testing for Dps per Cost over " + TestInterval + " minutes.");
            }

            writer.WriteLine("\nBest Laser Configurations\n");


            if (globalBest.ZeroQ is not null)
            {
                writer.WriteLine("0Q");
                globalBest.ZeroQ.WriteLaserInfo(writer);
                writer.WriteLine();
            }

            if (globalBest.QSwitched is not null)
            {
                writer.WriteLine($"{globalBest.QSwitched.QSwitchCount} Q");
                globalBest.QSwitched.WriteLaserInfo(writer);
            }

            if (globalBest.ZeroQ is null && globalBest.QSwitched is null)
            {
                writer.WriteLine("No configuration satisfied the recharge-time constraints.");
            }
        }
    }
}
