using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class QSortieMenuRequestImpl
        : AbstractReport, IQSortieMenuRequest
    {
        // Todo
        private QSortieRequestType qSortieRequestType = QSortieRequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="qSortieRequestType"></param>
        public IQSortieMenuRequest SetQSortieRequestType(QSortieRequestType qSortieRequestType)
        {
            this.qSortieRequestType = qSortieRequestType;
            return this;
        }

        /// <inheritdoc/>
        QSortieRequestType IQSortieMenuRequest.GetQSortieRequestType()
        {
            return this.qSortieRequestType;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}:{1}",
                typeof(QSortieRequestType).Name, this.qSortieRequestType);
        }
    }
}