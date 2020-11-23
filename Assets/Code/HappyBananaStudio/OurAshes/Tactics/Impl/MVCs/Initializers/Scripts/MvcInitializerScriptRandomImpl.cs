namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Initializers.Scripts
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Unity.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Hoplites;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Color;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Frameworks.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Constuction;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Information;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// MvcInitializer Script Random Impl
    /// </summary>
    public class MvcInitializerScriptRandomImpl
    : AbstractUnityScriptImpl, IMvcInitializerScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSet = new Dictionary<FactionId, ISet<PhalanxId>>()
        {
            {
                FactionId.CreativeFaction1,
                new HashSet<PhalanxId>()
                {
                    PhalanxId.Charlie,
                    PhalanxId.Echo,
                }
            },
            {
                FactionId.CreativeFaction2,
                new HashSet<PhalanxId>()
                {
                    PhalanxId.Delta,
                    PhalanxId.Foxtrot,
                }
            }
        };

        // Todo
        private readonly System.Random random = new System.Random();

        // Todo
        private readonly IDictionary<PhalanxId, IColorSchemeReport> talonPhalanxIdPaintSchemeReportIDictionary =
            new Dictionary<PhalanxId, IColorSchemeReport>();

        private bool foo = false;
        private IMvcFrameworkScript mvcFrameworkScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcInitializationReport BuildMvcInitializationReport()
        {
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

        private ISet<CallSign> BuildCallSignSet(int count)
        {
            ISet<CallSign> callSignSet = new HashSet<CallSign>();

            Array enumValues = Enum.GetValues(typeof(CallSign));
            while (callSignSet.Count != count &&
                callSignSet.Count != enumValues.Length - 1)
            {
                callSignSet.Add((CallSign)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return callSignSet;
        }

        private ISet<ICubeCoordinates> BuildCubeCoordinatesSet()
        {
            return;
        }

        private IDictionary<FactionId, ISet<PhalanxId>> BuildFactionIdPhalanxIdSetIDictionary()
        {
            IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetIDictionary = new Dictionary<FactionId, ISet<PhalanxId>>();

            int factionCount = this.random.Next(2, 4);

            ISet<FactionId> factionIdSet = this.BuildFactionIdSet(factionCount);
            ISet<PhalanxId> phalanxIdSet = this.BuildPhalanxIdSet(factionCount);

            foreach (FactionId factionId in factionIdSet)
            {
                logger.Debug("Adding: ?", factionId);
                factionIdPhalanxIdSetIDictionary.Add(factionId, new HashSet<PhalanxId>());
            }

            int counter = 0;
            foreach (PhalanxId phalanxId in phalanxIdSet)
            {
                counter++;
                int factionIndex = counter % factionCount;
                FactionId factionId = new List<FactionId>(factionIdSet)[factionIndex];
                factionIdPhalanxIdSetIDictionary[factionId].Add(phalanxId);
                logger.Debug("Adding: ? to ?", phalanxId, factionId);
            }

            return factionIdPhalanxIdSetIDictionary;
        }

        private ISet<FactionId> BuildFactionIdSet(int factionCount)
        {
            ISet<FactionId> factionIdSet = new HashSet<FactionId>();

            Array enumValues = Enum.GetValues(typeof(FactionId));
            while (factionIdSet.Count < factionCount &&
                factionIdSet.Count != enumValues.Length - 1)
            {
                factionIdSet.Add((FactionId)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return factionIdSet;
        }

        private IGameMapConstructionReport BuildGameMapConstructionReport()
        {
            return new GameMapConstructionReportImpl.Builder()
                .SetCubeCoordinatesSet(this.BuildCubeCoordinatesSet())
                .SetMapMirrored(this.IsMapMirrored())
                .Build();
        }

        private ISet<PhalanxId> BuildPhalanxIdSet(int factionCount)
        {
            ISet<PhalanxId> phalanxIdSet = new HashSet<PhalanxId>();

            Array enumValues = Enum.GetValues(typeof(PhalanxId));
            while (phalanxIdSet.Count < factionCount * 2 &&
                phalanxIdSet.Count != enumValues.Length - 1)
            {
                phalanxIdSet.Add((PhalanxId)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return phalanxIdSet;
        }

        private IDictionary<PhalanxId, ISet<ITalonConstructionReport>> BuildPhalanxIdTalonConstructionReportDictionaey(
            IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetIDictionary)
        {
            IDictionary<PhalanxId, ISet<ITalonConstructionReport>> phalanxIdTalonConstructionReportSetIDictionary =
                new Dictionary<PhalanxId, ISet<ITalonConstructionReport>>();

            int phalanxCount = 0;
            foreach (FactionId factionId in factionIdPhalanxIdSetIDictionary.Keys)
            {
                phalanxCount += factionIdPhalanxIdSetIDictionary[factionId].Count;
            }

            int maxTalonCount = phalanxCount * 2;
            foreach (FactionId factionId in factionIdPhalanxIdSetIDictionary.Keys)
            {
                IColorSchemeReport factionColorSchemeReport = FactionSchemeConstants.GetFactionColorSchemeReport(factionId);
                IEmblemSchemeReport factionEmblemSchemeReport = FactionSchemeConstants.GetFactionEmblemSchemeReport(factionId);

                foreach (PhalanxId phalanxId in factionIdPhalanxIdSetIDictionary[factionId])
                {
                    IEmblemSchemeReport phalanxEmblemSchemeReport = new EmblemSchemeReportImpl.Builder()
                                .SetBackgroundId(this.GetRandomEmblemSpriteId())
                                .SetForeground(this.GetRandomEmblemSpriteId())
                                .SetIconId(this.GetRandomEmblemSpriteId())
                                .Build();
                    IColorSchemeReport phalanxColorSchemeReport = new ColorSchemeReportImpl.Builder()
                                .SetPrimaryColorId(this.GetRandomPaintColorId())
                                .SetSecondaryColorId(this.GetRandomPaintColorId())
                                .SetTertiaryColorId(this.GetRandomPaintColorId())
                                .Build();
                    phalanxIdTalonConstructionReportSetIDictionary.Add(phalanxId, new HashSet<ITalonConstructionReport>());
                    ISet<CallSign> callSignSet = this.BuildCallSignSet((int)(maxTalonCount / phalanxCount));
                    foreach (CallSign callSign in callSignSet)
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
            return new HopliteConstructionReportImpl.Builder()
                .SetControllerId(ControllerType.Random)
                .SetHopliteTraitSet(new HashSet<HopliteTraitEnum>() { HopliteTraitEnum.Default })
                .Build();
        }

        private ITalonConstructionReport BuildRandomTalonConstructionReport(FactionId factionId, PhalanxId phalanxId,
            CallSign callSign, ITalonCustomizationReport talonCustomizationReport)
        {
            TalonModelId talonModelId = this.GetRandomTalonModelId();
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

        private IList<UtilityModelId> BuildRandomUtilityModelIdList(TalonModelId talonModelId)
        {
            int utilityPoints = TalonAttributesConstants.GetAttributes(talonModelId).GetMountableAttributes().GetUtilityMountPoints();
            IList<UtilityModelId> utilityModelIdList = new List<UtilityModelId>();

            for (int i = 0; i < utilityPoints; ++i)
            {
                utilityModelIdList.Add(this.GetRandomUtilityModelId());
            }
            return utilityModelIdList;
        }

        private IList<WeaponModelId> BuildRandomWeaponModelIdList(TalonModelId talonModelId)
        {
            int weaponPoints = TalonAttributesConstants.GetAttributes(talonModelId).GetMountableAttributes().GetWeaponMountPoints();

            IList<WeaponModelId> utilityModelIdList = new List<WeaponModelId>();
            for (int i = 0; i < weaponPoints; ++i)
            {
                utilityModelIdList.Add(this.GetRandomWeaponModelId());
            }
            return utilityModelIdList;
        }

        private IRosterConstructionReport BuildRosterConstructionReport()
        {
            IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSet = this.BuildFactionIdPhalanxIdSetIDictionary();

            return new RosterConstructionReportImpl.Builder()
                .SetFactionIdPhalanxIdSetDictionary(factionIdPhalanxIdSet)
                .SetPhalanxIdTalonConstructionReportDictionary(this.BuildPhalanxIdTalonConstructionReportDictionaey(factionIdPhalanxIdSet))
                .Build();
        }

        private EmblemSpriteIdEnum GetRandomEmblemSpriteId()
        {
            Array enumValues = Enum.GetValues(typeof(EmblemSpriteIdEnum));
            return (EmblemSpriteIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private ColorIdEnum GetRandomPaintColorId()
        {
            Array enumValues = Enum.GetValues(typeof(ColorIdEnum));
            return (ColorIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
        }

        private bool IsMapMirrored()
        {
            return this.random.Next() % 2 == 0;
        }
    }
}