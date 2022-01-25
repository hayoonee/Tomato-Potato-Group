using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{
    private bool isDragging = false;

    void Start()
    {
        
    }

    public void StartDrag()
    {
        isDragging = true;
    }

    public void StopDrag()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
