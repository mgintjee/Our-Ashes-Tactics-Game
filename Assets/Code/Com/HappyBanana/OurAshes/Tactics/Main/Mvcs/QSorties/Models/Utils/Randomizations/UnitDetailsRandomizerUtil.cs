using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    public class UnitDetailsRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static IUnitDetails Randomize(Random random, UnitID unitID)
        {
            ModelID modelID = EnumUtils.GenerateRandomEnum<ModelID>(random);
            ILoadoutDetails loadoutDetails = LoadoutDetailsRandomizerUtil.Randomize(random, modelID);
            IUnitDetails details = UnitDetailsImpl.Builder.Get()
                .SetUnitID(unitID)
                .SetModelID(modelID)
                .SetLoadoutDetails(loadoutDetails)
                .Build();
            logger.Info("Randomized: {}", details);
            return details;
        }
    }
}