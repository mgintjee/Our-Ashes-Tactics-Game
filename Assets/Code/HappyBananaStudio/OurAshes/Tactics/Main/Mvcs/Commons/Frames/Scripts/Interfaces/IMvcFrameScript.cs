﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Interfaces
{
    /// <summary>
    /// Mvc Frame Script Interface
    /// </summary>
    public interface IMvcFrameScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        bool IsComplete();
    }
}