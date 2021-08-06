using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Controllers.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Models.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Views.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Constructions.Frames.Implementations;
using System;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Startups.Scripts.Implementations
{
    /// <summary>
    /// Mvc Startup Script Implementation
    /// </summary>
    public class MvcStartupScript : AbstractUnityScript
    {
        // Todo
        private readonly int Seed = 20150123;

        // Todo
        private ICentralFrame _centralMvcFrame;

        /// <inheritdoc/>
        protected void FixedUpdate()
        {
            if (_centralMvcFrame != null)
            {
                Debug.Log(_centralMvcFrame.GetType().Name + " is not null...");
                if (!_centralMvcFrame.IsComplete())
                {
                    Debug.Log(_centralMvcFrame.GetType().Name + " is not complete...");
                    _centralMvcFrame.Continue();
                }
                else
                {
                    Debug.Log(_centralMvcFrame.GetType().Name + " is complete!");
                    ((IUnityScript)this).Destroy();
                }
            }
            else
            {
                _centralMvcFrame = new CentralFrame(MvcFrameConstruction.Builder.Get()
                    .SetMvcControllerConstruction(CentralControllerConstruction.Builder.GetBuilder().Build())
                    .SetMvcModelConstruction(CentralModelConstruction.Builder.GetBuilder().Build())
                    .SetMvcViewConstruction(CentralViewConstruction.Builder.GetBuilder().Build())
                    .SetSimulationType(SimulationType.Interactive)
                    .SetMvcType(MvcType.Central)
                    .SetRandom(new System.Random(Seed))
                    .SetUnityScript(this)
                    .Build());
                _centralMvcFrame.Continue();
            }
        }
    }
}