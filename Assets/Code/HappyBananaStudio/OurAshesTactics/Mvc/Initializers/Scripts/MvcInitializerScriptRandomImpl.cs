/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Paints;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Mvc.Initializers.Scripts
{
    /// <summary>
    /// MvcInitializer Script Random Impl
    /// </summary>
    public class MvcInitializerScriptRandomImpl
    : UnityScript, IMvcInitializerScript
    {
        // Todo
        private readonly System.Random random = new System.Random();
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
        private bool mapIsMirrored;

        // Todo
        private Dictionary<PhalanxIdEnum, IPaintSchemeReport> talonPhalanxIdPaintSchemeReportDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcInitializationReport BuildMvcInitializationReport()
        {
            this.mapIsMirrored = this.random.Next() % 2 == 0;
            this.talonPhalanxIdPaintSchemeReportDictionary = this.BuildTalonFactionIdPaintSchemeReportDictionary();
            IMvcInitializationReport mvcInitializationReport = ReportBuilder.Mvc.Initialization.GetBuilder()
               .SetGameRNGSeed(this.random.Next())
               .SetGameMapConstructionReport(this.BuildMapConstructionReport())
               .SetRosterConstructionReport(this.BuildRosterConstructionReport())
               .Build();
            return mvcInitializationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public PaintColorIdEnum LoadRandomTalonPaintColor()
        {
            Array enumValues = Enum.GetValues(typeof(PaintColorIdEnum));
            return (PaintColorIdEnum)enumValues.GetValue(random.Next(enumValues.Length));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private IGameMapConstructionReport BuildMapConstructionReport()
        {
            // Todo: Generate Set: CubeCoordinates
            return ReportBuilder.Maps.Game.Construction.GetBuilder()
                .SetMapMirrored(this.mapIsMirrored)
                .SetCubeCoordinatesSet(this.BuildCubeCoordinatesSet())
                .Build();
        }

        private HashSet<ICubeCoordinates> BuildCubeCoordinatesSet()
        {
            return CubeCoordinatesGeneratorUtil.GenerateCubeCoordinatesSet(this.mapRadius);
        }

        private ITalonConstructionReport BuildRandomTalonConstructionReport(FactionIdEnum talonFactionId, PhalanxIdEnum talonPhalanxId, CallSignEnum callSign)
        {
            HashSet<TalonIdEnum> talonIdSet = TalonAttributesConstants.GetSupportedTalonIds();
            TalonIdEnum talonId = new List<TalonIdEnum>(talonIdSet)[this.random.Next(talonIdSet.Count)];
            ITalonIdentificationReport talonIdentificationReport = ReportBuilder.Talon.Identification.GetBuilder()
                .SetFactionid(talonFactionId)
                .SetTalonId(talonId)
                .SetPhalanxId(talonPhalanxId)
                .SetCallSign(callSign)
                .Build();
            return ReportBuilder.Talon.Construction.GetBuilder()
                .SetTalonIdentificationReport(talonIdentificationReport)
                .SetWeaponIdList(this.BuildRandomWeaponIdList(talonId))
                .SetPaintSchemeReport(this.talonPhalanxIdPaintSchemeReportDictionary[talonPhalanxId])
                .Build();
        }

        private List<WeaponIdEnum> BuildRandomWeaponIdList(TalonIdEnum talonId)
        {
            List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();
            ITalonAttributes talonAttributes = TalonAttributesConstants.GetAttributes(talonId);
            HashSet<WeaponIdEnum> weaponIdSet = WeaponAttributesConstants.GetSupportedWeaponIds();
            for (int i = 0; i < talonAttributes.GetFireableAttributes().GetWeaponPoints(); ++i)
            {
                weaponIdList.Add(new List<WeaponIdEnum>(weaponIdSet)[this.random.Next(weaponIdSet.Count)]);
            }
            return weaponIdList;
        }

        private IRosterConstructionReport BuildRosterConstructionReport()
        {
            return ReportBuilder.Roster.Construction.GetBuilder()
                .SetFactionIdPhalanxIdSetDictionary(this.factionIdPhalanxIdSet)
                .SetPhalanxIdTalonConstructionReportDictionary(this.BuildPhalanxIdTalonConstructionReportDictionary())
                .Build();
        }

        private Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> BuildPhalanxIdTalonConstructionReportDictionary()
        {
            Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> phalanxIdTalonConstructionReportDictionary = new Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>>();

            foreach(FactionIdEnum factionId in this.factionIdPhalanxIdSet.Keys)
            {
                foreach (PhalanxIdEnum phalanxId in this.factionIdPhalanxIdSet[factionId])
                {
                    HashSet<ITalonConstructionReport> talonConstructionReportSet = new HashSet<ITalonConstructionReport>();
                    ITalonConstructionReport talonConstructionReport = this.BuildRandomTalonConstructionReport();
                    phalanxIdTalonConstructionReportDictionary.Add(phalanxId, newtalonConstructionReportSet);
                }
            }

            return phalanxIdTalonConstructionReportDictionary;
        }

        private HashSet<ITalonConstructionReport> BuildTalonConstructionReportSet()
        {
            HashSet<ITalonConstructionReport> talonConstructionReportSet = new HashSet<ITalonConstructionReport>();

            int maxTalonOnMap = this.mapRadius * 2;
            int talonPerPhalanx = Mathf.CeilToInt(maxTalonOnMap / phalanxCount);

            Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> talonFactionPhalanxIdDictionary = this.BuildTalonFactionIdPhalanxIdSetDictionary();
            Dictionary<PhalanxIdEnum, FactionIdEnum> talonPhalanxFactionIdDictionary = new Dictionary<PhalanxIdEnum, FactionIdEnum>();

            foreach (FactionIdEnum talonFactionId in talonFactionPhalanxIdDictionary.Keys)
            {
                foreach (PhalanxIdEnum talonPhalanxId in talonFactionPhalanxIdDictionary[talonFactionId])
                {
                    talonPhalanxFactionIdDictionary.Add(talonPhalanxId, talonFactionId);
                }
            }

            foreach (PhalanxIdEnum talonPhalanxId in this.talonPhalanxIdSet)
            {
                FactionIdEnum talonFactionId = talonPhalanxFactionIdDictionary[talonPhalanxId];

                for (int i = 0; i < talonPerPhalanx; ++i)
                {
                    talonConstructionReportSet.Add(this.BuildRandomTalonConstructionReport(talonFactionId, talonPhalanxId, i));
                }
            }

            return talonConstructionReportSet;
        }

        private Dictionary<PhalanxIdEnum, IPaintSchemeReport> BuildTalonFactionIdPaintSchemeReportDictionary()
        {
            Dictionary<PhalanxIdEnum, IPaintSchemeReport> talonFactionIdPaintSchemeReportDictionary = new Dictionary<PhalanxIdEnum, IPaintSchemeReport>();

            HashSet<PhalanxIdEnum> phalanxIdSet = new HashSet<PhalanxIdEnum>();

            foreach (FactionIdEnum factionId in this.factionIdPhalanxIdSet.Keys)
            {
                foreach (PhalanxIdEnum phalanxId in this.factionIdPhalanxIdSet[factionId])
                {
                    phalanxIdSet.Add(phalanxId);
                }
            }
            foreach (PhalanxIdEnum talonPhalanxId in phalanxIdSet)
            {
                talonFactionIdPaintSchemeReportDictionary.Add(talonPhalanxId, this.BuildRandomPaintSchemeReport());
            }
            return talonFactionIdPaintSchemeReportDictionary;
        }

        private IPaintSchemeReport BuildRandomPaintSchemeReport()
        {
            return ReportBuilder.Paint.GetBuilder()
                .SetPrimaryPaintColorId(this.LoadRandomTalonPaintColor())
                .SetSecondaryPaintColorId(this.LoadRandomTalonPaintColor())
                .SetTertiaryPaintColorId(this.LoadRandomTalonPaintColor())
                .Build();
        }

        private Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> BuildTalonFactionIdPhalanxIdSetDictionary()
        {
            Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary =
                new Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>>();

            foreach (FactionIdEnum talonFactionId in this.factionIdPhalanxIdSet.Keys)
            {
                talonFactionIdPhalanxIdSetDictionary.Add(talonFactionId, new HashSet<PhalanxIdEnum>());
            }
            // Todo: think of a good way to randomize this
            talonFactionIdPhalanxIdSetDictionary[FactionIdEnum.CreativeFaction1].Add(PhalanxIdEnum.PhalanxNorthWest);
            talonFactionIdPhalanxIdSetDictionary[FactionIdEnum.CreativeFaction1].Add(PhalanxIdEnum.PhalanxNorthEast);
            talonFactionIdPhalanxIdSetDictionary[FactionIdEnum.CreativeFaction2].Add(PhalanxIdEnum.PhalanxSouthWest);
            talonFactionIdPhalanxIdSetDictionary[FactionIdEnum.CreativeFaction2].Add(PhalanxIdEnum.PhalanxSouthEast);

            return talonFactionIdPhalanxIdSetDictionary;
        }
    }
}