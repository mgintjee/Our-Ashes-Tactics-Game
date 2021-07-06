using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Controllers.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Models.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Models.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Views.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Startups.Scripts.Implementations
{
    /// <summary>
    /// Mvc Startup Script Implementation
    /// </summary>
    public class MvcStartupScript
        : AbstractUnityScript
    {
        private readonly int Seed = 20150123;

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
                _centralMvcFrame = new CentralMvcFrame(
                    new MvcFrameConstruction.Builder()
                        .SetMvcControllerConstruction(new CentralMvcControllerConstruction())
                        .SetMvcModelConstruction(new CentralMvcModelConstruction())
                        .SetMvcViewConstruction(new CentralMvcViewConstruction())
                        .SetRandom(new Random(Seed))
                        .SetSimulationType(SimulationType.Interactive)
                        .SetUnityScript(this)
                        .Build());
            }
        }
    }
}