using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Scripts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Implementations
{
    /// <summary>
    /// Sortie Mvc View Implementation
    /// </summary>
    public class SortieMvcView
        : AbstractMvcView, IMvcView
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
        /// <param name="mvcFrameConstruction"></param>
        public SortieMvcView(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        public override bool IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        public override void Process(IMvcResponse mvcResponse)
        {
            throw new System.NotImplementedException();
        }

        public override void Process(IMvcRequest mvcRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}