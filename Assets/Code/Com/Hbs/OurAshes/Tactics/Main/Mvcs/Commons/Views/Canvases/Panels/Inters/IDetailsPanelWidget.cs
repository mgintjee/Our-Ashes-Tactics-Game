using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    /// <summary>
    /// Panel Widget Interface
    /// </summary>
    public interface IDetailsPanelWidget
        : IPanelWidget
    {
        void ProcessState(IMvcModelState mvcModelState);
    }
}