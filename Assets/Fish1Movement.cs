using UnityEngine;

public class Fish1Movement : MonoBehaviour
{
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float acceleration = 2f;
    public float turnSpeed = 3f;
    public float targetChangeInterval = 3f;
    public float wobbleMagnitude = 0.15f;
    public float wobbleFrequency = 2f;

    private float minX = 0f, maxX = 70f;
    private float minZ = 0f, maxZ = 50f;
    private float yLevel = 1f;

    private Vector3 targetPosition;
    private float currentSpeed;
    private float targetSpeed;
    private float changeTargetTimer;
    private Quaternion targetRotation;

    void Start()
    {
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

        // Movement direction with "wobble"
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 wobble = transform.right * Mathf.Sin(Time.time * wobbleFrequency) * wobbleMagnitude;
        Vector3 moveDirection = direction + wobble;

        // Update position
        transform.position += moveDirection * currentSpeed * Time.deltaTime;

        // Clamp position within bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            yLevel,
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );

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
        targetPosition = new Vector3(x, yLevel, z);

        // Randomly vary speed for burst motion
        targetSpeed = Random.Range(minSpeed, maxSpeed);

        // Optionally add short pauses
        if (Random.value < 0.1f)
        {
            targetSpeed = 0f;
        }
    }
}
