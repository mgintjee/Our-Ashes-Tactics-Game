using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constructions.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations
{
    /// <summary>
    /// Mvc Construction Implementation
    /// </summary>
    public class MvcFrameConstruction
        : AbstractReport, IMvcFrameConstruction
    {
        // Todo
        private readonly IUnityScript _unityScript;

        // Todo
        private readonly IMvcControllerConstruction _mvcControllerConstruction;

        // Todo
        private readonly IMvcModelConstruction _mvcModelConstruction;

        // Todo
        private readonly IMvcViewConstruction _mvcViewConstruction;

        // Todo
        private readonly MvcType _mvcType;

        // Todo
        private readonly SimulationType _simulationType;

        // Todo
        private readonly Random _random;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType">                  </param>
        /// <param name="simulationType">           </param>
        /// <param name="unityScript">              </param>
        /// <param name="mvcControllerConstruction"></param>
        /// <param name="mvcModelConstruction">     </param>
        /// <param name="mvcViewConstruction">      </param>
        private MvcFrameConstruction(MvcType mvcType, SimulationType simulationType, IUnityScript unityScript,
            IMvcControllerConstruction mvcControllerConstruction, IMvcModelConstruction mvcModelConstruction,
            IMvcViewConstruction mvcViewConstruction, Random random)
        {
            _mvcType = mvcType;
            _simulationType = simulationType;
            _unityScript = unityScript;
            _mvcControllerConstruction = mvcControllerConstruction;
            _mvcModelConstruction = mvcModelConstruction;
            _mvcViewConstruction = mvcViewConstruction;
            _random = random;
        }

        /// <inheritdoc/>
        MvcType IMvcFrameConstruction.GetMvcType()
        {
            return _mvcType;
        }

        /// <inheritdoc/>
        IMvcControllerConstruction IMvcFrameConstruction.GetMvcControllerConstruction()
        {
            return _mvcControllerConstruction;
        }

        /// <inheritdoc/>
        IMvcModelConstruction IMvcFrameConstruction.GetMvcModelConstruction()
        {
            return _mvcModelConstruction;
        }

        /// <inheritdoc/>
        IMvcViewConstruction IMvcFrameConstruction.GetMvcViewConstruction()
        {
            return _mvcViewConstruction;
        }

        /// <inheritdoc/>
        SimulationType IMvcFrameConstruction.GetSimulationType()
        {
            return _simulationType;
        }

        /// <inheritdoc/>
        IUnityScript IMvcFrameConstruction.GetUnityScript()
        {
            return _unityScript;
        }

        Random IMvcFrameConstruction.GetRandom()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}",
                StringUtils.Format(_mvcType),
                StringUtils.Format(_simulationType),
                _mvcControllerConstruction, _mvcModelConstruction, _mvcViewConstruction);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
            : AbstractBuilder<IMvcFrameConstruction>
        {
            // Todo
            private IMvcControllerConstruction _mvcControllerConstruction;

            // Todo
            private IMvcModelConstruction _mvcModelConstruction;

            // Todo
            private IMvcViewConstruction _mvcViewConstruction;

            // Todo
            private MvcType _mvcType;

            // Todo
            private IUnityScript _unityScript;

            // Todo
            private SimulationType _simulationType;

            // Todo
            private Random _random;

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcType"></param>
            /// <returns></returns>
            public Builder SetMvcType(MvcType mvcType)
            {
                _mvcType = mvcType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="random"></param>
            /// <returns></returns>
            public Builder SetRandom(Random random)
            {
                _random = random;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="simulationType"></param>
            /// <returns></returns>
            public Builder SetSimulationType(SimulationType simulationType)
            {
                _simulationType = simulationType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcControllerConstruction"></param>
            /// <returns></returns>
            public Builder SetMvcControllerConstruction(IMvcControllerConstruction mvcControllerConstruction)
            {
                _mvcControllerConstruction = mvcControllerConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcModelConstruction"></param>
            /// <returns></returns>
            public Builder SetMvcModelConstruction(IMvcModelConstruction mvcModelConstruction)
            {
                _mvcModelConstruction = mvcModelConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcViewConstruction"></param>
            /// <returns></returns>
            public Builder SetMvcViewConstruction(IMvcViewConstruction mvcViewConstruction)
            {
                _mvcViewConstruction = mvcViewConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                _unityScript = unityScript;
                return this;
            }

            /// <inheritdoc/>
            protected override IMvcFrameConstruction BuildObj()
            {
                // Instantiate a new construction
                return new MvcFrameConstruction(_mvcType, _simulationType,
                    _unityScript, _mvcControllerConstruction,
                    _mvcModelConstruction, _mvcViewConstruction, _random);
            }

            /// <inheritdoc/>
            protected override void Validate(ISet<string> invalidReasons)
            {
                ValidateEnum(invalidReasons, _mvcType);
                ValidateEnum(invalidReasons, _simulationType);
                Validate(invalidReasons, _unityScript);
                Validate(invalidReasons, _random);
                Validate(invalidReasons, _mvcControllerConstruction);
                Validate(invalidReasons, _mvcModelConstruction);
                Validate(invalidReasons, _mvcViewConstruction);
            }
        }
    }
}