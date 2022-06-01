using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class TitleTween : MonoBehaviour
{
    public RectTransform body;
    public Transform firstRotation;
    public Transform secondRotation;

    private async void Start()
    {
        await Task.Delay(100);
        UpAndDown(body);
    }

    private void UpAndDown(RectTransform t)
    {
        var tween = DOTween.Sequence();
        var startPos = this.transform.rotation;

        tween.Append(t.DORotateQuaternion(firstRotation.rotation, 0.7f)).SetEase(Ease.OutBounce);
        tween.Append(t.DORotateQuaternion(secondRotation.rotation, 1f)).SetEase(Ease.OutBounce);
        tween.Append(t.DORotateQuaternion(startPos, 0.3f)).SetEase(Ease.InCirc);
        tween.Play();
    }
}
