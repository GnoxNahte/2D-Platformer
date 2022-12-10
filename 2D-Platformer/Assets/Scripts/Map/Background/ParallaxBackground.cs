using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    [SerializeField] bool scrollVertically;

    // Since all backgrounds should scroll horizontally, there is no need to have this variable
    // [SerializeField] bool scrollHorizontally;

    private Vector3 spriteSize;
    private Camera playerCamera;


    private void Awake()
    {
        playerCamera = Camera.main;
    }

    private void Start()
    {

        spriteSize = spriteRenderer.size / 3f;
    }

    private void Update()
    {
        Vector3 camPos = playerCamera.transform.position;

        transform.position = new Vector3 (camPos.x * speed + Mathf.Floor(camPos.x / spriteSize.x) * spriteSize.x + spriteSize.x * 0.5f, transform.position.y);

        if (scrollVertically)
            transform.position = new Vector3(transform.position.x, camPos.y * speed + Mathf.Floor(camPos.y / spriteSize.y) * spriteSize.y + spriteSize.y * 0.5f);
    }

    private void OnValidate()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
