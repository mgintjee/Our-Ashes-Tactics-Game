﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class ModelAttributesManager
    {
        // Todo
        private static readonly IDictionary<ModelID, IUnitAttributes> MODEL_ID_UNIT_ATTRIBUTES =
            new Dictionary<ModelID, IUnitAttributes>()
            {
                { ModelID.MAA, new MaaAttributesImpl() },
                { ModelID.MBA, new MbaAttributesImpl() },
                { ModelID.MCA, new McaAttributesImpl() },
            };

        public static IOptional<IUnitAttributes> GetUnitAttributes(ModelID id)
        {
            return MODEL_ID_UNIT_ATTRIBUTES.ContainsKey(id)
                ? Optional<IUnitAttributes>.Of(MODEL_ID_UNIT_ATTRIBUTES[id])
                : Optional<IUnitAttributes>.Empty();
        }
    }
}