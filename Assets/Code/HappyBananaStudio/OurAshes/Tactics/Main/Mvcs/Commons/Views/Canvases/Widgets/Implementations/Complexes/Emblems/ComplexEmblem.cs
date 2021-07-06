using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Emblems.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Patterns.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Basics.Texts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Complexes.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces.Basics.Images;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces.Basics.Texts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Interfaces.Complexes.Emblems;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Implementations.Complexes.Emblems
{   /// <summary>
    /// Todo </summary>
    public class ComplexEmblem
        : AbstractComplexWidget, IComplexEmblem
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private void BuildBackground(ColorID colorId, SpriteID spriteId)
        {
            IBasicImage backgroundImage = this.BuildImage(colorId, spriteId);
            this.childWidgetSet.Add(backgroundImage);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private void BuildForeground(ColorID colorId, SpriteID spriteId)
        {
            IBasicImage foregroundImage = this.BuildImage(colorId, spriteId);
            this.childWidgetSet.Add(foregroundImage);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private void BuildIcon(ColorID colorId, SpriteID spriteId)
        {
            IBasicImage iconImage = this.BuildImage(colorId, spriteId);
            this.childWidgetSet.Add(iconImage);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId"> </param>
        /// <param name="spriteId"></param>
        /// <returns></returns>
        private IBasicImage BuildImage(ColorID colorId, SpriteID spriteId)
        {
            return new BasicImage.Builder()
                .SetColorId(colorId)
                .SetSpriteId(spriteId)
                .SetParentTransform(this.GetTransform())
                .SetTransparency(0f)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private void BuildCombatantCallSign(CombatantCallSign talonCallSign)
        {
            // Todo: Store some of these in a constants file
            IBasicText basicText = new BasicText.Builder()
                 .SetColorId(ColorID.Black)
                 .SetFontSize(12)
                 .SetFontStyle(FontStyle.BoldAndItalic)
                 .SetFontString(talonCallSign.ToString())
                 .SetParentTransform(this.GetTransform())
                 .Build();
            this.childWidgetSet.Add(basicText);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IPatternScheme _patternScheme = null;

            // Todo
            private IEmblemScheme _emblemScheme = null;

            // Todo
            private Transform _parentTransform = null;

            // Todo
            private CombatantCallSign _callSign = CombatantCallSign.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IComplexEmblem Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    ComplexEmblem complexEmblemSingle =
                        new GameObject(typeof(ComplexEmblem).Name)
                        .AddComponent<ComplexEmblem>();
                    complexEmblemSingle.SetParent(_parentTransform);
                    complexEmblemSingle.BuildBackground(_patternScheme.GetTertiaryColorID(),
                        _emblemScheme.GetBackgroundID());
                    complexEmblemSingle.BuildForeground(_patternScheme.GetSecondaryColorID(),
                        _emblemScheme.GetForegroundID());
                    complexEmblemSingle.BuildIcon(_patternScheme.GetPrimaryColorID(),
                        _emblemScheme.GetIconID());
                    complexEmblemSingle.BuildCombatantCallSign(_callSign);
                    return complexEmblemSingle;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorSchemeReport"></param>
            /// <returns></returns>
            public Builder SetColorSchemeReport(IPatternScheme colorSchemeReport)
            {
                _patternScheme = colorSchemeReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemSchemeReport"></param>
            /// <returns></returns>
            public Builder SetEmblemSchemeReport(IEmblemScheme emblemSchemeReport)
            {
                _emblemScheme = emblemSchemeReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                _parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSign"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSign)
            {
                _callSign = combatantCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (_parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                if (_callSign == CombatantCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantCallSign).Name + " cannot be none.");
                }
                if (_patternScheme == null)
                {
                    argumentExceptionSet.Add(typeof(IPatternScheme).Name + " cannot be null.");
                }
                if (_emblemScheme == null)
                {
                    argumentExceptionSet.Add(typeof(IEmblemScheme).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}