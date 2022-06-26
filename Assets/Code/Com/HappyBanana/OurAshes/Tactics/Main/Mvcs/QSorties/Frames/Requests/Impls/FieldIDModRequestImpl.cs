using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FieldIDModRequestImpl
        : DefaultRequestImpl, IFieldIDModRequest
    {
        // Todo
        private FieldID fieldID = FieldID.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fieldID"></param>
        public FieldIDModRequestImpl SetFieldID(FieldID fieldID)
        {
            this.fieldID = fieldID;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: ID:{1}",
                this.GetType().Name, this.fieldID);
        }

        /// <inheritdoc/>
        FieldID IFieldIDModRequest.GetFieldID()
        {
            return this.fieldID;
        }
    }
}