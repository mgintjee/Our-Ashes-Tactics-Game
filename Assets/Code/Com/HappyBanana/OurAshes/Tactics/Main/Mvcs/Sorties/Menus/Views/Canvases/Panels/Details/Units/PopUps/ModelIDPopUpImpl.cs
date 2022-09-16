using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Types;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Units.PopUps
{
    /// <summary>
    /// Model ID PopUp Impl
    /// </summary>
    public class ModelIDPopUpImpl
        : AbstractDynamicEnumPopUp<ModelID>
    {
        private ModelID id;

        protected override string DetermineButtonName(ModelID tEnum)
        {
            return RequestType.UnitModelIDSelect + ":" + tEnum.ToString() + ":Button";
        }

        protected override bool IsInteractable(ModelID tEnum)
        {
            return tEnum != id;
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
                IInternalBuilder SetModelIDs(IList<ModelID> ids);

                IInternalBuilder SetModelID(ModelID id);
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
                private IList<ModelID> ids;
                private ModelID id;

                IInternalBuilder IInternalBuilder.SetModelIDs(IList<ModelID> ids)
                {
                    this.ids = ids;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetModelID(ModelID id)
                {
                    this.id = id;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    ModelIDPopUpImpl widget = gameObject.AddComponent<ModelIDPopUpImpl>();
                    widget.tEnums = ids;
                    widget.id = id;
                    this.ApplyPanelValues(widget);
                    return widget;
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, ids);
                }
            }
        }
    }
}