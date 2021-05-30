using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Commons.Loggers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Commons.Randoms;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Scripts.Implementations
{
    /// <summary>
    /// Central Mvc Frame Script Implementation
    /// </summary>
    public class CentralMvcFrameScript
        : AbstractMvcFrameScript, ICentralMvcFrameScript
    {
        // Todo
        private static readonly ILogger _centralLogger = new CentralLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private bool _centralComplete;

        // Todo
        private ICentralMvcFrame _centralMvcFrame;

        /// <inheritdoc/>
        protected override void OnFixedUpdate()
        {
            if (_centralMvcFrame != null)
            {
                if (!_centralComplete)
                {
                    _centralMvcFrame.Continue();
                    _centralComplete = _centralMvcFrame.IsComplete();
                }
                else
                {
                    _centralLogger.Info("Central is complete.");
                }
            }
            else
            {
                _centralMvcFrame = new CentralMvcFrame();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected override void OnAwake()
        {
            _centralLogger.CreateLogFile();
            CentralRandom.GetInstance();
        }
    }
}