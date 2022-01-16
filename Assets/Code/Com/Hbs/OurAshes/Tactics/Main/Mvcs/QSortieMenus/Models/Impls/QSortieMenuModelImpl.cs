using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Models.Impls
{
    /// <summary>
    /// QSortie Model Impl
    /// </summary>
    public class QSortieMenuModelImpl
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public QSortieMenuModelImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected override IMvcModelState ProcessInitialMvcModelRequest()
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetMvcRequests(new HashSet<IMvcRequest>
                    {
                        new QSortieMenuRequestImpl().SetQSortieRequestType(QSortieMenuRequestType.CombatantDetails),
                        new QSortieMenuRequestImpl().SetQSortieRequestType(QSortieMenuRequestType.SortieDetails),
                        new QSortieMenuRequestImpl().SetQSortieRequestType(QSortieMenuRequestType.PhalanxDetails),
                        new QSortieMenuRequestImpl().SetQSortieRequestType(QSortieMenuRequestType.SortieDetails),
                        new QSortieMenuRequestImpl().SetQSortieRequestType(QSortieMenuRequestType.MapDetails)
                    });
            return this.mvcModelState;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelRequest"></param>
        /// <returns></returns>
        protected override IMvcModelState ProcessMvcModelRequest(IMvcRequest mvcModelRequest)
        {
            return this.mvcModelState;
        }
    }
}