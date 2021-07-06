using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts
{
    /// <summary>
    /// Mvc Frame Script Implementation
    /// </summary>
    public class MvcFrameScriptImplementation
        : AbstractUnityScript, IMvcFrameScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
            : AbstractBuilder<IMvcFrameScript>
        {
            // Todo
            protected IMvcFrameConstruction _mvcFrameConstruction;

            /// <inheritdoc/>
            protected override IMvcFrameScript BuildObj()
            {
                GameObject gameObject = new GameObject(typeof(IMvcFrameScript).Name + ": " + _mvcFrameConstruction.GetMvcType());
                IMvcFrameScript mvcFrameScript = gameObject.AddComponent<MvcFrameScriptImplementation>();
                mvcFrameScript.SetParent(_mvcFrameConstruction.GetUnityScript());
                return gameObject.GetComponent<IMvcFrameScript>();
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcFrameConstruction"></param>
            /// <returns></returns>
            public Builder SetMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction)
            {
                _mvcFrameConstruction = mvcFrameConstruction;
                return this;
            }

            /// <inheritdoc/>
            protected override void Validate(ISet<string> invalidReasons)
            {
                Validate(invalidReasons, _mvcFrameConstruction);
            }
        }
    }
}