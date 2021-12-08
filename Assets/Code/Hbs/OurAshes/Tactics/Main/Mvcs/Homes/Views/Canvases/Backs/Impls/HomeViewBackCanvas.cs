using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Views.Canvases.Backs.Impls
{
    /// <summary>
    /// Home View Back Canvas Interface
    /// </summary>
    public class HomeViewBackCanvas : CanvasScript, IMvcViewCanvas
    {
        void IMvcViewCanvas.Build()
        {
            throw new System.NotImplementedException();
        }

        Optional<Action> IMvcViewCanvas.CanvasAction(IInput click)
        {
            throw new NotImplementedException();
        }

        void IMvcViewCanvas.Clear()
        {
            throw new System.NotImplementedException();
        }

        void IMvcViewCanvas.Reset()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IMvcViewCanvas>
            {
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
            private class InternalBuilder : AbstractBuilder<IMvcViewCanvas>, IBuilder
            {
                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildObj()
                {
                    return null;
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}