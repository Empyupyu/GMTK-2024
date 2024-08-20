using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace GarbageScaler
{
    public class RotateAnimation : MonoBehaviour
    {
        public Vector3 EndRotate;
        public Vector3 EndLocalPosDown;
        public Vector3 EndLocalPosUp;
        public float DurationTurn;
        public float DurationMove;
        public float MoveToCenterDuration;
        public Ease Ease;

        private Vector3 startLocalPos;
        
        void Start()
        {
            transform.DORotate(EndRotate, DurationTurn).SetEase(Ease).SetLoops(-1);

            startLocalPos = transform.localPosition;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(EndLocalPosDown, DurationMove).SetEase(Ease));
            sequence.Append(transform.DOLocalMove(startLocalPos, MoveToCenterDuration).SetEase(Ease));
            sequence.Append(transform.DOLocalMove(EndLocalPosUp, DurationMove).SetEase(Ease));
            sequence.Append(transform.DOLocalMove(startLocalPos, MoveToCenterDuration).SetEase(Ease));
            sequence.SetLoops(-1);
            sequence.Play();
        }
        
    }
}
