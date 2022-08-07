using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs
{
    /// <summary>
    /// Text Image Widget Struct
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