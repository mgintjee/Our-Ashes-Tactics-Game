using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Commons.Panels
{
    /// <summary>
    /// Mini Field Panel Impl
    /// </summary>
    public class MiniFieldPanelImpl
        : AbstractPanelWidget, IFieldPanelWidget
    {
        private readonly IDictionary<Vector3, IFieldTilePanelWidget> tileCoordPanelWidgets = new Dictionary<Vector3, IFieldTilePanelWidget>();
        private IFieldDetails fieldDetails;
        private ICombatantsDetails combatantsDetails;

        public override void Process(Commons.Models.States.Inters.IMvcModelState mvcModelState)
        {
            Models.States.Inters.IMvcModelState modelState = (Models.States.Inters.IMvcModelState)mvcModelState;
            modelState.GetPrevMvcRequest().IfPresent(request =>
            {
                UpdateMiniFieldPanel(modelState.GetFieldDetails(), modelState.GetCombatantsDetails());
            });
        }

        IList<Vector3> IFieldPanelWidget.GetAvailableCoords()
        {
            return new List<Vector3>(this.tileCoordPanelWidgets.Keys);
        }

        Optional<IFieldTilePanelWidget> IFieldPanelWidget.GetFileTilePanelWidget(Vector3 tileCoords)
        {
            IFieldTilePanelWidget fieldTilePanelWidget = null;

            if (this.tileCoordPanelWidgets.ContainsKey(tileCoords))
            {
                fieldTilePanelWidget = this.tileCoordPanelWidgets[tileCoords];
            }

            return Optional<IFieldTilePanelWidget>.Of(fieldTilePanelWidget);
        }

        protected override void InitialBuild()
        {
            IImageWidget background = this.BuildBackground();
            background.SetColorID(ColorID.Gray);
            this.InternalAddWidget(background);
        }

        private void UpdateMiniFieldPanel(IFieldDetails fieldDetails, ICombatantsDetails combatantsDetails)
        {
            if (fieldDetails != this.fieldDetails || combatantsDetails != this.combatantsDetails)
            {
                this.fieldDetails = fieldDetails;
                this.combatantsDetails = combatantsDetails;
                logger.Debug("Updating mini field with {}/{}", fieldDetails, combatantsDetails);
                foreach (Vector3 coords in new HashSet<Vector3>(this.tileCoordPanelWidgets.Keys))
                {
                    this.InternalRemoveWidget(this.tileCoordPanelWidgets[coords]);
                    this.tileCoordPanelWidgets[coords].Destroy();
                    this.tileCoordPanelWidgets.Remove(coords);
                }
                Vector2 tileGridSize = GetGridSizeFrom(fieldDetails);
                foreach (ITileDetails details in fieldDetails.GetTileDetails())
                {
                    this.BuildMiniFieldTilePanel(details, tileGridSize);
                }
            }
        }

        private void BuildMiniFieldTilePanel(ITileDetails details, Vector2 tileGridSize)
        {
            Vector3 tileCoords = details.GetVector3();
            UnitID unitID = details.GetUnitID();
            TileType tileType = details.GetTileType();
            ColorID midColorID = from(tileType);
            IPatternDetails patternDetails = GetPatternDetails(unitID);
            IIconDetails iconDetails = GetIconDetails(unitID);
            logger.Debug("Building {}", details);
            Vector2 gridCoords = GetGridCoordsFrom(tileCoords, tileGridSize);
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                .SetCanvasGridCoords(gridCoords)
                .SetCanvasGridSize(tileGridSize);
            this.tileCoordPanelWidgets[tileCoords] = (IFieldTilePanelWidget)MiniFieldTilePanelImpl.Builder.Get()
                .SetPatternDetails(patternDetails)
                .SetIconDetails(iconDetails)
                .SetBackColorID(MiniFieldTileConstants.BACK_COLOR_ID)
                .SetBackSpriteID(MiniFieldTileConstants.TILE_SPRITE_ID)
                .SetMidColorID(midColorID)
                .SetMidSpriteID(MiniFieldTileConstants.TILE_SPRITE_ID)
                .SetTileCoords(tileCoords)
                .SetPanelGridSize(Vector2.One)
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(canvasLevel)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName("MiniFieldTile:" + tileCoords)
                .SetParent(this)
                .Build();
            this.InternalAddWidget(this.tileCoordPanelWidgets[tileCoords]);
        }

        private IIconDetails GetIconDetails(UnitID unitID)
        {
            IIconDetails details = IconDetailsImpl.Builder.Get()
                .SetPrimaryID(SpriteID.Blank)
                .SetSecondaryID(SpriteID.Blank)
                .SetTertiaryID(SpriteID.Blank)
                .Build();
            if (unitID != UnitID.None)
            {
                this.combatantsDetails.GetUnitDetails(unitID).IfPresent(unitDetails =>
              {
                  details = unitDetails.GetIconDetails();
              });
            }
            return details;
        }

        private IPatternDetails GetPatternDetails(UnitID unitID)
        {
            IPatternDetails details = PatternDetailsImpl.Builder.Get()
                .SetPrimaryID(ColorID.Black)
                .SetSecondaryID(ColorID.Black)
                .SetTertiaryID(ColorID.Black)
                .Build();
            if (unitID != UnitID.None)
            {
                this.combatantsDetails.GetPhalanxDetails(unitID).IfPresent(phalanxDetails =>
                {
                    details = phalanxDetails.GetPatternDetails();
                });
            }
            return details;
        }

        private ColorID from(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Plains:
                    return ColorID.GoldenRod;

                case TileType.Forest:
                    return ColorID.Green;

                case TileType.Marsh:
                    return ColorID.Green;

                case TileType.Mountain:
                    return ColorID.RosyBrown;

                case TileType.City:
                    return ColorID.SlateGray;

                case TileType.Village:
                    return ColorID.Blue;

                default:
                    return ColorID.Gray;
            }
        }

        /// <summary>
        /// ( x,y-1,z+1) (x-1, y,z+1) (x+1,y-1, z) ( x, y, z) (x-1,y+1, z) (x+1, y,z-1) ( x,y+1,z-1)
        /// </summary>
        /// <param name="tileCoords">  </param>
        /// <param name="tileGridSize"></param>
        /// <returns></returns>
        private Vector2 GetGridCoordsFrom(Vector3 tileCoords, Vector2 tileGridSize)
        {
            float center = 0.5f;
            float x = tileCoords.X;
            float y = tileCoords.Y;
            float z = tileCoords.Z;
            float gridStepX = tileGridSize.X;
            float gridStepY = tileGridSize.Y;
            float gridX = center;
            float gridY = center;
            gridY += gridStepY * ((y / 2) - (z / 2));
            gridX += gridStepX * (y + z) * (float)Math.Sqrt(3) / 2f;
            // Offset by the tile's gridSize to center it
            gridX -= tileGridSize.X / 2f;
            gridY -= tileGridSize.Y / 2f;
            return new Vector2(gridX, gridY);
        }

        private Vector2 GetGridSizeFrom(IFieldDetails fieldDetails)
        {
            FieldSize fieldSize = fieldDetails.GetFieldSize();

            float dimension = 0.1f;
            switch (fieldSize)
            {
                case FieldSize.Small:
                    dimension = 0.175f;
                    break;

                case FieldSize.Medium:
                    dimension = 0.125f;
                    break;

                case FieldSize.Large:
                    dimension = 0.1f;
                    break;

                default:
                    break;
            }
            return new Vector2(dimension, dimension);
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
                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    MiniFieldPanelImpl widget = gameObject.AddComponent<MiniFieldPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}