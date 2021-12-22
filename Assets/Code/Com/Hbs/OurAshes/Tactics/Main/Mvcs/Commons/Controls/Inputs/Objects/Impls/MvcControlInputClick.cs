using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct MvcControlInputClick
        : IMvcControlInputClick
    {
        // Todo
        private readonly Vector2 worldCoords;

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
        public MvcControlInputClick(int id, Vector2 worldCoords)
        {
            this.clickId = id;
            this.worldCoords = worldCoords;
            this.mvcControlInputType = MvcControlInputType.Click;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: ID:{1}, WorldCoords:{2}",
                this.mvcControlInputType, this.clickId, this.worldCoords);
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
        Vector2 IMvcControlInputClick.GetWorldCoords()
        {
            return this.worldCoords;
        }
    }
}