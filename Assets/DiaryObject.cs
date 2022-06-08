using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryObject : InteractibleObject
{
    public override string id => this.name;

    public override bool isKeyItem => true;


    private void Awake() {
        
        Core.Data.hasDiary = false;
        Core.Binds.OnInteract.AddListener((id) => CollectDiary(id));
    }

    private void CollectDiary(string id)
    {   
        if(id == this.id && isKeyItem)
        {
            Core.Data.hasDiary = true;
            Core.UI.diaryIcon.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
