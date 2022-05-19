using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ToyButton : MonoBehaviour
{
    public TMP_Text nick;
    public Image gif;
    public Transform t;
    
    private Sequence activeAnim;
    private Toy toy;

    private Vector3 lastPos;

    public void ToySetup(Toy toy)
    {
        this.toy = toy;
        UpdateComponent();
    }

    private void UpdateComponent()
    {
        this.gif.sprite = toy.gif;
        nick.SetText(toy.toyName);
        activeAnim = DOTween.Sequence();
    }
    
    public void HoverButton()
    {   
        if(!activeAnim.IsPlaying())
        {
            KillTween(activeAnim);

            var tween = DOTween.Sequence();
            activeAnim = tween;

            var rectT = t as RectTransform;
            var height = rectT.rect.height;
            
            lastPos = rectT.position;

            tween.Append(t.DOMoveY(height / 2, 0.4f).SetEase(Ease.InCubic));
            tween.Play();
        }
    }
    public void ExitHover()
    {
        if(!activeAnim.IsPlaying())
        {
            KillTween(activeAnim);

            var tween = DOTween.Sequence();
            activeAnim = tween;
            
            tween.Append(t.DOMoveY(lastPos.y, 0.2f).SetEase(Ease.InExpo));
            tween.Play();
        }
    }

    private void KillTween(Sequence anim) => anim?.Kill();
}
