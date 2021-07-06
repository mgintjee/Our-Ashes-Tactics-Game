using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Models.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Views.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Controllers.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Models.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Views.Constructions.Implementations;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Implementations
{
    /// <summary>
    /// Central Mvc Frame Implementation
    /// </summary>
    public class CentralMvcFrame
        : AbstractMvcFrame, ICentralMvcFrame
    {
        // Provides logging capability to the CENTRAL logs
        private readonly ILogger _centralLogger = LoggerManager.GetLogger(MvcType.Central, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>()
        {
            { MvcType.Sortie, null },
            { MvcType.World, null },
            { MvcType.Home, null },
        };

        // Todo
        private IMvcFrame _activeMvcFrame = null;

        // Todo
        private bool isComplete = false;

        // Todo
        private IMvcFrameScript mvcFrameScript;

        /// <summary>
        /// Todo
        /// </summary>
        public CentralMvcFrame(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if(this._activeMvcFrame == null)
            {
                // Todo: Maybe get these values from a file or something?
                // Todo: Also make this a method or something
                this._activeMvcFrame = new HomeMvcFrame(new MvcFrameConstruction.Builder()
                    .SetMvcControllerConstruction(new HomeMvcControllerConstruction())
                    .SetMvcModelConstruction(new HomeMvcModelConstruction())
                    .SetMvcViewConstruction(new HomeMvcViewConstruction())
                    .SetMvcType(MvcType.Home)
                    .SetSimulationType(SimulationType.Interactive)
                    .SetUnityScript(_mvcFrameScript)
                    .SetRandom(RandomManager.GetRandom(MvcType.Central))
                    .Build());
                this.mvcTypeFrames[MvcType.Home] = _activeMvcFrame;
            }
            else
            {
                _activeMvcFrame.Continue();
                if (_activeMvcFrame.IsComplete())
                {
                    _activeMvcFrame.Destroy();
                    _activeMvcFrame = null;
                    this.mvcTypeFrames[MvcType.Sortie] = null;
                }
            }
        }

        /// <inheritdoc/>
        void IMvcFrame.Destroy()
        {
            LoggerManager.EndLoggingFile(MvcType.Central);
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsComplete()
        {
            return this.isComplete;
        }

        protected override IMvcController BuildMvcController(IMvcFrameConstruction mvcFrameConstruction)
        {
            throw new System.NotImplementedException();
        }


        protected override IMvcModel BuildMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            throw new System.NotImplementedException();
        }

        protected override IMvcView BuildMvcView(IMvcFrameConstruction mvcFrameConstruction)
        {
            throw new System.NotImplementedException();
        }
    }
}