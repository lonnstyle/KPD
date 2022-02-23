using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 startPosition;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        // mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        // check for nearby connection points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            // make sure not my own collider
            if (collider.gameObject != gameObject)
            {
                // update wire to the connection point position
                UpdateObject(collider.transform.position);

                // check if the wires are same color
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    Debug.Log(startPosition);
                    // count connection
                    main.Instance.SwitchChange(1);
                    //hidden the Sprite
                    // finish step
                    collider.GetComponent<DragNDrop>()?.Done();
                    Done();
                }
                return;
            }
        }

        // update wire
        UpdateObject(newPosition);
    }

    void Done()
    {
        // destory the script
        Destroy(this);
    }

    private void OnMouseUp()
    {
        // reset wire position
        UpdateObject(startPosition);
    }

    void UpdateObject(Vector3 newPosition)
    {
        // update position
        transform.position = newPosition;

    }
}

