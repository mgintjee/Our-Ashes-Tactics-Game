using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Scripts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Scripts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WeaponView
        : IWeaponView
    {
        // Todo
        private readonly IWeaponViewScript viewScript;

        /// <summary>
        /// Todo
        /// </summary>
        private WeaponView(IUnityScript unityScript, GearSkin gearSkin)
        {
            this.viewScript = new WeaponViewScript.Builder()
                .SetGearSkin(gearSkin)
                .SetUnityScript(unityScript)
                .Build();
        }

        /// <inheritdoc/>
        void IWeaponView.Clear()
        {
            this.viewScript.Destroy();
        }
    }
}