using UnityEngine;

public class FollowX : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _offsetX;

    // Update is called once per frame

    private void Start()
    {
        _offsetX = transform.position.x - _target.position.x;
    }

    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = _target.position.x + _offsetX;
        transform.position = position;
    }
}
