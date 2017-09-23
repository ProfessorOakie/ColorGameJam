using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{

    public static PlayerList Instance;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public Player[] GetPlayers()
    {
        return GetComponentsInChildren<Player>();
    }

    public Player.ColorColor GetMinColor()
    {
        int red = 0;
        int blue = 0;
        int yellow = 0;
        foreach (Player p in GetPlayers())
        {
            switch (p.GetPlayerColor())
            {
                case Player.ColorColor.Red:
                    red++;
                    break;
                case Player.ColorColor.Blue:
                    blue++;
                    break;
                case Player.ColorColor.Yellow:
                    yellow++;
                    break;
            }
        }
        if(red < blue)
        {
            if (red < yellow) return Player.ColorColor.Red;
            else if (blue < yellow) return Player.ColorColor.Blue;
            else return Player.ColorColor.Yellow;
        }
        //poop code
        return Player.ColorColor.Red;
    }

}
