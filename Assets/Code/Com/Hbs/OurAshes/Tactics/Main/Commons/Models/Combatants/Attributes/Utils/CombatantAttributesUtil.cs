using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Utils
{
    /// <summary>
    /// Combatant Attributes Util
    /// </summary>
    public static class CombatantAttributesUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        /// <returns></returns>
        public static ICombatantAttributes Build(ICollection<ICombatantAttributes> combatantAttributes)
        {
            return CombatantAttributes.Builder.Get()
                .SetDestructibleAttributes(BuildDestructibleAttributes(combatantAttributes))
                .SetFireableAttributes(BuildFireableAttributes(combatantAttributes))
                .SetMovableAttributes(BuildMovableAttributes(combatantAttributes))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearReport"></param>
        /// <returns></returns>
        public static ICombatantAttributes Build(IGearReport gearReport)
        {
            ISet<ICombatantAttributes> combatantAttributes = new HashSet<ICombatantAttributes>();

            GearModelConstantsManager.GetConstants(gearReport.GetGearID()).IfPresent(gearModelConstants =>
            {
                combatantAttributes.Add(gearModelConstants.GetCombatantAttributes());
            });
            combatantAttributes.Add(Build(gearReport.GetTraitReport()));
            return Build(combatantAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitReport"></param>
        /// <returns></returns>
        public static ICombatantAttributes Build(ITraitReport traitReport)
        {
            ISet<ICombatantAttributes> combatantAttributes = new HashSet<ICombatantAttributes>();

            foreach (TraitID traitID in traitReport.GetTraitIDs())
            {
                TraitModelConstantsManager.GetConstants(traitID).IfPresent(traitModelConstants =>
                {
                    combatantAttributes.Add(traitModelConstants.GetCombatantAttributes());
                });
            }

            return Build(combatantAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        /// <returns></returns>
        private static IDestructibleAttributes BuildDestructibleAttributes(ICollection<ICombatantAttributes> combatantAttributes)
        {
            ISet<IDestructibleAttributes> destructibleAttributes = new HashSet<IDestructibleAttributes>();

            foreach (ICombatantAttributes attributes in combatantAttributes)
            {
                destructibleAttributes.Add(attributes.GetDestructibleAttributes());
            }

            return DestructibleAttributesUtil.Build(destructibleAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        /// <returns></returns>
        private static IFireableAttributes BuildFireableAttributes(ICollection<ICombatantAttributes> combatantAttributes)
        {
            ISet<IFireableAttributes> fireableAttributes = new HashSet<IFireableAttributes>();

            foreach (ICombatantAttributes attributes in combatantAttributes)
            {
                fireableAttributes.Add(attributes.GetFireableAttributes());
            }

            return FireableAttributesUtil.Build(fireableAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        /// <returns></returns>
        private static IMovableAttributes BuildMovableAttributes(ICollection<ICombatantAttributes> combatantAttributes)
        {
            ISet<IMovableAttributes> movableAttributes = new HashSet<IMovableAttributes>();

            foreach (ICombatantAttributes attributes in combatantAttributes)
            {
                movableAttributes.Add(attributes.GetMovableAttributes());
            }

            return MovableAttributesUtil.Build(movableAttributes);
        }
    }
}