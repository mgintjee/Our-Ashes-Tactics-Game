using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Impls;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Impls
{
    /// <summary>
    /// Mvc Frame Script Impl
    /// </summary>
    public class MvcFrameScriptImpl : UnityScript, IMvcFrameScript
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
            /// Builder Impl for this object
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
                    IMvcFrameScript mvcFrameScript = gameObject.AddComponent<MvcFrameScriptImpl>();
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