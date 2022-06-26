using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FieldSizeModRequestImpl
        : DefaultRequestImpl, IFieldSizeModRequest
    {
        // Todo
        private FieldSize fieldSize = FieldSize.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fieldSize"></param>
        public FieldSizeModRequestImpl SetFieldSize(FieldSize fieldSize)
        {
            this.fieldSize = fieldSize;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Size:{1}",
                this.GetType().Name, this.fieldSize);
        }

        /// <inheritdoc/>
        FieldSize IFieldSizeModRequest.GetFieldSize()
        {
            return this.fieldSize;
        }
    }
}