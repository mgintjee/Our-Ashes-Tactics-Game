using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Skins;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Views.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Views.Impls
{
    /// <summary>
    /// Combatant View Constants Impl
    /// </summary>
    public struct CombatantViewConstants : ICombatantViewConstants
    {
        private readonly CombatantID _combatantID;
        private readonly ICollection<CombatantSkin> _combatantSkins;

        private CombatantViewConstants(CombatantID combatantID, ICollection<CombatantSkin> combatantSkins)
        {
            _combatantID = combatantID;
            _combatantSkins = combatantSkins;
        }

        /// <inheritdoc/>
        CombatantID ICombatantViewConstants.GetCombatantID()
        {
            return _combatantID;
        }

        /// <inheritdoc/>
        ISet<CombatantSkin> ICombatantViewConstants.GetCombatantSkins()
        {
            return new HashSet<CombatantSkin>(_combatantSkins);
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ICombatantViewConstants>
            {
                IBuilder SetCombatantID(CombatantID combatantID);

                IBuilder SetCombatantSkins(ICollection<CombatantSkin> combatantSkins);
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
            private class InternalBuilder : AbstractBuilder<ICombatantViewConstants>, IBuilder
            {
                private CombatantID _combatantID = CombatantID.None;
                private ICollection<CombatantSkin> _combatantSkins = new List<CombatantSkin>();

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantSkins(ICollection<CombatantSkin> combatantSkins)
                {
                    _combatantSkins = new HashSet<CombatantSkin>(combatantSkins);
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantID(CombatantID combatantID)
                {
                    _combatantID = combatantID;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantViewConstants BuildObj()
                {
                    return new CombatantViewConstants(_combatantID, _combatantSkins);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantID);
                    this.Validate(invalidReasons, _combatantSkins);
                }
            }
        }
    }
}