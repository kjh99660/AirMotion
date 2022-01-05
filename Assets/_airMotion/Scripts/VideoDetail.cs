using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoDetail : MonoBehaviour
{
    public GameObject VideoPrefabs;  
    public VideoPlayer video;
    public Button button;
    private bool isPlaying;
    private GameObject Content;

    [Header("Text")]
    public Text t_tag;
    public Text t_title;
    public Text t_date;
    public Text t_view;
    public Text t_like;

    public void Init(string url)
    {
        video.url = url;
        isPlaying = false;
    }
    
    public void TouchVideo()//비디오 정지 및 재생 관련 메서드
    {
        if(isPlaying)
        {
            video.Pause();
            isPlaying = false;
        }
        else
        {
            video.Play();
            isPlaying = true;
        }
    }
    public bool MakeVideos()//목록 비디오를 초기화
    {
        Content = GameObject.Find("Canvas").transform.GetChild(4).GetChild(4).GetChild(1).GetChild(0).gameObject;
        if (Content.transform.childCount != 0)
        {
            for(int i = 0; i< Content.transform.childCount; i++)
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
}
