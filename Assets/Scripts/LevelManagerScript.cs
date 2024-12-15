
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawnPrefab, botPrefab, playerPrefab;
    public CharacterDataScript[] characters;
    int playerIndex;
	Vector3 spawnPos;
	bool goingToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAtRandom());
        characters = FindObjectsByType<CharacterDataScript>(FindObjectsSortMode.None);
		foreach (CharacterDataScript character in characters)
		{
			if(character.GetComponent<PlayerControlScript>())
				playerIndex= characters.ToList().IndexOf(character);
		}
		spawnPos = Vector3.up;
	}
    void Update() 
    {
		foreach (CharacterDataScript character in characters)
		{
			if (!character)
			{
				//StartCoroutine(RespawnCharacter(characters.ToList().IndexOf(character)));
				GameObject respawingCharacter;
				if (characters.ToList().IndexOf(character) == playerIndex)
					respawingCharacter = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
				else
					respawingCharacter = Instantiate(botPrefab, spawnPos, Quaternion.identity);
				characters[characters.ToList().IndexOf(character)] = respawingCharacter.GetComponent<CharacterDataScript>();
			}
				
		}
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
