namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.LineRenderers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
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