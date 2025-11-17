using UnityEngine;

public class SharkRandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float targetChangeInterval = 2f;

    // Aquarium bounds
    private float minX = 0f, maxX = 70f;
    private float minZ = 0f, maxZ = 50f;
    private float yLevel = 1f; // Keeps the shark above the floor; adjust as needed

    private Vector3 targetPosition;

    void Start()
    {
        SetNewTarget();
        InvokeRepeating("SetNewTarget", targetChangeInterval, targetChangeInterval);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Optional: Rotate to face movement direction
        Vector3 direction = targetPosition - transform.position;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 2f);
    }

    void SetNewTarget()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        targetPosition = new Vector3(x, yLevel, z);
    }
}