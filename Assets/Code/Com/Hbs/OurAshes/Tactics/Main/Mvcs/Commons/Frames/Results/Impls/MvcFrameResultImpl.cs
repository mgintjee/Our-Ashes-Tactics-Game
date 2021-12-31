using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Abstrs
{
    /// <summary>
    /// Mvc Frame Result Implementation
    /// </summary>
    public struct MvcFrameResultImpl
        : IMvcFrameResult
    {
        private IMvcFrameConstruction nextMvcFrameConstruction;
        private IMvcFrameConstruction currMvcFrameConstruction;
        private IMvcFrameConstruction prevMvcFrameConstruction;
        private IMvcFrameState mvcFrameState;

        private MvcFrameResultImpl(IMvcFrameConstruction nextMvcFrameConstruction,
            IMvcFrameConstruction currMvcFrameConstruction, IMvcFrameConstruction prevMvcFrameConstruction,
            IMvcFrameState mvcFrameState)
        {
            this.mvcFrameState = mvcFrameState;
            this.nextMvcFrameConstruction = nextMvcFrameConstruction;
            this.prevMvcFrameConstruction = prevMvcFrameConstruction;
            this.currMvcFrameConstruction = currMvcFrameConstruction;
        }

        /// <inheritdoc/>
        IMvcFrameConstruction IMvcFrameResult.GetCurrMvcFrameConstruction()
        {
            return this.currMvcFrameConstruction;
        }

        /// <inheritdoc/>
        IMvcFrameState IMvcFrameResult.GetMvcFrameState()
        {
            return this.mvcFrameState;
        }

        /// <inheritdoc/>
        IMvcFrameConstruction IMvcFrameResult.GetNextMvcFrameConstruction()
        {
            return this.nextMvcFrameConstruction;
        }

        /// <inheritdoc/>
        IMvcFrameConstruction IMvcFrameResult.GetPrevMvcFrameConstruction()
        {
            return this.prevMvcFrameConstruction;
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
                : IBuilder<IMvcFrameResult>
            {
                IInternalBuilder SetNextMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction);

                IInternalBuilder SetCurrMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction);

                IInternalBuilder SetPrevMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction);

                IInternalBuilder SetMvcFrameState(IMvcFrameState mvcFrameState);
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
                : AbstractBuilder<IMvcFrameResult>, IInternalBuilder
            {
                private IMvcFrameConstruction nextMvcFrameConstruction;
                private IMvcFrameConstruction currMvcFrameConstruction;
                private IMvcFrameConstruction prevMvcFrameConstruction;
                private IMvcFrameState mvcFrameState;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetNextMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction)
                {
                    this.nextMvcFrameConstruction = mvcFrameConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetCurrMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction)
                {
                    this.currMvcFrameConstruction = mvcFrameConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetPrevMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction)
                {
                    this.prevMvcFrameConstruction = mvcFrameConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetMvcFrameState(IMvcFrameState mvcFrameState)
                {
                    this.mvcFrameState = mvcFrameState;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcFrameResult BuildObj()
                {
                    return new MvcFrameResultImpl(this.nextMvcFrameConstruction,
                        this.currMvcFrameConstruction, this.prevMvcFrameConstruction, this.mvcFrameState);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.nextMvcFrameConstruction);
                    this.Validate(invalidReasons, this.currMvcFrameConstruction);
                    this.Validate(invalidReasons, this.mvcFrameState);
                }
            }
        }
    }
}