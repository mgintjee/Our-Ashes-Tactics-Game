using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Constructions.Frames.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Requests.Implementations
{
    /// <summary>
    /// Central Request Interface
    /// </summary>
    public class CentralRequest : AbstractReport, ICentralRequest
    {
        // Todo
        private readonly IMvcFrameConstruction _mvcFrameConstruction;

        // Todo
        private readonly MvcType _mvcType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType">             </param>
        /// <param name="mvcFrameConstruction"></param>
        private CentralRequest(MvcType mvcType, IMvcFrameConstruction mvcFrameConstruction)
        {
            _mvcType = mvcType;
            _mvcFrameConstruction = mvcFrameConstruction;
        }

        /// <inheritdoc/>
        IMvcFrameConstruction ICentralRequest.GetMvcFrameConstruction()
        {
            return _mvcFrameConstruction;
        }

        /// <inheritdoc/>
        MvcType ICentralRequest.GetMvcType()
        {
            return _mvcType;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}", StringUtils.Format(_mvcType), _mvcFrameConstruction);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ICentralRequest>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="mvcType"></param>
                /// <returns></returns>
                IBuilder SetMvcType(MvcType mvcType);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="mvcFrameConstruction"></param>
                /// <returns></returns>
                IBuilder SetMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ICentralRequest>, IBuilder
            {
                // Todo
                private IMvcFrameConstruction _mvcFrameConstruction;

                // Todo
                private MvcType _mvcType;

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcFrameConstruction(IMvcFrameConstruction mvcFrameConstruction)
                {
                    _mvcFrameConstruction = mvcFrameConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcType(MvcType mvcType)
                {
                    _mvcType = mvcType;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICentralRequest BuildObj()
                {
                    return new CentralRequest(_mvcType, _mvcFrameConstruction);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcType);
                    this.Validate(invalidReasons, _mvcFrameConstruction);
                }
            }
        }
    }
}