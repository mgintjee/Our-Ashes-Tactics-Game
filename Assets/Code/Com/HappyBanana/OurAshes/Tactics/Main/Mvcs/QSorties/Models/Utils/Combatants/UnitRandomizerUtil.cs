using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;
using System;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    public class UnitRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static IUnitDetails Randomize(Random random, UnitID unitID)
        {
            ModelID modelID = EnumUtils.GenerateRandomEnum<ModelID>(random);
            ILoadoutDetails loadoutDetails = LoadoutRandomizerUtil.Randomize(random, modelID);
            IIconDetails iconDetails = IconIDDetailsManager.GetDetails(GetIconID(modelID)).GetValue();
            IUnitDetails details = UnitDetailsImpl.Builder.Get()
                .SetUnitID(unitID)
                .SetModelID(modelID)
                .SetLoadoutDetails(loadoutDetails)
                .SetIconDetails(iconDetails)
                .Build();
            logger.Info("Randomized: {}", details);
            return details;
        }

        private static IconID GetIconID(ModelID modelID)
        {
            switch (modelID)
            {
                case ModelID.MAA:
                    return IconID.UnitModelMaa;

                case ModelID.MCA:
                    return IconID.UnitModelMba;

                case ModelID.MBA:
                    return IconID.UnitModelMca;

                default:
                    return IconID.None;
            }
        }
    }
}