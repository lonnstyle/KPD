using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire_1 : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
        Debug.Log(startPosition);
        Debug.Log(startPoint);
        width = wireEnd.size.x;
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
                UpdateWire(collider.transform.position);

                // check if the wires are same color
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    Debug.Log(startPosition);
                    // count connection
                    main.Instance.SwitchChange(1);
                    //hidden the Sprite
                    // finish step
                    collider.GetComponent<wire_1>()?.Done();
                    Done();
                }
                return;
            }
        }

        // update wire
        UpdateWire(newPosition);
    }

    void Done()
    {
        // turn on light
        lightOn.SetActive(true);

        // destory the script
        Destroy(this);
    }

    private void OnMouseUp()
    {
        // reset wire position
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
        // update position
        transform.position = newPosition;

        // update direction
        Vector3 direction = newPosition - startPoint;
        direction.z = 0f;
        transform.right = direction * transform.lossyScale.x;

        // update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        Debug.Log("startPoint:" + startPoint + "\nnewPositiion" + newPosition + "\ndist:" + dist);
        wireEnd.size = new Vector2(dist/45+width, wireEnd.size.y);
        Debug.Log("Sprite size: " + wireEnd.size.ToString("F2"));

    }
}

