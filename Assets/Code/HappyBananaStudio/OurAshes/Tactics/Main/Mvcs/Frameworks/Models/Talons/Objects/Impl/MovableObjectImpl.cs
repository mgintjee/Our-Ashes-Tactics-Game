namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Movable Object Impl
    /// </summary>
    public class MovableObjectImpl
        : IMovableObject
    {
        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly IEngineAttributes engineAttributes;

        // Todo
        private float currentActionPoints;

        // Todo
        private float currentMovementPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engineAttributes"></param>
        private MovableObjectImpl(TalonCallSign talonCallSign, IEngineAttributes engineAttributes)
        {
            this.talonCallSign = talonCallSign;
            this.currentActionPoints = engineAttributes.GetActionPoints();
            this.currentMovementPoints = engineAttributes.GetMovementPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movableObject"></param>
        public MovableObjectImpl(TalonCallSign talonCallSign, IMovableObject movableObject)
        {
            this.talonCallSign = talonCallSign;
            this.engineAttributes = movableObject.GetEngineAttributes();
            this.currentActionPoints = movableObject.GetCurrentActionPoints();
            this.currentMovementPoints = movableObject.GetCurrentMovementPoints();
        }

        /// <inheritdoc/>
        IEngineAttributes IMovableObject.GetEngineAttributes()
        {
            return this.engineAttributes;
        }

        /// <inheritdoc/>
        float IMovableObject.GetCurrentActionPoints()
        {
            return this.currentActionPoints;
        }

        /// <inheritdoc/>
        float IMovableObject.GetCurrentMovementPoints()
        {
            return this.currentMovementPoints;
        }

        /// <inheritdoc/>
        ISet<ITalonOrderReport> IMovableObject.GetTalonOrderReportSet(ICubeCoordinates cubeCoordinates)
        {
            ISet<ITalonOrderReport> talonActionOrderReportSet = new HashSet<ITalonOrderReport>();
            IPathFinder pathFinderMove = new PathFinderMoveImpl.Builder()
                .SetPathCostThreshold(this.engineAttributes.GetMovementPoints())
                .SetStartingCubeCoordinates(cubeCoordinates)
                .Build();
            pathFinderMove.BeginPathFinding();
            IDictionary<ICubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = pathFinderMove.GetPathObjectDictionary();
            foreach (IPathObject pathObject in cubeCoordinatesPathObjectDictionary.Values)
            {
                talonActionOrderReportSet.Add(
                    new TalonOrderReportImpl.Builder()
                        .SetActingTalonCallSign(this.talonCallSign)
                        .SetPathObject(pathObject)
                        .SetActionType(OrderType.Move)
                        .Build()
                    );
            }
            return talonActionOrderReportSet;
        }

        /// <inheritdoc/>
        void IMovableObject.InputMovableCosts(float actionPoints, float movementPoints)
        {
            this.currentActionPoints -= actionPoints;
            this.currentMovementPoints -= movementPoints;
        }

        /// <inheritdoc/>
        void IMovableObject.ResetForNewPhase()
        {
            this.currentActionPoints = this.engineAttributes.GetActionPoints();
            this.currentMovementPoints = this.engineAttributes.GetMovementPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private IEngineAttributes engineAttributes = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMovableObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MovableObjectImpl(this.talonCallSign, this.engineAttributes);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSign"></param>
            /// <param name="movableObject"></param>
            /// <returns></returns>
            public IMovableObject Build(TalonCallSign talonCallSign, IMovableObject movableObject)
            {
                return new MovableObjectImpl(talonCallSign, movableObject);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSign"></param>
            /// <returns></returns>
            public Builder SetTalonCallSign(TalonCallSign talonCallSign)
            {
                this.talonCallSign = talonCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="engineAttributes"></param>
            /// <returns></returns>
            public Builder SetEngineAttributes(IEngineAttributes engineAttributes)
            {
                this.engineAttributes = engineAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that talonCallSign has been set
                if (this.talonCallSign == TalonCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(TalonCallSign) + " has not been set");
                }
                // Check that armorAttributes has been set
                if (this.engineAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IEngineAttributes) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}