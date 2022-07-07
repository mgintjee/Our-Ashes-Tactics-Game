using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractStaticEnumPopUp<TEnum>
        : AbstractEnumPopUp<TEnum>, IPanelWidget
            where TEnum : Enum
    {
        protected override void ConfigureButton(IButtonPanelWidget button, TEnum tEnum)
        {
            CanvasWidgetUtils.SetButtonInteractable(button, IsButtonInteractable(tEnum));
        }

        protected abstract bool IsButtonInteractable(TEnum tEnum);

        protected override string DetermineButtonName(TEnum tEnum)
        {
            return typeof(TEnum).Name + "Select:" + tEnum.ToString() + ":Button";
        }

        protected override IList<TEnum> GetEnums()
        {
            return EnumUtils.GetEnumListWithoutFirst<TEnum>();
        }
    }
}