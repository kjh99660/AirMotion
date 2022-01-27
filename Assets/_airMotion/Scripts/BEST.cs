using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BEST : MonoBehaviour
{
    [Header ("TOP UI")]
    public Text[] txt_front;

    private UIManager UM;
    private GlobalCourutine GC;
    private bool HasVedio, HasVedioBest;
    private int BeforePage;
    private bool DownVideo;
    public GameObject Content;
    private RectTransform videoRect;
    public List<string> videoValue;
    public GameObject VideoPrefabs;
    public int nowDisplayingVideo; //현재 화면에 있는 비디오의 수
    public string urlNowUse;

    private void OnEnable()
    {
        InitValue();
        Debug.Log("OnEnable");
        StartCoroutine(BestMore());
    }
    IEnumerator BestMore()//best 로딩 코루틴
    {
        //need to more
        yield return new WaitForSeconds(1f);
        if (HasVedioBest)
        {
            MoveMainHasVedio();
        }
        else MoveMain();
    }


    //#Best_main_0 and Best_main_1 and Best_main_3
    public void ButtonMyVedio()//내영상들 모음으로 가는 내용
    {
        MoveHome();
    }

    public void ButtonMontlyBest()
    {
        if (HasVedioBest) MoveMainHasVedio();
        else MoveMain();
    }

    public void ButtonAll()
    {
        if (HasVedio)
        {
            MoveMainAll();
            StartCoroutine(CheckNewVedio());
        }
        else MoveMain();
    }

    public void ClickDirecctSearch()//수동검색 영상 검색 확인 버튼
    {
        if (GC == null) GC = GlobalCourutine.Instance;
        GC.AddCourutine("home", "DirectSearch");
        MoveHome();
    }

    public void AutoSearch()//자동 검색
    {
        if (GC == null) GC = GlobalCourutine.Instance;
        GC.AddCourutine("home", "CheckNewVedio");
        MoveHome();
    }

    public void ClickSearchVedio()// 영상 검색 버튼
    {
        UM.ChildActiveOnOff();
    }
    IEnumerator CheckNewVedio()//영상을 검색하는 내용 만약 영상이 이미 있으면 3번 페이지로 이동
    {
        NetworkManager.Instance.GetVedioData("20211210", "20211220", "3");//영상불러오는 시작날짜,끝나는날짜,ID

        yield return new WaitUntil(() => NetworkManager.Instance.isLoaded == true);
        yield return new WaitForSeconds(1f);
        if (MakeVideos()) HasVedio = true;
        else HasVedio = false;

        //MoveHomeOrMain();
        PopUp_search();

        yield return new WaitUntil(() => UM.CheckPopUp());

        //loading animation
        //if (!HasVedio) PopUp_noVedio();
        //if (newVedio) PopUp_vediolist();
        //if (gameObject.transform.Find("GlobalCourutine") != null) GC.CheckCourutine();

        yield return new WaitForSeconds(1f);
        DownVideo = false;
    }
    private void GetVideo()//아래로 스크롤 해서 동영상 더 가져오기
    {
        Debug.Log(DownVideo);
        Debug.Log(videoRect.sizeDelta.y + 250);
        Debug.Log(videoRect.anchoredPosition.y);
        if (DownVideo) return;
        if (Content.transform.childCount < 2) return;
        if (videoRect.sizeDelta.y + 250 < videoRect.anchoredPosition.y)
        {
            StartCoroutine(CheckNewVedio());

            Debug.Log("get Video");
            DownVideo = true;
        }
    }

    public bool MakeVideos()//비디오를 초기화
    {
        var temp = NetworkManager.Instance.Video.data;
        if (temp.Length == 0) return false;
        for (int i = 0; i < temp.Length; i++)
        {
            bool duplicate = false;
            var inf = temp[i];
            for (int j = 0; j < videoValue.Count; j++)
            {
                if (videoValue.Contains(inf.VideoOthers))
                {
                    duplicate = true;
                    break;
                }
            }
            if (duplicate) continue;
            for (int k = 0; k < 5; k++)
            {
                GameObject Video = Instantiate(VideoPrefabs);
                Video.GetComponent<VideoBest>().Init(inf.VideoOthers, inf.Time, inf.VideoKey, i);
                Video.transform.SetParent(Content.transform);
                videoValue.Add(inf.VideoOthers);
                nowDisplayingVideo++;
            }
        }
        return true;
    }
    //public void MoveHomeOrMain()
    //{
    //    Debug.Log("HasVedio:" + HasVedio);
    //    if (HasVedio) MoveMain();
    //    else MoveHome();
    //}


    // #Best vedio Detail_2
    public void GiveLike()//좋아요 눌렀을 때
    {

    }

    public void ClickVedio()//클릭한 비디오의 정보를 설정하는 내용
    {
        MoveDetail();
    }

    public void MoveDetail()
    {
        UM.PageMove(2);
    }
    public void DetailBack()
    {
        UM.PageMove(BeforePage);
    }


    // #PopUp
    public void Popup_premium() => UM.PopUp(0);
    public void Popup_bestVedio() => UM.PopUp(1);
    public void Popup_chooseMonth() => UM.PopUp(2);
    public void Popup_deleteComment() => UM.PopUp(3);
    public void Popup_reportComment() => UM.PopUp(4);
    private void PopUp_search() => UM.PopUp(5);
    public void MoveMain()//현재 비디오 목록이 없을 경우
    {
        BeforePage = 0;
        UM.PageMove(0);
    }
    public void MoveMainHasVedio()//현재 비디오 목록이 있을 경우
    {
        BeforePage = 1;
        UM.PageMove(1);
    }

    public void MoveMainAll()//내영상 목록으로 가기
    {
        BeforePage = 3;
        UM.PageMove(3);
    }
    public void MoveHome() => SceneManager.LoadScene("home");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");
    public void MovePanorama() => SceneManager.LoadScene("Panorama");
    private void InitValue()
    {
        UM = UIManager.Instance;
        GC = GlobalCourutine.Instance;
        BeforePage = 0;
        HasVedioBest = false; HasVedio = true;
        UM.ResetUIManager();
        for (int i = 0; i < txt_front.Length; i++)
        {            
            txt_front[i].text = "#" + System.DateTime.Now.Month.ToString() + "월 베스트";
        }
        videoRect = Content.GetComponent<RectTransform>();

    }
    private void Update()
    {
        GetVideo();
    }
}
