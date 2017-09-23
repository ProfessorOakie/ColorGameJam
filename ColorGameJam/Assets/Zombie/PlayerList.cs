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

}
