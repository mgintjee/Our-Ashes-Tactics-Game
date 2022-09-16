using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls
{
    /// <summary>
    /// Mvc Frame Construction Impl
    /// </summary>
    public class MvcFrameConstructionImpl
        : IMvcFrameConstruction
    {
        // Todo
        private readonly IUnityScript unityScript;

        // Todo
        private readonly MvcType mvcType;

        // Todo
        private readonly SimType simulationType;

        // Todo
        private readonly Random random;

        /// <summary> Constructor </summary> <param name="mvcType"></param> <param
        /// name="simulationType"></param> <param name="unityScript"></param <param name="random"></param>
        public MvcFrameConstructionImpl(MvcType mvcType, SimType simulationType, IUnityScript unityScript, Random random)
        {
            this.mvcType = mvcType;
            this.simulationType = simulationType;
            this.unityScript = unityScript;
            this.random = random;
        }

        /// <inheritdoc/>
        public MvcType GetMvcType()
        {
            return mvcType;
        }

        /// <inheritdoc/>
        public SimType GetSimulationType()
        {
            return simulationType;
        }

        /// <inheritdoc/>
        public IUnityScript GetUnityScript()
        {
            return unityScript;
        }

        /// <inheritdoc/>
        public Random GetRandom()
        {
            return random;
        }
    }
}