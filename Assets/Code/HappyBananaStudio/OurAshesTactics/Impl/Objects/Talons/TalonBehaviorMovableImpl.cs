/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Paths.Finder;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Talons
{
    /// <summary>
    /// TODO
    /// </summary>
    public class TalonBehaviorMovableImpl
    : ITalonBehaviorMovable
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // TODO
        private readonly IMovableAttributes movableAttributes = null;

        // TODO
        private Dictionary<ICubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<ICubeCoordinates, IPathObject>();

        // TODO
        private ICubeCoordinates currentCubeCoordinates;

        // TODO
        private int currentTurnPoints = int.MinValue;

        // ToTODOdo
        private int currrentMovePoints = int.MinValue;

        public TalonBehaviorMovableImpl(IMovableAttributes IMoveableAttributes)
        {
            if (IMoveableAttributes != null)
            {
                this.movableAttributes = IMoveableAttributes;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null", this.GetType(), typeof(ITalonCombatOrderReport));
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void BeginPathFinding()
        {
            this.cubeCoordinatesPathObjectDictionary = PathFinderMoveUtil.BeginPathfindingFor(
                this.currentCubeCoordinates, this.movableAttributes.GetMovePoints());
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns>
        /// </returns>
        public IMovableReport GetMovableAttributesReport()
        {
            return ReportBuilder.Talon.Attributes.Movable.GetBuilder()
                .SetCurrentMovePoints(this.currrentMovePoints)
                .SetCurrentOrderPoints(this.currrentMovePoints + (2 * this.currentTurnPoints))
                .SetCurrentTurnPoints(this.currentTurnPoints)
                .SetMaximumMovePoints(this.movableAttributes.GetMovePoints())
                .SetMaximumOrderPoints(this.movableAttributes.GetMovePoints() + (2 * this.movableAttributes.GetTurnPoints()))
                .SetMaximumTurnPoints(this.movableAttributes.GetTurnPoints())
                .Build();
        }

        /// <summary>
        /// TTODOodo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<IPathObject> GetPathObjectMoveSet()
        {
            return new HashSet<IPathObject>(this.cubeCoordinatesPathObjectDictionary.Values);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="talonActionReport">
        /// </param>
        public void InputTalonActionOrder(ITalonActionOrderReport talonActionReport)
        {
            if (talonActionReport != null)
            {
                ActionTypeEnum talonActionType = talonActionReport.GetActionType();
                switch (talonActionType)
                {
                    case ActionTypeEnum.Wait:
                        this.currentTurnPoints -= this.movableAttributes.GetTurnPoints();
                        break;

                    case ActionTypeEnum.Move:
                        this.currrentMovePoints -= talonActionReport.GetPathObject().GetPathObjectCost();
                        this.currentTurnPoints -= 1;
                        break;

                    case ActionTypeEnum.Fire:
                        this.currrentMovePoints -= this.movableAttributes.GetTurnPoints();
                        this.currentTurnPoints -= 2;
                        break;

                    default:
                        throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                            "\n\t> ?=? is unsupported.", new StackFrame().GetMethod().Name, typeof(ActionTypeEnum), talonActionType);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(ITalonActionOrderReport));
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void ResetTalonAttributeValues()
        {
            this.currentTurnPoints = this.movableAttributes.GetTurnPoints();
            this.currrentMovePoints = this.movableAttributes.GetMovePoints();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        public void SetCubeCoodinates(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                this.currentCubeCoordinates = cubeCoordinates;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(ICubeCoordinates));
            }
        }
    }
}