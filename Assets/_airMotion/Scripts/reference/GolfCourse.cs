using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GolfCourse : MonoBehaviour
{
    private UIManager UM;
    private Color red;
    private Color white;
    private void OnEnable()
    {
        InitValue();
        Debug.Log("GolfCourse OnEnable");
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
    void Update()
    {
        
    }
    public void MoveMyVedio() => SceneManager.LoadScene("myVedio");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");

    private void InitValue()
    {
        if (UM == null) UM = UIManager.Instance;
        UM.ResetUIManager();
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
