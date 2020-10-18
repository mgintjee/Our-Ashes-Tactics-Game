
namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Api.Utilities.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Paths.Finder;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Utilities.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Reports;
    using System.Collections.Generic;

    /// <summary>
    /// Mountable Object Impl
    /// </summary>
    public class MountableObjectImpl
        : IMountableObject
    {
        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport = null;

        // Todo
        private readonly IList<IUtilityInformationReport> utilityInformationReportList;

        // Todo
        private readonly IList<IWeaponInformationReport> weaponInformationReportList;

        // Todo
        private readonly int maxRange = int.MinValue;

        // Todo
        private readonly int maxAccuracy = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport">
        /// </param>
        public MountableObjectImpl(ITalonConstructionReport talonConstructionReport)
        {
            this.talonIdentificationReport = talonConstructionReport.GetTalonIdentificationReport();
            IWeaponAttributes weaponAttributes = new WeaponAttributesImpl.Builder()
                .SetWeaponAttributesCollection(new HashSet<IWeaponAttributes>()
                    {
                        // Add the Hoplite Bonus IWeaponAttributes
                        HopliteAttributesConstants.GetAttributes(
                            talonConstructionReport.GetHopliteConstructionReport().GetHopliteTraitSet())
                            .GetWeaponAttributes(),
                        // Add the Utility Bonus IWeaponAttributes
                        UtilityAttributesConstants.GetAttributes(
                            new HashSet<UtilityModelIdEnum>(talonConstructionReport.GetUtilityModelIdList()))
                            .GetWeaponAttributes()
                    }
                )
                .Build();

            this.weaponInformationReportList = new List<IWeaponInformationReport>();
            this.utilityInformationReportList = new List<IUtilityInformationReport>();

            foreach (UtilityModelIdEnum utilityModelId in talonConstructionReport.GetUtilityModelIdList())
            {
                if (!utilityModelId.Equals(UtilityModelIdEnum.None))
                {
                    this.utilityInformationReportList.Add(
                        new UtilityInformationReportImpl.Builder()
                            .SetBonusAttributes(UtilityAttributesConstants.GetAttributes(utilityModelId))
                            .SetUtilityModelId(utilityModelId)
                            .Build()
                        );
                }
                else
                {
                    this.utilityInformationReportList.Add(null);
                }
            }
            foreach (WeaponModelIdEnum weaponModelId in talonConstructionReport.GetWeaponModelIdList())
            {
                if (!weaponModelId.Equals(WeaponModelIdEnum.None))
                {
                    IWeaponAttributes newWeaponAttributes = new WeaponAttributesImpl.Builder()
                                .SetWeaponAttributesCollection(new HashSet<IWeaponAttributes>()
                                    { weaponAttributes, WeaponAttributesConstants.GetAttributes(weaponModelId) })
                                .Build();
                    if (newWeaponAttributes.GetMaxRangePoints() > this.maxRange)
                    {
                        this.maxRange = newWeaponAttributes.GetMaxRangePoints();
                    }
                    if (newWeaponAttributes.GetAccuracyPoints() > this.maxAccuracy)
                    {
                        this.maxAccuracy = newWeaponAttributes.GetAccuracyPoints();
                    }
                    this.weaponInformationReportList.Add(
                        new WeaponInformationReportImpl.Builder()
                            .SetWeaponAttributes(newWeaponAttributes)
                            .SetWeaponModelId(weaponModelId)
                            .Build()
                            );
                }
                else
                {
                    this.weaponInformationReportList.Add(null);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMountableAttributesReport IMountableObject.GetMountableAttributesReport()
        {
            return new MountableAttributesReportImpl.Builder()
                .SetWeaponInformationReportList(this.weaponInformationReportList)
                .SetUtilityInformationReportList(this.utilityInformationReportList)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonActionOrderFireReport> IMountableObject.GetTalonActionOrderFireReportSet(ICubeCoordinates cubeCoordinates)
        {
            ISet<ITalonActionOrderFireReport> talonActionOrderReportSet = new HashSet<ITalonActionOrderFireReport>();
            IDictionary<ICubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = PathFinderFireUtil
                .BeginPathfindingFor(cubeCoordinates, this.maxRange, this.maxAccuracy);

            foreach (ICubeCoordinates pathCubeCoordinates in cubeCoordinatesPathObjectDictionary.Keys)
            {
                ITalonIdentificationReport targetTalonIdentificationReport = GameMapObjectManager
                    .GetHexTileObjectFrom(pathCubeCoordinates).GetHexTileInformationReport().GetTalonIdentificationReport();
                talonActionOrderReportSet.Add(
                    new TalonActionOrderFireReportImpl.Builder()
                        .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                        .SetTargetTalonIdentificationReport(targetTalonIdentificationReport)
                        .SetPathObject(cubeCoordinatesPathObjectDictionary[pathCubeCoordinates])
                        .Build()
                    );
            }
            return talonActionOrderReportSet;
        }
    }
}
