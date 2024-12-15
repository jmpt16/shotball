using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawnPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAtRandom());
    }
    IEnumerator SpawnAtRandom()
    {
        
		int randInt = (int)(Random.value * spawnPoints.Length);
        if (spawnPoints[randInt].childCount==0)
        {
			Instantiate(spawnPrefab, spawnPoints[randInt]);
		}

        yield return new WaitForSeconds(5);
		StartCoroutine(SpawnAtRandom());
	}
}
