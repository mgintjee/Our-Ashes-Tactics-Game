using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Collections.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Collections.Implementations
{
    /// <summary>
    /// Path View Collection Implementation
    /// </summary>
    public class PathViewCollection
        : IPathViewCollection
    {
        // Todo
        private readonly ISet<IPathView> pathViews = new HashSet<IPathView>();

        void IPathViewCollection.Clear()
        {
            foreach (IPathView pathView in pathViews)
            {
                pathView.Clear();
            }
            pathViews.Clear();
        }

        void IPathViewCollection.Process(ISortieRequest controllerRequest)
        {
            throw new System.NotImplementedException();
        }

        void IPathViewCollection.Process(ISet<ISortieRequest> controllerRequests)
        {
            throw new System.NotImplementedException();
        }

        void IPathViewCollection.Process(ISortieResponse modelResponse)
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
            public IPathViewCollection Build()
            {
                return new PathViewCollection();
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