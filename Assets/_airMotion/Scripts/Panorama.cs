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




    //# PANORAMA_0 첫번째 화면
    public void ToggleFrameSlow()// 토글 느리게
    {
        if (UM.CurrentSelectedGameObject().GetComponent<Toggle>().isOn) FrameSpeed = 1;
    }
    public void ToggleFrameMiddle()// 토글 보통
    {
        if (UM.CurrentSelectedGameObject().GetComponent<Toggle>().isOn) FrameSpeed = 2;
    }
    public void ToggleFrameFast()// 토글 빠르게
    {
        if (UM.CurrentSelectedGameObject().GetComponent<Toggle>().isOn) FrameSpeed = 3;
    }
    public void BackToMainHorizon()//가로 모드에서 메인으로 나가는 버튼
    {
        MovePanorama();
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        
    }
    public void CreatePanorama()//동영상을 이미지로 만들기
    {
        PickImage(1920);
        //파노라마 조건을 세팅하고 파노라마로 넘어가는 내용
        StartCoroutine(LoadPanorama());
    }
    IEnumerator LoadPanorama()
    {

        yield return new WaitForSeconds(1f);
        MovePanoramaVertical();
        PopUp_vertical();

    }




    //#1 PANORAMA vertical
    public void ChangeModeToHorizon()//가로로 바꾸는 버튼
    {
        MovePanoramaHorizon();     
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }

    public void ConvertPanorama() //파노라마를 만드는 내용 - 변환하기
    {
        MovePanoramaVerticalDown();
    }

    public void MovePanorama() => UM.PageMove(0);//원래 페이지로 돌아가기




    //# PANORAMA horizontal
    public void ChangeModeToVertical()//가로에서 세로로 바꾸는 내용
    {
        MovePanoramaVertical();
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
    }
    public void ChangeModeToHorizonDownload()
    {
        MovePanoramaHorizonDown();
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
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
    
   
    public void MovePanoramaVerticalDown() => UM.PageMove(3);
    public void ConvertPanoramaHorizon()
    {
        //파노라마를 만드는 내용
        MovePanoramaHorizonDown();
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
    
    private void PickImage(int maxSize) //갤러리에서 이미지를 가저오기
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                // Assign texture to a temporary quad and destroy it after 5 seconds
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                quad.transform.forward = Camera.main.transform.forward;
                quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);

                Material material = quad.GetComponent<Renderer>().material;
                if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find("Legacy Shaders/Diffuse");

                material.mainTexture = texture;

                //Destroy(quad, 5f);

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
                //Destroy(texture, 5f);
            }
        });

        Debug.Log("Permission result: " + permission);
    }
    
    public void MovePanoramaVertical() => UM.PageMove(1);
    public void MovePanoramaHorizon() => UM.PageMove(2);
    
    public void MovePanoramaHorizonDown() => UM.PageMove(4);
    public void MoveSnapShot() => UM.PageMove(5);
    public void MoveSnapShotVertical() => UM.PageMove(6);
   
    private void PopUp_vertical() => UM.PopUp(0);
    private void PopUp_horizental() => UM.PopUp(1);
    private void PopUpConvert() => UM.PopUp(2);

    //단순 씬 이동
    public void MovePANORAMA() => SceneManager.LoadScene("PANORAMA");
    public void MoveHome() => SceneManager.LoadScene("home");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");

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
