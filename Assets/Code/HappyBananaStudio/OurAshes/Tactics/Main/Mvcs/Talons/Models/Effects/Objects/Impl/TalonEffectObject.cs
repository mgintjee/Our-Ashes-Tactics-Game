using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonEffectObject
        : ITalonEffectObject
    {
        // Todo
        private readonly float actionEffect;

        // Todo
        private readonly float healthEffect;

        // Todo
        private readonly float movementEffect;

        // Todo
        private readonly float armorEffect;

        // Todo
        private readonly int duration;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionEffect"></param>
        /// <param name="healthEffect"></param>
        /// <param name="movementEffect"></param>
        /// <param name="armorEffect"></param>
        /// <param name="duration"></param>
        private TalonEffectObject(float actionEffect, float healthEffect, float movementEffect, float armorEffect, int duration)
        {
            this.actionEffect = actionEffect;
            this.healthEffect = healthEffect;
            this.movementEffect = movementEffect;
            this.armorEffect = armorEffect;
            this.duration = duration;
        }

        /// <inheritdoc/>
        float ITalonEffectObject.GetActionEffect()
        {
            return this.actionEffect;
        }

        /// <inheritdoc/>
        float ITalonEffectObject.GetArmorEffect()
        {
            return this.armorEffect;
        }

        /// <inheritdoc/>
        int ITalonEffectObject.GetDuration()
        {
            return this.duration;
        }

        /// <inheritdoc/>
        float ITalonEffectObject.GetHealthEffect()
        {
            return this.healthEffect;
        }

        /// <inheritdoc/>
        float ITalonEffectObject.GetMovementEffect()
        {
            return this.movementEffect;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: ActionEffect={1}, ArmorEffect={2}, " +
                "HealthEffect={3}, MovementEffect={4}, Duration={5}",
                this.GetType().Name, this.actionEffect, this.armorEffect,
                this.healthEffect, this.movementEffect, this.duration);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float actionEffect = 0;

            // Todo
            private float healthEffect = 0;

            // Todo
            private float movementEffect = 0;

            // Todo
            private float armorEffect = 0;

            // Todo
            private int duration = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonEffectObject Build()
            {
                // Instantiate a new Object
                return new TalonEffectObject(this.actionEffect,
                    this.healthEffect, this.movementEffect, this.armorEffect, this.duration);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actionEffect"></param>
            /// <returns></returns>
            public Builder SetActionEffect(float actionEffect)
            {
                this.actionEffect = actionEffect;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="healthEffect"></param>
            /// <returns></returns>
            public Builder SetHealthEffect(float healthEffect)
            {
                this.healthEffect = healthEffect;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movementEffect"></param>
            /// <returns></returns>
            public Builder SetMovementEffect(float movementEffect)
            {
                this.movementEffect = movementEffect;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorEffect"></param>
            /// <returns></returns>
            public Builder SetArmorEffect(float armorEffect)
            {
                this.armorEffect = armorEffect;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="duration"></param>
            /// <returns></returns>
            public Builder SetDuration(int duration)
            {
                this.duration = duration;
                return this;
            }
        }
    }
}