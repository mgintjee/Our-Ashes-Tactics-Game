/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Constants;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Impl
{
    /// <summary>
    /// MvcInitializer Script Random Impl
    /// </summary>
    public class MvcInitializerScriptRandomImpl
    : MvcInitializerScript
    {
        #region Private Fields

        private readonly System.Random random = new System.Random();

        private readonly HashSet<TalonControllerIdEnum> talonControllerIdSet = new HashSet<TalonControllerIdEnum>()
        {
            TalonControllerIdEnum.Controller1,
            TalonControllerIdEnum.Controller2,
        };

        private readonly HashSet<TalonFactionIdEnum> talonFactionIdSet = new HashSet<TalonFactionIdEnum>()
        {
            TalonFactionIdEnum.CreativeFaction1,
            TalonFactionIdEnum.CreativeFaction2,
        };

        private readonly HashSet<TalonPhalanxIdEnum> talonPhalanxIdSet = new HashSet<TalonPhalanxIdEnum>()
        {
            TalonPhalanxIdEnum.PhalanxNorthEast,
            TalonPhalanxIdEnum.PhalanxSouthEast,
            TalonPhalanxIdEnum.PhalanxNorthWest,
            TalonPhalanxIdEnum.PhalanxSouthWest,
        };

        private bool mapIsMirrored;
        private int mapRadius;
        private Dictionary<TalonPhalanxIdEnum, TalonPaintSchemeReport> talonPhalanxIdPaintSchemeReportDictionary;

        #endregion Private Fields

        #region Public Methods

        public TalonColorIdEnum LoadRandomTalonPaintColor()
        {
            Array enumValues = Enum.GetValues(typeof(TalonColorIdEnum));
            return (TalonColorIdEnum)enumValues.GetValue(random.Next(enumValues.Length));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override MvcInitializationReport BuildMvcInitializationReport()
        {
            this.mapIsMirrored = this.random.Next() % 2 == 0;
            this.mapRadius = this.random.Next(2, 3);
            this.talonPhalanxIdPaintSchemeReportDictionary = this.BuildTalonFactionIdPaintSchemeReportDictionary();
            MvcInitializationReport mvcInitializationReport = new MvcInitializationReport.Builder()
               .SetGameSeed(this.random.Next())
               .SetMapConstructionReport(this.BuildMapConstructionReport())
               .SetRosterContructionReport(this.BuildRosterConstructionReport())
               .Build();
            return mvcInitializationReport;
        }

        #endregion Protected Methods

        #region Private Methods

        private MapConstructionReport BuildMapConstructionReport()
        {
            return new MapConstructionReport.Builder()
                .SetMapMirrored(this.mapIsMirrored)
                .SetMapRadius(this.mapRadius)
                .Build();
        }

        private TalonPaintSchemeReport BuildRandomPaintSchemeReport()
        {
            return new TalonPaintSchemeReport.Builder()
                .SetPrimaryPaintColor(this.LoadRandomTalonPaintColor())
                .SetSecondaryPaintColor(this.LoadRandomTalonPaintColor())
                .Build();
        }

        private TalonConstructionReport BuildRandomTalonConstructionReport(TalonFactionIdEnum talonFactionId, TalonPhalanxIdEnum talonPhalanxId, int talonPhalanxIndex)
        {
            HashSet<TalonIdEnum> talonIdSet = TalonAttributesConstants.GetSupportedTalonIds();
            TalonIdEnum talonId = new List<TalonIdEnum>(talonIdSet)[this.random.Next(talonIdSet.Count)];
            TalonIdentificationReport talonIdentificationReport = new TalonIdentificationReport.Builder()
                .SetTalonFactionId(talonFactionId)
                .SetTalonId(talonId)
                .SetTalonPhalanxId(talonPhalanxId)
                .SetTalonPhalanxIndex(talonPhalanxIndex)
                .Build();
            return new TalonConstructionReport.Builder()
                .SetTalonIdentificationReport(talonIdentificationReport)
                .SetWeaponIdList(this.BuildRandomWeaponIdList(talonId))
                .SetTalonPaintSchemeReport(this.talonPhalanxIdPaintSchemeReportDictionary[talonPhalanxId])
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

        private RosterConstructionReport BuildRosterConstructionReport()
        {
            return new RosterConstructionReport.Builder()
                .SetTalonConstructionReportSet(this.BuildTalonConstructionReportSet())
                .SetTalonControllerIdPhalanxIdSetDictionary(this.BuildTalonControllerIdPhalanxIdSetDictionary())
                .SetTalonFactionIdPhalanxIdSetDictionary(this.BuildTalonFactionIdPhalanxIdSetDictionary())
                .Build();
        }

        private HashSet<TalonConstructionReport> BuildTalonConstructionReportSet()
        {
            HashSet<TalonConstructionReport> talonConstructionReportSet = new HashSet<TalonConstructionReport>();

            int maxTalonOnMap = this.mapRadius * 2;
            int phalanxCount = this.talonPhalanxIdSet.Count;
            int talonPerPhalanx = Mathf.CeilToInt(maxTalonOnMap / phalanxCount);

            Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionPhalanxIdDictionary = this.BuildTalonFactionIdPhalanxIdSetDictionary();
            Dictionary<TalonPhalanxIdEnum, TalonFactionIdEnum> talonPhalanxFactionIdDictionary = new Dictionary<TalonPhalanxIdEnum, TalonFactionIdEnum>();

            foreach (TalonFactionIdEnum talonFactionId in talonFactionPhalanxIdDictionary.Keys)
            {
                foreach (TalonPhalanxIdEnum talonPhalanxId in talonFactionPhalanxIdDictionary[talonFactionId])
                {
                    talonPhalanxFactionIdDictionary.Add(talonPhalanxId, talonFactionId);
                }
            }

            foreach (TalonPhalanxIdEnum talonPhalanxId in this.talonPhalanxIdSet)
            {
                TalonFactionIdEnum talonFactionId = talonPhalanxFactionIdDictionary[talonPhalanxId];

                for (int i = 0; i < talonPerPhalanx; ++i)
                {
                    talonConstructionReportSet.Add(this.BuildRandomTalonConstructionReport(talonFactionId, talonPhalanxId, i));
                }
            }

            return talonConstructionReportSet;
        }

        private Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> BuildTalonControllerIdPhalanxIdSetDictionary()
        {
            Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary =
                new Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>>();

            foreach (TalonControllerIdEnum talonControllerId in this.talonControllerIdSet)
            {
                talonControllerIdPhalanxIdSetDictionary.Add(talonControllerId, new HashSet<TalonPhalanxIdEnum>());
            }

            talonControllerIdPhalanxIdSetDictionary[TalonControllerIdEnum.Controller1].Add(TalonPhalanxIdEnum.PhalanxNorthWest);
            talonControllerIdPhalanxIdSetDictionary[TalonControllerIdEnum.Controller2].Add(TalonPhalanxIdEnum.PhalanxSouthWest);
            talonControllerIdPhalanxIdSetDictionary[TalonControllerIdEnum.Controller1].Add(TalonPhalanxIdEnum.PhalanxNorthEast);
            talonControllerIdPhalanxIdSetDictionary[TalonControllerIdEnum.Controller2].Add(TalonPhalanxIdEnum.PhalanxSouthEast);

            return talonControllerIdPhalanxIdSetDictionary;
        }

        private Dictionary<TalonPhalanxIdEnum, TalonPaintSchemeReport> BuildTalonFactionIdPaintSchemeReportDictionary()
        {
            Dictionary<TalonPhalanxIdEnum, TalonPaintSchemeReport> talonFactionIdPaintSchemeReportDictionary = new Dictionary<TalonPhalanxIdEnum, TalonPaintSchemeReport>();

            foreach (TalonPhalanxIdEnum talonPhalanxId in this.talonPhalanxIdSet)
            {
                talonFactionIdPaintSchemeReportDictionary.Add(talonPhalanxId, this.BuildRandomPaintSchemeReport());
            }
            return talonFactionIdPaintSchemeReportDictionary;
        }

        private Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> BuildTalonFactionIdPhalanxIdSetDictionary()
        {
            Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary =
                new Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>>();

            foreach (TalonFactionIdEnum talonFactionId in this.talonFactionIdSet)
            {
                talonFactionIdPhalanxIdSetDictionary.Add(talonFactionId, new HashSet<TalonPhalanxIdEnum>());
            }
            // Todo: think of a good way to randomize this
            talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction1].Add(TalonPhalanxIdEnum.PhalanxNorthWest);
            talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction1].Add(TalonPhalanxIdEnum.PhalanxNorthEast);
            talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction2].Add(TalonPhalanxIdEnum.PhalanxSouthWest);
            talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction2].Add(TalonPhalanxIdEnum.PhalanxSouthEast);

            return talonFactionIdPhalanxIdSetDictionary;
        }

        #endregion Private Methods
    }
}