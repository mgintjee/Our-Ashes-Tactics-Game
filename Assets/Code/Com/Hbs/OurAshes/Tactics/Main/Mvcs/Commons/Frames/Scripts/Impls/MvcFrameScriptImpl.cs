using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Impls
{
    /// <summary>
    /// Mvc Frame Script Impl
    /// </summary>
    public class MvcFrameScriptImpl
        : AbstractUnityScript, IMvcFrameScript
    {
        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder
                : IScriptBuilder<IMvcFrameScript>
            {
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
            private class InternalBuilder
                : AbstractScriptBuilder<IMvcFrameScript>, IBuilder
            {
                /// <inheritdoc/>
                protected override IMvcFrameScript BuildScript(GameObject gameObject)
                {
                    IMvcFrameScript mvcFrameScript = gameObject.AddComponent<MvcFrameScriptImpl>();
                    this.ApplyScriptValues(mvcFrameScript);
                    return mvcFrameScript;
                }
            }
        }
    }
}