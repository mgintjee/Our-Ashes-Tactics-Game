namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.LineRenderers
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class LineRendererUtilScript
    : AbstractUnityScriptImpl
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