using System;
using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _stopDistance = 0.1f;
    private Vector3 _targetPosition;
    
    public event Action ReachedTarget;
    
    private bool IsReached => (transform.position - _targetPosition).sqrMagnitude <= _stopDistance * _stopDistance;

    public void Move(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        StartCoroutine(MoveToTarget(targetPosition, _speed));
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition, float speed)
    {
        while (true)
        {
            if (IsReached)
            {
                ReachedTarget?.Invoke();
                yield break;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}