using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{   
    public Animator anim;
    private bool isIdle = false;
    

    public void EnableAnima()
    {
        anim.SetBool("isIdle", false);
        isIdle = true;
    }
    public void DisableAnima()
    {
        anim.SetBool("isIdle", true);
        isIdle = false;
    }
}
