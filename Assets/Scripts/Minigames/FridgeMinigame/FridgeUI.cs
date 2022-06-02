using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeUI : MonoBehaviour
{   
    public int gridNum;
    public GameObject grid;
    public RectTransform container;
    public List<Vector2> coordinates;

    private void SetupMinigame()
    {
        for(int i = 0; i < gridNum; i++)
        {
            Instantiate(grid, container);
        }
    }
}
