using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI healthText, ammoText;

    // Update is called once per frame
    void Update()
    {
        PlayerControlScript player = FindFirstObjectByType<PlayerControlScript>();
        if (player != null)
        {
            healthText.text = "" + player.health;
            if(player.weapon)
                ammoText.text = "" + player.weapon.ammo;
        }
    }
}
