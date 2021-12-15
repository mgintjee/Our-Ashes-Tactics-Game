using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Scripts.Impls
{
    /// <summary>
    /// Mvc Manager Script Impl
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