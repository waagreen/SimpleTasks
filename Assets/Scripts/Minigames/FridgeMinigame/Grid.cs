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
    [SerializeField] private int totalSum;

    [Header("Grid Specs")]
    public int cellNum;
    public List<CellBehaviour> cellList;
    

}
