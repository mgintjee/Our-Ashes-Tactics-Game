using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.UIs.Interfaces.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.UIs.Interfaces.Basics.Texts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.UIs.Interfaces.Complexes.Texts
{
    /// <summary>
    /// Complex Text Interface
    /// </summary>
    public interface IComplexText : IWidget
    {
        IBasicText GetBasicText();

        IBasicImage GetBasicImage();
    }
}