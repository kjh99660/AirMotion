using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectImage : MonoBehaviour
{
    private Vector2 startPos;
    public RawImage rawImage;
    //1130 - 800 = 330
    //365 365 = 730
    //906 max
    //127 min
    //906 - 127 = 780/2
    //360

    private void Start()
    {
        startPos = transform.position;       
    }

    public void OnDrag(BaseEventData data)
    {

        PointerEventData pointer_data = (PointerEventData)data;
        Vector2 temp = pointer_data.position - startPos;

        Debug.Log(gameObject.transform.position.x);

        if (gameObject.transform.position.x > 900f && temp.x > 0) temp.x = 0;
        if (gameObject.transform.position.x < 180f && temp.x < 0) temp.x = 0;

        gameObject.transform.position += new Vector3(temp.x/10f, 0, 0);
        startPos = transform.position;
    }

    public void EndDrag(BaseEventData data)
    {
        rawImage.uvRect = new Rect(0.33f + ((gameObject.transform.position.x - 540f) / 360f * 0.33f), 0, 0.33f, 1);
    }

    

}
