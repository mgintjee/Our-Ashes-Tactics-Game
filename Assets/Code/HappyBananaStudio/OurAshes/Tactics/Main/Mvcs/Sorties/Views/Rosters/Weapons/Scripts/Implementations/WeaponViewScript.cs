using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Scripts.Implementations
{
    /// <summary>
    /// Sortie Weapon View Script Implementation
    /// </summary>
    public class WeaponViewScript : AbstractUnityScript, IWeaponViewScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript unityScript;

            // Todo
            private GearSkin gearSkin;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IWeaponViewScript Build()
            {
                // Todo: Load the WeaponSkin with the ResourceLoader
                GameObject gameObject = new GameObject(typeof(IWeaponViewScript).Name + ":" + gearSkin);
                IWeaponViewScript viewScript = gameObject.AddComponent<WeaponViewScript>();
                viewScript.SetParent(unityScript);
                return gameObject.GetComponent<IWeaponViewScript>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.unityScript = unityScript;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSkin"></param>
            /// <returns></returns>
            public Builder SetGearSkin(GearSkin gearSkin)
            {
                this.gearSkin = gearSkin;
                return this;
            }
        }
    }
}