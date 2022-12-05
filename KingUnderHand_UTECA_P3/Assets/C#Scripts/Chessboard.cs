using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Chessboard : MonoBehaviour
{
    [Header("Art Stuff")]
    [SerializeField] private Material tileMaterial;
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private float tileSize = 1.0f;
    [SerializeField] private float yOffset = 0.2f;
    [SerializeField] private Vector2 boardCenter = Vector2.zero;

    // LOGIC 
    private const int TILE_COUNT_X = 4;
    private const int TILE_COUNT_Y = 4;
    private GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;

    private Vector2 bounds;
    private void Awake()
    {
        GenerateAllTiles(1, (float)1.5, TILE_COUNT_X, TILE_COUNT_Y);
    }

    private void Update()
    {
        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile", "Hover")))
        {
            //Consigue los indices de los recuadros con los que colisiona el mouse
            Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

            //Si selecciona un recuadro sin tener ninguno seleccinoado
            if(currentHover == -Vector2.one)
            {
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
                
            }

            //Si selecciono un nuevo recuadro cambia de regreso el anterior
            if (currentHover != hitPosition)
            {
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
            }
        }

        else
        {
            if (currentHover != -Vector2Int.one)
            {

                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile"); 
                currentHover = -Vector2Int.one;
            }
        }
    }

    //Crear Tablero
    private void GenerateAllTiles(float tileSizeX, float tileSizeY, int tileCountX, int tileCountY) //Creacion de todos los recuadros
    {
        yOffset += transform.position.y;
        bounds = new Vector2((tileCountX / 2) * tileSizeX,(tileCountX / 2) * tileSizeY) + boardCenter;

        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
        {
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenerateSingleTile(tileSizeX, tileSizeY, x, y);
           
        }
    }

    private GameObject GenerateSingleTile(float tileSizeX, float tileSizeY, int x, int y)  // Forma de un solo recuadro.
    {
        GameObject tileObject = new GameObject(string.Format("X: {0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMaterial;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector2(x * tileSizeX, y * tileSizeY)-bounds;
        vertices[1] = new Vector2(x * tileSizeX, (y + 1) * tileSizeY)-bounds;
        vertices[2] = new Vector2((x + 1) * tileSizeX, y * tileSizeY)-bounds;
        vertices[3] = new Vector2((x + 1) * tileSizeX, (y + 1) * tileSizeY)-bounds;

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };
        mesh.vertices = vertices;
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        tileObject.layer = LayerMask.NameToLayer("Tile");
        tileObject.AddComponent<BoxCollider>();


        return tileObject;
    }

    //Operaciones
    private Vector2Int LookupTileIndex(GameObject hitInfo)
    {
        for (int x = 0; x < TILE_COUNT_X; x++)
            for (int y = 0; y < TILE_COUNT_Y; y++)
                if (tiles[x, y] == hitInfo)
                    return new Vector2Int(x, y);
        return -Vector2Int.one; //Invalido


    }
}
