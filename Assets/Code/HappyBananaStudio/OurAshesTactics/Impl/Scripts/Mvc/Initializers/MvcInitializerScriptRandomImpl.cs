/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Paints;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Frameworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Initializers
{
    /// <summary>
    /// MvcInitializer Script Random Impl
    /// </summary>
    public class MvcInitializerScriptRandomImpl
    : UnityScript, IMvcInitializerScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSet = new Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>>()
        {
            {
                FactionIdEnum.CreativeFaction1,
                new HashSet<PhalanxIdEnum>()
                {
                    PhalanxIdEnum.PhalanxNorthEast,
                    PhalanxIdEnum.PhalanxSouthEast,
                }
            },
            {
                FactionIdEnum.CreativeFaction2,
                new HashSet<PhalanxIdEnum>()
                {
                    PhalanxIdEnum.PhalanxNorthWest,
                    PhalanxIdEnum.PhalanxSouthWest,
                }
            }
        };

        private readonly int mapRadius = 4;

        // Todo
        private readonly System.Random random = new System.Random();

        // Todo
        private readonly Dictionary<PhalanxIdEnum, IPaintSchemeReport> talonPhalanxIdPaintSchemeReportDictionary =
            new Dictionary<PhalanxIdEnum, IPaintSchemeReport>();

        private IMvcFrameworkScript mvcFrameworkScript;
        private bool foo = false;
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcInitializationReport BuildMvcInitializationReport()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            IMvcInitializationReport mvcInitializationReport = ReportBuilder.Mvc.Initialization.GetBuilder()
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

        private HashSet<CallSignEnum> BuildCallSignSet(int count)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            HashSet<CallSignEnum> callSignSet = new HashSet<CallSignEnum>();

            Array enumValues = Enum.GetValues(typeof(CallSignEnum));
            while (callSignSet.Count != count &&
                callSignSet.Count!= enumValues.Length - 1)
            {
                callSignSet.Add((CallSignEnum)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return callSignSet;
        }

        private HashSet<ICubeCoordinates> BuildCubeCoordinatesSet()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            return CubeCoordinatesGeneratorUtil.GenerateHexagonCubeCoordinatesSet(this.mapRadius);
        }

        private Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> BuildFactionIdPhalanxIdSetDictionary()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSetDictionary = new Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>>();

            int factionCount = this.random.Next(2, 4);

            HashSet<FactionIdEnum> factionIdSet = this.BuildFactionIdSet(factionCount);
            HashSet<PhalanxIdEnum> phalanxIdSet = this.BuildPhalanxIdSet(factionCount);

            foreach (FactionIdEnum factionId in factionIdSet)
            {
                logger.Debug("Adding: ?", factionId);
                factionIdPhalanxIdSetDictionary.Add(factionId, new HashSet<PhalanxIdEnum>());
            }

            int counter = 0;
            foreach (PhalanxIdEnum phalanxId in phalanxIdSet)
            {
                counter++;
                int factionIndex = counter % factionCount;
                FactionIdEnum factionId = new List<FactionIdEnum>(factionIdSet)[factionIndex];
                factionIdPhalanxIdSetDictionary[factionId].Add(phalanxId);
                logger.Debug("Adding: ? to ?", phalanxId, factionId);
            }

            return factionIdPhalanxIdSetDictionary;
        }

        private HashSet<FactionIdEnum> BuildFactionIdSet(int factionCount)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            HashSet<FactionIdEnum> factionIdSet = new HashSet<FactionIdEnum>();

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
            return ReportBuilder.Maps.Game.Construction.GetBuilder()
                .SetCubeCoordinatesSet(this.BuildCubeCoordinatesSet())
                .SetMapMirrored(this.IsMapMirrored())
                .Build();
        }

        private HashSet<PhalanxIdEnum> BuildPhalanxIdSet(int factionCount)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            HashSet<PhalanxIdEnum> phalanxIdSet = new HashSet<PhalanxIdEnum>();

            Array enumValues = Enum.GetValues(typeof(PhalanxIdEnum));
            logger.Debug("PosVals: ?", string.Join(",", enumValues));
            while (phalanxIdSet.Count < factionCount * 2 &&
                phalanxIdSet.Count != enumValues.Length - 1)
            {
                phalanxIdSet.Add((PhalanxIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length)));
            }

            return phalanxIdSet;
        }

        private Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> BuildPhalanxIdTalonConstructionReportDictionaey(
            Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSetDictionary)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> phalanxIdTalonConstructionReportSetDictionary =
                new Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>>();

            int phalanxCount = 0;
            foreach (FactionIdEnum factionId in factionIdPhalanxIdSetDictionary.Keys)
            {
                phalanxCount += factionIdPhalanxIdSetDictionary[factionId].Count;
            }

            int maxTalonCount = phalanxCount * 2;
            foreach (FactionIdEnum factionId in factionIdPhalanxIdSetDictionary.Keys)
            {
                foreach (PhalanxIdEnum phalanxId in factionIdPhalanxIdSetDictionary[factionId])
                {
                    phalanxIdTalonConstructionReportSetDictionary.Add(phalanxId, new HashSet<ITalonConstructionReport>());
                    IPaintSchemeReport paintSchemeReport = ReportBuilder.Paint.GetBuilder()
                        .SetPrimaryPaintColorId(this.GetRandomPaintColorId())
                        .SetSecondaryPaintColorId(this.GetRandomPaintColorId())
                        .SetTertiaryPaintColorId(this.GetRandomPaintColorId())
                        .Build();
                    HashSet<CallSignEnum> callSignSet = this.BuildCallSignSet((int)(maxTalonCount / phalanxCount));
                    foreach (CallSignEnum callSign in callSignSet)
                    {
                        phalanxIdTalonConstructionReportSetDictionary[phalanxId].Add(this.BuildRandomTalonConstructionReport(
                            factionId, phalanxId, callSign, paintSchemeReport));
                    }
                }
            }

            return phalanxIdTalonConstructionReportSetDictionary;
        }

        private IHopliteAttributes BuildRandomHopliteAttributes()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            return AttributesBuilder.Hoplite.GetBuilder()
                .SetControllerId(ControllerIdEnum.Random)
                .SetHopliteTraitSet(new HashSet<HopliteTraitEnum>() { HopliteTraitEnum.HopliteTrait0 })
                .Build();
        }

        private ITalonConstructionReport BuildRandomTalonConstructionReport(FactionIdEnum factionId, PhalanxIdEnum phalanxId,
            CallSignEnum callSign, IPaintSchemeReport paintSchemeReport)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            TalonModelIdEnum talonModelId = this.GetRandomTalonModelId();
            return ReportBuilder.Talon.Construction.GetBuilder()
                .SetHopliteAttributes(this.BuildRandomHopliteAttributes())
                .SetPaintSchemeReport(paintSchemeReport)
                .SetTalonIdentificationReport(ReportBuilder.Talon.Identification.GetBuilder()
                        .SetCallSign(callSign)
                        .SetFactionid(factionId)
                        .SetPhalanxId(phalanxId)
                        .SetTalonId(talonModelId)
                    .Build())
                .SetUtilityList(this.BuildRandomUtilityModelIdList(talonModelId))
                .SetWeaponIdList(this.BuildRandomWeaponModelIdList(talonModelId))
                .Build();
        }

        private List<UtilityModelIdEnum> BuildRandomUtilityModelIdList(TalonModelIdEnum talonModelId)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            int utilityPoints = TalonAttributesConstants.Utility.GetAttributes(talonModelId).GetUtilityPoints();
            List<UtilityModelIdEnum> utilityModelIdList = new List<UtilityModelIdEnum>();

            for (int i = 0; i < utilityPoints; ++i)
            {
                utilityModelIdList.Add(this.GetRandomUtilityModelId());
            }
            return utilityModelIdList;
        }

        private List<WeaponModelIdEnum> BuildRandomWeaponModelIdList(TalonModelIdEnum talonModelId)
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            int weaponPoints = TalonAttributesConstants.Fireable.GetAttributes(talonModelId).GetWeaponPoints();
            List<WeaponModelIdEnum> utilityModelIdList = new List<WeaponModelIdEnum>();
            for (int i = 0; i < weaponPoints; ++i)
            {
                utilityModelIdList.Add(this.GetRandomWeaponModelId());
            }
            return utilityModelIdList;
        }

        private IRosterConstructionReport BuildRosterConstructionReport()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> factionIdPhalanxIdSet = this.BuildFactionIdPhalanxIdSetDictionary();

            return ReportBuilder.Roster.Construction.GetBuilder()
                .SetFactionIdPhalanxIdSetDictionary(factionIdPhalanxIdSet)
                .SetPhalanxIdTalonConstructionReportDictionary(this.BuildPhalanxIdTalonConstructionReportDictionaey(factionIdPhalanxIdSet))
                .Build();
        }

        private PaintColorIdEnum GetRandomPaintColorId()
        {
            logger.Debug("?", new StackFrame().GetMethod().Name);
            Array enumValues = Enum.GetValues(typeof(PaintColorIdEnum));
            return (PaintColorIdEnum)enumValues.GetValue(random.Next(1, enumValues.Length));
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