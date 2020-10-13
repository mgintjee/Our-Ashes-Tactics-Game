/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.LineRenderers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class LineRendererUtilScript
    : UnityScriptImpl
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
