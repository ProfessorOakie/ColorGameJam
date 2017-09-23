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
    private float SpawnLoopTime;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(SpawnLoop(initialSpawnTime));
    }

    // Update is called once per frame
    private void Update()
    {

    }

    IEnumerator SpawnLoop(float time)
    {
        SpawnZombie();
        yield return new WaitForSeconds(time);
        //TODO: change spawn loop time logic
        StartCoroutine(SpawnLoop(SpawnLoopTime));
    }

    private void SpawnZombie()
    {
        print("Zombie Was Spawned at time: " + Time.time + " from: " + gameObject.name);
        //Instantiate(ZombiePrefab, transform.position, transform.rotation);
    }
}
