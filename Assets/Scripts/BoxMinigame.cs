using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class BoxMinigame : MonoBehaviour
{
    public ToyPickerUI hud;
    public Transform container;
    
    [Header("Chest Transforms")]
    public Transform lid;
    public Transform endP;

    public int maxCount;
    private int boxCount;

    private UnityEvent OnAnimDone = new UnityEvent();
    private UnityEvent OnMinigameDone = new UnityEvent();

    private Material toyMaterial;
    private GameObject toy;

    private void Awake()
    {
        boxCount = 0;
        OnAnimDone.AddListener(() => Tdestroy(toy));
        OnMinigameDone.AddListener(SpawnHud);
        Core.Binds.OnInteract.AddListener(() => OpenChest(lid));
    }
    private void OnTriggerEnter(Collider boxedObject)
    {
        Debug.Log("Object collided");
        toyMaterial = boxedObject.GetComponent<Renderer>().material;
        toy = boxedObject.gameObject;
        FadeToy(1f, toyMaterial);
        boxCount++;
        
        if(boxCount >= maxCount)
        {
            OnMinigameDone.Invoke();
            Core.Data.isInteracting = true;
        }
    }
    private void OnDestroy()
    {
        OnAnimDone.RemoveAllListeners();
        OnMinigameDone.RemoveAllListeners();
    }
    public void OpenChest(Transform t)
    {
        var tween = DOTween.Sequence();

        
        tween.Append(t.DORotateQuaternion(endP.rotation, 1f).SetEase(Ease.InSine));
        tween.Play();
    }
    private void SpawnHud() => Instantiate(hud, container);
    private void FadeToy(float timeToFade, Material material) => material.DOFade(0f, timeToFade).SetEase(Ease.OutQuint).OnComplete(OnAnimDone.Invoke);
    private void Tdestroy(GameObject obj) => Destroy(obj);
}
