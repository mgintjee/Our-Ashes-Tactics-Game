using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MvcCompletionReport
{
    private readonly int turnCount;
    private readonly HashSet<TeamIdEnum> winningTeamIdSet;
    private readonly HashSet<TeamIdEnum> losingTeamIdSet;
    private readonly Dictionary<int, List<int>> turnActionReportListDictionary;
}