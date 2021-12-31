using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Impls
{
    /// <summary>
    /// Gear Report Impl
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
            /// Builder Impl for this object
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