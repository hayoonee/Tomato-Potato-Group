using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject DropZone;

    private bool isDragging = false;
    private GameObject startParent;
    private GameObject dropZone;
    private Vector2 startPosition;
    private bool isOverDropZone;

    void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("Drop Zone");
    }

    public void StartDrag()
    {
        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }

    public void StopDrag()
    {
        isDragging = false;
        if(isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            GetComponent<CardDrag>().enabled = false;
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }
}
