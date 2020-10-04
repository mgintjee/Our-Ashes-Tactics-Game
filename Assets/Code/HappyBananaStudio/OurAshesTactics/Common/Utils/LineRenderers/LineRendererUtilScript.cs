/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.LineRenderers
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