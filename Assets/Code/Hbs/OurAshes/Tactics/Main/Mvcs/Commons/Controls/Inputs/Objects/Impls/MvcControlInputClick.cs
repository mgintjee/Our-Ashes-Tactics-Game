using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct MvcControlInputClick : IMvcControlInputClick
    {
        // Todo
        private readonly float clickX;

        // Todo
        private readonly float clickY;

        // Todo
        private readonly int clickId;

        // Todo
        private readonly MvcControlInputType mvcControlInputType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"> </param>
        /// <param name="y"> </param>
        public MvcControlInputClick(int id, float x, float y)
        {
            this.clickId = id;
            this.clickX = x;
            this.clickY = y;
            this.mvcControlInputType = MvcControlInputType.Click;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: ID:{1}, X:{2}, Y:{3}",
                this.mvcControlInputType, this.clickId, this.clickX, this.clickY);
        }

        /// <inheritdoc/>
        int IMvcControlInputClick.GetClickId()
        {
            return this.clickId;
        }

        /// <inheritdoc/>
        MvcControlInputType IMvcControlInput.GetMvcControlInputType()
        {
            return this.mvcControlInputType;
        }

        /// <inheritdoc/>
        float IMvcControlInputClick.GetX()
        {
            return this.clickX;
        }

        /// <inheritdoc/>
        float IMvcControlInputClick.GetY()
        {
            return this.clickY;
        }
    }
}