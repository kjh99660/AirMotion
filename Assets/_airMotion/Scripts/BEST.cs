using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BEST : MonoBehaviour
{
    private UIManager UM;
    private void OnEnable()
    {
        InitValue();
        Debug.Log("OnEnable");
        StartCoroutine(BestMore());
    }
    IEnumerator BestMore()
    {
        yield return new WaitForSeconds(1f);
        MoveMain();
    }
    public void MoveMain() => UM.PageMove(0);
    public void MoveDirectSearch() => UM.PageMove(1);
    public void MoveMyVedio() => SceneManager.LoadScene("myVedio");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");
    private void InitValue()
    {
        UM = UIManager.Instance;
        UM.ResetUIManager();
    }
}
