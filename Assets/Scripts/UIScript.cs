using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI healthText, ammoText, pointsText,timeText;

    // Update is called once per frame
    void Update()
    {
        PlayerControlScript player = FindFirstObjectByType<PlayerControlScript>();
        if (player != null)
        {
            healthText.text = "" + player.health;
            if(player.weapon)
                ammoText.text = "" + player.weapon.ammo;
            else
				ammoText.text = "--";
			pointsText.text = "";
            foreach(CharacterDataScript character in FindObjectsByType<CharacterDataScript>(FindObjectsSortMode.None))
            {
                if(character == player) 
                {
					pointsText.text += "Player: "+character.points + "\n";
				}
                else
                {
					pointsText.text += "CPU: " + character.points + "\n";
				}
            }
            int time= FindFirstObjectByType<LevelManagerScript>().time;
			int seconds = ((int)time % 60);
			int minutes = ((int)time / 60);
            timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
		}
    }
}
