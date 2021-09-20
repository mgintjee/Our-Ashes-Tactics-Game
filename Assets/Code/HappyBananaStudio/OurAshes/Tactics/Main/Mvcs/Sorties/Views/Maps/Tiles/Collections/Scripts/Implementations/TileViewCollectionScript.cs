using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Collections.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Collections.Scripts.Implementations
{
    /// <summary>
    /// Sortie Tile View Collection Script Implementation
    /// </summary>
    public class TileViewCollectionScript : AbstractUnityScript, ITileViewCollectionScript
    {
        void ITileViewCollectionScript.Clear()
        {
            throw new System.NotImplementedException();
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
            public ITileViewCollectionScript Build()
            {
                GameObject gameObject = new GameObject(typeof(ITileViewCollectionScript).Name);
                ITileViewCollectionScript viewScript = gameObject.AddComponent<TileViewCollectionScript>();
                viewScript.SetParent(unityScript);
                return gameObject.GetComponent<ITileViewCollectionScript>();
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