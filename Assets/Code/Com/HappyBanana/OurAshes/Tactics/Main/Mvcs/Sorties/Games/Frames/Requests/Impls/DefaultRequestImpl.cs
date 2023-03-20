using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class DefaultRequestImpl
        : ISortieGameRequest

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
        public RequestType GetRequestType()
        {
            return this.requestType;
        }
    }
}