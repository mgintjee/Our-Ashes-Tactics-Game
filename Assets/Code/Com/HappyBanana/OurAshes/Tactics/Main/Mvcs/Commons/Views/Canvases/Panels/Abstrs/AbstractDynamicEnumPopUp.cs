using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractDynamicEnumPopUp<TEnum>
        : AbstractEnumPopUp<TEnum>, IPanelWidget
            where TEnum : Enum
    {
        protected IList<TEnum> tEnums = new List<TEnum>();

        protected override IList<TEnum> GetEnums()
        {
            return tEnums;
        }

        protected override void ConfigureButton(IButtonPanelWidget button, TEnum tEnum)
        {
            CanvasWidgetUtils.SetButtonInteractable(button, this.IsInteractable(tEnum));
        }

        protected abstract bool IsInteractable(TEnum tEnum);
    }
}