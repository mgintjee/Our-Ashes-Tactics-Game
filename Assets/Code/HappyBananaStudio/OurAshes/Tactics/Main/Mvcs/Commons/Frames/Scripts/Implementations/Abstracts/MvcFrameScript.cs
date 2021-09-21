using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Implementations;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts
{
    /// <summary>
    /// Mvc Frame Script Implementation
    /// </summary>
    public class MvcFrameScript : UnityScript, IMvcFrameScript
    {
        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMvcFrameScript>
            {
                IBuilder SetMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IMvcFrameScript>, IBuilder
            {
                // Todo
                private IMvcFrameConstruction _mvcFrameConstruction;

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction)
                {
                    _mvcFrameConstruction = mvcFrameConstruction;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcFrameScript BuildObj()
                {
                    GameObject gameObject = new GameObject(typeof(IMvcFrameScript).Name + ": " + _mvcFrameConstruction.GetMvcType());
                    IMvcFrameScript mvcFrameScript = gameObject.AddComponent<MvcFrameScript>();
                    mvcFrameScript.SetParent(_mvcFrameConstruction.GetUnityScript());
                    return gameObject.GetComponent<IMvcFrameScript>();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcFrameConstruction);
                }
            }
        }
    }
}