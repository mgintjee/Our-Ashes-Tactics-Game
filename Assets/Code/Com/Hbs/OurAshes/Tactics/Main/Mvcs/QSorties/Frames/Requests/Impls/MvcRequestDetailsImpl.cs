using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcRequestDetailsImpl
        : IQSortieMenuMvcRequest
    {
        // Todo
        private RequestType requestType = RequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="qSortieRequestType"></param>
        public MvcRequestDetailsImpl SetRequestType(RequestType qSortieRequestType)
        {
            this.requestType = qSortieRequestType;
            return this;
        }

        /// <inheritdoc/>
        RequestType IQSortieMenuMvcRequest.GetRequestType()
        {
            return this.requestType;
        }
    }
}