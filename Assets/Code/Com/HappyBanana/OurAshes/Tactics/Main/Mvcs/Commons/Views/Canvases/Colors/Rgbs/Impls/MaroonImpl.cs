﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Maroon Rgb Implementation
    /// </summary>
    public class MaroonImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MaroonImpl()
        {
            this.colorID = ColorID.Maroon;
            this.red = 128;
            this.green = 255;
            this.blue = 0;
        }
    }
}