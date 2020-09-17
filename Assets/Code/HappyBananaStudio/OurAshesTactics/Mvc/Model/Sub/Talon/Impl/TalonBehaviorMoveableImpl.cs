/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Util;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonBehaviorMoveableImpl
    : ITalonBehaviorMoveable
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly TalonAttributes talonAttributes = null;

        // Todo
        private Dictionary<CubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<CubeCoordinates, IPathObject>();

        // Todo
        private CubeCoordinates currentCubeCoordinates;

        // Todo
        private int currentOrderPoints = 0;

        // Todo
        private int currentTurnPoints = int.MinValue;

        // Todo
        private int currrentMovePoints = int.MinValue;

        #endregion Private Fields

        #region Public Constructors

        public TalonBehaviorMoveableImpl(TalonAttributes talonAttributes)
        {
            if (talonAttributes != null)
            {
                this.talonAttributes = talonAttributes;
                this.ResetTalonAttributeValues();
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(TalonAttributes) + " is null");
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public void BeginPathFinding()
        {
            this.cubeCoordinatesPathObjectDictionary = PathFinderMoveUtil.BeginPathfindingFor(this.currentCubeCoordinates, this.GetMaximumMovePoints());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetCurrentMovePoints()
        {
            return this.currrentMovePoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetCurrentOrderPoints()
        {
            int currentTurnPoints = this.GetCurrentTurnPoints();
            int currentMovePoints = this.GetCurrentMovePoints();
            logger.Info("Turn=?, Move=?, Sum=?, Prod=?, Order=?", currentTurnPoints, currentMovePoints,
                currentTurnPoints + currentMovePoints, currentTurnPoints * currentMovePoints, currentOrderPoints);
            return currentMovePoints + currentTurnPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetCurrentTurnPoints()
        {
            return this.currentTurnPoints;
        }

        /// <summary>
        /// Topdo
        /// </summary>
        /// <returns></returns>
        public int GetMaximumMovePoints()
        {
            return this.talonAttributes.GetMovePoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetMaximumOrderPoints()
        {
            return this.GetMaximumMovePoints() * this.GetMaximumTurnPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetMaximumTurnPoints()
        {
            return this.talonAttributes.GetTurnPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<IPathObject> GetPathObjectMoveSet()
        {
            return new HashSet<IPathObject>(this.cubeCoordinatesPathObjectDictionary.Values);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionReport"></param>
        public void InputTalonActionOrder(TalonActionOrderReport talonActionReport)
        {
            TalonActionTypeEnum talonActionType = talonActionReport.GetTalonActionType();
            switch (talonActionType)
            {
                case TalonActionTypeEnum.Wait:
                    this.currentOrderPoints += this.GetMaximumMovePoints() * this.currentTurnPoints;
                    this.currentTurnPoints -= this.GetMaximumTurnPoints();
                    break;

                case TalonActionTypeEnum.Move:
                    this.currentOrderPoints += talonActionReport.GetPathObject().GetPathObjectCost();
                    this.currrentMovePoints -= talonActionReport.GetPathObject().GetPathObjectCost();
                    this.currentTurnPoints -= 1;
                    break;

                case TalonActionTypeEnum.Fire:
                    this.currentOrderPoints += this.GetMaximumMovePoints();
                    this.currentTurnPoints -= 2;
                    this.currrentMovePoints -= this.GetMaximumMovePoints();
                    break;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ResetTalonAttributeValues()
        {
            this.currentTurnPoints = this.GetMaximumTurnPoints();
            this.currrentMovePoints = this.GetMaximumMovePoints();
            this.currentOrderPoints = 0;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        public void SetCubeCoodinates(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                this.currentCubeCoordinates = cubeCoordinates;
            }
        }

        #endregion Public Methods
    }
}