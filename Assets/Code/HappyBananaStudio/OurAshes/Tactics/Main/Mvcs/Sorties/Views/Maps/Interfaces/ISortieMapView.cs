using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieRequest"></param>
        void ProcessSelected(ISortieRequest sortieRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieRequests"></param>
        void Process(ISet<ISortieRequest> sortieRequests);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcResponse"></param>
        void Process(IMvcResponse mvcResponse);
    }
}