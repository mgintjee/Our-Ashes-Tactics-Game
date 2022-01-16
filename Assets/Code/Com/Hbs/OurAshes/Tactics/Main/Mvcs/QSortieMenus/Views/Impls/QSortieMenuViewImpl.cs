using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Canvases.Impls;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Views.Impls
{
    /// <summary>
    /// QSortieMenu View Impl
    /// </summary>
    public class QSortieMenuViewImpl
        : AbstractMvcView, IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public QSortieMenuViewImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override void InternalProcess(IMvcControlInput mvcControlInput)
        {
            logger.Info("Processing {}...", mvcControlInput);
            this.mvcViewCanvas.GetWidget(mvcControlInput).IfPresent(widget =>
            {
                logger.Info("Widget to process: Name={}", widget.GetName());
                QSortieMenuRequestType qSortieMenuRequestType = this.DetermineType(widget.GetName());
                if (qSortieMenuRequestType != QSortieMenuRequestType.None)
                {
                    foreach (IMvcRequest request in this.mvcModelState.GetMvcRequests())
                    {
                        if (((IQSortieMenuRequest)request).GetQSortieRequestType() == qSortieMenuRequestType)
                        {
                            logger.Info("Setting {}:{}", typeof(IQSortieMenuRequest), qSortieMenuRequestType);
                            ((MvcViewStateImpl)this.mvcViewState)
                                .SetMvcModelRequest(request);
                        }
                        break;
                    }
                }
            });
        }

        /// <inheritdoc/>
        protected override IMvcViewCanvas BuildInitialMvcViewCanvas()
        {
            return QSortieMenuViewCanvasImpl.Builder.Get()
                .SetMvcType(MvcType.QSortieMenu)
                .SetGridSize(CanvasGridConstants.GetMvcTypeGridSize(MvcType.QSortieMenu))
                .SetName(typeof(QSortieMenuViewCanvasImpl).Name)
                .SetParent(this.mvcFrameConstruction.GetUnityScript())
                .Build();
        }

        private QSortieMenuRequestType DetermineType(string widgetName)
        {
            IList<QSortieMenuRequestType> qSortieMenuRequestTypes = EnumUtils.GetEnumListWithoutFirst<QSortieMenuRequestType>();
            foreach (QSortieMenuRequestType qSortieMenuRequestType in qSortieMenuRequestTypes)
            {
                if (widgetName.Contains(qSortieMenuRequestType.ToString()))
                {
                    return qSortieMenuRequestType;
                }
            }
            return QSortieMenuRequestType.None;
        }
    }
}