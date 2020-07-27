using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// </summary>
public static class TeamIdConstants
{
    private static readonly Random random = new Random();
    public static HashSet<TeamIdEnum> GetTeamIdSet(int teamCount, bool randomized)
    {
        if(teamCount < 2 ||
            teamCount > 6)
        {
            throw new ArgumentException("Unable to GetTeamIdSet: " +
                typeof(TeamIdEnum) + ". Invalid Parameters." +
                "\n>teamCount: " + teamCount + " must be 1<teamCount<7");

        }

        HashSet<TeamIdEnum> teamIdSet = new HashSet<TeamIdEnum>();

        // Check if placement matters
        if(randomized 
            || teamCount > 4)
        {
            teamIdSet = GetRandomizedTeamIdSet(teamCount);
        }
        else
        {

        }

        return teamIdSet;
    }

    private static HashSet<TeamIdEnum> GetRandomizedTeamIdSet(int teamCount)
    {
        List<TeamIdEnum> teamIdList = GetEnumList<TeamIdEnum>();
        HashSet<TeamIdEnum> teamIdToReturn = new HashSet<TeamIdEnum>(GetEnumList<TeamIdEnum>());

        for (int i = 0; i < teamCount; ++i)
        {
            TeamIdEnum randomTeamId = teamIdList[random.Next(teamIdList.Count)];
            teamIdList.Remove(randomTeamId);
            teamIdToReturn.Add(randomTeamId);
        }

        return teamIdToReturn;
    }

private static TeamIdEnum GetOppositeTeamId(TeamIdEnum teamId)
{
    TeamIdEnum teamIdToReturn;
    switch (teamId)
    {
        case TeamIdEnum.East:
            teamIdToReturn = TeamIdEnum.West;
            break;
        case TeamIdEnum.NorthEast:
            teamIdToReturn = TeamIdEnum.SouthWest;
            break;
        case TeamIdEnum.NorthWest:
            teamIdToReturn = TeamIdEnum.SouthEast;
            break;
        case TeamIdEnum.West:
            teamIdToReturn = TeamIdEnum.East;
            break;
        case TeamIdEnum.SouthWest:
            teamIdToReturn = TeamIdEnum.NorthEast;
            break;
        case TeamIdEnum.SouthEast:
            teamIdToReturn = TeamIdEnum.NorthWest;
            break;
        default:
            throw new ArgumentException("Unable to GetOppositeTeamId. Invalid Parameters." +
                "\n>teamId: " + teamId + " is not valid");
    }
    return teamIdToReturn;


    }

    private static List<TeamIdEnum> GetEnumList<TeamIdEnum>() where TeamIdEnum : Enum
        => ((TeamIdEnum[])Enum.GetValues(typeof(TeamIdEnum))).ToList();

}