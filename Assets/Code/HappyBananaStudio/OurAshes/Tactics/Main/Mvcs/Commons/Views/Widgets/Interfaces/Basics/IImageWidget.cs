﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics
{
    /// <summary>
    /// Image Widget Interface
    /// </summary>
    public interface IImageWidget : IWidget
    {
        void SetSpriteID(SpriteID spriteID);
    }
}