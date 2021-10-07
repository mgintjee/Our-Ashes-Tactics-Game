using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Views.Gears.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Views.Gears.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Views.Gears.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class GearViewConstantsManager
    {
        private static readonly IDictionary<GearID, IGearViewConstants> IDViewConstants =
            new Dictionary<GearID, IGearViewConstants>()
        {
            {
                GearID.ArmorAlphaAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.ArmorAlphaAlphaDefault })
                .Build()
            },
            {
                GearID.ArmorBravoAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.ArmorBravoAlphaDefault })
                .Build()
            },
            {
                GearID.CabinAlphaAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.CabinAlphaAlphaDefault })
                .Build()
            },
            {
                GearID.CabinBravoAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.CabinBravoAlphaDefault})
                .Build()
            },
            {
                GearID.EngineAlphaAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.EngineAlphaAlphaDefault})
                .Build()
            },
            {
                GearID.EngineBravoAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.EngineBravoAlphaDefault})
                .Build()
            },
            {
                GearID.WeaponAlphaAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.WeaponAlphaAlphaDefault})
                .Build()
            },
            {
                GearID.WeaponBravoAlpha,
                GearViewConstants.Builder.Get()
                .SetGearSkins(new HashSet<GearSkin>(){GearSkin.WeaponBravoAlphaDefault})
                .Build()
            },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        public static Optional<IGearViewConstants> GetConstants(GearID combatantID)
        {
            return (IDViewConstants.ContainsKey(combatantID))
                ? Optional<IGearViewConstants>.Of(IDViewConstants[combatantID])
                : Optional<IGearViewConstants>.Empty();
        }
    }
}