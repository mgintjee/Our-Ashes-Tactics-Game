using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieGameRequest
        : IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        RequestType GetRequestType();
    }
}