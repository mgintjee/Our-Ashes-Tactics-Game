﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IQSortieMenuRequest
        : IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        QSortieMenuRequestType GetQSortieRequestType();
    }
}