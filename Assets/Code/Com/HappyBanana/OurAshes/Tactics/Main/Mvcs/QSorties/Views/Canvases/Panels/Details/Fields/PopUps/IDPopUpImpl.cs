using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.PopUps
{
    /// <summary>
    /// Field ID PopUp Impl
    /// </summary>
    public class IDPopUpImpl
        : AbstractStaticEnumPopUp<FieldID>
    {
        private IFieldDetails details;

        protected override bool IsButtonInteractable(FieldID tEnum)
        {
            return tEnum != this.details.GetFieldID();
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
                IInternalBuilder SetFieldDetails(IFieldDetails details);
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
                private IFieldDetails details;

                IInternalBuilder IInternalBuilder.SetFieldDetails(IFieldDetails details)
                {
                    this.details = details;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IDPopUpImpl widget = gameObject.AddComponent<IDPopUpImpl>();
                    widget.details = details;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}