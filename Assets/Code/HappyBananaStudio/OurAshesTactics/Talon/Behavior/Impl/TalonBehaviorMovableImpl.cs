/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Util;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Behavior.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Talon.Behavior.Impl
{
    /// <summary>
    /// TODO
    /// </summary>
    public class TalonBehaviorMovableImpl
    : ITalonBehaviorMovable
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // TODO
        private readonly IMoveableAttributes movableAttributes = null;

        // TODO
        private Dictionary<CubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<CubeCoordinates, IPathObject>();

        // TODO
        private CubeCoordinates currentCubeCoordinates;

        // TODO
        private int currentTurnPoints = int.MinValue;

        // ToTODOdo
        private int currrentMovePoints = int.MinValue;

        #endregion Private Fields

        #region Public Constructors

        public TalonBehaviorMovableImpl(IMoveableAttributes IMoveableAttributes)
        {
            if (IMoveableAttributes != null)
            {
                this.movableAttributes = IMoveableAttributes;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null", this.GetType(), typeof(TalonCombatOrderReport));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// TODO
        /// </summary>
        public void BeginPathFinding()
        {
            logger.Debug("BeginPathFinding for ?", this.currentCubeCoordinates);
            this.cubeCoordinatesPathObjectDictionary = PathFinderMoveUtil.BeginPathfindingFor(
                this.currentCubeCoordinates, this.movableAttributes.GetMovePoints());
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public MovableAttributesReport GetMovableAttributesReport()
        {
            return new MovableAttributesReport.Builder()
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
        /// <returns></returns>
        public HashSet<IPathObject> GetPathObjectMoveSet()
        {
            return new HashSet<IPathObject>(this.cubeCoordinatesPathObjectDictionary.Values);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="talonActionReport"></param>
        public void InputTalonActionOrder(TalonActionOrderReport talonActionReport)
        {
            if (talonActionReport != null)
            {
                TalonActionTypeEnum talonActionType = talonActionReport.GetTalonActionType();
                switch (talonActionType)
                {
                    case TalonActionTypeEnum.Wait:
                        this.currentTurnPoints -= this.movableAttributes.GetTurnPoints();
                        break;

                    case TalonActionTypeEnum.Move:
                        this.currrentMovePoints -= talonActionReport.GetPathObject().GetPathObjectCost();
                        this.currentTurnPoints -= 1;
                        break;

                    case TalonActionTypeEnum.Fire:
                        this.currrentMovePoints -= this.movableAttributes.GetTurnPoints();
                        this.currentTurnPoints -= 2;
                        break;

                    default:
                        throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                            "\n\t> ?=? is unsupported.", new StackFrame().GetMethod().Name, typeof(TalonActionTypeEnum), talonActionType);
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(TalonActionOrderReport));
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
        /// <param name="cubeCoordinates"></param>
        public void SetCubeCoodinates(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                this.currentCubeCoordinates = cubeCoordinates;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(CubeCoordinates));
            }
        }

        #endregion Public Methods
    }
}