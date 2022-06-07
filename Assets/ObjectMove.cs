using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    public float objectSpeed = 100f;
    public Transform mainObject;
    // Start is called before the first frame update
    void Start()
    {
        mainObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mainObject.Translate(Vector3.up * objectSpeed);
    }
}
