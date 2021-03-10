namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Orders.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Objects.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Sprites.Enums;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class PanelEntryInformationalOrder
        : AbstractPanelEntryInformational, IPanelEntryInformational
    {

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            // Todo
            private ITalonOrderReport talonOrderReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPanelEntryInformational Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    PanelEntryInformationalOrder complexWidgetInformationalOrder =
                        new GameObject(typeof(PanelEntryInformationalOrder).Name)
                        .AddComponent<PanelEntryInformationalOrder>();
                    IComplexWidgetText complexWidgetHeader = new ComplexWidgetText.Builder()
                        .SetParentTransform(complexWidgetInformationalOrder.transform)
                        .SetImageColorId(ColorId.Gray)
                        .SetImageSpriteId(SpriteId.RoundedSquare)
                        .SetImageTransparency(0.0f)
                        .SetTextColorId(ColorId.Black)
                        .SetTextFontSize(15)
                        .SetTextFontStyle(FontStyle.Bold)
                        .SetTextString(typeof(ComplexWidgetInformationalOrder).Name + ": " + this.talonOrderReport.GetOrderType())
                        .Build();
                    complexWidgetInformationalOrder.childWidgetSet.Add(complexWidgetHeader);
                    complexWidgetInformationalOrder.GetTransform().SetParent(this.parentTransform);
                    complexWidgetInformationalOrder.GetTransform().localPosition = Vector3.zero;
                    complexWidgetInformationalOrder.GetTransform().localScale = Vector3.one;
                    return complexWidgetInformationalOrder;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonOrderReport"></param>
            /// <returns></returns>
            public Builder SetTalonOrderReport(ITalonOrderReport talonOrderReport)
            {
                this.talonOrderReport = talonOrderReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                this.parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.talonOrderReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonOrderReport).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}