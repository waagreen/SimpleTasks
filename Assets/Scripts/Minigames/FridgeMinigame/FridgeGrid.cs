using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeGrid : MonoBehaviour
{
    //Gameobject da c�lula da geladeira
    public GameObject cellGrid;
    public RectTransform par;
    public RectTransform container;
    private float[,] gridCord;

    private float width, height;

    [Header("Grid Specs")]
    public int cellNum;
    

    void Awake()
    {
        for(int i = 0; i < cellNum; i++)
        {
            var grid = Instantiate(cellGrid, container);
        }

    }
}
