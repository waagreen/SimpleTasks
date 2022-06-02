using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchBehaviour : InteractibleObject
{
    public Light lamp;

    
    public override string id => this.name;
    public bool isOn;

    
    private void Awake()
    {
        isOn = false;

        Core.Binds.OnInteract.AddListener((id) => LightsOn(id));
        Core.Binds.OnInteract.AddListener((id) => LightsOff(id));
    }
    public void LightsOn(string id)
    {
        if(id == this.id && !isOn)
        {
            lamp.gameObject.SetActive(true);
        }
    }
    public void LightsOff(string id)
    {
        if(id == this.id && isOn)
        {
            lamp.gameObject.SetActive(false);
        }
    }
    private void ChangeState(bool state) => isOn = state;
}
