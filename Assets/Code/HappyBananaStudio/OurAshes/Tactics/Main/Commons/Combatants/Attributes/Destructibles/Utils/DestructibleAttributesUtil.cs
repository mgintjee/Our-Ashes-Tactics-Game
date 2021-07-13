using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Destructibles.Utils
{
    /// <summary>
    /// Destructible Attributes Util
    /// </summary>
    public static class DestructibleAttributesUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleAttributes"></param>
        /// <returns></returns>
        public static IDestructibleAttributes Build(ICollection<IDestructibleAttributes> destructibleAttributes)
        {
            float health = 0.0f;
            float armor = 0.0f;

            foreach (IDestructibleAttributes attributes in destructibleAttributes)
            {
                health += attributes.GetHealth();
                armor += attributes.GetArmor();
            }

            return DestructibleAttributes.Builder.Get()
                .SetArmor(armor)
                .SetHealth(health)
                .Build();
        }
    }
}