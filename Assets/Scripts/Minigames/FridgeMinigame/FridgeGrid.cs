using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeGrid : MonoBehaviour
{
    //Gameobject da célula da geladeira
    public GameObject cellGrid;
    private int[,] gridCord;
    private float width => this.width;
    private float height => this.height;
    
    [Header("Grid Specs")]
    public int columnNumber;
    public int rowNumber;
    




    // Start is called before the first frame update
    void Start()
    {
        CreateGrid(rowNumber,columnNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateGrid(int gridSizeX, int gridSizeY)
    {
        

        for(int i = 0; i < columnNumber; i++)
        {
            for(int j = 0; j < rowNumber; j++)
            {
                gridCord = new int [gridSizeX, gridSizeY];
                CreateCell(i,j);
            }
        }


    }

    private void CreateCell(int x, int y)
    {
        var grid = Instantiate(cellGrid,Core.UI.barHolder);
        grid.transform.position = new Vector3(x - (width - .5f), y - (height - .5f));

    }

}
