/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Path.Objects.Wait;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Talons.Objects
{
    /// <summary>
    /// Talon Behavior Impl
    /// </summary>
    public class TalonBehaviorImpl
    : ITalonBehavior
    {
        // Todo
        private readonly ITalonBehaviorDestructible talonBehaviorDestructible;

        // Todo
        private readonly ITalonBehaviorFireable talonBehaviorFireable;

        // Todo
        private readonly ITalonBehaviorMovable talonBehaviorMovable;

        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport;

        // Todo
        private ICubeCoordinates cubeCoordinates = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        public TalonBehaviorImpl(ITalonIdentificationReport talonIdentificationReport)
        {
            if (talonIdentificationReport != null)
            {
                this.talonIdentificationReport = talonIdentificationReport;
                ITalonAttributes talonAttributes = TalonAttributesConstants.GetAttributes(this.talonIdentificationReport.GetTalonId());
                if (talonAttributes != null)
                {
                    this.talonBehaviorMovable = new TalonBehaviorMovableImpl(talonAttributes.GetMovableAttributes());
                    this.talonBehaviorFireable = new TalonBehaviorFireableImpl(talonAttributes.GetFireableAttributes());
                    this.talonBehaviorDestructible = new TalonBehaviorDestructibleImpl(talonAttributes.GetDestructibleAttributes());
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                        "\n\t> ? is null", this.GetType(), typeof(ITalonAttributes));
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null", this.GetType(), typeof(ITalonIdentificationReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="weaponBehavior">
        /// </param>
        public void AddWeaponBehavior(int index, IWeaponBehavior weaponBehavior)
        {
            this.talonBehaviorFireable.AddWeapon(index, weaponBehavior);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ICubeCoordinates GetCubeCoordinates()
        {
            return this.cubeCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<ITalonActionOrderReport> GetPossibleTalonActionOrderReportSet()
        {
            // Begin pathFinding for the Movable
            this.talonBehaviorMovable.BeginPathFinding();
            // Begin pathFinding for the Fireable
            this.talonBehaviorFireable.BeginPathFinding();
            // Default an empty Set
            HashSet<ITalonActionOrderReport> talonActionOrderReportSet = new HashSet<ITalonActionOrderReport>();

            // Iterate over all possible pathObjects for moving
            foreach (IPathObject pathObject in this.talonBehaviorMovable.GetPathObjectMoveSet())
            {
                // Add the actionReport to fire
                talonActionOrderReportSet.Add(ReportBuilder.Talon.Action.Order.GetBuilder()
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
                    ICubeCoordinates cubeCoordinates = pathObject.GetCubeCoordinatesEnd();
                    // Collect the HexTileObject from the cubeCoordinates
                    IHexTileObject hexTileObject = GameMapObjectManager.FindHexTileObjectFrom(cubeCoordinates);
                    // Check that the HexTileObject is non-null
                    if (hexTileObject != null)
                    {
                        // Collect the talonIdentificationReport from the hexTileObject
                        ITalonIdentificationReport talonIdentificationReport = hexTileObject.GetHexTileInformationReport().GetTalonIdentificationReport();
                        // Check that the FactionIds are not the same
                        if (!this.talonIdentificationReport.GetFactionId().Equals(talonIdentificationReport.GetFactionId()))
                        {
                            // Add the actionReport to fire
                            talonActionOrderReportSet.Add(ReportBuilder.Talon.Action.Order.GetBuilder()
                                .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                                .SetPathObject(pathObject)
                                .SetTargetTalonIdentificationReport(talonIdentificationReport)
                                .Build());
                        }
                    }
                }
            }
            // Add the TalonActionOrderReport for Waiting
            talonActionOrderReportSet.Add(ReportBuilder.Talon.Action.Order.GetBuilder()
                .SetActingTalonIdentificationReport(this.talonIdentificationReport)
                .SetPathObject(new PathObjectWait(new List<ICubeCoordinates>() { this.GetCubeCoordinates() }))
                .Build()
                );

            return talonActionOrderReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonAttributesReport GetTalonAttributesReport()
        {
            return ReportBuilder.Talon.Attributes.GetBuilder()
                .SetDestructableReport(this.talonBehaviorDestructible.GetDestructibleAttributesReport())
                .SetFireableReport(this.talonBehaviorFireable.GetFireableAttributesReport())
                .SetMovableReport(this.talonBehaviorMovable.GetMovableAttributesReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectFire">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonCombatOrderReport GetTalonCombatOrderReport(IPathObject pathObjectFire)
        {
            return this.talonBehaviorFireable.GetTalonCombatOrderReport(pathObjectFire);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonActionResultReport InputTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
        {
            if (talonActionOrderReport != null)
            {
                this.talonBehaviorMovable.InputTalonActionOrder(talonActionOrderReport);
                return ReportBuilder.Talon.Action.Result.GetBuilder()
                    .SetTalonActionOrderReport(talonActionOrderReport)
                    .SetTalonAttributesReport(this.GetTalonAttributesReport())
                    .SetTalonCombatResultReport(null)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null", new StackFrame().GetMethod().Name, typeof(ITalonActionOrderReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCombatOrderReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonCombatResultReport InputTalonCombatOrderReport(ITalonCombatOrderReport talonCombatOrderReport)
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
        /// <param name="cubeCoordinates">
        /// </param>
        public void SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
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
                    "\n\t>" + typeof(ICubeCoordinates) + " is null");
            }
        }
    }
}