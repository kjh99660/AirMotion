using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panorama : MonoBehaviour
{
    private bool ConvertOptionTeaTime;
    private int FrameSpeed;
    private UIManager UM;
    private Color red;
    private Color white;
    private void OnEnable()
    {
        InitValue();
        Debug.Log("MyVedio OnEnable");
        StartCoroutine(LoadPanorama());
    }

    public void ToggleConvertOptions()
    {
        GameObject Button = UM.CurrentSelectedGameObject();
        if (Button.GetComponent<Toggle>().isOn)
        {
            ConvertOptionTeaTime = true;
        }
        else ConvertOptionTeaTime = false;      
    }
    public void ToggleFrameSlow()
    {
        if(UM.CurrentSelectedGameObject().GetComponent<Toggle>().isOn)FrameSpeed = 1;
    }
    public void ToggleFrameMiddle()
    {
        if (UM.CurrentSelectedGameObject().GetComponent<Toggle>().isOn) FrameSpeed = 2;
    }
    public void ToggleFrameFast()
    {
        if (UM.CurrentSelectedGameObject().GetComponent<Toggle>().isOn) FrameSpeed = 3;
    }
    public void CreatePanorama()
    {
        //파노라마를 만드는 내용
        StartCoroutine(LoadPanorama());
    }
    // Update is called once per frame
    IEnumerator LoadPanorama()
    {
        yield return new WaitForSeconds(1f);
        MovePanoramaVertical();
        
    }
    private void MovePanorama() => UM.PageMove(0);
    private void MovePanoramaVertical() => UM.PageMove(1);
    private void MovePanoramaHorizon() => UM.PageMove(2);
    private void MovePanoramaVerticalDown() => UM.PageMove(3);
    private void MovePanoramaHorizonDown() => UM.PageMove(4);
    private void MoveSnapShot() => UM.PageMove(5);
    private void MoveSnapShotVertical() => UM.PageMove(6);
    public void MovePANORAMA() => SceneManager.LoadScene("PANORAMA");
    public void MoveHome() => SceneManager.LoadScene("home");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");
    private void PopUp_vertical() => UM.PopUp(0);
    private void PopUp_horizental() => UM.PopUp(1);
    private void PopUpConvert() => UM.PopUp(2);

    private void InitValue()
    {
        if (UM == null) UM = UIManager.Instance;
        UM.ResetUIManager();
        ConvertOptionTeaTime = true;
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
