using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    private bool _moving;
    Vector3 startPoint;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

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
                    collider.GetComponent<DragMove>()?.Done();
                    Done();
                }
                return;
            }
        }
        UpdateObject(newPosition);

    }
    void Done()
    {
        Destroy(this);
    }
    private void OnMouseUp() {
        UpdateObject(startPosition);
    }
    void UpdateObject(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
