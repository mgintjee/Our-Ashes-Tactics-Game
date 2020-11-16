

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Paths.Finder;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Attributes;
    using System.Collections.Generic;

    /// <summary>
    /// Movable Object Api
    /// </summary>
    public class MovableObjectImpl
        : IMovableObject
    {
        // Todo
        private readonly IMovableAttributes movableAttributes = null;

        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport = null;

        // Todo
        private int actionPoints = int.MinValue;

        // Todo
        private int movePoints = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleAttributes">
        /// </param>
        public MovableObjectImpl(ITalonConstructionReport talonConstructionReport)
        {
            this.talonIdentificationReport = talonConstructionReport.GetTalonIdentificationReport();
            this.movableAttributes = new MovableAttributesImpl.Builder()
                .SetMovableAttributesCollection(new HashSet<IMovableAttributes>()
                    {
                        // Add the base TalonModelId MovableAttributes
                        TalonAttributesConstants.GetAttributes(
                            talonConstructionReport.GetTalonIdentificationReport().GetTalonModelId())
                            .GetMovableAttributes(),
                        // Add the Hoplite Bonus MovableAttributes
                        HopliteAttributesConstants.GetAttributes(
                            talonConstructionReport.GetHopliteConstructionReport().GetHopliteTraitSet())
                            .GetMovableAttributes(),
                        // Add the Utility Bonus MovableAttributes
                        UtilityAttributesConstants.GetAttributes(
                            new HashSet<UtilityModelId>(talonConstructionReport.GetUtilityModelIdList()))
                            .GetMovableAttributes()
                    }
                )
                .Build();
            this.movePoints = this.movableAttributes.GetMovePoints();
            this.actionPoints = this.movableAttributes.GetActionPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMovableAttributesReport IMovableObject.GetMovableAttributesReport()
        {
            return new MovableAttributesReportImpl.Builder()
                .SetCurrentMovePoints(this.movePoints)
                .SetCurrentActionPoints(this.actionPoints)
                .SetMaximumMovePoints(this.movableAttributes.GetMovePoints())
                .SetMaximumActionPoints(this.movableAttributes.GetActionPoints())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonActionOrderReport> IMovableObject.GetTalonActionOrderReportSet(ICubeCoordinates cubeCoordinates)
        {
            ISet<ITalonActionOrderReport> talonActionOrderReportSet = new HashSet<ITalonActionOrderReport>();
            IDictionary<ICubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = PathFinderMoveUtil
                .BeginPathfindingFor(cubeCoordinates, this.movableAttributes.GetMovePoints());
            foreach (IPathObject pathObject in cubeCoordinatesPathObjectDictionary.Values)
            {
                talonActionOrderReportSet.Add(
                    new TalonActionOrderReportImpl.Builder()
                        .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                        .SetPathObject(pathObject)
                        .Build()
                    );
            }
            return talonActionOrderReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionCost">
        /// </param>
        /// <param name="moveCost">
        /// </param>
        void IMovableObject.InputActionCosts(int actionCost, int moveCost)
        {
            this.actionPoints -= actionCost;
            this.movePoints -= moveCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IMovableObject.ResetForNewTurn()
        {
            this.movePoints = this.movableAttributes.GetMovePoints();
            this.actionPoints = this.movableAttributes.GetActionPoints();
        }
    }
}
