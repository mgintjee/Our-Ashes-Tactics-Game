using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Weapons.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Weapons.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Implementations
{
    /// <summary>
    /// Gear Report Implementation
    /// </summary>
    public class GearReport : AbstractReport, IGearReport
    {
        // Todo
        private readonly GearID _gearID;

        // Todo
        private readonly ITraitReport _traitReport;

        // Todo
        private readonly ICombatantAttributes _combatantAttributes;

        // Todo
        private readonly IWeaponAttributes _weaponAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearID">     </param>
        /// <param name="traitReport"></param>
        private GearReport(GearID gearID, ITraitReport traitReport)
        {
            _gearID = gearID;
            _traitReport = traitReport;
            _combatantAttributes = CombatantAttributesUtil.Build(this);
            _weaponAttributes = WeaponAttributesUtil.Build(this);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, Set {2}",
                this.GetType().Name,
                StringUtils.Format(_gearID),
                _traitReport);
        }

        /// <inheritdoc/>
        ICombatantAttributes IGearReport.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        /// <inheritdoc/>
        GearID IGearReport.GetGearID()
        {
            return _gearID;
        }

        /// <inheritdoc/>
        ITraitReport IGearReport.GetTraitReport()
        {
            return _traitReport;
        }

        /// <inheritdoc/>
        IWeaponAttributes IGearReport.GetWeaponAttributes()
        {
            return _weaponAttributes;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}", _gearID, _traitReport);
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IGearReport>
            {
                IBuilder SetGearID(GearID gearID);

                IBuilder SetTraitReport(ITraitReport traitReport);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IGearReport>, IBuilder
            {
                private GearID _gearID;
                private ITraitReport _traitReport;

                /// <inheritdoc/>
                IBuilder IBuilder.SetGearID(GearID gearID)
                {
                    _gearID = gearID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetTraitReport(ITraitReport traitReport)
                {
                    _traitReport = traitReport;
                    return this;
                }

                /// <inheritdoc/>
                protected override IGearReport BuildObj()
                {
                    return new GearReport(_gearID, _traitReport);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _gearID);
                }
            }
        }
    }
}