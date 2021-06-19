using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Startups.Scripts.Implementations
{
    /// <summary>
    /// Mvc Startup Script Implementation
    /// </summary>
    public class MvcStartupScript
        : AbstractUnityScript
    {
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
                _centralMvcFrame = new CentralMvcFrame(this);
            }
        }
    }
}