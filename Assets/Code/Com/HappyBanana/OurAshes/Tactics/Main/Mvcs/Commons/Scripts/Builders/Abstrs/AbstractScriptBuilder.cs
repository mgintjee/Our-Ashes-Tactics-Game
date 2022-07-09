using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs
{
    /// <summary>
    /// Abstract Builder Script
    /// </summary>
    public abstract class AbstractScriptBuilder<T>
        : AbstractBuilder<T>, IScriptBuilder<T>
    {
        // Todo
        protected string name;

        // Todo
        protected IUnityScript unityScript;

        /// <inheritdoc/>
        IScriptBuilder<T> IScriptBuilder<T>.SetName(string name)
        {
            this.name = name;
            return this;
        }

        /// <inheritdoc/>
        IScriptBuilder<T> IScriptBuilder<T>.SetParent(IUnityScript unityScript)
        {
            this.unityScript = unityScript;
            return this;
        }

        /// <inheritdoc/>
        protected override T BuildObj()
        {
            return this.BuildScript(new UnityEngine.GameObject(this.name));
        }

        /// <inheritdoc/>
        protected override void Validate(IList<string> invalidReasons)
        {
            this.Validate(invalidReasons, this.name);
            this.Validate(invalidReasons, this.unityScript);
            this.ValidateScriptBuilder(invalidReasons);
        }

        protected void ApplyScriptValues(IUnityScript unityScript)
        {
            unityScript.GetGameObject().name = this.name;
            unityScript.SetParent(this.unityScript);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="invalidReasons"></param>
        protected virtual void ValidateScriptBuilder(IList<string> invalidReasons)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        protected abstract T BuildScript(UnityEngine.GameObject gameObject);
    }
}