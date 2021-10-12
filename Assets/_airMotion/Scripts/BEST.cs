using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BEST : MonoBehaviour
{
    private UIManager UM;
    private GlobalCourutine GC;
    private bool HasVedio, HasVedioBest;
    private int BeforePage;

    private void OnEnable()
    {
        InitValue();
        Debug.Log("OnEnable");
        StartCoroutine(BestMore());
    }
    public void GiveLike()
    {
        //���ƿ� ������ ��
    }
    /// <summary>
    /// //////
    /// </summary>
    public void ButtonMontlyBest()
    {
        if (HasVedioBest) MoveMainHasVedio();
        else MoveMain();
    }
    public void ButtonMyVedio()
    {
        //������� �������� ���� ����
    }
    public void ButtonAll()
    {
        if (HasVedio) MoveMainAll();
        else MoveMain();
    }
    public void ClickSearchVedio()
    {
        UM.ChildActiveOnOff();
    }
    public void ClickDirecctSearch()//�����˻� ���� �˻� Ȯ�� ��ư
    {
        if (GC == null) GC = GlobalCourutine.Instance;
        GC.AddCourutine("home", "DirectSearch");
        MoveHome();
    }
    public void AutoSearch()
    {
        if (GC == null) GC = GlobalCourutine.Instance;
        GC.AddCourutine("home", "CheckNewVedio");
        MoveHome();
    }
    IEnumerator BestMore()
    {
        yield return new WaitForSeconds(1f);
        if (HasVedioBest)
        {
            MoveMainHasVedio();
        }
        else MoveMain();
    }
    public void ClickVedio()
    {
        //Ŭ���� ������ ������ �����ϴ� ����
        MoveDetail();
    }

    public void Popup_premium() => UM.PopUp(0);
    public void Popup_bestVedio() => UM.PopUp(1);
    public void Popup_chooseMonth() => UM.PopUp(2);
    public void Popup_deleteComment() => UM.PopUp(3);
    public void Popup_reportComment() => UM.PopUp(4);
    public void DetailBack()
    {
        UM.PageMove(BeforePage);
    }
    public void MoveMain()
    {
        BeforePage = 0;
        UM.PageMove(0);
    }
    public void MoveMainHasVedio()
    {
        BeforePage = 1;
        UM.PageMove(1);
    }
    public void MoveDetail()
    {
        UM.PageMove(2);
    }
    public void MoveMainAll()
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
    }
}
