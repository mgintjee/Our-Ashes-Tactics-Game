using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Attrs.Managers
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
        public static Optional<IGearAttributes<EngineGearID>> GetAttributes(EngineGearID id)
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