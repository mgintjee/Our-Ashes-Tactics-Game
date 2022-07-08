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

        protected abstract void ConfigureButton(IButtonPanelWidget button, TEnum tEnum);

        protected abstract string DetermineButtonName(TEnum tEnum);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ISet<ICanvasWidget> BuildButtons()
        {
            int counter = 0;
            ISet<ICanvasWidget> canvasWidgets = new HashSet<ICanvasWidget>();
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
        private IButtonPanelWidget BuildButton(TEnum tEnum, int counter)
        {
            int denominator = (int)this.canvasGridConvertor.GetGridSize().Y;
            if (denominator == 0)
            {
                denominator = 1;
            }
            int x = counter / denominator;
            int y = counter % denominator;
            // Todo: Move this to some constants files
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(x, y))
                    .SetCanvasGridSize(Vector2.One);
            string buttonType = tEnum.ToString();
            string widgetName = this.DetermineButtonName(tEnum);
            string buttonText = buttonType;
            // Todo: Move canvas level to some constants file
            IButtonPanelWidget buttonPanelWidget = this.BuildButton(widgetName, widgetGridSpec, buttonText, 99);
            ConfigureButton(buttonPanelWidget, tEnum);
            return buttonPanelWidget;
        }
    }
}