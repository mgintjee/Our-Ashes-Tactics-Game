/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Views.Impls
{
    /// <summary>
    /// Sortie Mvc View Impl
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
        private MvcSortieView(IMvcControlConstruction mvcSortieFrameConstruction,
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

        void IMvcView.Process(IMvcModelResponse mvcModelResponse)
        {
            throw new System.NotImplementedException();
        }

        bool IMvcSortieView.IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        void IMvcSortieView.Process(ISortieRequest ModelRequest)
        {
            throw new System.NotImplementedException();
        }

        void IMvcSortieView.Process(ISet<ISortieRequest> ModelRequests)
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
            private IMvcControlConstruction mvcSortieFrameConstruction;

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
            public Builder SetMvcSortieFrameConstruction(IMvcControlConstruction mvcSortieFrameConstruction)
            {
                this.mvcSortieFrameConstruction = mvcSortieFrameConstruction;
                return this;
            }
        }
    }
}*/