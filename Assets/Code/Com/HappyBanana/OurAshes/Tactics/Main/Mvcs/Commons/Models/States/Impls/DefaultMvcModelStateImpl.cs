using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class DefaultMvcModelStateImpl
        : AbstractMvcModelState
    {
        public override IMvcModelState GetCopy()
        {
            return new DefaultMvcModelStateImpl()
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public DefaultMvcModelStateImpl SetPrevMvcRequest(IMvcRequest prevMvcRequest)
        {
            this.prevMvcRequest = prevMvcRequest;
            return this;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}:" +
                "\n{1}", this.GetType().Name, this.prevMvcRequest);
        }
    }
}