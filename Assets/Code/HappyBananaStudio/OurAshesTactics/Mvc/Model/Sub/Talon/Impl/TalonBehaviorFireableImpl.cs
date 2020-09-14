/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Util;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonBehaviorFireableImpl
    : ITalonBehaviorFireable
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly TalonAttributes talonAttributes = null;

        // Todo
        private readonly List<IWeaponBehavior> weaponBehaviorList;

        // Todo
        private Dictionary<CubeCoordinates, IPathObject> cubeCoordinatesPathObjectDictionary = new Dictionary<CubeCoordinates, IPathObject>();

        // Todo
        private CubeCoordinates currentCubeCoordinates = null;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonAttributes"></param>
        public TalonBehaviorFireableImpl(TalonAttributes talonAttributes)
        {
            if (talonAttributes != null)
            {
                this.talonAttributes = talonAttributes;
                this.weaponBehaviorList = new List<IWeaponBehavior>();
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
        /// <param name="weaponBehavior"></param>
        public void AddWeapon(IWeaponBehavior weaponBehavior)
        {
            if (weaponBehavior != null)
            {
                if (this.weaponBehaviorList.Count < this.talonAttributes.GetWeaponPoints())
                {
                    this.weaponBehaviorList.Add(weaponBehavior);
                }
            }
            else
            {
                throw new ArgumentException("Unable to add " + typeof(IWeaponBehavior) + ". Invalid Parameters." +
                    "\n\t>" + typeof(IWeaponBehavior) + " is null");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void BeginPathFinding()
        {
            this.cubeCoordinatesPathObjectDictionary = (this.weaponBehaviorList.Count > 0)
                ? PathFinderFireUtil.BeginPathfindingFor(this.currentCubeCoordinates)
                : new Dictionary<CubeCoordinates, IPathObject>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange"></param>
        /// <returns></returns>
        public int GetMaxAccuracyPenalty(int targetRange)
        {
            int maxAccuracyPenalty = int.MinValue;
            foreach (IWeaponBehavior weaponBehavior in this.weaponBehaviorList)
            {
                int weaponMaxAccuracyPenalty = weaponBehavior.GetMaxAccuracyPenalty(targetRange);
                if (maxAccuracyPenalty < weaponMaxAccuracyPenalty)
                {
                    maxAccuracyPenalty = weaponMaxAccuracyPenalty;
                }
            }

            return maxAccuracyPenalty;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<IPathObject> GetPathObjectFireSet()
        {
            return new HashSet<IPathObject>(this.cubeCoordinatesPathObjectDictionary.Values);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire"></param>
        /// <returns></returns>
        public TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire)
        {
            List<WeaponCombatOrderReport> weaponCombatOrderList = new List<WeaponCombatOrderReport>();
            if (pathObjectFire != null)
            {
                foreach (IWeaponBehavior weaponBehavior in this.weaponBehaviorList)
                {
                    // Collect the weaponCombatOrder from the weaponBehavior
                    WeaponCombatOrderReport weaponCombatOrder = weaponBehavior.GenerateWeaponReport(pathObjectFire.GetPathObjectCost(),
                        pathObjectFire.GetPathObjectLength());
                    logger.Debug("Added ?", weaponCombatOrder);
                    // Add the generated weaponCombatOrder to the list
                    weaponCombatOrderList.Add(weaponCombatOrder);
                }
            }
            return new TalonCombatOrderReport.Builder()
                .SetWeaponCombatOrderReportList(weaponCombatOrderList)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public List<WeaponIdEnum> GetWeaponIdList()
        {
            List<WeaponIdEnum> weaponIdList = new List<WeaponIdEnum>();

            foreach (IWeaponBehavior weaponBehavior in this.weaponBehaviorList)
            {
                weaponIdList.Add(weaponBehavior.GetWeaponId());
            }
            return weaponIdList;
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