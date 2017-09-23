using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{

    private static List<Player> Players;
    public static void AddPlayerToTrackable(Player p)
    {
        Players.Add(p);
    }
    public static List<Player> GetPlayers()
    {
        return Players;
    }

    private void Start()
    {
        if (Players == null) Players = new List<Player>();
    }
}
