<<<<<<< HEAD:Assets/Code/Com/HappyBanana/OurAshes/Tactics/Main/Mvcs/Commons/Combatants/Loadouts/Gears/Engines/Attrs/Managers/EngineAttributesManager.cs
﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
=======
﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
>>>>>>> dev:Assets/Code/Com/HappyBanana/OurAshes/Tactics/Main/Combatants/Loadouts/Gears/Engines/Attrs/Managers/EngineAttributesManager.cs
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Engines.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Engines.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Engines.Attrs.Managers
{
    public static class EngineAttributesManager
    {
        private static readonly IList<IGearAttributes<EngineGearID>> KNOWN_IMPLS = new List<IGearAttributes<EngineGearID>>()
        {
            new EsaAttributesImpl(),
            new EmaAttributesImpl(),
            new ElaAttributesImpl()
        };

        /// <summary>
        /// s Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IOptional<IGearAttributes<EngineGearID>> GetAttributes(EngineGearID id)
        {
            foreach (IGearAttributes<EngineGearID> gearAttributes in KNOWN_IMPLS)
            {
                if (gearAttributes.GetID() == id)
                {
                    return Optional<IGearAttributes<EngineGearID>>.Of(gearAttributes);
                }
            }
            return Optional<IGearAttributes<EngineGearID>>.Empty();
        }
    }
}