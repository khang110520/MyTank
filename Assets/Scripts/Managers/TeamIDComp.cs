using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamIDComp : MonoBehaviour
{
    [SerializeField]
    private TeamID teamID;


    public TeamID Team => teamID;

    public static bool IsEnemy(TankShooting teamA, TankShooting teamB)
    {
        return teamA.Team != teamB.Team;
    }
    public static bool IsAlly(TankShooting teamA, TankShooting teamB)
    {
        return IsEnemy(teamA, teamB);
    }
}

public static class TeamIDCompExtention
{

    public static bool IsEnemy(this TankShooting teamA, TankShooting teamB)
    {
        return teamA.Team != teamB.Team;
    }
    public static bool IsAlly(this TankShooting teamA, TankShooting teamB)
    {
        return IsEnemy(teamA, teamB);
    }
}

public enum TeamID
{
    None = 0,
    RedTeam = 1,
    BluTeam = 2,
}
