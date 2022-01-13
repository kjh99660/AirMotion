using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpDelete : MonoBehaviour
{
    private UIManager UM;
    private void Start()
    {
        UM = UIManager.Instance;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            UM.CancelPopUp(1);
        }
        
   
    }
}
