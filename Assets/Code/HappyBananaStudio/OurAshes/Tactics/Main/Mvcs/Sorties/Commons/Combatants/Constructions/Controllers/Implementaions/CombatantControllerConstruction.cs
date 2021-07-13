using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.AIs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Controllers.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Controllers.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CombatantControllerConstruction : ICombatantControllerConstruction
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly ControllerID _controllerType;

        // Todo
        private readonly AIType _aiType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        /// <param name="combatantID">      </param>
        /// <param name="loadoutReport">    </param>
        private CombatantControllerConstruction(CombatantCallSign combatantCallSign, ControllerID controllerType, AIType aiType)
        {
            _combatantCallSign = combatantCallSign;
            _controllerType = controllerType;
            _aiType = aiType;
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatantControllerConstruction.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <inheritdoc/>
        ControllerID ICombatantControllerConstruction.GetControllerType()
        {
            return _controllerType;
        }

        /// <inheritdoc/>
        AIType ICombatantControllerConstruction.GetAIType()
        {
            return _aiType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ICombatantControllerConstruction>
            {
                IBuilder SetCombatantCallSign(CombatantCallSign combatantCallSign);

                IBuilder SetAIType(AIType aiType);

                IBuilder SetControllerID(ControllerID controllerID);
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
            private class InternalBuilder : AbstractBuilder<ICombatantControllerConstruction>, IBuilder
            {
                // Todo
                private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

                // Todo
                private ControllerID _controllerID = ControllerID.None;

                // Todo
                private AIType _aiType = AIType.None;

                /// <inheritdoc/>
                IBuilder IBuilder.SetAIType(AIType aiType)
                {
                    _aiType = aiType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantCallSign(CombatantCallSign combatantCallSign)
                {
                    _combatantCallSign = combatantCallSign;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetControllerID(ControllerID controllerID)
                {
                    _controllerID = controllerID;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantControllerConstruction BuildObj()
                {
                    return new CombatantControllerConstruction(_combatantCallSign, _controllerID, _aiType);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantCallSign);
                    this.Validate(invalidReasons, _controllerID);
                }
            }
        }
    }
}