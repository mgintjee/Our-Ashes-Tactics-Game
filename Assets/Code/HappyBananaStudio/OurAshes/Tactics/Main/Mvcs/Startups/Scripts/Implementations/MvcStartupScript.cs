using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Commons.Loggers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Commons.Randoms;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Startups.Scripts.Implementations
{
    /// <summary>
    /// Mvc Startup Script Implementation
    /// </summary>
    public class MvcStartupScript
        : AbstractUnityScript
    {
        // Todo
        private bool _centralComplete;

        // Todo
        private ICentralMvcFrame _centralMvcFrame;

        /// <inheritdoc/>
        protected void FixedUpdate()
        {
            if (_centralMvcFrame != null)
            {
                if (!_centralMvcFrame.IsComplete())
                {
                    _centralMvcFrame.Continue();
                }
            }
            else
            {
                _centralMvcFrame = new CentralMvcFrame();
            }
        }
    }
}