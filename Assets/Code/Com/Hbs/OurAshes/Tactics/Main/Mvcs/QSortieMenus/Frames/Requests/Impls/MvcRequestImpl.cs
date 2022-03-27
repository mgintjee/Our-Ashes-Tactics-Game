using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcRequestImpl
        : IQSortieMenuMvcRequest
    {
        // Todo
        private RequestType qSortieRequestType = RequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="qSortieRequestType"></param>
        public IQSortieMenuMvcRequest SetRequestType(RequestType qSortieRequestType)
        {
            this.qSortieRequestType = qSortieRequestType;
            return this;
        }

        /// <inheritdoc/>
        RequestType IQSortieMenuMvcRequest.GetRequestType()
        {
            return this.qSortieRequestType;
        }
    }
}