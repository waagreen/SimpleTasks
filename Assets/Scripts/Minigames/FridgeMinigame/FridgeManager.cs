using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeManager : InteractibleObject
{
    public override string id => this.name;

    public GameObject fridgeUI;
    public RectTransform holder;

    private bool doing = false;

    private void Awake()
    {
        Core.Binds.OnInteract.AddListener((id) => StartMiniGame(id));
    }

    public void StartMiniGame(string id)
    {
        if(id == this.id && !doing)
        {
            doing = true;
            Instantiate(fridgeUI, holder);
            Core.Data.isInteracting = true;
        }
    }

    private void OnDestroy() =>  Core.Binds?.OnInteract.RemoveListener((id) => StartMiniGame(id));
}
