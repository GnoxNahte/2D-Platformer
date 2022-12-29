using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// How to setup:
// - Create GameObject with SpriteRenderer
// - Attach this script
// - Set sprite
// - Set sprite DrawMode to "Tiled"
// - Transfer scale (XY) to SpriteRenderer.Size (Width, Height). 
// - Multiply X by 5

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] float parallaxSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    //[SerializeField] bool scrollVertically;

    // Since all backgrounds should scroll horizontally, there is no need to have this variable
    // [SerializeField] bool scrollHorizontally;

    private Vector3 spriteSize;
    private Camera playerCamera;


    private void Awake()
    {
        playerCamera = Camera.main;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteSize = spriteRenderer.size / 5f;
    }

    private void Update()
    {
        Vector3 camPos = playerCamera.transform.position;

        float xPos = camPos.x * parallaxSpeed;
        transform.position = new Vector3 (xPos % spriteSize.x + Mathf.Floor(xPos / spriteSize.x / parallaxSpeed) * spriteSize.x, transform.position.y);
        
        //if (scrollVertically)
        //    transform.position = new Vector3(transform.position.x, camPos.y * parallaxSpeed + Mathf.Floor(camPos.y / spriteSize.y) * spriteSize.y + spriteSize.y * 0.5f);
    }

    private void OnValidate()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
