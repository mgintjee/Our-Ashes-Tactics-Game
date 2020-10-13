/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
namespace HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Initializers
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Schemes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Mvc.Frameworks;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Schemes.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Maps.Game;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Mvc.Initializers;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Rosters;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Customization;
    using HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Frameworks;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// MvcInitializer Script Random Impl
    /// </summary>
    public class MvcInitializerScriptRandomImpl
    : UnityScriptImpl, IMvcInitializerScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSet = new Dictionary<FactionIdEnum, ISet<PhalanxIdEnum>>()
        {
            {
                FactionIdEnum.CreativeFaction1,
                new HashSet<PhalanxIdEnum>()
                {
                    PhalanxIdEnum.Charlie,
                    PhalanxIdEnum.Echo,
                }
            },
            {
                FactionIdEnum.CreativeFaction2,
                new HashSet<PhalanxIdEnum>()
                {
                    PhalanxIdEnum.Delta,
                    PhalanxIdEnum.Foxtrot,
                }
            }
        };

        private readonly int mapRadius = 4;

        // Todo
        private readonly System.Random random = new System.Random();

        // Todo
        private readonly IDictionary<PhalanxIdEnum, IColorSchemeReport> talonPhalanxIdPaintSchemeReportIDictionary =
            new Dictionary<PhalanxIdEnum, IColorSchemeReport>();

        private bool foo = false;
        private IMvcFrameworkScript mvcFrameworkScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcInitializationReport BuildMvcInitializationReport()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            IMvcInitializationReport mvcInitializationReport = new MvcInitializationReportImpl.Builder()
               .SetGameRNGSeed(this.random.Next())
               .SetGameMapConstructionReport(this.BuildGameMapConstructionReport())
               .SetRosterConstructionReport(this.BuildRosterConstructionReport())
               .Build();
            logger.Info("Building ?", mvcInitializationReport);
            return mvcInitializationReport;
        }

        public void FixedUpdate()
        {
            if (!foo)
            {
                if (this.mvcFrameworkScript != null)
                {
                    if (!this.mvcFrameworkScript.IsInitialized())
                    {
                        foo = true;
                        this.mvcFrameworkScript.Initialize(this.BuildMvcInitializationReport());
                    }
                }
            }
        }

        public void Start()
        {
            GameObject mvcFrameworkGameObject = new GameObject(MvcFrameworkConstants.Script.GetMvcFrameworkGameObjectName());
            IMvcFrameworkScript mvcFrameworkScript = mvcFrameworkGameObject.AddComponent<MvcFrameworkScriptImpl>();
            mvcFrameworkScript.GetTransform().SetParent(this.GetTransform());
            this.mvcFrameworkScript = mvcFrameworkScript;
        }

        private ISet<CallSignEnum> BuildCallSignSet(int count)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            ISet<CallSignEnum> callSignSet = new HashSet<CallSignEnum>();

            Array enumValues = Enum.GetValues(typeof(CallSignEnum));
            while (callSignSet.Count != count &&
                callSignSet.Count != enumValues.Length - 1)
            {
                callSignSet.Add((CallSignEnum)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return callSignSet;
        }

        private ISet<ICubeCoordinates> BuildCubeCoordinatesSet()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            return CubeCoordinatesGeneratorUtil.GenerateHexagonCubeCoordinatesSet(this.random.Next(2, 4));
        }

        private IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> BuildFactionIdPhalanxIdSetIDictionary()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSetIDictionary = new Dictionary<FactionIdEnum, ISet<PhalanxIdEnum>>();

            int factionCount = this.random.Next(2, 4);

            ISet<FactionIdEnum> factionIdSet = this.BuildFactionIdSet(factionCount);
            ISet<PhalanxIdEnum> phalanxIdSet = this.BuildPhalanxIdSet(factionCount);

            foreach (FactionIdEnum factionId in factionIdSet)
            {
                logger.Debug("Adding: ?", factionId);
                factionIdPhalanxIdSetIDictionary.Add(factionId, new HashSet<PhalanxIdEnum>());
            }

            int counter = 0;
            foreach (PhalanxIdEnum phalanxId in phalanxIdSet)
            {
                counter++;
                int factionIndex = counter % factionCount;
                FactionIdEnum factionId = new List<FactionIdEnum>(factionIdSet)[factionIndex];
                factionIdPhalanxIdSetIDictionary[factionId].Add(phalanxId);
                logger.Debug("Adding: ? to ?", phalanxId, factionId);
            }

            return factionIdPhalanxIdSetIDictionary;
        }

        private ISet<FactionIdEnum> BuildFactionIdSet(int factionCount)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            ISet<FactionIdEnum> factionIdSet = new HashSet<FactionIdEnum>();

            Array enumValues = Enum.GetValues(typeof(FactionIdEnum));
            while (factionIdSet.Count < factionCount &&
                factionIdSet.Count != enumValues.Length - 1)
            {
                factionIdSet.Add((FactionIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return factionIdSet;
        }

        private IGameMapConstructionReport BuildGameMapConstructionReport()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            return new GameMapConstructionReportImpl.Builder()
                .SetCubeCoordinatesSet(this.BuildCubeCoordinatesSet())
                .SetMapMirrored(this.IsMapMirrored())
                .Build();
        }

        private ISet<PhalanxIdEnum> BuildPhalanxIdSet(int factionCount)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            ISet<PhalanxIdEnum> phalanxIdSet = new HashSet<PhalanxIdEnum>();

            Array enumValues = Enum.GetValues(typeof(PhalanxIdEnum));
            logger.Debug("PosVals: ?", string.Join(",", enumValues));
            while (phalanxIdSet.Count < factionCount * 2 &&
                phalanxIdSet.Count != enumValues.Length - 1)
            {
                phalanxIdSet.Add((PhalanxIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return phalanxIdSet;
        }

        private IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> BuildPhalanxIdTalonConstructionReportDictionaey(
            IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSetIDictionary)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportSetIDictionary =
                new Dictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>>();

            int phalanxCount = 0;
            foreach (FactionIdEnum factionId in factionIdPhalanxIdSetIDictionary.Keys)
            {
                phalanxCount += factionIdPhalanxIdSetIDictionary[factionId].Count;
            }

            int maxTalonCount = phalanxCount * 2;
            foreach (FactionIdEnum factionId in factionIdPhalanxIdSetIDictionary.Keys)
            {
                IColorSchemeReport factionColorSchemeReport = FactionSchemeConstants.GetFactionColorSchemeReport(factionId);
                IEmblemSchemeReport factionEmblemSchemeReport = FactionSchemeConstants.GetFactionEmblemSchemeReport(factionId);

                foreach (PhalanxIdEnum phalanxId in factionIdPhalanxIdSetIDictionary[factionId])
                {
                    IEmblemSchemeReport phalanxEmblemSchemeReport = new EmblemSchemeReportImpl.Builder()
                                .SetEmblemIconId(this.GetRandomEmblemIconId())
                                .SetEmblemBackgroundId(this.GetRandomEmblemBackgroundId())
                                .Build();
                    IColorSchemeReport phalanxColorSchemeReport = new ColorSchemeReportImpl.Builder()
                                .SetPrimaryColorId(this.GetRandomPaintColorId())
                                .SetSecondaryColorId(this.GetRandomPaintColorId())
                                .SetTertiaryColorId(this.GetRandomPaintColorId())
                                .Build();
                    phalanxIdTalonConstructionReportSetIDictionary.Add(phalanxId, new HashSet<ITalonConstructionReport>());
                    ISet<CallSignEnum> callSignSet = this.BuildCallSignSet((int)(maxTalonCount / phalanxCount));
                    foreach (CallSignEnum callSign in callSignSet)
                    {
                        phalanxIdTalonConstructionReportSetIDictionary[phalanxId].Add(
                            this.BuildRandomTalonConstructionReport(
                            factionId, phalanxId, callSign, new TalonCustomizationReportImpl.Builder()
                            .SetFactionColorSchemeReport(factionColorSchemeReport)
                            .SetFactionEmblemSchemeReport(factionEmblemSchemeReport)
                            .SetPhalanxColorSchemeReport(phalanxColorSchemeReport)
                            .SetPhalanxEmblemSchemeReoprt(phalanxEmblemSchemeReport)
                            .Build()
                            ));
                    }
                }
            }

            return phalanxIdTalonConstructionReportSetIDictionary;
        }

        private IHopliteConstructionReport BuildRandomHopliteConstructionReport()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            return new HopliteConstructionReportImpl.Builder()
                .SetControllerId(ControllerIdEnum.Random)
                .SetHopliteTraitSet(new HashSet<HopliteTraitEnum>() { HopliteTraitEnum.Default })
                .Build();
        }

        private ITalonConstructionReport BuildRandomTalonConstructionReport(FactionIdEnum factionId, PhalanxIdEnum phalanxId,
            CallSignEnum callSign, ITalonCustomizationReport talonCustomizationReport)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            TalonModelIdEnum talonModelId = this.GetRandomTalonModelId();
            return new TalonConstructionReportImpl.Builder()
                .SetHopliteConstructionReport(this.BuildRandomHopliteConstructionReport())
                .SetTalonCustomizationReport(talonCustomizationReport)
                .SetTalonIdentificationReport(new TalonIdentificationReportImpl.Builder()
                        .SetCallSign(callSign)
                        .SetFactionId(factionId)
                        .SetPhalanxId(phalanxId)
                        .SetTalonModelId(talonModelId)
                    .Build())
                .SetUtilityList(this.BuildRandomUtilityModelIdList(talonModelId))
                .SetWeaponIdList(this.BuildRandomWeaponModelIdList(talonModelId))
                .Build();
        }

        private IList<UtilityModelIdEnum> BuildRandomUtilityModelIdList(TalonModelIdEnum talonModelId)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            int utilityPoints = TalonAttributesConstants.GetAttributes(talonModelId).GetMountableAttributes().GetUtilityMountPoints();
            IList<UtilityModelIdEnum> utilityModelIdList = new List<UtilityModelIdEnum>();

            for (int i = 0; i < utilityPoints; ++i)
            {
                utilityModelIdList.Add(this.GetRandomUtilityModelId());
            }
            return utilityModelIdList;
        }

        private IList<WeaponModelIdEnum> BuildRandomWeaponModelIdList(TalonModelIdEnum talonModelId)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            int weaponPoints = TalonAttributesConstants.GetAttributes(talonModelId).GetMountableAttributes().GetWeaponMountPoints();

            IList<WeaponModelIdEnum> utilityModelIdList = new List<WeaponModelIdEnum>();
            for (int i = 0; i < weaponPoints; ++i)
            {
                utilityModelIdList.Add(this.GetRandomWeaponModelId());
            }
            return utilityModelIdList;
        }

        private IRosterConstructionReport BuildRosterConstructionReport()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> factionIdPhalanxIdSet = this.BuildFactionIdPhalanxIdSetIDictionary();

            return new RosterConstructionReportImpl.Builder()
                .SetFactionIdPhalanxIdSetIDictionary(factionIdPhalanxIdSet)
                .SetPhalanxIdTalonConstructionReportIDictionary(this.BuildPhalanxIdTalonConstructionReportDictionaey(factionIdPhalanxIdSet))
                .Build();
        }

        private EmblemBackgroundIdEnum GetRandomEmblemBackgroundId()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Array enumValues = Enum.GetValues(typeof(EmblemBackgroundIdEnum));
            return (EmblemBackgroundIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private EmblemIconIdEnum GetRandomEmblemIconId()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Array enumValues = Enum.GetValues(typeof(EmblemIconIdEnum));
            return (EmblemIconIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private ColorIdEnum GetRandomPaintColorId()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Array enumValues = Enum.GetValues(typeof(ColorIdEnum));
            return (ColorIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private TalonModelIdEnum GetRandomTalonModelId()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Array enumValues = Enum.GetValues(typeof(TalonModelIdEnum));
            return (TalonModelIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private UtilityModelIdEnum GetRandomUtilityModelId()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Array enumValues = Enum.GetValues(typeof(UtilityModelIdEnum));
            return (UtilityModelIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private WeaponModelIdEnum GetRandomWeaponModelId()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Array enumValues = Enum.GetValues(typeof(WeaponModelIdEnum));
            return (WeaponModelIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private bool IsMapMirrored()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            return this.random.Next() % 2 == 0;
        }
    }
}
