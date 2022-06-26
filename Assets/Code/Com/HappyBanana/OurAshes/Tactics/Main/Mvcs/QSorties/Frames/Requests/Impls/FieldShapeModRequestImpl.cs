using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FieldShapeModRequestImpl
        : DefaultRequestImpl, IFieldShapeModRequest
    {
        // Todo
        private FieldShape fieldShape = FieldShape.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fieldShape"></param>
        public FieldShapeModRequestImpl SetFieldShape(FieldShape fieldShape)
        {
            this.fieldShape = fieldShape;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Shape:{1}",
                this.GetType().Name, this.fieldShape);
        }

        /// <inheritdoc/>
        FieldShape IFieldShapeModRequest.GetFieldShape()
        {
            return this.fieldShape;
        }
    }
}