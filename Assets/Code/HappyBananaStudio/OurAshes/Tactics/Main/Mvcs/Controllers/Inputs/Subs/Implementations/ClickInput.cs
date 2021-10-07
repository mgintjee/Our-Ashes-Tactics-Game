using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Implementations;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Subs.Implementations
{
    /// <summary>
    /// Controller Click Input Implementation
    /// </summary>
    public class ClickInput : UnityScript, IClickInput
    {
        private IClick click;

        public void Update()
        {
            // Todo Check if clicked
            // OMG what if I don't utilize ANY button functionality and I just do it based off of the canvas position or the world position
            /// Determining if it is on the world or canvas could be hard. Could just check if it falls on some widget in the Foreground,
            /// it is there and then default to the background canvas
            if (Input.GetMouseButtonDown(0))
                Debug.Log("Pressed primary button.");

            if (Input.GetMouseButtonDown(1))
                Debug.Log("Pressed secondary button.");

            if (Input.GetMouseButtonDown(2))
                Debug.Log("Pressed middle click.");
        }

        IClick IClickInput.GetClick()
        {
            return this.click;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IClickBuilder : IBuilder<IClickInput>
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IClickBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IClickInput>, IClickBuilder
            {
                protected override IClickInput BuildObj()
                {
                    GameObject gameObject = new GameObject();
                    IClickInput clickInput = gameObject.AddComponent<ClickInput>();
                    return clickInput;
                }

                protected override void Validate(ISet<string> invalidReasons)
                {
                    // Todo
                }
            }
        }
    }
}