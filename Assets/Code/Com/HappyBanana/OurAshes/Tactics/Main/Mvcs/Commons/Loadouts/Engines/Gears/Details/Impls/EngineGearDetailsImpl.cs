using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Details.Impls
{
    /// <summary>
    /// Engine Gear Details Implementation
    /// </summary>
    public struct EngineGearDetailsImpl
        : IEngineGearDetails
    {
        // Todo
        private readonly EngineGearID engineGearID;

        // Todo
        private readonly ISet<EngineTraitID> engineTraitIDs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="Engine"></param>
        /// <param name="health"></param>
        private EngineGearDetailsImpl(EngineGearID EngineGearID, ISet<EngineTraitID> EngineTraitIDs)
        {
            this.engineGearID = EngineGearID;
            this.engineTraitIDs = EngineTraitIDs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}, {1}",
                StringUtils.Format(this.engineGearID),
                StringUtils.Format(this.engineTraitIDs));
        }

        /// <inheritdoc/>
        EngineGearID IEngineGearDetails.GetEngineGearID()
        {
            return this.engineGearID;
        }

        /// <inheritdoc/>
        ISet<EngineTraitID> IEngineGearDetails.GetEngineTraitIDs()
        {
            return new HashSet<EngineTraitID>(this.engineTraitIDs);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : IBuilder<IEngineGearDetails>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="engineGearID"></param>
                /// <returns></returns>
                IInternalBuilder SetEngineGearID(EngineGearID engineGearID);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="engineTraitIDs"></param>
                /// <returns></returns>
                IInternalBuilder SetEngineTraitIDs(ISet<EngineTraitID> engineTraitIDs);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="engineTraitID"></param>
                /// <returns></returns>
                IInternalBuilder AddEngineTraitID(EngineTraitID engineTraitID);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<IEngineGearDetails>, IInternalBuilder
            {
                // Todo
                private EngineGearID engineGearID = EngineGearID.None;

                // Todo
                private ISet<EngineTraitID> engineTraitIDs = new HashSet<EngineTraitID>();

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.AddEngineTraitID(EngineTraitID engineTraitID)
                {
                    this.engineTraitIDs.Add(engineTraitID);
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetEngineGearID(EngineGearID engineGearID)
                {
                    this.engineGearID = engineGearID;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetEngineTraitIDs(ISet<EngineTraitID> engineTraitIDs)
                {
                    this.engineTraitIDs = new HashSet<EngineTraitID>(engineTraitIDs);
                    return this;
                }

                /// <inheritdoc/>
                protected override IEngineGearDetails BuildObj()
                {
                    return new EngineGearDetailsImpl(engineGearID, engineTraitIDs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, engineGearID);
                }
            }
        }
    }
}