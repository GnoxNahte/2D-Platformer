using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChecker : MonoBehaviour
{
    public LayerMask LayerMask;

    public bool IsTouchingTile => tileCollider.IsTouchingLayers(LayerMask);

    public event Func<TileMaterial> OnHitTile;
    public event Func<TileMaterial> OnExitTile;

    private Collider2D tileCollider;

    private void Awake()
    {
        tileCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHitTile?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExitTile?.Invoke();
    }
}
