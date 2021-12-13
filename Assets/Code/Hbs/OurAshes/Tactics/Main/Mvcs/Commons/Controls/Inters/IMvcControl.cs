using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters
{
    /// <summary>
    /// Mvc Control Interface
    /// </summary>
    public interface IMvcControl
    {
        bool IsProcessing();

        IMvcControlState GetMvcControlState();

        void Process(IMvcModelState mvcModelState);

        void Process(IMvcControlInput mvcControlInput);

        void Process(IMvcViewState mvcViewState);
    }
}