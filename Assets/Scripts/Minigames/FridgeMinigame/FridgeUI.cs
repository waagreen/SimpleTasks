using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FridgeUI : MonoBehaviour
{   
    public List<GenericGrid> gridList;
    private UnityEvent OnFridgeOrganized = new UnityEvent();

    private int completionNum = 0;

    private void Awake() {
       
        Core.UI.OnMiniGameStepEnd.AddListener(CheckCompletion);
        OnFridgeOrganized.AddListener(EndFridgeGame);
    }

    public void CheckCompletion()
    {
        completionNum++;

        if(completionNum == gridList.Count)
        {
            OnFridgeOrganized.Invoke();
        }
    }
    private void EndFridgeGame()
    {
        Destroy(this.gameObject);
        Core.Data.isInteracting = false;
    }

    private void OnDestroy()
    {
        OnFridgeOrganized.RemoveListener(CheckCompletion);
    }
}
