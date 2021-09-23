using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTest : MonoBehaviour //비디오 클립을 서버로부터 받아오고 실행하는 스크립트
{
    private ArrayList hall, viewCount, date, download;
    private List<GameObject> videos;
    public GameObject content, video;
    private Vector3 zero;

    void Start()
    {
        InitValue();
        GetDataFromServer();
        MakeVideo(0);
    }

    public void GetDataFromServer()
    {
        //서버로 부터 데이터를 받는 코드
        hall.Add("1번 홀");
        viewCount.Add("조회수" + 50);
        date.Add(2020 + "." + 11 + "." + 13);
        download.Add("다운로드" + 2020 + "." + 11 + "." + 31 + "까지");
    }

    public void MakeVideo(int videoNumber) //서버애서 제공받은 비디오 클립의 내용을 프리펩에 넣고 만드는 내용
    {
        GameObject temp;
        video.transform.GetChild(1).GetComponent<Text>().text = hall[videoNumber].ToString();
        video.transform.GetChild(2).GetComponent<Text>().text = viewCount[videoNumber].ToString();
        video.transform.GetChild(3).GetComponent<Text>().text = date[videoNumber].ToString();
        video.transform.GetChild(4).GetComponent<Text>().text = download[videoNumber].ToString();
        temp = GameObject.Instantiate(video, zero, Quaternion.identity);
        temp.transform.SetParent(content.transform);

    }

    public void InitValue()
    {
        hall = new ArrayList();
        viewCount = new ArrayList();
        date = new ArrayList();
        download = new ArrayList();
        videos = new List<GameObject>();
        zero = new Vector3(0, 0, 0);
    }
}
