using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Point" && Core.Binds.baseMove.KeyboardMouse.ComfortObject.inProgress)
        {
            Destroy(other.gameObject);
            Core.UI.points.Remove(other.gameObject);
            Debug.Log("Points: " + Core.UI.points.Count);
        }
    }
}
