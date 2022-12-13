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

    [Header("Prefabs & Materiales")]
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Material[] teamMatrial;

    // LOGIC 
    public ChessPiece[,] chessPieces;
    private List<Vector2Int> availableMoves = new List<Vector2Int>();
    private ChessPiece currentlyDragging;
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

            //if (Input.GetMouseButtonDown(0))
            //{
            //    chessPieces = new ChessPiece[4, 4];
            //    if (chessPieces[hitPosition.x, hitPosition.y] != null)
            //    {
            //        //Es nuestro turno?
            //        if (true)
            //        {
            //            currentlyDragging = chessPieces[hitPosition.x, hitPosition.y];

            //            //Consigue lista de jugadas validas, cambia el color de las casillas apropiadas.
            //            availableMoves = currentlyDragging.GetAvailableMoves(ref chessPieces, TILE_COUNT_X, TILE_COUNT_Y);
            //            HighlightTiles();
            //        }

            //    }
            //}
                              
            

            //if (currentlyDragging != null && Input.GetMouseButtonUp(0))
            //{
            //    Vector2Int previousPostion = new Vector2Int(currentlyDragging.currentX, currentlyDragging.currentY);

            //    bool validMove = MoveTo(currentlyDragging, hitPosition.x,hitPosition.y);
            //    if(!validMove)
            //    {
            //        currentlyDragging.transform.position = GetTileCenter(previousPostion.x, previousPostion.y);

            //    }
            //}
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



    //Posicionando las cartas
    //private void PositionAllPieces()
    //{

    //    for (int x = 0; x < TILE_COUNT_X; x++)
    //        for (int y = 0; y < TILE_COUNT_Y; y++)
    //            if (chessPieces[x, y] != null)
    //                PositionSinglePiece(x, y, true);
    //}

    //private void PositionSinglePiece(int x, int y, bool force = false)
    //{
    //    chessPieces[x, y].currentX = x;
    //    chessPieces[x, y].currentY = y;
    //    chessPieces[x, y].transform.position = new Vector2(x * tileSize, y * tileSize);
    //}
    //private Vector2 GetTileCenter(int x, int y) //Consigue el centro delos recuadros
    //{
    //    return new Vector2(x * tileSize, y * tileSize) + new Vector2(tileSize / 2, tileSize / 2);
    //}
    //HilightTiles
    //private void HighlightTiles()
    //{
    //    for (int i = 0; i < availableMoves.Count; i++)
    //    {
    //        tiles[availableMoves[i].x, availableMoves[i].y].layer = LayerMask.NameToLayer("Highlight");
    //    }
    //}

    //private void RemoveHighlightTiles()
    //{
    //    for (int i = 0; i < availableMoves.Count; i++)
    //    {
    //        tiles[availableMoves[i].x, availableMoves[i].y].layer = LayerMask.NameToLayer("Tile");

    //        availableMoves.Clear();
    //    }
    //}
    //Operaciones
    #region  

    //private bool MoveTo(ChessPiece cp, int x, int y) //movimiento
    //{
    //    Vector2Int previousPosition = new Vector2Int(cp.currentX, cp.currentY);

    //    chessPieces[x, y] = cp;
    //    chessPieces[previousPosition.x, previousPosition.y] = null;

    //    PositionSinglePiece(x, y);

    //    return true;

    //}
    private Vector2Int LookupTileIndex(GameObject hitInfo)
    {
        for (int x = 0; x < TILE_COUNT_X; x++)
            for (int y = 0; y < TILE_COUNT_Y; y++)
                if (tiles[x, y] == hitInfo)
                    return new Vector2Int(x, y);
        return -Vector2Int.one; //Invalido


    }
    #endregion

}
