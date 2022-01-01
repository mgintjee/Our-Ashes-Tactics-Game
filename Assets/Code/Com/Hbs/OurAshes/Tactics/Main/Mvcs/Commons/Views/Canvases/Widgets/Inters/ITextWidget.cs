using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters
{
    /// <summary>
    /// Basic Text Widget Interface
    /// </summary>
    public interface ITextWidget
        : ICanvasWidget
    {
        void SetText(string text);

        void SetFont(FontID fontID);

        void SetSize(int size);

        void SetBestFit(bool isBestFit, int minSize, int maxSize);

        void SetColorID(ColorID colorID);
        void SetAlignType(AlignType alignType);
    }
}