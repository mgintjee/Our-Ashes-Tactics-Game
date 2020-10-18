namespace HappyBananaStudio.OurAshes.Tactics.Abs.Widgets.ScoreBoards.Entries
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Emblems.Widgets.Emblems;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards.Entries;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.Texts;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Schemes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Abstract ScoreBoard Faction Widget Impl
    /// </summary>
    public abstract class AbstractScoreBoardFactionWidgetImpl
        : AbstractWidgetImpl, IScoreBoardFactionWidget
    {
        // Todo
        protected IEmblemWidget factionEmblemWidget;

        // Todo
        protected ISimpleTextWidget scoreBoardValueTextWidget;

        // Todo
        protected FactionIdEnum factionId;

        // Todo
        protected Vector3 emblemScale;

        /// <summary>
        /// Todo
        /// </summary>
        public abstract void UpdateEntry();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        void IScoreBoardFactionWidget.Initialize(FactionIdEnum factionId)
        {
            if (!factionId.Equals(FactionIdEnum.None))
            {
                if (this.factionEmblemWidget == null &&
                    this.scoreBoardValueTextWidget == null)
                {
                    this.factionId = factionId;
                    this.factionEmblemWidget = this.BuildFactionEmblemWidget();
                    this.scoreBoardValueTextWidget = this.BuildScoreBoardValueTextWidget();
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. ? is already initialized.",
                        new StackFrame().GetMethod().Name, this.GetType());
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IEmblemWidget BuildFactionEmblemWidget()
        {
            IEmblemWidget factionEmblemWidget = WidgetResourceLoader.Emblems
                .LoadEmblemWidget(FactionSchemeConstants.GetFactionEmblemSchemeReport(factionId),
                FactionSchemeConstants.GetFactionColorSchemeReport(factionId));
            factionEmblemWidget.GetTransform().SetParent(this.GetTransform());
            factionEmblemWidget.UpdateWidgetDimensions();
            factionEmblemWidget.UpdateWidgetPosition();
            // Todo: Determine way to calculate desired scale
            factionEmblemWidget.GetTransform().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            this.BuildBackgroundFor(factionEmblemWidget);
            return factionEmblemWidget;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ISimpleTextWidget BuildScoreBoardValueTextWidget()
        {
            ISimpleTextWidget scoreBoardValueTextWidget = WidgetResourceLoader.Texts.LoadSimpleTextWidget();
            scoreBoardValueTextWidget.GetTransform().SetParent(this.GetTransform());
            scoreBoardValueTextWidget.UpdateWidgetDimensions();
            scoreBoardValueTextWidget.UpdateWidgetPosition();
            this.BuildBackgroundFor(scoreBoardValueTextWidget);
            return scoreBoardValueTextWidget;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget"></param>
        private void BuildBackgroundFor(IWidget widget)
        {
            Image widgetBackground = widget.GetGameObject().AddComponent<Image>();
            widgetBackground.sprite = SpriteResourceLoader.Foreground.LoadSpriteForegroundResource(EmblemForegroundIdEnum.Circle);
            Color backgroundColor =  widgetBackground.color;
            backgroundColor.a = .75f;
            widgetBackground.color = backgroundColor;
        }
    }
}
