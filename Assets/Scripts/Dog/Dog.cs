using UnityEngine;


public class Dog : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;

    private void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    private static Vector3 GetRoamingDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRoamingDirection() * UnityEngine.Random.Range(10f, 70f);
    }
}