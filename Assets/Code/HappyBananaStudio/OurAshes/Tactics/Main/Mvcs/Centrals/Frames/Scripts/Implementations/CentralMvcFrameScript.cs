using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Scripts.Implementations
{
    /// <summary>
    /// Central Mvc Frame Script Implementation
    /// </summary>
    public class CentralMvcFrameScript
        : AbstractMvcFrameScript, ICentralMvcFrameScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript parentUnityScript;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICentralMvcFrameScript Build()
            {
                GameObject gameObject = new GameObject(typeof(ICentralMvcFrameScript).Name);
                ICentralMvcFrameScript viewScript = gameObject.AddComponent<CentralMvcFrameScript>();
                viewScript.SetParent(parentUnityScript);
                return gameObject.GetComponent<ICentralMvcFrameScript>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.parentUnityScript = unityScript;
                return this;
            }
        }

        /*
        // Provides logging capability to the CENTRAL logs
        private readonly ILogger _centralLogger = LoggerManager.GetLogger(MvcType.Central,new StackFrame().GetMethod().DeclaringType);

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
                _centralMvcFrame = new CentralMvcFrame(this);
            }
        }
        */
    }
}