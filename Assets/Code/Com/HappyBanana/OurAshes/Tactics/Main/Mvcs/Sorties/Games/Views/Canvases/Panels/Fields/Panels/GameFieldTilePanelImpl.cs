using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Commons.Constants;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Commons.Panels
{
    /// <summary>
    /// Field Tile Panel Impl
    /// </summary>
    public class GameFieldTilePanelImpl
        : AbstractPanelWidget, IFieldTilePanelWidget
    {
        private Vector3 tileCoords;
        private ColorID backColorID;
        private ColorID midColorID;
        private IIconDetails iconDetails;
        private IPatternDetails patternDetails;
        private SpriteID backSpriteID;
        private SpriteID midSpriteID;
        private IImageWidget backImage;
        private IImageWidget midImage;
        private IIconWidget foreIcon;

        public Vector3 GetCoords()
        {
            return this.tileCoords;
        }

        public IImageWidget GetBackgroundImage()
        {
            return this.backImage;
        }

        public IImageWidget GetMidgroundImage()
        {
            return this.midImage;
        }

        public IIconWidget GetForegroundIcon()
        {
            return this.foreIcon;
        }

        protected override void InitialBuild()
        {
            backImage = BuildImage(MiniFieldTileConstants.BACK_NAME,
                MiniFieldTileConstants.BACK_SPEC, MiniFieldTileConstants.LEVEL,
                MiniFieldTileConstants.ALPHA, backColorID, backSpriteID);
            midImage = BuildImage(MiniFieldTileConstants.MID_NAME,
                MiniFieldTileConstants.MID_SPEC, MiniFieldTileConstants.LEVEL,
                MiniFieldTileConstants.ALPHA, midColorID, midSpriteID);
            foreIcon = BuildIcon(MiniFieldTileConstants.FORE_NAME,
                MiniFieldTileConstants.FORE_SPEC, MiniFieldTileConstants.LEVEL,
                iconDetails, patternDetails);
            InternalAddWidget(backImage);
            InternalAddWidget(midImage);
            InternalAddWidget(foreIcon);
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

                IInternalBuilder SetBackSpriteID(SpriteID id);

                IInternalBuilder SetMidSpriteID(SpriteID id);

                IInternalBuilder SetIconDetails(IIconDetails details);

                IInternalBuilder SetPatternDetails(IPatternDetails details);
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
                private SpriteID backSpriteID;
                private SpriteID midSpriteID;
                private IIconDetails iconDetails;
                private IPatternDetails patternDetails;

                public IInternalBuilder SetBackColorID(ColorID id)
                {
                    this.backColorID = id;
                    return this;
                }

                public IInternalBuilder SetMidColorID(ColorID id)
                {
                    this.midColorID = id;
                    return this;
                }

                public IInternalBuilder SetBackSpriteID(SpriteID id)
                {
                    this.backSpriteID = id;
                    return this;
                }

                public IInternalBuilder SetMidSpriteID(SpriteID id)
                {
                    this.midSpriteID = id;
                    return this;
                }

                public IInternalBuilder SetIconDetails(IIconDetails details)
                {
                    iconDetails = details;
                    return this;
                }

                public IInternalBuilder SetPatternDetails(IPatternDetails details)
                {
                    patternDetails = details;
                    return this;
                }

                public IInternalBuilder SetTileCoords(Vector3 coords)
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
                    widget.backSpriteID = backSpriteID;
                    widget.midSpriteID = midSpriteID;
                    widget.iconDetails = iconDetails;
                    widget.patternDetails = patternDetails;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}