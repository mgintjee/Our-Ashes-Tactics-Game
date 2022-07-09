using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.PopUps
{
    /// <summary>
    /// WeaponGear ID Mod PopUp Impl
    /// </summary>
    public class WeaponGearIDModPopUpImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private IUnitDetails unitDetails;

        protected override void InitialBuild()
        {
            IList<WeaponGearID> gearIDs = unitDetails.GetLoadoutDetails().GetWeaponGearIDs();
            IList<GearSize> gearSizes = ModelAttributesManager.GetUnitAttributes(unitDetails.GetModelID())
                .GetValue().GetMountableAttributes().GetWeaponGearSizes();
            for (int i = 0; i < gearSizes.Count; ++i)
            {
                GearSize gearSize = gearSizes[i];
                WeaponGearID weaponGearID = gearIDs[i];
                InternalAddWidget(BuildEntry(gearSizes.Count, i, gearSize, weaponGearID));
            }
        }

        private IPanelWidget BuildEntry(int max, int index, GearSize gearSize, WeaponGearID gearID)
        {
            UnitID id = unitDetails.GetUnitID();
            IList<WeaponGearID> ids = UnitGearIDConstants.Weapons.GetGearIDs(gearSize);
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(index, 0))
                    .SetCanvasGridSize(new Vector2(1, 1));
            return WeaponGearIDModPopUpEntry.Builder.Get()
                .SetUnitID(id)
                .SetWeaponGearIDs(ids)
                .SetIndex(index)
                .SetPanelGridSize(GetIDPopUpGridSize(ids.Count))
                .SetWidgetGridSpec(widgetGridSpec)
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(99)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetName(RequestType.UnitWeaponGearIDModPopUp.ToString())
                .SetParent(this)
                .Build();
        }

        private Vector2 GetIDPopUpGridSize(int idCount)
        {
            int rows = (idCount > 6) ? 6 : idCount;
            int cols = (rows == 6) ? 1 + (idCount / rows) : 1;
            logger.Debug("ID count: {}, rows: {}, cols: {}", idCount, rows, cols);
            return new Vector2(cols, rows);
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
                IInternalBuilder SetUnitDetails(IUnitDetails unitDetails);
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
                private IUnitDetails unitDetails;

                IInternalBuilder IInternalBuilder.SetUnitDetails(IUnitDetails unitDetails)
                {
                    this.unitDetails = unitDetails;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    WeaponGearIDModPopUpImpl widget = gameObject.AddComponent<WeaponGearIDModPopUpImpl>();
                    widget.unitDetails = unitDetails;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, unitDetails);
                }
            }
        }
    }
}