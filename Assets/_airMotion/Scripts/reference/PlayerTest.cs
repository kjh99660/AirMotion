using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTest : MonoBehaviour //���� Ŭ���� �����κ��� �޾ƿ��� �����ϴ� ��ũ��Ʈ
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
        //������ ���� �����͸� �޴� �ڵ�
        hall.Add("1�� Ȧ");
        viewCount.Add("��ȸ��" + 50);
        date.Add(2020 + "." + 11 + "." + 13);
        download.Add("�ٿ�ε�" + 2020 + "." + 11 + "." + 31 + "����");
    }

    public void MakeVideo(int videoNumber) //�����ּ� �������� ���� Ŭ���� ������ �����鿡 �ְ� ����� ����
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
