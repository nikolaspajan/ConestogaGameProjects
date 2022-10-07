using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapRenderScript : MonoBehaviour
{
    public int MinSectionWidth;
    public float Seed;
    public TileBase MyTileBase;
    public Tilemap MyTileMap;
    public int Width;
    public int Height;
    public int[,] Map;

    // Start is called before the first frame update
    void Start()
    {
        Map = GenerateArray(Width, Height, true);
        Map = PerlinNoise(Map, Seed);
        RenderMap(
         Map,
         MyTileMap,
         MyTileBase);

        UpdateMap(Map, MyTileMap);

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateMap(
        //  Map,
        //  MyTileMap);
    }

    public static int[,] PerlinNoise(
        int[,] map, 
        float seed)
    {
        int newPoint;
        //Used to reduced the position of the Perlin point
        float reduction = 0.5f;
        //Create the Perlin
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            float noise = (Mathf.PerlinNoise(x, seed) - reduction);

            if (noise < 0.02)
                newPoint = 1;
            else
                newPoint = 2;

            //Make sure the noise starts near the halfway point of the height
            //newPoint += map.GetUpperBound(1) / 2;
            if (newPoint == 1)
            {
                for (int y = newPoint; y >= 0; y--)
                {
                    if (y >= 1)
                        map[x, y] = 2;
                    else
                        map[x, y] = 1;
                }
            }
            else if (newPoint == 2)
            {
                for (int y = newPoint; y >= 0; y--)
                {
                    map[x, y] = 1;
                }
            }
            else
            {
                for (int y = newPoint; y >= 0; y--)
                {
                    map[x, y] = 0;
                }
            }
        }
        return map;
    }

    public static int[,] GenerateArray(
        int width, 
        int height, 
        bool empty)
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (empty)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }

    public static void RenderMap(
        int[,] map, 
        Tilemap tilemap, 
        TileBase tile)
    {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();
        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }

    public static void UpdateMap(
        int[,] map, 
        Tilemap tilemap) //Takes in our map and tilemap, setting null tiles where needed
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                //We are only going to update the map, rather than rendering again
                //This is because it uses less resources to update tiles to null
                //As opposed to re-drawing every single tile (and collision data)
                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }

}
