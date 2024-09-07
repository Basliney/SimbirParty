using UnityEngine;

public class FollowLogic : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed = 1;
    [SerializeField] private (float, float) _camReaction;

    private float _time;

    void Update()
    {
        var offset = GetDistance(transform.position, _player.position);
        //if (offset <= _camReaction.Item2 && offset > _camReaction.Item1)
        //    return;

        _time = Time.deltaTime * _speed;
        var interpolatedVector = Vector3.Lerp(transform.transform.position, _player.position + _offset, _time);

        this.transform.position = interpolatedVector;
        transform.LookAt(_player);
    }

    private void Move()
    {

    }

    private float GetDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + 0 + Mathf.Pow(a.z - b.z, 2));
    }
}
