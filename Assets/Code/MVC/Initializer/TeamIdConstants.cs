using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// </summary>
public static class TeamIdConstants
{
    #region Private Fields

    private static readonly Random random = new Random();

    #endregion Private Fields

    #region Public Methods

    public static HashSet<SpawnIdEnum> GetTeamIdSet(int teamCount, bool randomized)
    {
        if (teamCount < 2 ||
            teamCount > 6)
        {
            throw new ArgumentException("Unable to GetTeamIdSet: " +
                typeof(SpawnIdEnum) + ". Invalid Parameters." +
                "\n>teamCount: " + teamCount + " must be 1<teamCount<7");
        }

        HashSet<SpawnIdEnum> teamIdSet = new HashSet<SpawnIdEnum>();

        // Check if placement matters
        if (randomized
            || teamCount > 4)
        {
            teamIdSet = GetRandomizedTeamIdSet(teamCount);
        }
        else
        {
        }

        return teamIdSet;
    }

    #endregion Public Methods

    #region Private Methods

    private static List<TeamIdEnum> GetEnumList<TeamIdEnum>() where TeamIdEnum : Enum
        => ((TeamIdEnum[])Enum.GetValues(typeof(TeamIdEnum))).ToList();

    private static SpawnIdEnum GetOppositeTeamId(SpawnIdEnum teamId)
    {
        SpawnIdEnum teamIdToReturn;
        switch (teamId)
        {
            case SpawnIdEnum.East:
                teamIdToReturn = SpawnIdEnum.West;
                break;

            case SpawnIdEnum.NorthEast:
                teamIdToReturn = SpawnIdEnum.SouthWest;
                break;

            case SpawnIdEnum.NorthWest:
                teamIdToReturn = SpawnIdEnum.SouthEast;
                break;

            case SpawnIdEnum.West:
                teamIdToReturn = SpawnIdEnum.East;
                break;

            case SpawnIdEnum.SouthWest:
                teamIdToReturn = SpawnIdEnum.NorthEast;
                break;

            case SpawnIdEnum.SouthEast:
                teamIdToReturn = SpawnIdEnum.NorthWest;
                break;

            default:
                throw new ArgumentException("Unable to GetOppositeTeamId. Invalid Parameters." +
                    "\n>teamId: " + teamId + " is not valid");
        }
        return teamIdToReturn;
    }

    private static HashSet<SpawnIdEnum> GetRandomizedTeamIdSet(int teamCount)
    {
        List<SpawnIdEnum> teamIdList = GetEnumList<SpawnIdEnum>();
        HashSet<SpawnIdEnum> teamIdToReturn = new HashSet<SpawnIdEnum>(GetEnumList<SpawnIdEnum>());

        for (int i = 0; i < teamCount; ++i)
        {
            SpawnIdEnum randomTeamId = teamIdList[random.Next(teamIdList.Count)];
            teamIdList.Remove(randomTeamId);
            teamIdToReturn.Add(randomTeamId);
        }

        return teamIdToReturn;
    }

    #endregion Private Methods
}