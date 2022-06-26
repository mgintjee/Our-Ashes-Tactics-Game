﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Utils;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractDynamicEnumPopUp<TEnum>
        : AbstractPanelWidget, IPanelWidget
            where TEnum : Enum
    {
        private IList<TEnum> tEnums = new List<TEnum>();
        /// <summary>
        /// Todo
        /// </summary>
        protected override void InitialBuild()
        {
            this.InternalAddWidget(this.BuildBackground());
            this.InternalAddWidgets(this.BuildButtons());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tEnum"></param>
        /// <returns></returns>
        protected abstract bool IsButtonEnabled(TEnum tEnum);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ISet<ICanvasWidget> BuildButtons()
        {
            int counter = 0;
            ISet<ICanvasWidget> canvasWidgets = new HashSet<ICanvasWidget>();
            foreach (TEnum tEnum in this.tEnums)
            {
                canvasWidgets.Add(BuildAndSetIDButton(tEnum, counter++));
            }
            return canvasWidgets;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tEnum">  </param>
        /// <param name="counter"></param>
        /// <returns></returns>
        private IButtonPanelWidget BuildAndSetIDButton(TEnum tEnum, int counter)
        {
            // Todo: Move this to some constants file
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, 1) * counter)
                    .SetCanvasGridSize(Vector2.One);
            string buttonType = tEnum.ToString();
            string widgetName = typeof(TEnum).Name + "Mod:" + buttonType + ":Button";
            string buttonText = buttonType;
            bool isEnabled = this.IsButtonEnabled(tEnum);
            // Todo: Move canvas level to some constants file
            IButtonPanelWidget buttonPanelWidget = this.BuildButton(widgetName, widgetGridSpec, buttonText, buttonType, 99);
            CanvasWidgetUtils.EnableWidget(buttonPanelWidget, isEnabled);
            return buttonPanelWidget;
        }
    }
}