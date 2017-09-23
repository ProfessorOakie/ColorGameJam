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
	[SerializeField]
	private Color CoreColor;




	void Update () {
		Movement ();
		if (Input.GetKeyDown (KeyCode.S)) {
			TakeDamage_RCPlayer (10)
		
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
		yield return new WaitForSeconds(Random.Range(.5f, 6f));
        //TODO: change spawn loop time logic
        StartCoroutine(SpawnLoop(SpawnLoopTime));
    }

    private void SpawnZombie()
    {
        print("Zombie Was Spawned at time: " + Time.time + " from: " + gameObject.name);
        //Instantiate(ZombiePrefab, transform.position, transform.rotation);
    }
			private void TakeDamage_RCPlayer (float amount, Color bulletcolor)
	{
				CurrentHealth = CurrentHealth - ((amount + Color bulletcolor);
		if (CurrentHealth <= 0) 
		{
			Dead ();
		}

	}
}
