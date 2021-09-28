using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEST : MonoBehaviour
{
    private UIManager UM;
    private void Start()
    {
        InitValue();
        Debug.Log("start");
    }

    public void MoveDirectSearch() => UM.PageMove(1);
    private void InitValue()
    {
        UM = UIManager.Instance;
        UM.ResetUIManager();
    }
}
