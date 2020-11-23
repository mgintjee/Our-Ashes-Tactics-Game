namespace HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// RosterObject Impl
    /// </summary>
    public class RosterObjectImpl
    : IRosterObject
    {
        // Todo
        private readonly ISet<CallSign> activeCallSignSet = new HashSet<CallSign>();

        // Todo
        private readonly IDictionary<CallSign, ITalonObject> callSignTalonObjectDictionary =
            new Dictionary<CallSign, ITalonObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReportSet">
        /// </param>
        public RosterObjectImpl(IDictionary<CallSign, ITalonObjectConstructionReport> callSignTalonConstructionReportDictionary)
        {
            foreach (KeyValuePair<CallSign, ITalonObjectConstructionReport> entry in callSignTalonConstructionReportDictionary)
            {
                this.callSignTalonObjectDictionary.Add(entry.Key, new TalonObjectImpl(entry.Value));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        void IRosterObject.DeactivateCallSign(CallSign callSign)
        {
            if (this.activeCallSignSet.Contains(callSign))
            {
                this.activeCallSignSet.Remove(callSign);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is not active.", new StackFrame().GetMethod().Name, callSign);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<CallSign> IRosterObject.GetActiveCallSignSet()
        {
            return new HashSet<CallSign>(this.activeCallSignSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<CallSign> IRosterObject.GetAllCallSignSet()
        {
            return new HashSet<CallSign>(this.callSignTalonObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonObject IRosterObject.GetTalonObject(CallSign callSign)
        {
            if (this.callSignTalonObjectDictionary.ContainsKey(callSign))
            {
                return this.callSignTalonObjectDictionary[callSign];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is not tracked.", new StackFrame().GetMethod().Name, callSign);
            }
        }
    }
}