/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Enums;
using HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons;
using HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Attributes;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects
{
    /// <summary>
    /// Movable Object Api
    /// </summary>
    public class MovableObjectImpl
        : IMovableObject
    {
        // Todo
        private readonly IMovableAttributes movableAttributes = null;

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
                            new HashSet<UtilityModelIdEnum>(talonConstructionReport.GetUtilityModelIdList()))
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
        void IMovableObject.ResetForNewTurn()
        {
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
    }
}
