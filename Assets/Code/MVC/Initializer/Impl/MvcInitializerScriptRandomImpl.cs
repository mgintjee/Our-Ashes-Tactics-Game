using System;
using System.Collections.Generic;
using UnityEngine;

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
    private int mapSeed;
    private Dictionary<TalonFactionIdEnum, TalonPaintSchemeReport> talonFactionIdPaintSchemeReportDictionary;

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
        this.mapSeed = this.random.Next();
        talonFactionIdPaintSchemeReportDictionary = this.BuildTalonFactionIdPaintSchemeReportDictionary();
        MvcInitializationReport mvcInitializationReport = new MvcInitializationReport.Builder()
           .SetMapInformationReport(this.BuildMapConstructionReport())
           .SetTalonConstructionReportSet(this.BuildTalonConstructionReportSet())
           .SetTalonControllerIdPhalanxIdSetDictionary(this.BuildTalonControllerIdPhalanxIdSetDictionary())
           .SetTalonFactionIdPhalanxIdSetDictionary(this.BuildTalonFactionIdPhalanxIdSetDictionary())
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
            .SetMapSeed(this.mapSeed)
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
        TalonIdEnum talonId = TalonIdEnum.CreativeName1;
        TalonIdentificationReport talonIdentificationReport = new TalonIdentificationReport.Builder()
            .SetTalonFactionId(talonFactionId)
            .SetTalonId(talonId)
            .SetTalonPhalanxId(talonPhalanxId)
            .SetTalonPhalanxIndex(talonPhalanxIndex)
            .Build();
        return new TalonConstructionReport.Builder()
            .SetTalonIdentificationReport(talonIdentificationReport)
            .SetWeaponIdList(this.BuildRandomWeaponIdList(talonId))
            .SetTalonPaintSchemeReport(this.talonFactionIdPaintSchemeReportDictionary[talonFactionId])
            .Build();
    }

    private List<WeaponIdEnum> BuildRandomWeaponIdList(TalonIdEnum talonId)
    {
        List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();
        TalonAttributes talonAttributes = TalonAttributesConstants.GetAttributes(talonId);
        for (int i = 0; i < talonAttributes.GetWeaponPoints(); ++i)
        {
            weaponIdList.Add(WeaponIdEnum.CreativeName1);
        }
        return weaponIdList;
    }

    private HashSet<TalonConstructionReport> BuildTalonConstructionReportSet()
    {
        HashSet<TalonConstructionReport> talonConstructionReportSet = new HashSet<TalonConstructionReport>();

        int maxTalonOnMap = this.mapRadius * 2;
        int phalanxCount = this.talonPhalanxIdSet.Count;
        int talonPerPhalanx = Mathf.CeilToInt(maxTalonOnMap / phalanxCount);

        foreach (TalonPhalanxIdEnum talonPhalanxId in this.talonPhalanxIdSet)
        {
            TalonFactionIdEnum talonFactionId = (talonPhalanxId.Equals(TalonPhalanxIdEnum.PhalanxNorthWest) ||
                talonPhalanxId.Equals(TalonPhalanxIdEnum.PhalanxSouthWest))
                ? TalonFactionIdEnum.CreativeFaction1
                : TalonFactionIdEnum.CreativeFaction2;

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
        talonControllerIdPhalanxIdSetDictionary[TalonControllerIdEnum.Controller1].Add(TalonPhalanxIdEnum.PhalanxSouthWest);
        talonControllerIdPhalanxIdSetDictionary[TalonControllerIdEnum.Controller2].Add(TalonPhalanxIdEnum.PhalanxNorthEast);
        talonControllerIdPhalanxIdSetDictionary[TalonControllerIdEnum.Controller2].Add(TalonPhalanxIdEnum.PhalanxSouthEast);

        return talonControllerIdPhalanxIdSetDictionary;
    }

    private Dictionary<TalonFactionIdEnum, TalonPaintSchemeReport> BuildTalonFactionIdPaintSchemeReportDictionary()
    {
        Dictionary<TalonFactionIdEnum, TalonPaintSchemeReport> talonFactionIdPaintSchemeReportDictionary = new Dictionary<TalonFactionIdEnum, TalonPaintSchemeReport>();

        foreach (TalonFactionIdEnum talonFactionId in this.talonFactionIdSet)
        {
            talonFactionIdPaintSchemeReportDictionary.Add(talonFactionId, this.BuildRandomPaintSchemeReport());
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

        talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction1].Add(TalonPhalanxIdEnum.PhalanxNorthWest);
        talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction1].Add(TalonPhalanxIdEnum.PhalanxSouthWest);
        talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction2].Add(TalonPhalanxIdEnum.PhalanxNorthEast);
        talonFactionIdPhalanxIdSetDictionary[TalonFactionIdEnum.CreativeFaction2].Add(TalonPhalanxIdEnum.PhalanxSouthEast);

        return talonFactionIdPhalanxIdSetDictionary;
    }

    #endregion Private Methods
}