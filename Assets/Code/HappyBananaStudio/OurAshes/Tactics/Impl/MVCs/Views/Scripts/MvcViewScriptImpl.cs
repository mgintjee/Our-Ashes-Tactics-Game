
namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Views.Scripts
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets.ScoreBoards;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Unity.Scripts;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// MvcView Script Api
    /// </summary>
    public class MvcViewScriptImpl
        : UnityScriptImpl, IMvcViewScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private ISet<ICanvasWidget> canvasWidgetSet = new HashSet<ICanvasWidget>();
        // Todo
        private IScoreBoardWidget scoreBoardWidget;

        // private ITalonTurnWidget talonTurnWidget;
        // private ITalonActionWidget talonActionWidget;
        // private ITalonInfoWidget talonInfoWidget;

        /// <summary>
        /// Todo
        /// </summary>
        private void Awake()
        {
            WidgetGridUtil.SetCanvasHeight(this.GetComponent<RectTransform>().rect.height);
            WidgetGridUtil.SetCanvasWidth(this.GetComponent<RectTransform>().rect.width);
        }
        /// <summary>
        /// Todo
        /// </summary>
        void IMvcViewScript.LoadWidgets()
        {
            this.scoreBoardWidget = WidgetResourceLoader.ScoreBoards.LoadScoreBoardWidget();
            this.scoreBoardWidget.GetTransform().SetParent(this.transform);
            this.scoreBoardWidget.LoadEntryWidgets(GameTypeEnum.Skirmish);
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IMvcViewScript.UpdateWidgets()
        {
            this.scoreBoardWidget.UpdateEntryWidgets();
        }
    }
}
