using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Managers;
using System;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils.Combatants
{
    public class UnitRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static IUnitDetails Randomize(Random random, UnitID unitID)
        {
            ModelID modelID = EnumUtils.GenerateRandomEnum<ModelID>(random);
            ILoadoutDetails loadoutDetails = LoadoutRandomizerUtil.Randomize(random, modelID);
            IIconDetails iconDetails = IconIDDetailsManager.GetDetails(modelID.GetIconID()).GetValue();
            IUnitDetails details = UnitDetailsImpl.Builder.Get()
                .SetUnitID(unitID)
                .SetModelID(modelID)
                .SetLoadoutDetails(loadoutDetails)
                .SetIconDetails(iconDetails)
                .Build();
            logger.Info("Randomized: {}", details);
            return details;
        }
    }
}