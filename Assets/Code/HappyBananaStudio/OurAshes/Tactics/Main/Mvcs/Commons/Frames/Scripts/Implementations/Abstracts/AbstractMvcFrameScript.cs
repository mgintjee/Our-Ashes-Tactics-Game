using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Scripts.Implementations.Abstracts
{
    /// <summary>
    /// Mvc Frame Script Interface
    /// </summary>
    public abstract class AbstractMvcFrameScript
        : AbstractUnityScript, IMvcFrameScript
    {
        // Todo
        protected bool IsComplete;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.OnAwake();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void Start()
        {
            this.OnStart();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            this.OnFixedUpdate();
        }

        /// <inheritdoc/>
        bool IMvcFrameScript.IsComplete()
        {
            return this.IsComplete;
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected virtual void OnFixedUpdate() { }

        /// <summary>
        /// Todo
        /// </summary>
        protected virtual void OnStart() { }

        /// <summary>
        /// Todo
        /// </summary>
        protected virtual void OnAwake() { }
    }
}