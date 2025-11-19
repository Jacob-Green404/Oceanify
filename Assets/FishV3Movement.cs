using UnityEngine;

public class FastFishVerticalMovement : MonoBehaviour
{
    public float minSpeed = 6f;
    public float maxSpeed = 10f;
    public float acceleration = 4f;
    public float turnSpeed = 6f;
    public float targetChangeInterval = 1.5f;
    public float wobbleMagnitude = 0.2f;
    public float wobbleFrequency = 3f;
    public float verticalRange = 3f;  // Range of vertical movement around base yLevel
    public float verticalSpeed = 1.5f; // Speed of vertical oscillation

    private float minX = 0f, maxX = 70f;
    private float minZ = 0f, maxZ = 50f;
    private float minY = 1f;   // Minimum Y level
    private float maxY = 45f;  // Maximum Y level

    private float baseYLevel = 23f; // Base Y level; set roughly centered in minY-maxY range

    private Vector3 targetPosition;
    private float currentSpeed;
    private float targetSpeed;
    private float changeTargetTimer;
    private Quaternion targetRotation;

    void Start()
    {
        // Start with baseYLevel centered between minY and maxY
        baseYLevel = (minY + maxY) / 2f;

        SetNewTarget();
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        targetSpeed = currentSpeed;
        changeTargetTimer = targetChangeInterval;
    }

    void Update()
    {
        changeTargetTimer -= Time.deltaTime;
        if (changeTargetTimer <= 0f)
        {
            SetNewTarget();
            changeTargetTimer = Random.Range(targetChangeInterval * 0.75f, targetChangeInterval * 1.25f);
        }

        // Gradual speed adjustment
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        // Vertical oscillation using sine wave and clamp to minY and maxY
        float verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
        float newY = Mathf.Clamp(baseYLevel + verticalOffset, minY, maxY);

        // Movement direction with "wobble" added horizontally
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 wobble = transform.right * Mathf.Sin(Time.time * wobbleFrequency) * wobbleMagnitude;
        Vector3 moveDirection = direction + wobble;

        // Update position with vertical movement
        Vector3 newPosition = transform.position + moveDirection * currentSpeed * Time.deltaTime;
        newPosition.y = newY;

        // Clamp horizontal position within bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;

        // Smooth turning
        if (moveDirection != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    void SetNewTarget()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        // Vertical target remains base because vertical oscillation is separate and clamped
        targetPosition = new Vector3(x, baseYLevel, z);

        // Random speed bursts for dynamic movement
        targetSpeed = Random.Range(minSpeed, maxSpeed);

        // Short random pauses less likely due to quicker movement style
        if (Random.value < 0.05f)
        {
            targetSpeed = 0f;
        }
    }
}
