using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class DefaultRequestImpl
        : IQSortieMenuMvcRequest
    {
        // Todo
        private RequestType requestType = RequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="qSortieRequestType"></param>
        public DefaultRequestImpl SetRequestType(RequestType qSortieRequestType)
        {
            this.requestType = qSortieRequestType;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Type:{1}", this.GetType().Name, this.requestType);
        }

        /// <inheritdoc/>
        RequestType IQSortieMenuMvcRequest.GetRequestType()
        {
            return this.requestType;
        }
    }
}