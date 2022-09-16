using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractEnumPopUp<TEnum>
        : AbstractPanelWidget, IPanelWidget
            where TEnum : Enum
    {
        /// <summary>
        /// Todo
        /// </summary>
        protected override void InitialBuild()
        {
            this.InternalAddWidget(this.BuildBackground());
            this.InternalAddWidgets(this.BuildButtons());
        }

        protected abstract IList<TEnum> GetEnums();

        protected abstract void ConfigureButton(IButtonWidget button, TEnum tEnum);

        protected abstract string DetermineButtonName(TEnum tEnum);

        protected virtual string DeterimineButtonText(TEnum tEnum)
        {
            return tEnum.ToString();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IList<ICanvasWidget> BuildButtons()
        {
            int counter = 0;
            IList<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>();
            foreach (TEnum tEnum in GetEnums())
            {
                canvasWidgets.Add(BuildButton(tEnum, counter++));
            }

            return canvasWidgets;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tEnum">  </param>
        /// <param name="counter"></param>
        /// <returns></returns>
        private IButtonWidget BuildButton(TEnum tEnum, int counter)
        {
            int startY = (int)this.canvasGridConvertor.GetGridSize().Y;
            if (startY == 0)
            {
                startY = 1;
            }
            int x = counter / startY;
            int y = startY - 1 - counter % startY;
            // Todo: Move this to some constants files
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(x, y))
                    .SetCanvasGridSize(Vector2.One);
            string widgetName = this.DetermineButtonName(tEnum);
            string buttonText = counter + ")" + DeterimineButtonText(tEnum);
            // Todo: Move canvas level to some constants file
            IButtonWidget buttonPanelWidget = this.BuildButton(widgetName, widgetGridSpec, buttonText, 99);
            ConfigureButton(buttonPanelWidget, tEnum);
            return buttonPanelWidget;
        }
    }
}