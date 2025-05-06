using UnityEngine;

public class Camera : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
