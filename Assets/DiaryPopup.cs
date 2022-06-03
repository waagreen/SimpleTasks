using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DiaryPopup : MonoBehaviour
{
    public Image mainPage;   
    public Transform container;

    public void ChangeState()
    {
        mainPage.gameObject.SetActive(false);
        container.gameObject.SetActive(true);
    }

}
