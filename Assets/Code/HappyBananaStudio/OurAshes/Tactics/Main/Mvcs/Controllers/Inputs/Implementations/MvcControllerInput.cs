using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Implementations;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Implementations
{
    /// <summary>
    /// Mvc Controller Input Implementation
    /// </summary>
    public class MvcControllerInput : UnityScript, IMvcControllerInput
    {
        // Todo: probably include all of the other inputs here too. How do I link them to the view is another question.
        // Maybe in the report and have the MvcView display whatever the UI is? Pending on changes in the model/controller?
        private IClickInput clickInput;

        public void Start()
        {
            this.clickInput = ClickInput.Builder.Get()
                .Build();
        }

        Optional<IClick> IMvcControllerInput.GetClick()
        {
            return (this.clickInput != null)
                ? Optional<IClick>.Of(this.clickInput.GetClick())
                : Optional<IClick>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IMvcControllerInput>
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
            private class InternalBuilder : AbstractBuilder<IMvcControllerInput>, IBuilder
            {
                /// <inheritdoc/>
                protected override IMvcControllerInput BuildObj()
                {
                    GameObject gameObject = new GameObject("ControlerInput");
                    return gameObject.AddComponent<MvcControllerInput>();
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}