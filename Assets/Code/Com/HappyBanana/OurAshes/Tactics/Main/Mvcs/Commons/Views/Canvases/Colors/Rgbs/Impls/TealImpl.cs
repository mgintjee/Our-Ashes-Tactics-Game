﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Teal Rgb Implementation
    /// </summary>
    public class TealImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TealImpl()
        {
            this.colorID = ColorID.Teal;
            this.red = 0;
            this.green = 128;
            this.blue = 128;
        }
    }
}