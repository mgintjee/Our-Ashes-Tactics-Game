using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc View Canvas Implementation
    /// </summary>
    public abstract class AbstractMvcViewCanvas : IMvcViewCanvas
    {
        /// <inheritdoc/>
        void IMvcViewCanvas.Build()
        {
            this.InternalBuild();
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Clear()
        {
            this.InternalClear();
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Reset()
        {
            ((IMvcViewCanvas)this).Clear();
            ((IMvcViewCanvas)this).Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void InternalBuild();

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void InternalClear();
    }
}