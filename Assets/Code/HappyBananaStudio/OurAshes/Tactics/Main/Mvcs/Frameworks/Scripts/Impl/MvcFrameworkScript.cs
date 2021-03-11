namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Scripts.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Construction.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Construction.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Scripts.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// MvcFramework Script Api
    /// </summary>
    public class MvcFrameworkScript
    : AbstractUnityScript, IMvcFrameworkScript
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
            if (!this.mvcFrameworkObject.IsAnimating())
            {
                if (!this.mvcFrameworkObject.IsGameComplete())
                {
                    this.mvcFrameworkObject.ContinueGame();
                }
                else
                {
                    this.Destroy();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void Initialize()
        {
            // Todo: Probably load the util game Objects from the ResourceLoader at this stage
            // If i even need them at this point
            if (this.mvcFrameworkObject == null)
            {
                RandomNumberGeneratorUtil.BuildRandom();
                ISet<IPhalanxReport> phalanxReports = new HashSet<IPhalanxReport>()
                {
                    new PhalanxReport.Builder()
                        .SetAIType(AIType.Random)
                        .SetControllerType(ControllerType.AI)
                        .SetCustomizationReport(RandomCustomizationReportGenerator.GenerateRandomCustomizationReport())
                        .SetPhalanxCallSign(PhalanxCallSign.Alfa)
                        .SetPhalanxCallSigns(new HashSet<PhalanxCallSign>(){ PhalanxCallSign.Bravo })
                        .SetTalonCallSigns(new HashSet<TalonCallSign>(){ TalonCallSign.Alpha})
                        .Build(),
                    new PhalanxReport.Builder()
                        .SetAIType(AIType.Random)
                        .SetControllerType(ControllerType.AI)
                        .SetCustomizationReport(RandomCustomizationReportGenerator.GenerateRandomCustomizationReport())
                        .SetPhalanxCallSign(PhalanxCallSign.Bravo)
                        .SetPhalanxCallSigns(new HashSet<PhalanxCallSign>(){PhalanxCallSign.Alfa })
                        .SetTalonCallSigns(new HashSet<TalonCallSign>(){ TalonCallSign.Beta})
                        .Build(),
                    new PhalanxReport.Builder()
                        .SetAIType(AIType.Random)
                        .SetControllerType(ControllerType.AI)
                        .SetCustomizationReport(RandomCustomizationReportGenerator.GenerateRandomCustomizationReport())
                        .SetPhalanxCallSign(PhalanxCallSign.Charlie)
                        .SetPhalanxCallSigns(new HashSet<PhalanxCallSign>(){ })
                        .SetTalonCallSigns(new HashSet<TalonCallSign>(){ TalonCallSign.Chi})
                        .Build(),
                    new PhalanxReport.Builder()
                        .SetAIType(AIType.Random)
                        .SetControllerType(ControllerType.AI)
                        .SetCustomizationReport(RandomCustomizationReportGenerator.GenerateRandomCustomizationReport())
                        .SetPhalanxCallSign(PhalanxCallSign.Delta)
                        .SetPhalanxCallSigns(new HashSet<PhalanxCallSign>(){ })
                        .SetTalonCallSigns(new HashSet<TalonCallSign>(){ TalonCallSign.Delta, TalonCallSign.Epsilon})
                        .Build()
                };
                ISet<ITalonConstructionReport> talonConstructionReports = new HashSet<ITalonConstructionReport>();
                foreach (IPhalanxReport phalanxReport in phalanxReports)
                {
                    foreach (TalonCallSign talonCallSign in phalanxReport.GetTalonCallSigns())
                    {
                        talonConstructionReports.Add(new TalonConstructionReport.Builder()
                            .SetTalonCallSign(talonCallSign)
                            .SetCustomizationReport(phalanxReport.GetCustomizationReport())
                            .SetTalonLoadoutReport(RandomTalonLoadoutReportGenerator
                                .GenerateRandomTalonLoadoutReport(EnumUtils.GetRandomEnum<TalonId>()))
                            .Build());
                    }
                }
                // Todo: Load from file or something or have a default
                IViewConfigurationReport viewConfigurationReport = ViewConfigurationReport.DefaultViewConfigurationReport();
                IMvcConstructionReport mvcConstructionReport = new MvcConstructionReport.Builder()
                    .SetMatchType(MatchType.FactionDeathmatch)
                    .SetSimulationType(SimulationType.WhiteBox)
                    .SetGameBoardShape(GameBoardShape.Hexagon)
                    .SetGameBoardLimit(2 + RandomNumberGeneratorUtil.GetNextInt() % 3)
                    .SetMirroredBoard(true)
                    .SetPhalanxReports(phalanxReports)
                    .SetTalonConstructionReports(talonConstructionReports)
                    .SetViewConfigurationReport(viewConfigurationReport)
                    .Build();

                this.mvcFrameworkObject = new MvcFrameworkObject.Builder()
                    .SetMvcConstructionReport(mvcConstructionReport)
                    .Build();
            }
        }
    }
}