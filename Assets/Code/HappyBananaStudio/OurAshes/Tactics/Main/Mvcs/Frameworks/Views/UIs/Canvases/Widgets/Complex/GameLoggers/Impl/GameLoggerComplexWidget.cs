namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.GameLoggers.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblem.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Texts.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.GameLoggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.ResourceLoaders.Sprites;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class GameLoggerComplexWidget
        : AbstractComplexWidget, IGameLoggerComplexWidget
    {
        /// <inheritdoc/>
        void IComplexWidget.UpdateValues()
        {

        }

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
            public IGameLoggerComplexWidget Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    GameLoggerComplexWidget gameLoggerComplexWidget = new GameObject(typeof(GameLoggerComplexWidget).Name)
                        .AddComponent<GameLoggerComplexWidget>();
                    new BasicWidgetImage.Builder()
                        .SetParentTransform(gameLoggerComplexWidget.GetTransform())
                        .SetColor(Color.cyan)
                        .SetSprite( SpriteResourceLoader.LoadSpriteResource( EmblemId.RoundedSquare))
                        .SetTransparency(0.75f)
                        .Build();
                    new BasicWidgetText.Builder()
                        .SetFontString(this.message)
                        .SetFontSize(5)
                        .SetColor(Color.black)
                        .SetParentTransform(gameLoggerComplexWidget.GetTransform())
                        .SetFontStyle(FontStyle.Normal)
                        .Build();
                    gameLoggerComplexWidget.GetTransform().SetParent(this.parentTransform);
                    gameLoggerComplexWidget.GetTransform().localPosition = Vector3.zero;
                    gameLoggerComplexWidget.GetTransform().localScale = Vector3.one;
                    return gameLoggerComplexWidget;
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
}