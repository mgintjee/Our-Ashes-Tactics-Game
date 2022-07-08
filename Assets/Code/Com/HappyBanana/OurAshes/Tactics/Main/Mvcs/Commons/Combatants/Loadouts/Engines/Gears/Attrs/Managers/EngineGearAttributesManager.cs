using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class EngineGearAttributesManager
    {
        private static readonly IDictionary<EngineGearID, IGearAttributes> ID_ATTRIBUTES =
            new Dictionary<EngineGearID, IGearAttributes>()
            {
                { EngineGearID.EAA, new EaaAttributesImpl() },
                { EngineGearID.EBA, new EbaAttributesImpl() },
                { EngineGearID.ECA, new EcaAttributesImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Optional<IGearAttributes> GetAttributes(EngineGearID id)
        {
            return (ID_ATTRIBUTES.ContainsKey(id))
                ? Optional<IGearAttributes>.Of(ID_ATTRIBUTES[id])
                : Optional<IGearAttributes>.Empty();
        }
    }
}