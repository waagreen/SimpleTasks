using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int main;
    public int second;

    [Header("Movement Variables")]
    public float _speed;
    public float _gravity;
    public RaycastHit hit;
    public Ray ray;
    [HideInInspector] public Vector3 grav;
    [HideInInspector] public Vector3 move;
    

    [Header("Stress Variables")]
    public float stressSpeed = 1f;
    public float waitTime = 30f;
    [HideInInspector] public int stressLevel = 1;


    [Header("Interaction Variables")]
    public float contactDistance = 10f;
    public GameObject playerHands;
    public bool isHolding = false;
    public bool isComforting = false;
    public bool isInteracting = false;
    [HideInInspector] public GameObject selectedObject;    
}
