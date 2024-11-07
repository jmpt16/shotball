using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onButtonTriggerEnter += OnDoorOpen;
        GameEvents.current.onButtonTriggerExit += OnDoorClose;
    }

    private void OnDoorOpen(int id)
    {
        if (id == this.id) { gameObject.SetActive(false);}
    }
    private void OnDoorClose(int id)
    {
        if (id == this.id) { gameObject.SetActive(true); }
    }
}
