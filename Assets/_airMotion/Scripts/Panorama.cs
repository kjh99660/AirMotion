using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Panorama : MonoBehaviour
{
    private UIManager UM;
    private Color red;
    private Color white;
    private void OnEnable()
    {
        InitValue();
        Debug.Log("MyVedio OnEnable");
        StartCoroutine(LoadMyVedio());
    }
    public void ToggleTopButtons()
    {
        GameObject Button = EventSystem.current.currentSelectedGameObject.gameObject;
        /*
        foreach (GameObject _ in TopButtons)
        {
            UM.ChangeImage(whiteButton_top, _);
            _.transform.GetChild(0).GetComponent<Text>().color = red;
        }
        UM.ChangeImage(redButton_top, Button);
        Button.transform.GetChild(0).GetComponent<Text>().color = white;
        */
    }

    // Update is called once per frame
    IEnumerator LoadMyVedio()
    {
        yield return new WaitForSeconds(1f);
        MoveMain();
    }
    public void MoveMain() => UM.PageMove(0);
    public void MoveMyVedio() => SceneManager.LoadScene("myVedio");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");

    private void InitValue()
    {
        if (UM == null) UM = UIManager.Instance;
        UM.ResetUIManager();
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
