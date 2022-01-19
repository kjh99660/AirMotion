using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoFullScreen : MonoBehaviour
{
    private UIManager UM;
    private VideoPlayer video;
    public Button button;

    [Header("Video UI")]
    public GameObject UI;
    public Toggle play;
    public Toggle pause;
    public Button fullScreen;
    public Button detail;
    public Slider timeSlider;


    public void Init(VideoPlayer videoPlayer, float videoTime, float videolength)
    {
        UI.SetActive(false);
        video = videoPlayer;       
        UM = UIManager.Instance;
        timeSlider.maxValue = videolength;
        timeSlider.value = videoTime;
        Debug.Log(video.length + "  :  " + video.time);       
    }



    //#���� UI ����
    public void FullScreen()//��üȭ�� ��ư
    {
        Destroy(this.gameObject);
    }

    public void DetailButton()//������ ��ư
    {
        UM.PopUp(15);
    }

    public void OnPointerDrag()//���� �ڵ�� �ð� ����
    {
        video.Stop();
        video.time = timeSlider.value;
    }

    public void PlayButton()//���� ���� ��ư
    {
        if (video.isPlaying)
        {
            video.Pause();
            pause.isOn = true;
            play.isOn = false;
        }
        else
        {
            video.Play();
            pause.isOn = false;
            play.isOn = true;
        }
    }

    public void TouchVideo()//���� ���� �� ��� ���� �޼���
    {
        if (UI.activeSelf) UI.SetActive(false);
        else StartCoroutine(UITimeCount());
    }

    private IEnumerator UITimeCount()//UI�� �ڵ����� ����� �� �ֵ��� �ϴ� �ڷ�ƾ
    {
        int time = 0;
        bool already = false;
        UI.SetActive(true);
        while (UI.activeSelf)
        {
            yield return new WaitForSeconds(1f);
            time++;
            if (time > 7)
            {
                already = true;
                break;
            }
        }
        if (already) UI.SetActive(false);
    }

}