using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panorama : MonoBehaviour
{
    private UIManager UM;
    private GlobalCourutine GC;
    private bool ConvertOptionTeaTime;
    private int FrameSpeed;
    private Color red;
    private Color white;
    private void OnEnable()
    {
        InitValue();
        Debug.Log("MyVedio OnEnable");
        MovePanorama();
    }
    public void BackToMainHorizon()
    {
        MovePanorama();
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        //가로 모드에서 메인으로 나가는 버튼
    }
    public void ChangeModeToHorizon()
    {
        MovePanoramaHorizon();
        //가로로 바꾸는 버튼
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    public void ChangeModeToHorizonDownload()
    {
        MovePanoramaHorizonDown();
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    public void ChangeModeToVertical()
    {
        MovePanoramaVertical();
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
    }
    public void ChangeModeToVerticalDownload()
    {
        MovePanoramaVerticalDown();
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
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
    public void ConvertPanorama()
    {
        //파노라마를 만드는 내용
        MovePanoramaVerticalDown();
    }
    public void ConvertPanoramaHorizon()
    {
        //파노라마를 만드는 내용
        MovePanoramaHorizonDown();
    }
    public void CreatePanorama()
    {
        //파노라마 조건을 세팅하고 파노라마로 넘어가는 내용
        StartCoroutine(LoadPanorama());
    }
    public void DownloadPanorama()
    {
        StartCoroutine(DownloadPanorama_());
    }

    IEnumerator DownloadPanorama_()
    {
        PopUpConvert();
        yield return new WaitForSeconds(1f);
        GC.AddCourutine("home", "BackToVedio");
        MoveHome();
    }
    IEnumerator LoadPanorama()
    {
        
        yield return new WaitForSeconds(1f);
        MovePanoramaVertical();
        PopUp_vertical();
        
    }
    public void MovePanorama() => UM.PageMove(0);
    public void MovePanoramaVertical() => UM.PageMove(1);
    public void MovePanoramaHorizon() => UM.PageMove(2);
    public void MovePanoramaVerticalDown() => UM.PageMove(3);
    public void MovePanoramaHorizonDown() => UM.PageMove(4);
    public void MoveSnapShot() => UM.PageMove(5);
    public void MoveSnapShotVertical() => UM.PageMove(6);
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
        if (GC == null) GC = GlobalCourutine.Instance;
        if (UM == null) UM = UIManager.Instance;
        UM.ResetUIManager();
        ConvertOptionTeaTime = true;
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
