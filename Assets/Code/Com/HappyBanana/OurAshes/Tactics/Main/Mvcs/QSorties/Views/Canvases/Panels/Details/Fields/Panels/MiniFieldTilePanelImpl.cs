using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Panels
{
    /// <summary>
    /// Field Tile Panel Impl
    /// </summary>
    public class MiniFieldTilePanelImpl
        : AbstractPanelWidget, IFieldTilePanelWidget
    {
        private Vector3 tileCoords;
        private ColorID backColorID;
        private ColorID midColorID;
        private ColorID foreColorID;
        private SpriteID backSpriteID;
        private SpriteID midSpriteID;
        private SpriteID foreSpriteID;
        private IImageWidget backImage;
        private IImageWidget midImage;
        private IImageWidget foreImage;

        Vector3 IFieldTilePanelWidget.GetCoords()
        {
            return this.tileCoords;
        }

        IImageWidget IFieldTilePanelWidget.GetBackgroundImage()
        {
            return this.backImage;
        }

        IImageWidget IFieldTilePanelWidget.GetMidgroundImage()
        {
            return this.midImage;
        }

        IImageWidget IFieldTilePanelWidget.GetForegroundImage()
        {
            return this.foreImage;
        }

        protected override void InitialBuild()
        {
            this.backImage = this.BuildImage(MiniFieldConstants.BACK_NAME,
                MiniFieldConstants.BACK_SPEC, MiniFieldConstants.LEVEL,
                MiniFieldConstants.ALPHA, backColorID, backSpriteID);
            this.midImage = this.BuildImage(MiniFieldConstants.MID_NAME,
                MiniFieldConstants.MID_SPEC, MiniFieldConstants.LEVEL,
                MiniFieldConstants.ALPHA, midColorID, midSpriteID);
            this.foreImage = this.BuildImage(MiniFieldConstants.FORE_NAME,
                MiniFieldConstants.FORE_SPEC, MiniFieldConstants.LEVEL,
                MiniFieldConstants.ALPHA, foreColorID, foreSpriteID);
            if(this.foreSpriteID == SpriteID.None)
            {
                this.foreImage.SetEnabled(false);
            }
            this.InternalAddWidget(this.backImage);
            this.InternalAddWidget(this.midImage);
            this.InternalAddWidget(this.foreImage);
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
                IInternalBuilder SetTileCoords(Vector3 coords);

                IInternalBuilder SetBackColorID(ColorID id);

                IInternalBuilder SetMidColorID(ColorID id);

                IInternalBuilder SetForeColorID(ColorID id);

                IInternalBuilder SetBackSpriteID(SpriteID id);

                IInternalBuilder SetMidSpriteID(SpriteID id);

                IInternalBuilder SetForeSpriteID(SpriteID id);
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
                private Vector3 tileCoords;
                private ColorID backColorID;
                private ColorID midColorID;
                private ColorID foreColorID;
                private SpriteID backSpriteID;
                private SpriteID midSpriteID;
                private SpriteID foreSpriteID;

                IInternalBuilder IInternalBuilder.SetBackColorID(ColorID id)
                {
                    this.backColorID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetMidColorID(ColorID id)
                {
                    this.midColorID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetForeColorID(ColorID id)
                {
                    this.foreColorID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetBackSpriteID(SpriteID id)
                {
                    this.backSpriteID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetMidSpriteID(SpriteID id)
                {
                    this.midSpriteID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetForeSpriteID(SpriteID id)
                {
                    this.foreSpriteID = id;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetTileCoords(Vector3 coords)
                {
                    this.tileCoords = coords;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    MiniFieldTilePanelImpl widget = gameObject.AddComponent<MiniFieldTilePanelImpl>();
                    widget.tileCoords = tileCoords;
                    widget.backColorID = backColorID;
                    widget.midColorID = midColorID;
                    widget.foreColorID = foreColorID;
                    widget.backSpriteID = backSpriteID;
                    widget.midSpriteID = midSpriteID;
                    widget.foreSpriteID = foreSpriteID;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}