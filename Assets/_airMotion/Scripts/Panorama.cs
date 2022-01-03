using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using OpenCvSharp;
using System.IO;

public class Panorama : MonoBehaviour
{
    private UIManager UM;
    private GlobalCourutine GC;

    [Header ("Convert Values")]
    public VideoPlayer PanoramaVideo;
    public RawImage Image;

    [Header("Player Slider")]
    public Slider slider;
    private bool ImageLoaded;
    private bool ConvertOptionTeaTime;
    private float FrameSpeed;
    private Color red;
    private Color white;

    private void OnEnable()
    {
        InitValue();
        Debug.Log("MyVedio OnEnable");
        MovePanorama();
    }




    //# PANORAMA_0 ù��° ȭ��
    public void ToggleFrameSlow()// ��� ������
    {
        FrameSpeed = 1.0f;
    }

    public void ToggleFrameMiddle()// ��� ����
    {
        FrameSpeed = 0.6f;
    }

    public void ToggleFrameFast()// ��� ������
    {
        FrameSpeed = 0.3f;
    }

    public void BackToMainHorizon()//���� ��忡�� �������� ������ ��ư
    {
        MovePanorama();
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        
    }

    public void CreatePanorama()//�������� �̹����� �����
    {                
        StartCoroutine(LoadPanorama(ConvertOptionTeaTime, FrameSpeed));
    }

    IEnumerator LoadPanorama(bool option, float frame)
    {
        PickVideo(1920);
        PanoramaVideo.Prepare();
        while (!PanoramaVideo.isPrepared) yield return null;
        PanoramaVideo.time = 0;
        slider.maxValue = (float)PanoramaVideo.length;
        
        yield return new WaitForSeconds(1f);

        if(ImageLoaded)
        {
            MovePanoramaVertical();
            PopUp_vertical();
        }
    }




    //#1 PANORAMA vertical
    public void ChangeModeToHorizon()//���η� �ٲٴ� ��ư
    {
        MovePanoramaHorizon();     
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }

    public void ConvertPanorama() //�ĳ�󸶸� ����� ���� - ��ȯ�ϱ�
    {
        StartCoroutine(MakePanorama(slider.value));
        MovePanoramaVerticalDown();
    }

    public void SetVideoPos() //���� �ð��� �����ϴ� UI
    {
        PanoramaVideo.time = slider.value;
        PanoramaVideo.Play();
        PanoramaVideo.Pause();
    }

    public IEnumerator MakePanorama(float startTime)
    {
        double time = startTime;
        PanoramaVideo.Prepare();
        while (!PanoramaVideo.isPrepared)
        {
            yield return null;
        }
        for (int i = 0; i < 6; i++)//�̹��� ĸ��
        {
            if (i != 0) time += FrameSpeed;
            PanoramaVideo.time = time;
            PanoramaVideo.Play();
            yield return new WaitUntil(() => Math.Abs(PanoramaVideo.time - time) < (FrameSpeed / 2));
            PanoramaVideo.Pause();

            RenderTexture newRenderTexure = new RenderTexture(Image.texture.width, Image.texture.height, 0);
            Graphics.Blit(Image.texture, newRenderTexure);

            Texture2D texture2D = new Texture2D(Image.texture.width, Image.texture.height, TextureFormat.RGB24, false);
            texture2D.ReadPixels(new UnityEngine.Rect(0, 0, Image.texture.width, Image.texture.height), 0, 0);
            texture2D.Apply();
            byte[] texurePNG = texture2D.EncodeToPNG();
            string path = Application.persistentDataPath + "/" + i + "Panorama.png";
            File.WriteAllBytes(path, texurePNG);

            Debug.Log("time: " + time + " FrameSpeed: " + FrameSpeed);
        }

        Mat[] mat = new Mat[6];
        for (int i = 0; i < 6; i++)
        {
            Cv2.ImRead(Application.persistentDataPath + "/" + i + "Panorama.png", ImreadModes.Unchanged);
        }
        //Cv2.HConcat(mat, dst);
    }

    public void MovePanorama() => UM.PageMove(0);//���� �������� ���ư���





    //# PANORAMA horizontal
    public void ChangeModeToVertical()//���ο��� ���η� �ٲٴ� ����
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
        //�ĳ�󸶸� ����� ����
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
    
    private void PickVideo(int maxSize) //���������� ������ ��������
    {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
        {
            Debug.Log("Video path: " + path);
            if (path != null)
            {
                // Play the selected video
                PanoramaVideo.url = "file://" + path;
                ImageLoaded = true;
            }
            else
            {
                ImageLoaded = false;
                return;
            }
        }, "Select a video");

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

    //�ܼ� �� �̵�
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
        FrameSpeed = 1.0f;
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
