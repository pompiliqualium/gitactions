using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Forest : MonoBehaviour
{
    public GameObject tree;
    public LayerMask mask;
    public ObjectPooler objectPooler;
    private float xBounds;
    private float zBounds;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        Mesh mesh = transform.GetComponentInParent<MeshFilter>().mesh;
        xBounds = mesh.bounds.size.x - 5;
        zBounds = mesh.bounds.size.z - 5;
    }

    private void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool("Tree", GetRandomPosition(), Quaternion.identity);
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        randomPosition.x = Random.Range(-xBounds / 2f, xBounds / 2f);
        randomPosition.z = Random.Range(-zBounds / 2f, zBounds / 2f);
        randomPosition.y = 10f;
        randomPosition.y = GetYPos(randomPosition);

        // Transform instance = Instantiate(spawnObject, this.transform).transform;
        // instance.localPosition = randomPosition;
        return randomPosition;
    }

    private float GetYPos(Vector3 currentPosition)
    {
        float newY = 0;
        float distance = 100f;
        if (Physics.Raycast(currentPosition, Vector3.down, out RaycastHit hit, distance, mask))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                newY = hit.point.y;
            }
        }


        return newY;
    }
}