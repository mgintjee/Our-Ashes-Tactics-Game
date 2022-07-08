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
        private readonly RequestType requestType = RequestType.None;

        public DefaultRequestImpl(RequestType requestType)
        {
            this.requestType = requestType;
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