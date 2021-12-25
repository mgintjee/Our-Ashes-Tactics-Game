using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Utils
{
    /// <summary>
    /// Fireable Attributes Util
    /// </summary>
    public static class FireableAttributesUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fireableAttributes"></param>
        /// <returns></returns>
        public static IFireableAttributes Build(ICollection<IFireableAttributes> fireableAttributes)
        {
            float range = 0.0f;
            float accuracy = 0.0f;

            foreach (IFireableAttributes attributes in fireableAttributes)
            {
                range += attributes.GetRange();
                accuracy += attributes.GetAccuracy();
            }

            return FireableAttributes.Builder.Get()
                .SetAccuracy(accuracy)
                .SetRange(range)
                .Build();
        }
    }
}