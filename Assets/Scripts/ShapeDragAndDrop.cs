
using UnityEngine;

public class ShapeDragAndDrop : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;
    private ConveyorMovement conveyorMovement;

    private bool isDragging;
    private Vector2 dragOffset;
    private float dragZDistance;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        conveyorMovement = GetComponent<ConveyorMovement>();

        dragZDistance = -mainCamera.transform.position.z;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryStartDragging();
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            DragShape();
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }

    private Vector2 GetPointerWorldPosition()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = dragZDistance;

        return mainCamera.ScreenToWorldPoint(screenPosition);
    }

    private void TryStartDragging()
    {
        Vector2 pointerPosition = GetPointerWorldPosition();

        Collider2D hit = Physics2D.OverlapPoint(pointerPosition);

        if (hit == null || hit.gameObject != gameObject)
            return;

        isDragging = true;
        dragOffset = rb.position - pointerPosition;

        if (conveyorMovement != null)
        {
            conveyorMovement.SetPickedUp();
        }

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void DragShape()
    {
        Vector2 targetPosition = GetPointerWorldPosition() + dragOffset;
        rb.MovePosition(targetPosition);
    }

    private void StopDragging()
    {
        isDragging = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
