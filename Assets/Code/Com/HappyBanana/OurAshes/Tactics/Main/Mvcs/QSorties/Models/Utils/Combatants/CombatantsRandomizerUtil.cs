using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.Details.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Mods;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    public class CombatantsRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static ICombatantsDetails Randomize(Random random, FieldSize size)
        {
            int factionCount = GetFactionCount(random, size);
            int phalanxCount = GetPhalanxCount(random, size);
            int unitCount = GetUnitCount(random, size, phalanxCount);
            logger.Debug("Randomizing with {} factions, {} phalanxes, {} units",
                factionCount, phalanxCount, unitCount);
            IList<FactionID> factionIDs = GetFactionIDs(random, factionCount);
            IList<PhalanxID> phalanxIDs = EnumUtils.GenerateRandomEnums<PhalanxID>(random, phalanxCount);
            IList<UnitID> unitIDs = EnumUtils.GenerateRandomEnums<UnitID>(random, unitCount);
            IList<IFactionDetails> factionDetails = RandomizeFactionDetails(random, factionIDs, phalanxIDs);
            IList<IPhalanxDetails> phalanxDetails = RandomizePhalanxDetails(random, factionDetails, phalanxIDs, unitIDs);
            IList<IUnitDetails> unitDetails = RandomizeUnitDetails(random, unitIDs);
            return CombatantsDetailsImpl.Builder.Get()
                .SetFactionDetails(factionDetails)
                .SetPhalanxDetails(phalanxDetails)
                .SetUnitDetails(unitDetails)
                .Build();
        }

        private static IList<FactionID> GetFactionIDs(Random random, int count)
            {
        if(count == 1)
            {
                return new List<FactionID>() { FactionID.Freelance };
            }
            else
            {
              return  EnumUtils.GenerateRandomEnums<FactionID>(random, count);
            }
            }

       public static IList<IFactionDetails> RandomizeFactionDetails(Random random, IList<FactionID> factionIDs, IList<PhalanxID> phalanxIDs)
        {
            IList<IFactionDetails> factionDetails = new List<IFactionDetails>();
            IDictionary<FactionID, IList<PhalanxID>> factionPhalanxIDs = new Dictionary<FactionID, IList<PhalanxID>>();
            IList<FactionID> unusedFactionIDs = EnumUtils.GetEnumListWithoutFirst<FactionID>();
            foreach (FactionID id in unusedFactionIDs)
            {
                if (!factionPhalanxIDs.ContainsKey(id))
                {
                    factionPhalanxIDs[id] = new List<PhalanxID>();
                }
            }
            foreach (PhalanxID phalanxID in phalanxIDs)
            {
                FactionID factionID = EnumUtils.GenerateRandomEnumFrom(random, factionIDs);
                factionPhalanxIDs[factionID].Add(phalanxID);
            }
            foreach (KeyValuePair<FactionID, IList<PhalanxID>> pairs in factionPhalanxIDs)
            {
                FactionID factionID = pairs.Key;
                factionDetails.Add(FactionDetailsImpl.Builder.Get()
                    .SetFactionID(factionID)
                    .SetPhalanxIDs(pairs.Value)
                    .SetIconDetails(IconIDDetailsManager.GetDetails(factionID.GetIconID()).GetValue())
                    .SetPatternDetails(PatternIDDetailsManager.GetDetails(factionID.GetPatternID()).GetValue())
                    .Build());
            }

            logger.Debug("Randomized {}", factionDetails);
            return factionDetails;
        }

        private static IList<IPhalanxDetails> RandomizePhalanxDetails(Random random, IList<IFactionDetails> factionDetails,
            IList<PhalanxID> phalanxIDs, IList<UnitID> unitIDs)
        {
            IList<IPhalanxDetails> phalanxDetails = new List<IPhalanxDetails>();
            IDictionary<PhalanxID, IList<UnitID>> phalanxUnitIDs = new Dictionary<PhalanxID, IList<UnitID>>();
            foreach (UnitID unitID in unitIDs)
            {
                PhalanxID phalanxID = EnumUtils.GenerateRandomEnumFrom(random, phalanxIDs);
                if (!phalanxUnitIDs.ContainsKey(phalanxID))
                {
                    phalanxUnitIDs[phalanxID] = new List<UnitID>();
                }
                phalanxUnitIDs[phalanxID].Add(unitID);
            }
            foreach (KeyValuePair<PhalanxID, IList<UnitID>> pair in phalanxUnitIDs)
            {
                PhalanxID phalanxID = pair.Key;
                IIconDetails iconDetails = RandomizeIconDetails(random);
                IPatternDetails patternDetails = RandomizePatternDetails(random);
                FactionDetailsQueryUtil.GetDetails(factionDetails, phalanxID).IfPresent(factionDetails =>
                {
                    if(factionDetails.GetFactionID() != FactionID.Freelance)
                    {
                        patternDetails = factionDetails.GetPatternDetails();
                    }
                });
                phalanxDetails.Add(PhalanxDetailsImpl.Builder.Get()
                    .SetPhalanxID(phalanxID)
                    .SetUnitIDs(pair.Value)
                    .SetIconDetails(iconDetails)
                    .SetPatternDetails(patternDetails)
                    .Build());
            }
            logger.Debug("Randomized {}", phalanxDetails);
            return phalanxDetails;
        }
        private static IIconDetails RandomizeIconDetails(Random random)
        {
            return IconDetailsImpl.Builder.Get()
                .SetPrimaryID(EnumUtils.GenerateRandomEnum<SpriteID>(random))
                .SetSecondaryID(EnumUtils.GenerateRandomEnum<SpriteID>(random))
                .SetTertiaryID(EnumUtils.GenerateRandomEnum<SpriteID>(random))
                .Build();
        }
        private static IPatternDetails RandomizePatternDetails(Random random)
        {
            return PatternDetailsImpl.Builder.Get()
                .SetPrimaryID(EnumUtils.GenerateRandomEnum<ColorID>(random))
                .SetSecondaryID(EnumUtils.GenerateRandomEnum<ColorID>(random))
                .SetTertiaryID(EnumUtils.GenerateRandomEnum<ColorID>(random))
                .Build();
        }

        private static IList<IUnitDetails> RandomizeUnitDetails(Random random, IList<UnitID> unitIDs)
        {
            IList<IUnitDetails> details = new List<IUnitDetails>();
            foreach(UnitID id in unitIDs)
            {
                details.Add(UnitRandomizerUtil.Randomize(random, id));
            }
            logger.Debug("Randomized {}", details);
            return details;
        }

        private static int GetFactionCount(Random random, FieldSize fieldSize)
        {
            int maxFactionCount = FactionCountConstants.GetMaxCount(fieldSize);
            return random.Next(FactionCountConstants.MIN_COUNT, maxFactionCount);
        }

        private static int GetPhalanxCount(Random random, FieldSize fieldSize)
        {
            int maxPhalanxCount = PhalanxCountConstants.GetMaxCount(fieldSize);
            return random.Next(PhalanxCountConstants.MIN_COUNT, maxPhalanxCount);
        }

        private static int GetUnitCount(Random random, FieldSize fieldSize, int phalanxCount)
        {
            int maxUnitCount = UnitCountConstants.GetMaxCount(fieldSize, phalanxCount);
            return random.Next(phalanxCount, maxUnitCount);
        }

    }
}