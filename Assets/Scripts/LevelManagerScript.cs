
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawnPrefab;
    public CharacterDataScript[] characters;
    public int fullTime,time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAtRandom());
	}
	void Update()
	{
        time = fullTime - (int)Time.time;
        if (time <= 0 )
        {
			StartCoroutine(EndRound());
		}
	}

	IEnumerator EndRound()
    {
        foreach (CharacterDataScript character in FindObjectsByType<CharacterDataScript>(FindObjectsSortMode.None))
        {
            Destroy(character.gameObject);
		}
		yield return new WaitForSeconds(5);
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
