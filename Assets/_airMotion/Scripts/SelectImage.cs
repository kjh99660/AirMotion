using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectImage : MonoBehaviour
{
    private Vector2 startPos;
    public GameObject left;

    private void Start()
    {
        startPos = transform.position;       
    }

    public void OnDrag(BaseEventData data)
    {

        PointerEventData pointer_data = (PointerEventData)data;
        Vector2 temp = pointer_data.position - startPos;

        if (Input.mousePosition.x > 900f && temp.x > 0)
        {
            gameObject.transform.position = new Vector2(900f, startPos.y);
            startPos = transform.position;
            return;
        }
        else if (Input.mousePosition.x < 180f && temp.x < 0)
        {
            gameObject.transform.position = new Vector2(180f, startPos.y);
            startPos = transform.position;
            return;
        }
        gameObject.transform.position = new Vector2(Input.mousePosition.x, gameObject.transform.position.y);
        
    }

    public void EndDrag(BaseEventData data)
    {
        //360 >> 2160~3240
        //-360 >> 0~1080
        GameObject.Find("PanoramaManager").GetComponent<Panorama>().pos = (int)left.transform.position.x * 3;
    }



}
