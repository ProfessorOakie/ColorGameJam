using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpawner : MonoBehaviour {

    [SerializeField]
    private float SpawnRadius = 5;
    [SerializeField]
    private float SpawnRadiusWidth = 1;
    [SerializeField]
    private GameObject BlackHolePrefab;
    [SerializeField]
    private int InitialNumberSpawned = 3;

    void OnJoinedRoom()
    {
        for(int i = 0; i < InitialNumberSpawned; i++)
            SpawnBlackHole();
    }

    private void SpawnBlackHole()
    {
        Quaternion q = Quaternion.Euler(Random.value - 0.5f, Random.value - 0.5f, 0);
        PhotonNetwork.Instantiate(BlackHolePrefab.name, GetPositionOnRing(), q, 0);
    }

    private Vector3 GetPositionOnRing()
    {
        Vector3 pos = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
        pos.Normalize();
        pos *= SpawnRadius + Random.Range(-SpawnRadiusWidth / 2.0f, SpawnRadiusWidth / 2.0f);
        return pos;
    }

}
