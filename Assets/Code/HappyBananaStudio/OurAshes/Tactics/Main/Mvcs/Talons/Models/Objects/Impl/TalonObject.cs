using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Attributes.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Attributes.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Utilities.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Destructibles.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Destructibles.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Fireables.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Fireables.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Movables.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Movables.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Impl
{
    /// <summary>
    /// Talon Object Impl
    /// </summary>
    public class TalonObject
        : ITalonObject
    {
        // Todo
        private readonly IDestructibleObject destructibleObject;

        // Todo
        private readonly IFireableObject fireableObject;

        // Todo
        private readonly IMovableObject movableObject;

        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly ITalonLoadoutReport talonLoadoutReport;

        // Todo
        private ICubeCoordinates cubeCoordinates;

        // Todo
        private readonly ITalonCustomizationReport talonCustomizationReport;

        // Todo
        private IDictionary<ITalonEffectObject, int> talonEffectRemainingDurationDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <param name="talonLoadoutReport"></param>
        private TalonObject(TalonCallSign talonCallSign,
            ITalonLoadoutReport talonLoadoutReport, ITalonCustomizationReport customizationReport)
        {
            this.talonCallSign = talonCallSign;
            this.talonLoadoutReport = talonLoadoutReport;
            this.talonCustomizationReport = customizationReport;
            this.talonEffectRemainingDurationDictionary = new Dictionary<ITalonEffectObject, int>();
            this.destructibleObject = new DestructibleObject.Builder()
                .SetArmorAttributes(this.BuildArmorAttributes())
                .Build();
            this.fireableObject = new FireableObject.Builder()
                .SetTalonCallSign(this.talonCallSign)
                .SetWeaponAttributesList(this.BuildWeaponAttributesList())
                .Build();
            this.movableObject = new MovableObject.Builder()
                .SetTalonCallSign(this.talonCallSign)
                .SetEngineAttributes(this.BuildEngineAttributes())
                .Build();
        }

        /// <inheritdoc/>
        ISet<ITalonOrderReport> ITalonObject.GetTalonOrderReportSet()
        {
            ISet<ITalonOrderReport> talonActionOrderReportSet = new HashSet<ITalonOrderReport>()
            {
                new TalonOrderReport.Builder()
                    .SetActingTalonCallSign(this.talonCallSign)
                    .SetActionType(OrderType.Wait)
                    .SetPathObject(new PathObjectWait(new List<ICubeCoordinates>(){this.cubeCoordinates }))
                    .Build()
            };
            talonActionOrderReportSet.UnionWith(this.movableObject.GetTalonOrderReportSet(this.cubeCoordinates));
            talonActionOrderReportSet.UnionWith(this.fireableObject.GetTalonOrderFireReportSet(this.cubeCoordinates));
            return talonActionOrderReportSet;
        }

        /// <inheritdoc/>
        ITalonReport ITalonObject.GetTalonReport()
        {
            IEngineAttributes engineAttributes = this.movableObject.GetEngineAttributes();
            IArmorAttributes armorAttributes = this.destructibleObject.GetArmorAttributes();
            return new TalonReport.Builder()
                .SetCurrentTalonAttributesReport(new TalonAttributesReport.Builder()
                    .SetActionPoints(this.movableObject.GetCurrentActionPoints())
                    .SetMovementPoints(this.movableObject.GetCurrentMovementPoints())
                    .SetArmorPoints(this.destructibleObject.GetCurrentArmorPoints())
                    .SetHealthPoints(this.destructibleObject.GetCurrentHealthPoints())
                    .Build())
                .SetMaximumTalonAttributesReport(new TalonAttributesReport.Builder()
                    .SetActionPoints(engineAttributes.GetActionPoints())
                    .SetMovementPoints(engineAttributes.GetMovementPoints())
                    .SetArmorPoints(armorAttributes.GetArmorPoints())
                    .SetHealthPoints(armorAttributes.GetHealthPoints())
                    .Build())
                .SetTalonCallSign(this.talonCallSign)
                .SetTalonLoadoutReport(this.talonLoadoutReport)
                .SetTalonCustomizationReport(this.talonCustomizationReport)
                .SetCubeCoordinates(this.cubeCoordinates)
                .Build();
        }

        /// <inheritdoc/>
        void ITalonObject.InputTalonEffect(ITalonEffectObject talonEffectObject)
        {
            this.InputTalonEffectObject(talonEffectObject);
        }

        /// <inheritdoc/>
        void ITalonObject.SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            this.cubeCoordinates = cubeCoordinates;
        }

        /// <inheritdoc/>
        void ITalonObject.ResetForNewPhase()
        {
            this.movableObject.ResetForNewPhase();
            this.ApplyCachedTalonEffectObjects();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IArmorAttributes BuildArmorAttributes()
        {
            // Collect the IArmorAttributes from the Talon, Armor, and Engine
            ISet<IArmorAttributes> armorAttributesSet = new HashSet<IArmorAttributes>()
            {
                TalonLoadoutAttributesConstants.GetTalonLoadoutAttributes(
                    this.talonLoadoutReport.GetTalonId()).GetArmorAttributes(),
                this.talonLoadoutReport.GetArmorReport().GetLoadoutAttributes().GetArmorAttributes(),
                this.talonLoadoutReport.GetEngineReport().GetLoadoutAttributes().GetArmorAttributes(),
            };
            // Collect the IArmorAttributes from the mounts
            foreach (IMountReport mountReport in this.talonLoadoutReport.GetMountReportList())
            {
                armorAttributesSet.Add(mountReport.GetLoadoutAttributes().GetArmorAttributes());
            }
            return new ArmorAttributes.Builder().Build(armorAttributesSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IEngineAttributes BuildEngineAttributes()
        {
            // Collect the IEngineAttributes from the Talon, Armor, and Engine
            ISet<IEngineAttributes> engineAttributesSet = new HashSet<IEngineAttributes>()
            {
                TalonLoadoutAttributesConstants.GetTalonLoadoutAttributes(
                    this.talonLoadoutReport.GetTalonId()).GetEngineAttributes(),
                this.talonLoadoutReport.GetArmorReport().GetLoadoutAttributes().GetEngineAttributes(),
                this.talonLoadoutReport.GetEngineReport().GetLoadoutAttributes().GetEngineAttributes(),
            };
            // Collect the IEngineAttributes from the mounts
            foreach (IMountReport mountReport in this.talonLoadoutReport.GetMountReportList())
            {
                engineAttributesSet.Add(mountReport.GetLoadoutAttributes().GetEngineAttributes());
            }
            return new EngineAttributes.Builder().Build(engineAttributesSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IList<IWeaponAttributes> BuildWeaponAttributesList()
        {
            // Default an empty list for the IWeaponAttributes
            IList<IWeaponAttributes> weaponAttributesList = new List<IWeaponAttributes>();
            // Collect the IWeaponAttributes from the Armor and Engine
            ISet<IWeaponAttributes> weaponAttributesSet = new HashSet<IWeaponAttributes>()
            {
                this.talonLoadoutReport.GetArmorReport().GetLoadoutAttributes().GetWeaponAttributes(),
                this.talonLoadoutReport.GetEngineReport().GetLoadoutAttributes().GetWeaponAttributes(),
            };
            // Iterate over the List: IMountReport for the Utilities
            foreach (IMountReport mountReport in this.talonLoadoutReport.GetMountReportList())
            {
                // Check if the IMountReport is a IUtilityReport
                if (mountReport is IUtilityReport utilityReport)
                {
                    // Collect the IWeaponAttributes from the Utility
                    weaponAttributesSet.Add(utilityReport.GetLoadoutAttributes().GetWeaponAttributes());
                }
            }
            // Iterate over the List: IMountReport for the Weapons
            foreach (IMountReport mountReport in this.talonLoadoutReport.GetMountReportList())
            {
                // Check if the IMountReport is a IWeaponReport
                if (mountReport is IWeaponReport weaponReport)
                {
                    // Build a new IWeaponAttributes from the Set: IWeaponAttributes
                    weaponAttributesList.Add(new WeaponAttributes.Builder()
                        .Build(new HashSet<IWeaponAttributes>(weaponAttributesSet)
                        { weaponReport.GetLoadoutAttributes().GetWeaponAttributes() }));
                }
                else
                {
                    // Add a null value since this is not a IWeaponReport
                    weaponAttributesList.Add(null);
                }
            }
            return weaponAttributesList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void InputTalonEffectObject(ITalonEffectObject talonEffectObject)
        {
            if (talonEffectObject.GetDuration() == 0)
            {
                // The Effect is immediate
                this.destructibleObject.InputTalonEffect(talonEffectObject);
                this.movableObject.InputTalonEffect(talonEffectObject);
            }
            else
            {
                // Cache the effect
                this.talonEffectRemainingDurationDictionary.Add(
                    talonEffectObject, talonEffectObject.GetDuration());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void ApplyCachedTalonEffectObjects()
        {
            ISet<ITalonEffectObject> talonEffectObjectSet = new HashSet<ITalonEffectObject>(
                this.talonEffectRemainingDurationDictionary.Keys);
            foreach (ITalonEffectObject talonEffectObject in talonEffectObjectSet)
            {
                int remainingDuration = this.talonEffectRemainingDurationDictionary[talonEffectObject] - 1;
                this.InputTalonEffectObject(talonEffectObject);
                if (remainingDuration == 0)
                {
                    this.talonEffectRemainingDurationDictionary.Remove(talonEffectObject);
                }
                else
                {
                    this.talonEffectRemainingDurationDictionary[talonEffectObject] = remainingDuration;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private ITalonLoadoutReport talonLoadoutReport = null;

            // Todo
            private ITalonCustomizationReport customizationReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonObject(this.talonCallSign,
                        this.talonLoadoutReport, this.customizationReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
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
            /// <param name="talonLoadoutReport"></param>
            /// <returns></returns>
            public Builder SetTalonLoadoutReport(ITalonLoadoutReport talonLoadoutReport)
            {
                this.talonLoadoutReport = talonLoadoutReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="customizationReport"></param>
            /// <returns></returns>
            public Builder SetCustomizationReport(ITalonCustomizationReport customizationReport)
            {
                this.customizationReport = customizationReport;
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
                    argumentExceptionSet.Add(typeof(TalonCallSign).Name + " has not been set");
                }
                // Check that talonLoadoutReport has been set
                if (this.talonLoadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonLoadoutReport).Name + " has not been set");
                }
                // Check that customizationReport has been set
                if (this.customizationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonCustomizationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}