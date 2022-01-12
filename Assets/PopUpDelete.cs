using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpDelete : MonoBehaviour
{
    UIManager UM;
    private void Start()
    {
        UM = UIManager.Instance;
    }
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == gameObject)
        {
            UM.CancelPopUp(1);
        }      
    }
}
