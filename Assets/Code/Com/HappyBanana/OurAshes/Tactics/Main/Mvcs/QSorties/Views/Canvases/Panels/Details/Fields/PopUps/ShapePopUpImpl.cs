using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.PopUps
{
    /// <summary>
    /// Field ID PopUp Impl
    /// </summary>
    public class ShapePopUpImpl
        : AbstractStaticEnumPopUp<FieldShape>
    {
        private IFieldDetails fieldDetails;

        protected override bool IsButtonInteractable(FieldShape tEnum)
        {
            return tEnum != this.fieldDetails.GetFieldShape();
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
                IInternalBuilder SetFieldDetails(IFieldDetails fieldDetails);
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
                private IFieldDetails fieldDetails;

                IInternalBuilder IInternalBuilder.SetFieldDetails(IFieldDetails fieldDetails)
                {
                    this.fieldDetails = fieldDetails;
                    return this;
                }

                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    ShapePopUpImpl widget = gameObject.AddComponent<ShapePopUpImpl>();
                    widget.fieldDetails = fieldDetails;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}