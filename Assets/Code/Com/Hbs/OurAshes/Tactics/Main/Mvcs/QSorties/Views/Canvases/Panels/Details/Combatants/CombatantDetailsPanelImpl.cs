using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Models;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Combatants.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Combatants
{
    /// <summary>
    /// Panel Widget Impl
    /// </summary>
    public class CombatantDetailsPanelImpl
        : AbstractPanelWidget, IPanelWidget
    {
        private static readonly IList<CombatantID> combatantIDs = EnumUtils.GetEnumListWithoutFirst<CombatantID>();
        private static readonly IList<WeaponGearID> weaponGearIDs = EnumUtils.GetEnumListWithoutFirst<WeaponGearID>();
        private static readonly IList<ArmorGearID> armorGearIDs = EnumUtils.GetEnumListWithoutFirst<ArmorGearID>();
        private static readonly IList<EngineGearID> engineGearIDs = EnumUtils.GetEnumListWithoutFirst<EngineGearID>();
        private static readonly IList<ModelID> modelIDs = EnumUtils.GetEnumListWithoutFirst<ModelID>();
        private static readonly IList<string> combatantIDStrings = EnumUtils.GetEnumsAsStrings(combatantIDs);
        private static readonly IList<string> modelIDStrings = EnumUtils.GetEnumsAsStrings(modelIDs);
        private static readonly IList<string> weaponGearIDStrings = EnumUtils.GetEnumsAsStrings(weaponGearIDs);
        private static readonly IList<string> armorGearIDStrings = EnumUtils.GetEnumsAsStrings(armorGearIDs);
        private static readonly IList<string> engineGearIDStrings = EnumUtils.GetEnumsAsStrings(engineGearIDs);
        private int combatantIDIndex = 0;
        private int weaponGearIDIndex = 0;
        private int armorGearIDIndex = 0;
        private int engineGearIDIndex = 0;
        private int modelIDIndex = 0;
        private ICarouselPanelWidget combatantIDCarouselWidget;
        private ICarouselPanelWidget weaponGearIDCarouselWidget;
        private ICarouselPanelWidget armorGearIDCarouselWidget;
        private ICarouselPanelWidget engineGearIDCarouselWidget;
        private ICarouselPanelWidget modelIDCarouselWidget;
        private IMultiTextPanelWidget weaponGearIDHeader;
        private IMultiTextPanelWidget weaponGearIDList;
        private IMultiTextPanelWidget weaponGearIDButtons;

        public override void Process(IMvcModelState modelState)
        {
            Models.States.Inters.IMvcModelState mvcModelState = (Models.States.Inters.IMvcModelState)modelState;
        }

        protected override void InitialBuild()
        {
            ISet<ICanvasWidget> panelWidgets = new HashSet<ICanvasWidget>() {
                this.BuildAndSetCombatantIDCarousel(),
                this.BuildAndSetModelIDCarousel(),
                this.BuildAndSetEngineGearIDCarousel(),
                this.BuildAndSetArmorGearIDCarousel(),
                this.BuildAndSetWeaponGearIDHeader(),
                this.BuildAndSetWeaponGearIDList(),
                this.BuildAndSetWeaponGearIDButtons(),
                this.BuildAndSetWeaponGearIDCarousel()
            };
            this.InternalAddWidgets(panelWidgets);
        }

        private IMultiTextPanelWidget BuildAndSetWeaponGearIDHeader()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponGearIDList.HEADER_COORDS)
                    .SetCanvasGridSize(PanelConstants.WeaponGearIDList.HEADER_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct(typeof(WeaponGearID).Name,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(WeaponGearID).Name + ":Header";
            this.weaponGearIDHeader = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, false);
            return this.weaponGearIDHeader;
        }

        private IMultiTextPanelWidget BuildAndSetWeaponGearIDList()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponGearIDList.LIST_COORDS)
                    .SetCanvasGridSize(PanelConstants.WeaponGearIDList.LIST_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("[]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
            string textName = typeof(WeaponGearID).Name + ":List";
            this.weaponGearIDList = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, false);
            return this.weaponGearIDList;
        }

        private IMultiTextPanelWidget BuildAndSetWeaponGearIDButtons()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponGearIDList.BUTTONS_COORDS)
                    .SetCanvasGridSize(PanelConstants.WeaponGearIDList.BUTTONS_SIZE);
            IList<TextImageWidgetStruct> textImageWidgetStructs = new List<TextImageWidgetStruct>
            {
                new TextImageWidgetStruct("-",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR),
                new TextImageWidgetStruct("+",
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR)
            };
            string textName = typeof(WeaponGearID).Name + ":Buttons";
            this.weaponGearIDButtons = this.BuildMultiText(textName, widgetGridSpec,
                textImageWidgetStructs, true);
            return this.weaponGearIDButtons;
        }

        private ICarouselPanelWidget BuildAndSetCombatantIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.CombatantIDs.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(CombatantID).Name;
            this.combatantIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.combatantIDCarouselWidget.UpdateSpinnerText(this.combatantIDIndex, combatantIDStrings);
            return this.combatantIDCarouselWidget;
        }

        private ICarouselPanelWidget BuildAndSetModelIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.ModelIDs.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(ModelID).Name;
            this.modelIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.modelIDCarouselWidget.UpdateSpinnerText(this.modelIDIndex, modelIDStrings);
            return this.modelIDCarouselWidget;
        }

        private ICarouselPanelWidget BuildAndSetWeaponGearIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.WeaponGearIDSpinner.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(WeaponGearID).Name;
            this.weaponGearIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.weaponGearIDCarouselWidget.UpdateSpinnerText(this.weaponGearIDIndex, weaponGearIDStrings);
            return this.weaponGearIDCarouselWidget;
        }

        private ICarouselPanelWidget BuildAndSetArmorGearIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.ArmorGearIDs.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(ArmorGearID).Name;
            this.armorGearIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.armorGearIDCarouselWidget.UpdateSpinnerText(this.armorGearIDIndex, armorGearIDStrings);
            return this.armorGearIDCarouselWidget;
        }

        private ICarouselPanelWidget BuildAndSetEngineGearIDCarousel()
        {
            IWidgetGridSpec widgetGridSpec = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(PanelConstants.EngineGearIDs.COORDS)
                    .SetCanvasGridSize(PanelConstants.SIZE);
            string textName = typeof(EngineGearID).Name;
            this.engineGearIDCarouselWidget = this.BuildCarousel(textName, widgetGridSpec);
            this.engineGearIDCarouselWidget.UpdateSpinnerText(this.engineGearIDIndex, engineGearIDStrings);
            return this.engineGearIDCarouselWidget;
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
                    IPanelWidget widget = gameObject.AddComponent<CombatantDetailsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}