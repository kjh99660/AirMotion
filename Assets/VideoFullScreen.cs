using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoFullScreen : MonoBehaviour
{
    private UIManager UM;
    public GameObject VideoPrefabs;
    public VideoPlayer video;
    public Button button;
    private GameObject Content;

    [Header("Video UI")]
    public GameObject UI;
    public Toggle play;
    public Toggle pause;
    public Button fullScreen;
    public Button detail;
    public Slider timeSlider;


    public void Init(string url)
    {
        UI.SetActive(false);
        video.url = url;
        video.Prepare();
        StartCoroutine(SetVideoInf());
        UM = UIManager.Instance;
    }

    private IEnumerator SetVideoInf()//비디오 정보 초기화
    {
        while (!video.isPrepared)
        {
            yield return null;
        }
        timeSlider.maxValue = (float)video.length;
    }




    //#비디오 UI 관련
    public void FullScreen()//전체화면 버튼
    {
        Destroy(this.gameObject);
    }

    public void DetailButton()//더보기 버튼
    {
        UM.PopUp(15);
    }

    public void OnPointerDrag()//비디오 핸들로 시간 조정
    {
        video.Stop();
        video.time = timeSlider.value;
    }

    public void PlayButton()//시작 정지 버튼
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

    public void TouchVideo()//비디오 정지 및 재생 관련 메서드
    {
        if (UI.activeSelf) UI.SetActive(false);
        else StartCoroutine(UITimeCount());
    }

    private IEnumerator UITimeCount()//UI가 자동으로 사라질 수 있도록 하는 코루틴
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

    private void ProgressBarSetting()//동영상 시간 진행
    {
        if (video.isPlaying)
        {
            timeSlider.value = (float)video.time;
        }
    }


    private void Update()
    {
        ProgressBarSetting();
    }
}
