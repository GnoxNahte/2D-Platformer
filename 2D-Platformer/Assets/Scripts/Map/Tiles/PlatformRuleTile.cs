using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileMaterial
{
    Sand,
    Grass,
    Dirt,
    Metal,
}

[CreateAssetMenu(fileName = "Platform Rule Tile", menuName = "Tiles/Rule Tile")]
public class PlatformRuleTile : RuleTile
{
    public TileMaterial mat;

    //public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    //{
    //    base.GetTileData(position, tilemap, ref tileData);
    //    tileData.flags
    //}
}
