namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Mangers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Fireable Object Impl
    /// </summary>
    public class FireableObject
        : IFireableObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly IList<IWeaponAttributes> weaponAttributesList;

        // Todo
        private readonly int maxRange;

        // Todo
        private readonly float maxAccuracy;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <param name="mountReportList"></param>
        private FireableObject(TalonCallSign talonCallSign, IList<IWeaponAttributes> weaponAttributesList)
        {
            this.talonCallSign = talonCallSign;
            this.weaponAttributesList = new List<IWeaponAttributes>(weaponAttributesList);
            this.maxAccuracy = this.GetMaxAccuracy();
            this.maxRange = this.GetMaxRange();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fireableObject"></param>
        private FireableObject(TalonCallSign talonCallSign, IFireableObject fireableObject)
        {
            this.talonCallSign = talonCallSign;
            this.weaponAttributesList = new List<IWeaponAttributes>(fireableObject.GetWeaponAttributesList());
            this.maxAccuracy = this.GetMaxAccuracy();
            this.maxRange = this.GetMaxRange();
        }

        /// <inheritdoc/>
        IList<IWeaponAttributes> IFireableObject.GetWeaponAttributesList()
        {
            return new List<IWeaponAttributes>(this.weaponAttributesList);
        }

        /// <inheritdoc/>
        ISet<ITalonOrderFireReport> IFireableObject.GetTalonOrderFireReportSet(ICubeCoordinates cubeCoordinates)
        {
            ISet<ITalonOrderFireReport> talonActionOrderReportSet = new HashSet<ITalonOrderFireReport>();
            IPathFinder pathFinderFire = new PathFinderFire.Builder()
                .SetMaxAccuracy(this.maxAccuracy)
                .SetMaxRange(this.maxRange)
                .SetStartingCubeCoordinates(cubeCoordinates)
                .Build();
            pathFinderFire.BeginPathFinding();
            IDictionary<ICubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary =
                pathFinderFire.GetPathObjectDictionary();

            foreach (ICubeCoordinates pathCubeCoordinates in cubeCoordinatesPathObjectDictionary.Keys)
            {
                TalonCallSign targetTalonCallSign = GameBoardManager.GetHexTileObjectFrom(pathCubeCoordinates)
                    .GetHexTileReport().GetTalonCallSign();
                PhalanxCallSign phalanxCallSign = PhalanxRosterManager.GetPhalanxCallSign(this.talonCallSign);
                PhalanxCallSign targetPhalanxCallSign = PhalanxRosterManager.GetPhalanxCallSign(targetTalonCallSign);
                if (!PhalanxRosterManager.ArePhalanxCallSignsFriendly(phalanxCallSign, targetPhalanxCallSign))
                {
                    talonActionOrderReportSet.Add(
                        new TalonOrderFireReport.Builder()
                            .SetActingTalonCallSign(this.talonCallSign)
                            .SetTargetTalonCallSign(targetTalonCallSign)
                            .SetPathObject(cubeCoordinatesPathObjectDictionary[pathCubeCoordinates])
                            .SetActionType(OrderType.Fire)
                            .Build()
                        );
                }
                else
                {
                    logger.Debug("Unable to add ?. ? and ? are friendly.",
                        typeof(IPathObject), this.talonCallSign, targetTalonCallSign);
                }
            }
            return talonActionOrderReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetMaxAccuracy()
        {
            float maxAccuracy = 0;

            foreach (IWeaponAttributes weaponAttributes in this.weaponAttributesList)
            {
                if (weaponAttributes != null)
                {
                    float weaponAccuracyPoints = weaponAttributes.GetAccuracyPoints();
                    if (maxAccuracy < weaponAccuracyPoints)
                    {
                        maxAccuracy = weaponAccuracyPoints;
                    }
                }
            }

            return maxAccuracy;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private int GetMaxRange()
        {
            int maxRange = 0;

            foreach (IWeaponAttributes weaponAttributes in this.weaponAttributesList)
            {
                if (weaponAttributes != null)
                {
                    int weaponRangePoints = weaponAttributes.GetMaxRangePoints();
                    if (maxRange < weaponRangePoints)
                    {
                        maxRange = weaponRangePoints;
                    }
                }
            }

            return maxRange;
        }

        /// <inheritdoc/>
        void IFireableObject.ResetForNewPhase()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private IList<IWeaponAttributes> weaponAttributesList = new List<IWeaponAttributes>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IFireableObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new FireableObject(this.talonCallSign, this.weaponAttributesList);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSign"></param>
            /// <param name="fireableObject"></param>
            /// <returns></returns>
            public IFireableObject Build(TalonCallSign talonCallSign, IFireableObject fireableObject)
            {
                return new FireableObject(talonCallSign, fireableObject);
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
            /// <param name="weaponAttributesList"></param>
            /// <returns></returns>
            public Builder SetWeaponAttributesList(IList<IWeaponAttributes> weaponAttributesList)
            {
                this.weaponAttributesList = new List<IWeaponAttributes>(weaponAttributesList);
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
                // Check that weaponAttributesList has been set
                if (this.weaponAttributesList == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IWeaponAttributes) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}