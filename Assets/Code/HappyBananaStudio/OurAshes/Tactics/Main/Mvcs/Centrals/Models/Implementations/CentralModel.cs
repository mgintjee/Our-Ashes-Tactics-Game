using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Requests.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Constructions.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Constructions.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Models.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Views.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Implementations;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Models.Implementations
{
    /// <summary>
    /// Central Model Implementation
    /// </summary>
    public class CentralModel : AbstractMvcModel, IMvcModel
    {
        // Todo
        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>()
        {
            { MvcType.Sortie, null }, { MvcType.World, null }, { MvcType.Home, null },
        };

        // Todo
        private MvcType _activeMvcType = MvcType.None;
        // Todo
        private MvcType _prevMvcType = MvcType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public CentralModel(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            IMvcFrame mvcFrame = new HomeFrame(mvcFrameConstruction);
        }

        /// <inheritdoc/>
        protected override void BuildInitialRequests()
        {

        }

        /// <inheritdoc/>
        protected override void ProcessConfirmedRequest(IMvcRequest mvcRequest)
        {
            if(mvcRequest is EmptyMvcRequest emptyMvcRequest)
            {
                mvcTypeFrames[_activeMvcType].Continue();
            }
            else if(mvcRequest is ICentralRequest centralRequest)
            {
                if (_prevMvcType == MvcType.None)
                {
                    IMvcFrame mvcFrame = new HomeFrame(MvcFrameConstruction.Builder.Get()
                        .SetMvcControllerConstruction(HomeControllerConstruction.Builder.GetBuilder().Build())
                        .SetMvcModelConstruction(HomeModelConstruction.Builder.GetBuilder().Build())
                        .SetMvcViewConstruction(HomeViewConstruction.Builder.GetBuilder().Build())
                        .SetUnityScript(centralRequest.GetMvcFrameConstruction().GetUnityScript())
                        .SetSimulationType(centralRequest.GetMvcFrameConstruction().GetSimulationType())
                        .SetRandom(RandomManager.GetRandom(MvcType.Home))
                        .SetMvcType(MvcType.Home)
                        .Build());
                    _prevMvcType = MvcType.Home;
                    _activeMvcType = MvcType.Home;
                    mvcTypeFrames[MvcType.Home] = mvcFrame;
                }
                else
                {
                    if (_activeMvcType == MvcType.None)
                    {
                        IMvcFrame mvcFrame = null;
                        switch (centralRequest.GetMvcType())
                        {
                            case MvcType.Sortie:
                                mvcFrame = new SortieFrame(centralRequest.GetMvcFrameConstruction());
                                break;
                            default:
                                _logger.Warn("{} is not currently supported!", centralRequest.GetMvcType());
                                break;
                        }
                        if (mvcFrame != null)
                        {
                            _activeMvcType = centralRequest.GetMvcType();
                            mvcTypeFrames[centralRequest.GetMvcType()] = mvcFrame;
                        }
                    }
                    else
                    {
                        _logger.Warn("Unable to process {}. {} is currently active...", mvcRequest, _activeMvcType);
                    }
                }
            }
        }
    }
}