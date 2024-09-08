using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform _object;

    void Update()
    {
        transform.LookAt(_object);
    }
}
