using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls
{
    /// <summary>
    /// Mvc Frame Construction Impl
    /// </summary>
    public class MvcFrameConstruction
        : IMvcFrameConstruction
    {
        // Todo
        private readonly IUnityScript _unityScript;

        // Todo
        private readonly IMvcControlConstruction _mvcControlConstruction;

        // Todo
        private readonly IMvcModelConstruction _mvcModelConstruction;

        // Todo
        private readonly IMvcViewConstruction _mvcViewConstruction;

        // Todo
        private readonly MvcType _mvcType;

        // Todo
        private readonly SimsType _simulationType;

        // Todo
        private readonly Random _random;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType">               </param>
        /// <param name="simulationType">        </param>
        /// <param name="unityScript">           </param>
        /// <param name="mvcControlConstruction"></param>
        /// <param name="mvcModelConstruction">  </param>
        /// <param name="mvcViewConstruction">   </param>
        private MvcFrameConstruction(MvcType mvcType, SimsType simulationType, IUnityScript unityScript,
            IMvcControlConstruction mvcControlConstruction, IMvcModelConstruction mvcModelConstruction,
            IMvcViewConstruction mvcViewConstruction, Random random)
        {
            _mvcType = mvcType;
            _simulationType = simulationType;
            _unityScript = unityScript;
            _mvcControlConstruction = mvcControlConstruction;
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
        IMvcControlConstruction IMvcFrameConstruction.GetMvcControlConstruction()
        {
            return _mvcControlConstruction;
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
        SimsType IMvcFrameConstruction.GetSimulationType()
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
            public interface IBuilder
                : IBuilder<IMvcFrameConstruction>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="mvcType"></param>
                /// <returns></returns>
                IBuilder SetMvcType(MvcType mvcType);

                IBuilder SetMvcControlConstruction(IMvcControlConstruction mvcControlConstruction);

                IBuilder SetMvcViewConstruction(IMvcViewConstruction mvcViewConstruction);

                IBuilder SetMvcModelConstruction(IMvcModelConstruction mvcModelConstruction);

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
                IBuilder SetSimulationType(SimsType simulationType);

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
            private class InternalBuilder
                : AbstractBuilder<IMvcFrameConstruction>, IBuilder
            {
                // Todo
                private IMvcControlConstruction _mvcControlConstruction;

                // Todo
                private IMvcModelConstruction _mvcModelConstruction;

                // Todo
                private IMvcViewConstruction _mvcViewConstruction;

                // Todo
                private MvcType _mvcType;

                // Todo
                private IUnityScript _unityScript;

                // Todo
                private SimsType _simulationType;

                // Todo
                private Random _random;

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcType(MvcType mvcType)
                {
                    _mvcType = mvcType;
                    switch (mvcType)
                    {
                        case MvcType.LoadingScreen:
                        case MvcType.HomeMenu:
                        case MvcType.SplashScreen:
                        case MvcType.QSortieMenu:
                            _mvcControlConstruction = new MvcControlConstructionImpl();
                            _mvcViewConstruction = new MvcViewConstructionImpl();
                            _mvcModelConstruction = new MvcModelConstructionImpl();
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
                IBuilder IBuilder.SetSimulationType(SimsType simulationType)
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
                IBuilder IBuilder.SetMvcControlConstruction(IMvcControlConstruction mvcControlConstruction)
                {
                    this._mvcControlConstruction = mvcControlConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcViewConstruction(IMvcViewConstruction mvcViewConstruction)
                {
                    this._mvcViewConstruction = mvcViewConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcModelConstruction(IMvcModelConstruction mvcModelConstruction)
                {
                    this._mvcModelConstruction = mvcModelConstruction;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcFrameConstruction BuildObj()
                {
                    return new MvcFrameConstruction(_mvcType, _simulationType, _unityScript,
                        _mvcControlConstruction, _mvcModelConstruction, _mvcViewConstruction, _random);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcType);
                    this.Validate(invalidReasons, _simulationType);
                    this.Validate(invalidReasons, _unityScript);
                    this.Validate(invalidReasons, _mvcControlConstruction);
                    this.Validate(invalidReasons, _mvcModelConstruction);
                    this.Validate(invalidReasons, _mvcViewConstruction);
                    this.Validate(invalidReasons, _random);
                }
            }
        }
    }
}