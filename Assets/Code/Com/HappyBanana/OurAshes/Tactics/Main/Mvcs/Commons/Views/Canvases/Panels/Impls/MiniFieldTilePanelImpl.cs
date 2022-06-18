using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Field Tile Panel Impl
    /// </summary>
    public class MiniFieldTilePanelImpl
        : AbstractPanelWidget, IFieldTilePanelWidget
    {
        private Vector2 tileCoords;
        private IImageWidget backgroundImage;
        private IImageWidget middlegroundImage;
        private IImageWidget foregroundImage;

        private ColorID backgroundColorID;
        private ColorID middlegroundColorID;
        private ColorID foregroundColorID;
        private SpriteID spriteID;

        Vector2 IFieldTilePanelWidget.GetCoords()
        {
            return this.tileCoords;
        }

        protected override void InitialBuild()
        {
            // Todo
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : PanelWidgetBuilders.IPanelWidgetBuilder
            {
                IInternalBuilder SetBackgroundColor(ColorID colorID);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : PanelWidgetBuilders.InternalPanelWidgetBuilder, IInternalBuilder
            {
                private ColorID backgroundColorID = ColorID.Gray;

                IInternalBuilder IInternalBuilder.SetBackgroundColor(ColorID colorID)
                {
                    this.backgroundColorID = colorID;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<MiniFieldTilePanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}