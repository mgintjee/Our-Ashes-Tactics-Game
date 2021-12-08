using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Impls;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Impls
{
    /// <summary>
    /// Mvc Control Input Implementation
    /// </summary>
    public class MvcControlInput : UnityScript, IMvcControlInput
    {
        // Todo: probably include all of the other inputs here too. How do I link them to the view
        // is another question. Maybe in the report and have the MvcView display whatever the UI is?
        // Pending on changes in the model/Control?

        public void Start()
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IMvcControlInput>
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IMvcControlInput>, IBuilder
            {
                /// <inheritdoc/>
                protected override IMvcControlInput BuildObj()
                {
                    GameObject gameObject = new GameObject("ControlerInput");
                    return gameObject.AddComponent<MvcControlInput>();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}