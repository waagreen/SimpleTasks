using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractibleObject : MonoBehaviour
{ 
    public abstract string id {get;}
    public abstract bool isKeyItem {get;}
}
