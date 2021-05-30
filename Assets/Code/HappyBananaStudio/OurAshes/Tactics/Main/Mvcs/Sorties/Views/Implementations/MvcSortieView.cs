using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Implementations
{
    /// <summary>
    /// Sortie Mvc View Implementation
    /// </summary>
    public class MvcSortieView
        : IMvcSortieView
    {
        // Todo
        private readonly ICanvasView canvasView;

        // Todo
        private readonly IRosterView rosterView;

        // Todo
        private readonly IMapView mapView;

        // Todo
        private readonly ISortieViewScript sortieViewScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcSortieFrameConstruction"></param>
        /// <param name="unityScript">               </param>
        private MvcSortieView(IMvcSortieFrameConstruction mvcSortieFrameConstruction,
            IUnityScript unityScript)
        {
            this.sortieViewScript = new SortieViewScript.Builder()
                .SetUnityScript(unityScript)
                .Build();
            this.canvasView = new CanvasView.Builder()
                .SetUnityScript(sortieViewScript)
                .Build();
            this.rosterView = new RosterView.Builder()
                .SetUnityScript(sortieViewScript)
                .Build();
            this.mapView = new MapView.Builder()
                .SetUnityScript(sortieViewScript)
                .Build();
        }

        void IMvcView.InputModelResponse(IMvcModelResponse mvcModelResponse)
        {
            throw new System.NotImplementedException();
        }

        bool IMvcSortieView.IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        void IMvcSortieView.Process(ISortieControllerRequest controllerRequest)
        {
            throw new System.NotImplementedException();
        }

        void IMvcSortieView.Process(ISet<ISortieControllerRequest> controllerRequests)
        {
            throw new System.NotImplementedException();
        }

        void IMvcSortieView.Process(ISortieModelResponse sortieModelResponse)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript parentUnityScript;

            // Todo
            private IMvcSortieFrameConstruction mvcSortieFrameConstruction;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcSortieView Build()
            {
                return new MvcSortieView(this.mvcSortieFrameConstruction, parentUnityScript);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.parentUnityScript = unityScript;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcSortieFrameConstruction"></param>
            /// <returns></returns>
            public Builder SetMvcSortieFrameConstruction(IMvcSortieFrameConstruction mvcSortieFrameConstruction)
            {
                this.mvcSortieFrameConstruction = mvcSortieFrameConstruction;
                return this;
            }
        }
    }
}