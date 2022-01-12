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
    public int pos;
    public RawImage[] fraction;
    public RawImage[] fractionHorizon;

    [Header("Player Slider")]
    public Slider slider;
    public Slider sliderVertical;
    private bool ImageLoaded;
    private bool ConvertOptionHorizon;
    private float FrameSpeed;
    private Color red;
    private Color white;
    private OutputArray dst;

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
        StartCoroutine(LoadPanorama(ConvertOptionHorizon, FrameSpeed));
    }

    IEnumerator LoadPanorama(bool option, float frame)
    {
        PickVideo(1920);
        PanoramaVideo.Prepare();
        while (!PanoramaVideo.isPrepared) yield return null;
        PanoramaVideo.time = 0;
        slider.maxValue = (float)PanoramaVideo.length;
        sliderVertical.maxValue = (float)PanoramaVideo.length;

        yield return new WaitForSeconds(1f);

        if(ImageLoaded && option)
        {
            MovePanoramaVertical();
            PopUp_vertical();
        }
        if(ImageLoaded && !option)
        {
            MovePanoramaHorizon();
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
    }

    public void SetVideoPos() //���� �ð��� �����ϴ� UI
    {
        PanoramaVideo.time = slider.value;
        if(!ConvertOptionHorizon)PanoramaVideo.time = sliderVertical.value;

        PanoramaVideo.Play();
        PanoramaVideo.Pause();
    }

    public IEnumerator MakePanorama(float startTime)//�̹��� ĸ�� �� ���� ������ �̹����� �ĳ�� �����
    {
        PopUpConvert();

        double time = startTime;
        time -= 4 * FrameSpeed;
        if (time < 0) time = 0;

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
            if(ConvertOptionHorizon)
            {
                RenderTexture newRenderTexure = new RenderTexture(3240, Image.texture.height, 0);
                Graphics.Blit(Image.texture, newRenderTexure);

                Texture2D texture2D = new Texture2D(1080, Image.texture.height, TextureFormat.RGB24, false);


                texture2D.ReadPixels(new UnityEngine.Rect(1080 + pos, 0, 2160 + pos, Image.texture.height), 0, 0);//���⸦ �����ϸ� �̹����� ������ ����� �ٲ� �� ����
                texture2D.Apply();

                byte[] texurePNG = texture2D.EncodeToPNG();
                string path = Application.persistentDataPath + "/" + i + "Panorama.png";
                File.WriteAllBytes(path, texurePNG);
                DestroyImmediate(texture2D);
            }
            else
            {
                RenderTexture newRenderTexure = new RenderTexture(Image.texture.width, Image.texture.height, 0);
                Graphics.Blit(Image.texture, newRenderTexure);

                Texture2D texture2D = new Texture2D(Image.texture.width, Image.texture.height, TextureFormat.RGB24, false);

                texture2D.ReadPixels(new UnityEngine.Rect(0, 0, Image.texture.width, Image.texture.height), 0, 0);
                texture2D.Apply();

                byte[] texurePNG = texture2D.EncodeToPNG();
                string path = Application.persistentDataPath + "/" + i + "Panorama.png";
                File.WriteAllBytes(path, texurePNG);
                DestroyImmediate(texture2D);
            }
            

            
        }

        for (int i = 0; i < 6; i++)//�̹��� �����
        {
            Texture2D texture = new Texture2D(0, 0);
            string path = Application.persistentDataPath + "/" + i + "Panorama.png";

            byte[] byteTexture = File.ReadAllBytes(path);
            if (byteTexture.Length > 0)
            {
                texture.LoadImage(byteTexture);
            }        
            if (ConvertOptionHorizon) fraction[i].texture = texture;
            else fractionHorizon[i].texture = texture;

            
        }

        UM.CancelPopUp(2);
        if (!ConvertOptionHorizon) MovePanoramaHorizonDown();
        else MovePanoramaVerticalDown();
    }

    public void MovePanorama() => UM.PageMove(0);//���� �������� ���ư���





    //# PANORAMA horizontal
    public void ConvertPanoramaHorizon() //�ĳ�󸶸� ����� ���� - ��ȯ�ϱ�
    {      
        StartCoroutine(MakePanorama(slider.value));     
    }
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
        GameObject Button = GameObject.Find("btn_horizontal");
        if (Button.GetComponent<Toggle>().isOn)
        {
            ConvertOptionHorizon = true;
        }
        else ConvertOptionHorizon = false;      
    }
    
    public void MovePanoramaVerticalDown() => UM.PageMove(3);
   
    public void DownloadPanorama()
    {
        StartCoroutine(DownloadPanorama_());
    }

    IEnumerator DownloadPanorama_()
    {
        StartCoroutine(SaveScreen());        
        yield return new WaitForSeconds(1f);
        GC.AddCourutine("home", "BackToVedio");
        MoveHome();
    }

    private IEnumerator SaveScreen()
    {
        yield return new WaitForEndOfFrame();
        if(ConvertOptionHorizon)
        {
            Texture2D texture = new Texture2D(Screen.width, 360);
            texture.ReadPixels(new UnityEngine.Rect(0, 780, Screen.width, 360), 0, 0);
            texture.Apply();
            byte[] bytes = texture.EncodeToJPG();
            File.WriteAllBytes(Application.persistentDataPath + "/" + "FinalPanorama.png", bytes);
            DestroyImmediate(texture);
        }
        else
        {
            Texture2D texture = new Texture2D(424, 1440);
            texture.ReadPixels(new UnityEngine.Rect(328, 323, 424, 1440), 0, 0);
            texture.Apply();
            byte[] bytes = texture.EncodeToJPG();
            File.WriteAllBytes(Application.persistentDataPath + "/" + "FinalPanorama.png", bytes);
            DestroyImmediate(texture);
        }
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
        ConvertOptionHorizon = true;       
        FrameSpeed = 1.0f;
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
