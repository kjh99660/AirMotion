using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoDetail : MonoBehaviour
{
    bool isSliderPause;
    private UIManager UM;
    public GameObject VideoPrefabs;
    public VideoPlayer video;
    public Button button;
    public GameObject videoFullScreen;
    private GameObject Content;

    [Header("Text")]
    public Text t_tag;
    public Text t_title;
    public Text t_date;
    public Text t_view;
    public Text t_like;

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

    public bool MakeVideos()//목록 비디오를 초기화
    {
        Content = GameObject.Find("Canvas").transform.GetChild(4).GetChild(4).GetChild(1).GetChild(0).gameObject;
        if (Content.transform.childCount != 0)
        {
            for (int i = 0; i < Content.transform.childCount; i++)
            {
                Destroy(Content.transform.GetChild(i).gameObject);
            }
        }

        var temp = NetworkManager.Instance.Video.data;
        if (temp.Length == 0) return false;

        for (int i = 0; i < temp.Length; i++)
        {
            var inf = temp[i];
            GameObject Video = Instantiate(VideoPrefabs);
            Video.GetComponent<VideoSomenail>().Init(inf.VideoOthers, inf.Time, inf.VideoKey, i);
            Video.transform.parent = Content.transform;
        }
        return true;
    }




    //#비디오 UI 관련
    public void FullScreen()//전체화면 버튼
    {
        GameObject temp = Instantiate(videoFullScreen, gameObject.transform.parent);
        temp.transform.position = transform.parent.position;
        temp.GetComponent<VideoFullScreen>().Init(video.url);
    }

    public void DetailButton()//더보기 버튼
    {
        UM.PopUp(15);
    }

    public void OnPointerDragEnd()//비디오 시간 조정 완료
    {
        print("OnPointerDrag");            
        video.time = timeSlider.value;
        video.Play();
        isSliderPause = false;
    }
    public void OnPointerDown()//비디오 핸들 눌렀을 때
    {
        print("OnPointerDrag");
        isSliderPause = true;
        video.Pause();
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
        if (video.isPlaying && isSliderPause == false)
        {
            print("ProgressBarSetting");
            timeSlider.value = (float)video.time;
        }
    }


    private void Update()
    {
        ProgressBarSetting();
    }
    void SliderPause()
    {

    }
}
