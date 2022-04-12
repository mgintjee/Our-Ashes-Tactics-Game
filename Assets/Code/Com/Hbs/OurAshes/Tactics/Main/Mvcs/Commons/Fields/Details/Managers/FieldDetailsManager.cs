using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FieldDetailsManager
    {
        private static readonly ISet<IFieldDetails> FIELD_DETAILS = new HashSet<IFieldDetails>()
            { new AlphaFieldDetailsImpl() };

        public static Optional<IFieldDetails> GetFieldDetails(FieldID fieldID)
        {
            Optional<IFieldDetails> optional = Optional<IFieldDetails>.Empty();

            foreach (IFieldDetails fieldDetails in FIELD_DETAILS)
            {
                if (fieldDetails.GetFieldID() == fieldID)
                {
                    optional = Optional<IFieldDetails>.Of(fieldDetails);
                }
            }

            return optional;
        }
    }
}