using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Vector3 _direction = Vector3.forward;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
