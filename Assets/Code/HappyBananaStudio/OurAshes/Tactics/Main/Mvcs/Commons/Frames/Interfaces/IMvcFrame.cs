﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces
{
    /// <summary>
    /// Mvc Frame Interface
    /// </summary>
    public interface IMvcFrame
    {
        /// <summary>
        /// Todo
        /// </summary>
        void Continue();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsComplete();

        /// <summary>
        /// Todo
        /// </summary>
        void Destroy();

        /// <summary>
        /// Todo
        /// </summary>
        IMvcFrameConstruction GetCurrentMvcFrameConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        IMvcFrameConstruction GetUpcomingMvcFrameConstruction();
    }
}