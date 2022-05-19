using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UiSystem : MonoBehaviour
{
    [HideInInspector] public StressBar activeBar;
    [HideInInspector] public List<GameObject> points = new List<GameObject>();
    [SerializeField] private Transform barHolder;
    public StressBar stress;
    public PointBehaviour point;
    public UnityEvent OnMiniGameEnd = new UnityEvent();

    private bool isStressed = false;

    private void Awake() 
    {
        OnMiniGameEnd.AddListener(EndStressGame);    
    }

    public void CreateStressBar(int stressLevel)
    {
        if (isStressed) return;

        if (stressLevel >= 4) activeBar = stress.BarSetup(barHolder, Color.red, .9f, 5);
        else if (stressLevel >= 3) activeBar = stress.BarSetup(barHolder, Color.yellow, 1.4f, 4);
        else if (stressLevel >= 2) activeBar = stress.BarSetup(barHolder, Color.blue, 1.7f, 3);
        else activeBar = stress.BarSetup(barHolder, Color.cyan, 2.1f, 3);

        activeBar?.ArrowMove(activeBar.arrowSpeed);
        for (int i = 0; i < activeBar.nPoints; i++)
        {
            var a = CreatePoints(activeBar.GetRandomRectWidth(), activeBar.barColor);
            points.Add(a);
        }

        isStressed = true;
    }

    public GameObject CreatePoints(float nWidth, Color color)
    {
        var a = Instantiate(point, new Vector3(Random.Range(activeBar.startPos.position.x, activeBar.endPos.position.x), 0.5f, 0f), transform.rotation, activeBar.barTransform.transform);
        a.body.sizeDelta = new Vector2(nWidth, 0);
        a.body.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, activeBar.barTransform.rect.size.y * 2);
        a.body.SetAsFirstSibling();
        a.pointColor.color = color;
        
        return a.gameObject;
    }

    private void EndStressGame()
    {
        Core.Data.isComforting = false;
        isStressed = false;
        Destroy(activeBar.gameObject);
    }
    public void CheckMiniGameEnd()
    {
        if(points.Count == 0 && activeBar != null) OnMiniGameEnd.Invoke();
    }
    private void OnDisable() 
    {
        OnMiniGameEnd.RemoveAllListeners();    
    }
}
