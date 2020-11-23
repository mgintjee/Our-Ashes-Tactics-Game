namespace HappyBananaStudio.OurAshes.Tactics.Impl.ROEs.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Roe Object Impl
    /// </summary>
    public class RoeObjectImpl
        : IRoeObject
    {
        // Todo
        private readonly IDictionary<CallSign, ISet<CallSign>> friendlyCallSignDictionary = new Dictionary<CallSign, ISet<CallSign>>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSignSet">
        /// </param>
        public RoeObjectImpl(ISet<CallSign> callSignSet)
        {
            foreach (CallSign callSign in callSignSet)
            {
                this.friendlyCallSignDictionary.Add(callSign, new HashSet<CallSign>() { callSign });
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxIdCallSignSetDictionary">
        /// </param>
        public RoeObjectImpl(IDictionary<PhalanxId, ISet<CallSign>> phalanxIdCallSignSetDictionary)
        {
            foreach (PhalanxId phalanxId in phalanxIdCallSignSetDictionary.Keys)
            {
                ISet<CallSign> friendlyCallSignSet = phalanxIdCallSignSetDictionary[phalanxId];
                foreach (CallSign callSign in friendlyCallSignSet)
                {
                    this.friendlyCallSignDictionary.Add(callSign, new HashSet<CallSign>(friendlyCallSignSet));
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxIdCallSignSetDictionary">
        /// </param>
        public RoeObjectImpl(IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetDictionary,
            IDictionary<PhalanxId, ISet<CallSign>> phalanxIdCallSignSetDictionary)
        {
            foreach (FactionId factionId in factionIdPhalanxIdSetDictionary.Keys)
            {
                ISet<PhalanxId> friendlyPhalanxIdSet = factionIdPhalanxIdSetDictionary[factionId];
                ISet<CallSign> friendlyCallSignSet = new HashSet<CallSign>();
                foreach (PhalanxId phalanxId in friendlyPhalanxIdSet)
                {
                    foreach (CallSign callSign in phalanxIdCallSignSetDictionary[phalanxId])
                    {
                        friendlyCallSignSet.Add(callSign);
                    }
                }
                foreach (CallSign callSign in friendlyCallSignSet)
                {
                    this.friendlyCallSignDictionary.Add(callSign, new HashSet<CallSign>(friendlyCallSignSet));
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSignA">
        /// </param>
        /// <param name="callSignB">
        /// </param>
        /// <returns>
        /// </returns>
        bool IRoeObject.AreCallSignsFriendly(CallSign callSignA, CallSign callSignB)
        {
            if (this.friendlyCallSignDictionary.ContainsKey(callSignA) &&
                this.friendlyCallSignDictionary.ContainsKey(callSignB))
            {
                return this.friendlyCallSignDictionary[callSignA].Contains(callSignB) &&
                    this.friendlyCallSignDictionary[callSignB].Contains(callSignA);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? and ? are not both tracked.",
                    new StackFrame().GetMethod(), callSignA, callSignB);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<CallSign> IRoeObject.GetFriendlyCallSignSet(CallSign callSign)
        {
            if (this.friendlyCallSignDictionary.ContainsKey(callSign))
            {
                return new HashSet<CallSign>(this.friendlyCallSignDictionary[callSign]);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is not tracked.",
                    new StackFrame().GetMethod(), callSign);
            }
        }
    }
}