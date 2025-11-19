using UnityEngine;

public class SharkRandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float targetChangeInterval = 2f;

    // Aquarium bounds
    private float minX = -43f; // Updated to go from -43
    private float maxX = 43f;   // to 43
    private float minZ = 0f;
    private float maxZ = 50f;
    private float yLevel = 2f; // keep Y>=2

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
        float x = Random.Range(minX, maxX); // Full range on X axis
        float z = Random.Range(minZ, maxZ);
        float y = yLevel; // Keep Y fixed at 2, or you can add some oscillation if preferred
        targetPosition = new Vector3(x, y, z);
    }
}