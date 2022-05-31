using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //Gameobject da c�lula da geladeira
    public GameObject cellGrid;
    public RectTransform container;

    public bool isDone = false;
    private int maxCount;
    private int totalSum;

    [Header("Grid Specs")]
    public int cellNum;
    public List<CellBehaviour> cellList;
    

    void Awake()
    {
        for(int i = 0; i < cellNum; i++)
        {
            var grid = Instantiate(cellGrid, container);
            cellList.Add(grid.GetComponent<CellBehaviour>());
        }

        maxCount = cellList.Count;
    }
    private void Update()
    {
        if(SumCheck()) isDone = true;
        else isDone = false;
    }

    private bool SumCheck()
    {
        foreach (var cell in cellList)
        {
            if(cell.checkNum >= 1) totalSum++;
            else totalSum--;
        }

        if(totalSum < maxCount) return false;
        return true;
    }

}
