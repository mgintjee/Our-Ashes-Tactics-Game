namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Scripts.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Customizations;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Loadouts;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Scripts.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Randoms.Generators.Numbers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Utils.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcFramework Script Api
    /// </summary>
    public class MvcFrameworkScript
    : AbstractUnityScriptImpl, IMvcFrameworkScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject = null;

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            this.Initialize();
            logger.Debug("IsGameComplete: ?", this.mvcFrameworkObject.IsGameComplete());
            if (!this.mvcFrameworkObject.IsGameComplete())
            {
                this.mvcFrameworkObject.ContinueGame();
            }
            else
            {
                this.Destroy();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void Initialize()
        {
            // Todo: Probably load the util game Objects from the ResourceLoader at this stage
            if (this.mvcFrameworkObject == null)
            {
                RandomNumberGeneratorUtil.BuildRandom(22);
                IDictionary<FactionCallSign, ISet<PhalanxCallSign>> factionIdPhalanxIdSetDictionary =
                    new Dictionary<FactionCallSign, ISet<PhalanxCallSign>>()
                    {
                        { FactionCallSign.Faction1,
                        new HashSet<PhalanxCallSign>() { PhalanxCallSign.Alfa, PhalanxCallSign.Bravo} },
                        { FactionCallSign.Faction2,
                        new HashSet<PhalanxCallSign>() { PhalanxCallSign.Charlie, PhalanxCallSign.Delta} },
                    };
                IDictionary<PhalanxCallSign, ISet<TalonCallSign>> phalanxIdTalonCallSignSetDictionary =
                    new Dictionary<PhalanxCallSign, ISet<TalonCallSign>>()
                    {
                        { PhalanxCallSign.Alfa,
                        new HashSet<TalonCallSign>() { TalonCallSign.Alpha} },
                        { PhalanxCallSign.Bravo,
                        new HashSet<TalonCallSign>() { TalonCallSign.Beta} },
                        { PhalanxCallSign.Charlie,
                        new HashSet<TalonCallSign>() { TalonCallSign.Chi} },
                        { PhalanxCallSign.Delta,
                        new HashSet<TalonCallSign>() { TalonCallSign.Delta}  },
                    };
                IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary =
                    new Dictionary<TalonCallSign, ITalonConstructionReport>()
                    {
                        {
                            TalonCallSign.Alpha,
                            new TalonConstructionReport.Builder()
                                .SetCustomizationReport(RandomCustomizationReportGenerator
                                    .GenerateRandomCustomizationReport())
                                .SetTalonLoadoutReport(RandomTalonLoadoutReportGenerator
                                    .GenerateRandomTalonLoadoutReport(EnumUtils.GetRandomEnum<TalonId>()))
                                .Build()
                        },
                        {
                            TalonCallSign.Beta,
                            new TalonConstructionReport.Builder()
                                .SetCustomizationReport(RandomCustomizationReportGenerator
                                    .GenerateRandomCustomizationReport())
                                .SetTalonLoadoutReport(RandomTalonLoadoutReportGenerator
                                    .GenerateRandomTalonLoadoutReport(EnumUtils.GetRandomEnum<TalonId>()))
                                .Build()
                        },
                        {
                            TalonCallSign.Chi,
                            new TalonConstructionReport.Builder()
                                .SetCustomizationReport(RandomCustomizationReportGenerator
                                    .GenerateRandomCustomizationReport())
                                .SetTalonLoadoutReport(RandomTalonLoadoutReportGenerator
                                    .GenerateRandomTalonLoadoutReport(EnumUtils.GetRandomEnum<TalonId>()))
                                .Build()
                        },
                        {
                            TalonCallSign.Delta,
                            new TalonConstructionReport.Builder()
                                .SetCustomizationReport(RandomCustomizationReportGenerator
                                    .GenerateRandomCustomizationReport())
                                .SetTalonLoadoutReport(RandomTalonLoadoutReportGenerator
                                    .GenerateRandomTalonLoadoutReport(EnumUtils.GetRandomEnum<TalonId>()))
                                .Build()
                        },
                    };
                this.mvcFrameworkObject = new MvcFrameworkObject.Builder()
                    .SetMatchType(MatchType.FactionDeathmatch)
                    .SetSimulationType(SimulationType.BlackBox)
                    .SetGameBoardShape(GameBoardShape.Hexagon)
                    .SetGameBoardLimit(3)
                    .SetMirroredBoard(true)
                    .SetFactionIdPhalanxIdSetDictionary(factionIdPhalanxIdSetDictionary)
                    .SetPhalanxTalonCallSignSetDictionary(phalanxIdTalonCallSignSetDictionary)
                    .SetTalonCallSignConstructionReportDictionary(talonCallSignConstructionReportDictionary)
                    .Build();
            }
        }
    }
}