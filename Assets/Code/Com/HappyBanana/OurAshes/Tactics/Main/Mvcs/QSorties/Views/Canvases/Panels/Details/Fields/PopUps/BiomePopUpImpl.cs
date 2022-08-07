using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.PopUps
{
    /// <summary>
    /// Field ID PopUp Impl
    /// </summary>
    public class BiomePopUpImpl
        : AbstractStaticEnumPopUp<FieldBiome>
    {
        private IFieldDetails fieldDetails;

        protected override bool IsButtonInteractable(FieldBiome tEnum)
        {
            return tEnum != this.fieldDetails.GetFieldBiome();
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
                    BiomePopUpImpl widget = gameObject.AddComponent<BiomePopUpImpl>();
                    widget.fieldDetails = fieldDetails;
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}