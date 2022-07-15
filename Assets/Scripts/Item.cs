using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private string _name;

    private Vector3 _startingPosition;

    public bool UsePointerDisplacement = true;
    private bool dragging = false;
    private Vector3 pointerDisplacement = Vector3.zero;
    private float zDisplacement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {

            Vector3 mousePos = MouseInWorldCoords();
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }
    }


    private Vector3 MouseInWorldCoords()
    {
        var screenMousePos = Input.mousePosition;
        //Debug.Log(screenMousePos);
        screenMousePos.z = zDisplacement;
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        zDisplacement = -Camera.main.transform.position.z + transform.position.z;
        pointerDisplacement = -transform.position + MouseInWorldCoords();
    

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragging)
        {

            dragging = false;
            transform.position = _startingPosition;

        }
    }

    public void setStartingPosition(Vector3 pos)
    {
        _startingPosition = pos;
    }
}
