using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    [Tooltip("0 = Sprite stays at original pos\n1 = Sprite follows camera")]
    Vector2 parallaxSpeed;

    [SerializeField] Vector2 moveSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    private Vector2 spriteSize;
    private Camera playerCamera;

    private Vector2 startOffset;

    private const float spriteScaleFactor = 5f;

    private void Awake()
    {
        playerCamera = Camera.main;

        OnValidate();
    }

    private void Start()
    {
        spriteSize = spriteRenderer.size / spriteScaleFactor;

        startOffset = transform.position;
    }

    private void UpdateOld()
    {
        Vector2 camPos = playerCamera.transform.position;
    
        // Calculate object position using camera position and parallax speed
        Vector2 pos = camPos * parallaxSpeed;
        
        pos.x += (moveSpeed.x * Time.time) % spriteSize.x;
        pos.y += (moveSpeed.y * Time.time) % spriteSize.y;
    
        // Calculate the tiling offset based on the position and sprite size
        Vector2 tilingOffset = MathExtensions.Floor(playerCamera.transform.position / (spriteSize)) * spriteSize;
        // If the position is negative, adjust the tiling offset
        // Else if parallax speed is 0, set tiling offset to 0
    
        if (pos.x < 0f)
            tilingOffset.x += spriteSize.x;
        else if (parallaxSpeed.x == 0f)
            tilingOffset.x = 0f;
    
        if (pos.y < 0f)
            tilingOffset.y += spriteSize.y;
        else if (parallaxSpeed.y == 0f)
            tilingOffset.y = 0f;
    
        // Calculate the final position based on the tiling offset and start offset
        transform.position = new Vector3(
            pos.x % spriteSize.x + tilingOffset.x + startOffset.x,
            pos.y % spriteSize.y + tilingOffset.y + startOffset.y);
    }

    private void Update()
    {
        Vector2 camPos = playerCamera.transform.position;

        // Calculate the tiling offset based on the camera's position and sprite size, 
        Vector2 tilingOffset = MathExtensions.Floor(camPos / spriteSize) * spriteSize;

        // If the position is negative, adjust the tiling offset
        // Else if parallax speed is 0, set tiling offset to 0
        if (camPos.x < 0f)
            tilingOffset.x += spriteSize.x;
        else if (parallaxSpeed.x == 0f)
            tilingOffset.x = 0f;

        if (camPos.y < 0f)
            tilingOffset.y += spriteSize.y;
        else if (parallaxSpeed.y == 0f)
            tilingOffset.y = 0f;

        // Calculate the target position:
        // - Parallax pos: camPos.x * parallaxSpeed.x
        // - Move pos: moveSpeed.x * Time.time
        // Find the remainder after dividing by the sprite size. 
        Vector2 targetPos = new Vector2(
            (camPos.x * parallaxSpeed.x + moveSpeed.x * Time.time) % spriteSize.x,
            (camPos.y * parallaxSpeed.y + moveSpeed.y * Time.time) % spriteSize.y);

        // Add up everything together
        transform.position = targetPos + tilingOffset + startOffset;
    }

    [ContextMenu("Setup Sprite Renderer")]
    public void SetupSpriteRenderer()
    {
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        
        spriteRenderer.transform.localScale = Vector3.one;

        Vector2 newSize = spriteRenderer.sprite.bounds.size * spriteScaleFactor;

        // If its 1, no need to change because it will always follow camera
        if (parallaxSpeed.x == 1f)
            newSize.x = spriteRenderer.sprite.bounds.size.x;
        if (parallaxSpeed.y == 1f)
            newSize.y = spriteRenderer.sprite.bounds.size.y;

        spriteRenderer.size = newSize;
    }

    private void OnValidate()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
