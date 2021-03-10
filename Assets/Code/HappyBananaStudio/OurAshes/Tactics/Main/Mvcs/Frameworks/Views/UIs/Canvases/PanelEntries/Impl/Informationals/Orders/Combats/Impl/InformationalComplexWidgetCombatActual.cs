/*
 * namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Orders.Combats.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class InformationalComplexWidgetCombatActual
        : AbstractInformationalComplexWidgetCombat
    {
        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            // Todo
            private string message = "";

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IComplexWidgetInformational Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    InformationalComplexWidgetCombatActual informationalComplexWidget =
                        new GameObject(typeof(InformationalComplexWidgetCombatActual).Name)
                        .AddComponent<InformationalComplexWidgetCombatActual>();
                    informationalComplexWidget.GetTransform().SetParent(this.parentTransform);
                    informationalComplexWidget.GetTransform().localPosition = Vector3.zero;
                    informationalComplexWidget.GetTransform().localScale = Vector3.one;
                    return informationalComplexWidget;
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
            /// <param name="message"></param>
            /// <returns></returns>
            public Builder SetMessage(string message)
            {
                this.message = message;
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
                if (this.message == null)
                {
                    argumentExceptionSet.Add("message cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}*/