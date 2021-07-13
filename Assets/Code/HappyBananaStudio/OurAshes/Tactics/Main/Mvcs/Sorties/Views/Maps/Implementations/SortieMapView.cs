using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Collections.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Collections.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Scripts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Collections.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Collections.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SortieMapView
        : ISortieMapView
    {
        // Todo
        private readonly IPathViewCollection pathViewCollection;

        // Todo
        private readonly ITileViewCollection tileViewCollection;

        // Todo
        private readonly IMapViewScript mapViewScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="unityScript"></param>
        private SortieMapView(IUnityScript unityScript)
        {
            this.mapViewScript = new MapViewScript.Builder()
                .SetUnityScript(unityScript)
                .Build();
            this.pathViewCollection = new PathViewCollection.Builder()
                .SetUnityScript(mapViewScript)
                .Build();
            this.tileViewCollection = new TileViewCollection.Builder()
                .SetUnityScript(mapViewScript)
                .Build();
        }

        /// <inheritdoc/>
        void ISortieMapView.Process(ISortieRequest controllerRequest)
        {
            pathViewCollection.Process(controllerRequest);
            tileViewCollection.Process(controllerRequest);
        }

        /// <inheritdoc/>
        void ISortieMapView.Process(ISet<ISortieRequest> controllerRequests)
        {
            pathViewCollection.Process(controllerRequests);
            tileViewCollection.Process(controllerRequests);
        }

        /// <inheritdoc/>
        void ISortieMapView.Process(IMvcResponse mvcResponse)
        {
            pathViewCollection.Process(mvcResponse);
            tileViewCollection.Process(mvcResponse);
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
            public ISortieMapView Build()
            {
                return new SortieMapView(unityScript);
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