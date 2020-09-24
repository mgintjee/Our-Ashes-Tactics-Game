/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Manager;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Api;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Constants;
using HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Behavior.Api;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Behavior.Impl
{
    /// <summary>
    /// Talon Behavior Impl
    /// </summary>
    public class TalonBehaviorImpl
    : ITalonBehavior
    {
        #region Private Fields

        // Todo
        private readonly ITalonBehaviorDestructible talonBehaviorDestructible;

        // Todo
        private readonly ITalonBehaviorFireable talonBehaviorFireable;

        // Todo
        private readonly ITalonBehaviorMovable talonBehaviorMovable;

        // Todo
        private readonly TalonIdentificationReport talonIdentificationReport ;

        // Todo
        private CubeCoordinates cubeCoordinates = null;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        public TalonBehaviorImpl(TalonIdentificationReport talonIdentificationReport)
        {
            if (talonIdentificationReport != null)
            {
                this.talonIdentificationReport = talonIdentificationReport;
                ITalonAttributes talonAttributes = TalonAttributesConstants.GetAttributes(this.talonIdentificationReport.GetTalonId());
                if (talonAttributes != null)
                {
                    this.talonBehaviorMovable = new TalonBehaviorMovableImpl(talonAttributes.GetMoveableAttributes());
                    this.talonBehaviorFireable = new TalonBehaviorFireableImpl(talonAttributes.GetFireableAttributes());
                    this.talonBehaviorDestructible = new TalonBehaviorDestructibleImpl(talonAttributes.GetDestructibleAttributes());
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(ITalonAttributes) + " is null");
                }
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(TalonIdentificationReport) + " is null");
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index"></param>
        /// <param name="weaponBehavior"></param>
        public void AddWeaponBehavior(int index, IWeaponBehavior weaponBehavior)
        {
            this.talonBehaviorFireable.AddWeapon(index, weaponBehavior);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public CubeCoordinates GetCubeCoordinates()
        {
            return this.cubeCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet()
        {
            // Begin pathFinding for the Movable
            this.talonBehaviorMovable.BeginPathFinding();
            // Begin pathFinding for the Fireable
            this.talonBehaviorFireable.BeginPathFinding();
            // Default an empty Set
            HashSet<TalonActionOrderReport> talonActionOrderReportSet = new HashSet<TalonActionOrderReport>();

            // Iterate over all possible pathObjects for moving
            foreach (IPathObject pathObject in this.talonBehaviorMovable.GetPathObjectMoveSet())
            {
                // Add the actionReport to fire
                talonActionOrderReportSet.Add(new TalonActionOrderReport.Builder()
                    .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                    .SetPathObject(pathObject)
                    .SetTargetTalonIdentificationReport(null)
                    .Build());
            }
            // Iterate over all possible pathObjects for firing
            foreach (IPathObject pathObject in this.talonBehaviorFireable.GetPathObjectFireSet())
            {
                int pathObjectCost = pathObject.GetPathObjectCost();
                int maxFireAccuracyPenalty = this.talonBehaviorFireable.GetMaxAccuracyPenalty(pathObject.GetPathObjectLength());
                if (pathObjectCost < maxFireAccuracyPenalty)
                {
                    // Collect the ending cubeCoordinates for the pathObject
                    CubeCoordinates cubeCoordinates = pathObject.GetCubeCoordinatesEnd();
                    // Collect the HexTileObject from the cubeCoordinates
                    IHexTileObject hexTileObject = MapObjectManager.FindHexTileObjectFrom(cubeCoordinates);
                    // Check that the HexTileObject is non-null
                    if (hexTileObject != null)
                    {
                        // Collect the talonIdentificationReport from the hexTileObject
                        TalonIdentificationReport talonIdentificationReport = hexTileObject.GetHexTileInformationReport().GetTalonIdentificationReport();
                        // Check that the FactionIds are not the same
                        if (!this.talonIdentificationReport.GetTalonFactionId().Equals(talonIdentificationReport.GetTalonFactionId()))
                        {
                            // Add the actionReport to fire
                            talonActionOrderReportSet.Add(new TalonActionOrderReport.Builder()
                                .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                                .SetPathObject(pathObject)
                                .SetTargetTalonIdentificationReport(talonIdentificationReport)
                                .Build());
                        }
                    }
                }
            }
            // Add the TalonActionOrderReport for Waiting
            talonActionOrderReportSet.Add(new TalonActionOrderReport.Builder()
                .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                .SetPathObject(new PathObjectWait(new List<CubeCoordinates>() { this.GetCubeCoordinates() }))
                .Build()
                );

            return talonActionOrderReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonAttributesReport GetTalonAttributesReport()
        {
            return new TalonAttributesReport.Builder()
                .SetDestructableAttributesReport(this.talonBehaviorDestructible.GetDestructibleAttributesReport())
                .SetFireableAttributesReport(this.talonBehaviorFireable.GetFireableAttributesReport())
                .SetMoveableAttributesReport(this.talonBehaviorMovable.GetMovableAttributesReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire"></param>
        /// <returns></returns>
        public TalonCombatOrderReport GetTalonCombatOrderReport(PathObjectFire pathObjectFire)
        {
            return this.talonBehaviorFireable.GetTalonCombatOrderReport(pathObjectFire);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrder"></param>
        /// <returns></returns>
        public TalonActionResultReport InputTalonActionOrderReport(TalonActionOrderReport talonActionOrder)
        {
            TalonActionResultReport talonActionReport = null;
            if (talonActionOrder != null)
            {
                this.talonBehaviorMovable.InputTalonActionOrder(talonActionOrder);
                talonActionReport = new TalonActionResultReport.Builder()
                    .SetTalonActionOrder(talonActionOrder)
                    .SetTalonAttributesReport(this.GetTalonAttributesReport())
                    .Build();
            }
            return talonActionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCombatOrderReport"></param>
        /// <returns></returns>
        public TalonCombatResultReport InputTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
        {
            return this.talonBehaviorDestructible.InputTalonCombatOrderReport(talonCombatOrderReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ResetForNewTurn()
        {
            this.talonBehaviorMovable.ResetTalonAttributeValues();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        public void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                this.cubeCoordinates = cubeCoordinates;
                this.talonBehaviorFireable.SetCubeCoodinates(cubeCoordinates);
                this.talonBehaviorMovable.SetCubeCoodinates(cubeCoordinates);
            }
            else
            {
                throw new ArgumentException("Unable to SetCubeCoordinates" +
                    "\n\t>" + typeof(CubeCoordinates) + " is null");
            }
        }

        #endregion Public Methods
    }
}