using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private UIManager UM;
    void Start()
    {
        InitValue();
    }
    

    private void InitValue()
    {
        UM = UIManager.Instance;
        
    }
}
