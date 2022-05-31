    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    [Range(0, 1)]public int checkNum;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("COLLIDING!!");
        if(other.attachedRigidbody) 
        {
            checkNum = 1;
        }
        else checkNum = 0;
    }
}
