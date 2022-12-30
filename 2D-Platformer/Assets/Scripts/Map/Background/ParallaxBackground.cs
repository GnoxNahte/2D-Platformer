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
    [SerializeField]
    [Tooltip("0 = Sprite stays at original pos\n1 = Sprite follows camera")]
    Vector2 parallaxSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    private Vector2 spriteSize;
    private Camera playerCamera;

    private Vector2 startOffset;

    private void Awake()
    {
        playerCamera = Camera.main;

        OnValidate();
    }

    private void Start()
    {
        spriteSize = spriteRenderer.size / 5f;

        startOffset = transform.position;
    }

    private void Update()
    {
        // Calculate object position using camera position and parallax speed
        Vector2 pos = playerCamera.transform.position * parallaxSpeed;

        // Calculate the tiling offset based on the position and sprite size
        Vector2 tilingOffset = MathExtensions.Floor(pos / (spriteSize * parallaxSpeed + MathExtensions.Vector2Epsilon)) * spriteSize;

        // If the position is negative, adjust the tiling offset
        if (pos.x < 0)
            tilingOffset.x += spriteSize.x;
        if (pos.y < 0)
            tilingOffset.y += spriteSize.y;

        // Calculate the final position based on the tiling offset and start offset
        transform.position = new Vector3(
            pos.x % spriteSize.x + tilingOffset.x + startOffset.x,
            pos.y % spriteSize.y + tilingOffset.y + startOffset.y);
    }

    private void OnValidate()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
