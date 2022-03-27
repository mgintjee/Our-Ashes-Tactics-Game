using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Scripts.Impls
{
    /// <summary>
    /// Mvc Manager Script Impl
    /// </summary>
    public class MvcManagerScriptImpl
        : AbstractUnityScript
    {
        // Todo
        private IMvcManager mvcManager;

        /// <inheritdoc/>
        protected void FixedUpdate()
        {
            mvcManager.Continue();
        }

        /// <inheritdoc/>
        protected void Awake()
        {
            mvcManager = new MvcManagerImpl(this);
        }
    }
}