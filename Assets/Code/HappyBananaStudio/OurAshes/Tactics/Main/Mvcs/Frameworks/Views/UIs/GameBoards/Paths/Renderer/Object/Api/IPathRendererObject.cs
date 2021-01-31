namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Paths.Renderer.Object.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IPathRendererObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        void ShowPathObject(IPathObject pathObject);

        /// <summary>
        /// Todo
        /// </summary>
        void HidePathObject();
    }
}