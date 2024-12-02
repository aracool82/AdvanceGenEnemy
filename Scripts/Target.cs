using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Target : MonoBehaviour
{
    [SerializeField] private Vector3[] _points;
    
    private Mover _mover;
    private int _currentPoint = 0;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _mover.ReachedTarget += MoveToNextPoint;
    }

    private void OnDisable()
    {
        _mover.ReachedTarget -= MoveToNextPoint;
    }

    private void Start()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        Vector3 target = _points[_currentPoint];
        _mover.Move(target);
        _currentPoint = (_currentPoint + 1) % _points.Length;
    }
}