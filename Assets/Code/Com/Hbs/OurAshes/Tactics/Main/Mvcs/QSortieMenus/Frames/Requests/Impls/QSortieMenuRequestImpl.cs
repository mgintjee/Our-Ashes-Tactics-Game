using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class QSortieMenuRequestImpl
        : IQSortieMenuRequest
    {
        // Todo
        private QSortieMenuRequestType qSortieRequestType = QSortieMenuRequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="qSortieRequestType"></param>
        public IQSortieMenuRequest SetQSortieRequestType(QSortieMenuRequestType qSortieRequestType)
        {
            this.qSortieRequestType = qSortieRequestType;
            return this;
        }

        /// <inheritdoc/>
        QSortieMenuRequestType IQSortieMenuRequest.GetQSortieRequestType()
        {
            return this.qSortieRequestType;
        }
    }
}