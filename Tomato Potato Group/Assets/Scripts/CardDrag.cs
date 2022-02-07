using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CardDrag : NetworkBehaviour
{
    public GameObject Canvas;
    public PlayerManager playerManager;

    private bool isDragging = false;
    private bool isDraggable = true;
    private GameObject startParent;
    private GameObject dropZone;
    private Vector2 startPosition;
    private bool isOverDropZone;

    void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        if (!hasAuthority)
        {
            isDraggable = false;
        }
    }

    public void StartDrag()
    {
        if (!isDraggable) return;
        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }

    public void StopDrag()
    {
        if (!isDraggable) return;
        isDragging = false;
        if(isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            GetComponent<CardDrag>().enabled = false;
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            playerManager = networkIdentity.GetComponent<PlayerManager>();
            playerManager.PlayCard(gameObject);
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
