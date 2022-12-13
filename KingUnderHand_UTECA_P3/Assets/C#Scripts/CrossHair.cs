using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public GameObject crosshair;
    private Vector3 target;
    void Start()
    {
        Cursor.visible = false; //Desactiva el cursor
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
        //Calcular tamaño de la pantalla y spawnea prefab en el lado izquierdo de la pantalla.
    }
}