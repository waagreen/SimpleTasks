using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetOutButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fridgeUI;
    public bool activateButton;
    private void Update()
    {
        if (activateButton == true) GetOutTheFridge();

    }
    public void GetOutTheFridge()
    {
        fridgeUI.SetActive(false);
    }
    public void ButtonClick()
    {
        activateButton = true;
        Debug.Log($"true");
    }
}
