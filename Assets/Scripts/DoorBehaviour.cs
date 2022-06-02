using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorBehaviour : InteractibleObject
{
    [Header("Door Transforms")]
    public Transform door;
    public Transform endP;
    public Transform startP;
    public AudioSource doorAudio;
    public AudioClip doorOpenClip;

    public override string id => this.name;
    public bool isOpen;

    
    private void Awake()
    {
        Core.Binds.OnInteract.AddListener((id) => OpenDoor(door, id));
        Core.Binds.OnInteract.AddListener((id) => CloseDoor(door, id));
    }
    public void OpenDoor(Transform t, string id)
    {

        if(id == this.id && !isOpen)
        {
            var tween = DOTween.Sequence();

            tween.Append(t.DOLocalRotateQuaternion(endP.rotation, .7f).SetEase(Ease.OutCubic)).OnComplete(() => ChangeState(true));
            tween.Play();

            doorAudio.PlayOneShot(doorOpenClip);
        }
    }
    public void CloseDoor(Transform t, string id)
    {
        if(id == this.id && isOpen)
        {
            var tween = DOTween.Sequence();

            tween.Append(t.DOLocalRotateQuaternion(startP.rotation, .5f).SetEase(Ease.InSine)).OnComplete(() => ChangeState(false));
            tween.Play();
        }
    }
    private void ChangeState(bool state) => isOpen = state;
}
