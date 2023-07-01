using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

/* 유저가 클릭하면 포커싱 되는 객체들 */
public class Focusable : MonoBehaviour, IPointerClickHandler
{
    /* Focusable을 기준으로 어디로 이동시킬지 결정한다. */
    public Vector3 TargetPosition;
    public Vector3 TargetRotation;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        var cam = Camera.main;
        var seq = DOTween.Sequence()
            .Append(cam.transform.DOMove(transform.position + TargetPosition, 1f))
            .Join(cam.transform.DORotate(TargetRotation, 1f));
    }
}
