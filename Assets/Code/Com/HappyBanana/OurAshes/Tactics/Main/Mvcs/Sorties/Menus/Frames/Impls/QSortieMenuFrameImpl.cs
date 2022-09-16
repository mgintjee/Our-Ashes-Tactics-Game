using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Impls
{
    /// <summary>
    /// QSortie Frame Impl
    /// </summary>
    public class QSortieMenuFrameImpl
        : AbstractMvcFrame, IMvcFrame
    {
        public QSortieMenuFrameImpl(IMvcFrameConstruction mvcFrameConstruction, IMvcFrameResult prevMvcFrameResult)
            : base(mvcFrameConstruction, prevMvcFrameResult)
        {
        }

        /// <inheritdoc/>
        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcModelImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            return new MvcViewImpl(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override IMvcRequest GetInitialRequest()
        {
            return new DefaultRequestImpl(RequestType.DetailsSortie);
        }

        /// <inheritdoc/>
        protected override void BuildNextMvcFrameConstruction()
        {
            mvcM.GetState().GetPrevMvcRequest().IfPresent(request =>
            {
                IQSortieMenuMvcRequest qSortieRequest = (IQSortieMenuMvcRequest)request;
                logger.Info("Building next {} for {}", typeof(IMvcFrameConstruction).Name, mvcType);
                switch (qSortieRequest.GetRequestType())
                {
                    case RequestType.SortieStart:
                        MvcType mvcType = MvcType.Sortie;
                        Random random = RandomManager.GetRandom(mvcType, currMvcFConstr.GetRandom().Next());
                        IMvcModelState mvcModelState = ((IMvcModelState)mvcM.GetState());
                        ICombatantsDetails combatantsDetails = mvcModelState.GetCombatantsDetails();
                        IFieldDetails fieldDetails = mvcModelState.GetFieldDetails();
                        IUnityScript unityScript = currMvcFConstr.GetUnityScript().GetParent().GetValue();
                        nextMvcFConstr = new SortieFrameConstructionImpl(combatantsDetails, fieldDetails,
                            mvcType, SimType.Interactive, unityScript, random);
                        break;
                }
            });
        }
    }
}