using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Collections.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Collections.Implementations
{
    /// <summary>
    /// Sortie Tile View Collection Implementation
    /// </summary>
    public class TileViewCollection
        : ITileViewCollection
    {
        // Todo
        private readonly ISet<ITileView> tileViews = new HashSet<ITileView>();

        private TileViewCollection()
        {
        }

        void ITileViewCollection.Clear()
        {
            foreach (ITileView tileView in tileViews)
            {
                tileView.Clear();
            }
            tileViews.Clear();
        }

        void ITileViewCollection.Process(ISortieRequest controllerRequest)
        {
            throw new System.NotImplementedException();
        }

        void ITileViewCollection.Process(ISet<ISortieRequest> controllerRequests)
        {
            throw new System.NotImplementedException();
        }

        void ITileViewCollection.Process(IMvcResponse mvcResponse)
        {
            // Todo: Check if there is a controller request If not generate all of the tiles Else
            // update tiles based off of the reports
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
            public ITileViewCollection Build()
            {
                return new TileViewCollection();
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