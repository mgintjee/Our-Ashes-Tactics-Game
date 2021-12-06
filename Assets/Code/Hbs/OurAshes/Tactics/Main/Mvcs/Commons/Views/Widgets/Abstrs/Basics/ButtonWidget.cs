using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters.Basics;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Abstrs.Basics
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ButtonWidget : AbstractWidget, IButtonWidget
    {
        // Todo
        private Action onPressAction;

        // Todo
        private Action onReleaseAction;

        // Todo
        protected Button button;

        /// <inheritdoc/>
        public void Start()
        {
            Debug.Log("BUTTON START!");
            this.button = this.GetGameObject().AddComponent<Button>();
            this.button.onClick.AddListener(() => OnPress());
        }

        void IButtonWidget.SetOnPress(Action onPressAction)
        {
            Debug.Log("Setting onPress!");
            this.onPressAction = onPressAction;
            this.OnPress();
        }

        /// <inheritdoc/>
        public void OnPress()
        {
            Debug.Log("onPress!");
            if (this.onPressAction != null)
            {
                this.onPressAction.Invoke();
            }
            // log a warning
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IButtonBuilder : IWidgetBuilder<IButtonWidget>
            {
                IButtonBuilder SetOnPress(Action onPressAction);

                IButtonBuilder SetOnRelease(Action onReleaseAction);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IButtonBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractWidgetBuilder<IButtonWidget>, IButtonBuilder
            {
                // Todo
                private Action onPressAction;

                // Todo
                private Action onReleaseAction;

                /// <inheritdoc/>
                protected override IButtonWidget BuildObj()
                {
                    GameObject gameObject = new GameObject();
                    IButtonWidget buttonWidget = gameObject.AddComponent<ButtonWidget>();
                    buttonWidget.SetOnPress(this.onPressAction);
                    this.ApplyCommonParams(buttonWidget);
                    return buttonWidget;
                }

                /// <inheritdoc/>
                IButtonBuilder IButtonBuilder.SetOnPress(Action onPressAction)
                {
                    this.onPressAction = onPressAction;
                    return this;
                }

                /// <inheritdoc/>
                IButtonBuilder IButtonBuilder.SetOnRelease(Action onReleaseAction)
                {
                    return this;
                }
            }
        }
    }
}