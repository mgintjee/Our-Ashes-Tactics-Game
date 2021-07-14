using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Weapons.Collections.Interfaces
{
    /// <summary>
    /// Sortie Weapon View Collection Interface
    /// </summary>
    public interface IWeaponViewCollection
    {
        /// <summary>
        /// Todo
        /// </summary>
        void Clear();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequest"></param>
        void Process(ISortieRequest controllerRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequests"></param>
        void Process(ISet<ISortieRequest> controllerRequests);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcResponse"></param>
        void Process(IMvcResponse mvcResponse);
    }
}