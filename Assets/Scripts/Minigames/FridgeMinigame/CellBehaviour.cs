using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    [Range(0, 1)]public int checkNum;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.attachedRigidbody) checkNum = 1;
        else checkNum = 0;
    }
}
