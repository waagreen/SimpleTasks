using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StressBar : MonoBehaviour
{
    //bar body and color
    public Color barColor;
    public RectTransform barTransform;
    public Transform endPos;
    public Transform startPos;

    //arrow body and speed
    public Transform arrowTransform;
    public Collider2D arrowCol;
    public float arrowSpeed;
    public int nPoints;
    private Sequence aMove;

    //function responsible for instantiate and custom the stressed bar
    public StressBar BarSetup(Transform barHolder, Color barColor, float arrowSpeed, int nPoints)
    {
        var nB = Instantiate(this, barHolder);
        nB.barColor = barColor;
        nB.arrowSpeed = arrowSpeed;
        nB.nPoints = nPoints;

        return nB;
    }

    public void ArrowMove(float speed)
    {
        aMove = DOTween.Sequence();

        aMove.Append(arrowTransform.DOMoveX((startPos.position.x - 25f), speed).SetEase(Ease.OutSine));
        aMove.Append(arrowTransform.DOMoveX((endPos.position.x + 25f), speed).SetEase(Ease.OutSine));

        aMove.Play().SetLoops(-1, LoopType.Restart);
    }

    public float GetRandomRectWidth() => Random.Range(100f, 650f);
}
