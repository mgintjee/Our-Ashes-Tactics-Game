/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Util.Renderer
{
    /// <summary>
    /// Todo
    /// </summary>
    public class LineRendererUtilScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public LineRenderer GetLineRenderer()
        {
            return this.GetGameObject().GetComponent<LineRenderer>();
        }

        #endregion Public Methods
    }
}