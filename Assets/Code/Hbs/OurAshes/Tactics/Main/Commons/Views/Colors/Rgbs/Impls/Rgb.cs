using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Colors.Rgbs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Colors.Rgbs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct Rgb : IRgb
    {
        // Todo
        private readonly int blue;

        // Todo
        private readonly int green;

        // Todo
        private readonly int red;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="red">  </param>
        /// <param name="green"></param>
        /// <param name="blue"> </param>
        private Rgb(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        /// <inheritdoc/>
        float IRgb.GetFloatBlue()
        {
            return this.blue / 255f;
        }

        /// <inheritdoc/>
        float IRgb.GetFloatGreen()
        {
            return this.green / 255f;
        }

        /// <inheritdoc/>
        float IRgb.GetFloatRed()
        {
            return this.red / 255f;
        }

        /// <inheritdoc/>
        int IRgb.GetIntBlue()
        {
            return this.blue;
        }

        /// <inheritdoc/>
        int IRgb.GetIntGreen()
        {
            return this.green;
        }

        /// <inheritdoc/>
        int IRgb.GetIntRed()
        {
            return this.red;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IRgb>
            {
                IBuilder SetRed(int red);

                IBuilder SetGreen(int green);

                IBuilder SetBlue(int blue);
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
            private class InternalBuilder : AbstractBuilder<IRgb>, IBuilder
            {
                private int _red;
                private int _green;
                private int _blue;

                /// <inheritdoc/>
                IBuilder IBuilder.SetRed(int red)
                {
                    _red = red;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetGreen(int green)
                {
                    _green = green;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetBlue(int blue)
                {
                    _blue = blue;
                    return this;
                }

                /// <inheritdoc/>
                protected override IRgb BuildObj()
                {
                    return new Rgb(_red, _green, _blue);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _red);
                    this.Validate(invalidReasons, _green);
                    this.Validate(invalidReasons, _blue);
                }
            }
        }
    }
}