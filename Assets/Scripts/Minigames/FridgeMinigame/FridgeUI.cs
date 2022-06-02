using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeUI : MonoBehaviour
{   
    public List<GenericGrid> gridList;

    private int completionNum = 0;

    private void Awake() {
       
        Core.UI.OnMiniGameStepEnd.AddListener(CheckCompletion);
    }

    public void CheckCompletion()
    {
        completionNum++;

        if(completionNum > gridList.Count)
        {
            Core.UI.OnMiniGameEnd.Invoke();
        }
    }

    private void OnDestroy()
    {
        Core.UI.OnMiniGameStepEnd.RemoveListener(CheckCompletion);
    }
}
