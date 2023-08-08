using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{

    [SerializeField] private string _targetTag = "Player";
    [SerializeField] private float _speed;

    private Rigidbody2D rigidbody2D;

    [SerializeField] private Collider2D checkMoveZone;
    [SerializeField] private Collider2D colliderCoin;

    private Transform _targetMove;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _targetMove = CheckOverlapWithTarget(checkMoveZone);

        if (CheckOverlapWithTarget(colliderCoin))
        {
            _targetMove.GetComponent<Player>().AddCoin(1);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_targetMove != null)
        {
            Vector2 directionMove = (_targetMove.position - transform.position).normalized * _speed;

            rigidbody2D.velocity = directionMove;
        }
    }

    private Transform CheckOverlapWithTarget(Collider2D colliderOverlap)
    {
        List<Collider2D> results = new();
        colliderOverlap.Overlap(results);

        foreach (Collider2D collider in results)
            if (collider.transform.tag == _targetTag)
                return collider.transform;

        return null;
    }
}
