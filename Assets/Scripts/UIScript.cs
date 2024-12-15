using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI healthText, ammoText, pointsText;

    // Update is called once per frame
    void Update()
    {
        PlayerControlScript player = FindFirstObjectByType<PlayerControlScript>();
        if (player != null)
        {
            healthText.text = "" + player.health;
            if(player.weapon)
                ammoText.text = "" + player.weapon.ammo;
            /*pointsText.text = "";
            foreach(CharacterDataScript character in FindObjectsByType<CharacterDataScript>(FindObjectsSortMode.None))
            {
				pointsText.text += character.points +"\n";
			}*/
		}
    }
}
