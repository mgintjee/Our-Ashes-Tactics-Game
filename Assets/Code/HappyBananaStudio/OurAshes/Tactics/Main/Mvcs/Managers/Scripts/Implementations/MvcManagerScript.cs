using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Managers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Managers.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Managers.Scripts.Implementations
{
    /// <summary>
    /// Mvc Manager Script Implementation
    /// </summary>
    public class MvcManagerScript : UnityScript
    {
        // Todo
        private IMvcManager _mvcManager;

        /// <inheritdoc/>
        protected void FixedUpdate()
        {
            _mvcManager.Continue();
        }

        /// <inheritdoc/>
        private void Awake()
        {
            _mvcManager = new MvcManager(this);
        }
    }
}