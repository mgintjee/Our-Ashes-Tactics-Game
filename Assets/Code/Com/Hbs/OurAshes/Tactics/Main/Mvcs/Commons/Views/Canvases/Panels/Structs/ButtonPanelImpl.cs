using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Button Panel Impl
    /// </summary>
    public struct TextImageWidgetStruct
    {
        private readonly string textString;
        private readonly ColorID textColorID;
        private readonly ColorID imageColorID;

        public TextImageWidgetStruct(string textString, ColorID textColorID, ColorID imageColorID)
        {
            this.textString = textString;
            this.textColorID = textColorID;
            this.imageColorID = imageColorID;
        }

        public string GetTextString()
        {
            return this.textString;
        }

        public ColorID GetTextColorID()
        {
            return this.textColorID;
        }

        public ColorID GetImageColorID()
        {
            return this.imageColorID;
        }
    }
}