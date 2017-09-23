using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{


    [SerializeField]
    private GameObject ZombiePrefab;
    [SerializeField]
    private float initialSpawnTime;
    [SerializeField]
    private float SpawnLoopTimeMin;
    [SerializeField]
    private float SpawnLoopTimeMax;
    [SerializeField]
    private SpriteRenderer coreColorChangingSpriteRenderer;
    [SerializeField]
    private Color red = Color.red;
    [SerializeField]
    private Color blue = Color.blue;
    [SerializeField]
    private Color yellow = Color.yellow;

    private Player.ColorColor CoreColor;




    // Use this for initialization
    private void Start()
    {
        StartCoroutine(SpawnLoop(initialSpawnTime));
        SetCoreColor(CoreColor);
    }

    private void SetCoreColor(Player.ColorColor col)
    {
        CoreColor = col;
        switch (col)
        {
            case Player.ColorColor.Red:
                coreColorChangingSpriteRenderer.color = red;
                break;
            case Player.ColorColor.Blue:
                coreColorChangingSpriteRenderer.color = blue;
                break;
            case Player.ColorColor.Yellow:
                coreColorChangingSpriteRenderer.color = yellow;
                break;
        }
    }

    public Player.ColorColor GetCoreColor()
    {
        return CoreColor;
    }

    IEnumerator SpawnLoop(float time)
    {
        SpawnZombie();
		yield return new WaitForSeconds(time);
        //TODO: change spawn loop time logic
        StartCoroutine(SpawnLoop(Random.Range(SpawnLoopTimeMin, SpawnLoopTimeMax)));
    }

    private void SpawnZombie()
    {
        //print("Zombie Was Spawned at time: " + Time.time + " from: " + gameObject.name);
        PhotonNetwork.Instantiate(ZombiePrefab.name, transform.position, transform.rotation, 0);
    }

}
