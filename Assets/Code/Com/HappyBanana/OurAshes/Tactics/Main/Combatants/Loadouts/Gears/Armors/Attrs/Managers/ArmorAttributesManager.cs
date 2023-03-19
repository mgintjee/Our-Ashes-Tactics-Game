<<<<<<< HEAD:Assets/Code/Com/HappyBanana/OurAshes/Tactics/Main/Mvcs/Commons/Combatants/Loadouts/Gears/Armors/Attrs/Managers/ArmorAttributesManager.cs
﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
=======
﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
>>>>>>> dev:Assets/Code/Com/HappyBanana/OurAshes/Tactics/Main/Combatants/Loadouts/Gears/Armors/Attrs/Managers/ArmorAttributesManager.cs
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Armors.Attrs.Managers
{
    public static class ArmorAttributesManager
    {
        private static readonly IList<IGearAttributes<ArmorGearID>> KNOWN_IMPLS = new List<IGearAttributes<ArmorGearID>>()
        {
            new AsaAttributesImpl(),
            new AmaAttributesImpl(),
            new AlaAttributesImpl()
        };

        /// <summary>
        /// s Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IOptional<IGearAttributes<ArmorGearID>> GetAttributes(ArmorGearID id)
        {
            foreach (IGearAttributes<ArmorGearID> gearAttributes in KNOWN_IMPLS)
            {
                if (gearAttributes.GetID() == id)
                {
                    return Optional<IGearAttributes<ArmorGearID>>.Of(gearAttributes);
                }
            }
            return Optional<IGearAttributes<ArmorGearID>>.Empty();
        }
    }
}