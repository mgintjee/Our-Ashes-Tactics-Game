/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.LineRenderers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class LineRendererUtilScript
    : UnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public LineRenderer GetLineRenderer()
        {
            return this.GetGameObject().GetComponent<LineRenderer>();
        }
    }
}