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



    // Use this for initialization
    private void Start()
    {
        StartCoroutine(SpawnLoop(initialSpawnTime));
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
        print("Zombie Was Spawned at time: " + Time.time + " from: " + gameObject.name);
        PhotonNetwork.Instantiate(ZombiePrefab.name, transform.position, transform.rotation, 0);
    }

}
