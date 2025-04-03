using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _speed;
    private int _pointIndex = 0;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_pointIndex].position, _speed * Time.deltaTime);

        if (transform.position == _points[_pointIndex].position)
            SetIndex();
    }

    private void SetIndex()
    {
        _pointIndex++;

        if(_pointIndex >= _points.Count)
        {
            _pointIndex = 0;
        }
    }
}
