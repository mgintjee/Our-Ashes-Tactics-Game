using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Collections.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Collections.Scripts.Implementations
{
    /// <summary>
    /// Sortie Weapon View Collection Script Implementation
    /// </summary>
    public class WeaponViewCollectionScript : AbstractUnityScript, IWeaponViewCollectionScript
    {
        private readonly IList<IWeaponView> weaponViews = new List<IWeaponView>();

        void IWeaponViewCollectionScript.Clear()
        {
            foreach (IWeaponView weaponView in weaponViews)
            {
                weaponView.Clear();
            }
            weaponViews.Clear();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript unityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IWeaponViewCollectionScript Build()
            {
                // Add Weapon ID and Skin and the position
                GameObject gameObject = new GameObject(typeof(IWeaponViewCollectionScript).Name);
                IWeaponViewCollectionScript viewScript = gameObject.AddComponent<WeaponViewCollectionScript>();
                viewScript.SetParent(unityScript);
                return gameObject.GetComponent<IWeaponViewCollectionScript>();
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
        }
    }
}