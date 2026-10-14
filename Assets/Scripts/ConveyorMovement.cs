
using UnityEngine;

public class ConveyorMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private bool onConveyor;
    private bool hasBeenPickedUp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (onConveyor && !hasBeenPickedUp)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, 0f);
        }
    }

    public void SetOnConveyor(bool value)
    {
        onConveyor = value;
    }

    public void SetPickedUp()
    {
        hasBeenPickedUp = true;
        onConveyor = false;
        rb.linearVelocity = Vector2.zero;
    }
}
