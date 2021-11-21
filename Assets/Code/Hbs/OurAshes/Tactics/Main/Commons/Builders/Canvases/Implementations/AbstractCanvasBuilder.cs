using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Canvases.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Canvases.Implementations
{
    /// <summary>
    /// Abstract Canvas Builder Implementation
    /// </summary>
    public abstract class AbstractCanvasBuilder<T> : AbstractBuilder<T>, ICanvasBuilder<T>
    {
        // Todo
        protected string name;

        // Todo
        protected IUnityScript unityScript;

        // Todo
        protected ICanvasGridMeasurements canvasGridMeasurements;

        protected override T BuildObj()
        {
            GameObject gameObject = new GameObject(this.name);
            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            return this.BuildScript(gameObject);
        }

        protected override void Validate(ISet<string> invalidReasons)
        {
            this.Validate(invalidReasons, this.name);
            this.Validate(invalidReasons, this.unityScript);
            this.Validate(invalidReasons, this.canvasGridMeasurements);
        }

        ICanvasBuilder<T> ICanvasBuilder<T>.SetName(string name)
        {
            this.name = name;
            return this;
        }

        ICanvasBuilder<T> ICanvasBuilder<T>.SetParent(IUnityScript unityScript)
        {
            this.unityScript = unityScript;
            return this;
        }

        ICanvasBuilder<T> ICanvasBuilder<T>.SetMeasurements(ICanvasGridMeasurements canvasGridMeasurements)
        {
            this.canvasGridMeasurements = canvasGridMeasurements;
            return this;
        }

        protected abstract T BuildScript(GameObject gameObject);
    }
}