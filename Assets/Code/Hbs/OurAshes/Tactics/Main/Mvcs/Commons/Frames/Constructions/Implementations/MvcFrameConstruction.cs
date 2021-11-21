using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Contstructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Splashes.Constructions.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Constructions.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Constructions.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Views.Constructions.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Constructions.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Constructions.Implementations;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations
{
    /// <summary>
    /// Mvc Frame Construction Implementation
    /// </summary>
    public class MvcFrameConstruction : IMvcFrameConstruction
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

        /// <inheritdoc/>
        Random IMvcFrameConstruction.GetRandom()
        {
            return _random;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// </summary>
            private Builder()
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IMvcFrameConstruction>
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
                /// <param name="unityScript"></param>
                /// <returns></returns>
                IBuilder SetUnityScript(IUnityScript unityScript);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="simulationType"></param>
                /// <returns></returns>
                IBuilder SetSimulationType(SimulationType simulationType);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="random"></param>
                /// <returns></returns>
                IBuilder SetRandom(Random random);
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
            private class InternalBuilder : AbstractBuilder<IMvcFrameConstruction>, IBuilder
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

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcType(MvcType mvcType)
                {
                    _mvcType = mvcType;
                    switch (mvcType)
                    {
                        case MvcType.Splash:
                            _mvcControllerConstruction = SplashControllerConstruction.Builder.Get().Build();
                            _mvcModelConstruction = SplashModelConstruction.Builder.Get().Build();
                            _mvcViewConstruction = SplashViewConstruction.Builder.Get().Build();
                            break;

                        case MvcType.Home:
                            _mvcControllerConstruction = HomeControllerConstruction.Builder.Get().Build();
                            _mvcModelConstruction = HomeModelConstruction.Builder.Get().Build();
                            _mvcViewConstruction = HomeViewConstruction.Builder.Get().Build();
                            break;
                    }
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetRandom(Random random)
                {
                    _random = random;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSimulationType(SimulationType simulationType)
                {
                    _simulationType = simulationType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetUnityScript(IUnityScript unityScript)
                {
                    _unityScript = unityScript;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcFrameConstruction BuildObj()
                {
                    return new MvcFrameConstruction(_mvcType, _simulationType, _unityScript,
                        _mvcControllerConstruction, _mvcModelConstruction, _mvcViewConstruction, _random);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcType);
                    this.Validate(invalidReasons, _simulationType);
                    this.Validate(invalidReasons, _unityScript);
                    this.Validate(invalidReasons, _mvcControllerConstruction);
                    this.Validate(invalidReasons, _mvcModelConstruction);
                    this.Validate(invalidReasons, _mvcViewConstruction);
                    this.Validate(invalidReasons, _random);
                }
            }
        }
    }
}