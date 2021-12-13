using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Scripts.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Scripts.Abstrs
{
    /// <summary>
    /// Abstract Builder Script
    /// </summary>
    public abstract class AbstractBuilderScript<T> : AbstractBuilder<T>, IBuilderScript<T>
    {
        // Todo
        protected string name;

        // Todo
        protected IUnityScript unityScript;

        /// <inheritdoc/>
        IBuilderScript<T> IBuilderScript<T>.SetName(string name)
        {
            this.name = name;
            return this;
        }

        /// <inheritdoc/>
        IBuilderScript<T> IBuilderScript<T>.SetParent(IUnityScript unityScript)
        {
            this.unityScript = unityScript;
            return this;
        }

        /// <inheritdoc/>
        protected override T BuildObj()
        {
            return this.BuildScript(new GameObject(this.name));
        }

        /// <inheritdoc/>
        protected override void Validate(ISet<string> invalidReasons)
        {
            this.Validate(invalidReasons, this.name);
            this.Validate(invalidReasons, this.unityScript);
        }

        protected abstract T BuildScript(GameObject gameObject);
    }
}