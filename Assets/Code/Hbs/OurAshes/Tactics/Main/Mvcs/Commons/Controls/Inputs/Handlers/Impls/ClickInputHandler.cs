using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Impls;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Impls
{
    /// <summary>
    /// TOdo
    /// </summary>
    public class ClickInputHandler : UnityScript, IMvcControlInputHandler
    {
        /// <inheritdoc/>
        public void Update()
        {
            // Todo Check if clicked OMG what if I don't utilize ANY button functionality and I just
            // do it based off of the canvas position or the world position
            /// Determining if it is on the world or canvas could be hard. Could just check if it
            /// falls on some widget in the Foreground, it is there and then default to the
            /// background canvas
            if (Input.GetMouseButtonDown(0))
                Debug.Log("Pressed primary button.");

            if (Input.GetMouseButtonDown(1))
                Debug.Log("Pressed secondary button.");

            if (Input.GetMouseButtonDown(2))
                Debug.Log("Pressed middle click.");
        }

        /// <inheritdoc/>
        IInput IMvcControlInputHandler.GetInput()
        {
            throw new System.NotImplementedException();
        }
    }
}