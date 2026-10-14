
using UnityEngine;

public class ConveyorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shape"))
        {
            ConveyorMovement movement =
                other.GetComponent<ConveyorMovement>();

            if (movement != null)
            {
                movement.SetOnConveyor(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shape"))
        {
            ConveyorMovement movement =
                other.GetComponent<ConveyorMovement>();

            if (movement != null)
            {
                movement.SetOnConveyor(false);
            }
        }
    }
}

