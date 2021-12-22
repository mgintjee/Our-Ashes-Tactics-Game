using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Utils
{
    /// <summary>
    /// Movable Attributes Util
    /// </summary>
    public static class MovableAttributesUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movableAttributes"></param>
        /// <returns></returns>
        public static IMovableAttributes Build(ICollection<IMovableAttributes> movableAttributes)
        {
            float actions = 0.0f;
            float movement = 0.0f;

            foreach (IMovableAttributes attributes in movableAttributes)
            {
                actions += attributes.GetActions();
                movement += attributes.GetMovement();
            }

            return MovableAttributes.Builder.Get()
                .SetActions(movement)
                .SetMovements(actions)
                .Build();
        }
    }
}