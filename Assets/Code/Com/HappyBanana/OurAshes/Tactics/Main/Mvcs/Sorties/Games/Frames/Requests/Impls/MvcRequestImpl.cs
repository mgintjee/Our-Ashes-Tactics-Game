using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcRequestImpl
        : ISortieGameRequest
    {
        // Todo
        private RequestType requestType = RequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="homeRequestType"></param>
        public ISortieGameRequest SetRequestType(RequestType homeRequestType)
        {
            this.requestType = homeRequestType;
            return this;
        }

        /// <inheritdoc/>
        public RequestType GetRequestType()
        {
            return this.requestType;
        }
    }
}