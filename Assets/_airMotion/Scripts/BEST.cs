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
    IEnumerator BestMore()//best �ε� �ڷ�ƾ
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
    public void ButtonMyVedio()//������� �������� ���� ����
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
        if (HasVedio) MoveMainAll();
        else MoveMain();
    }

    public void ClickDirecctSearch()//�����˻� ���� �˻� Ȯ�� ��ư
    {
        if (GC == null) GC = GlobalCourutine.Instance;
        GC.AddCourutine("home", "DirectSearch");
        MoveHome();
    }

    public void AutoSearch()//�ڵ� �˻�
    {
        if (GC == null) GC = GlobalCourutine.Instance;
        GC.AddCourutine("home", "CheckNewVedio");
        MoveHome();
    }

    public void ClickSearchVedio()// ���� �˻� ��ư
    {
        UM.ChildActiveOnOff();
    }




    // #Best vedio Detail_2
    public void GiveLike()//���ƿ� ������ ��
    {
        
    }
   
    public void ClickVedio()//Ŭ���� ������ ������ �����ϴ� ����
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
   
    public void MoveMain()//���� ���� ����� ���� ���
    {
        BeforePage = 0;
        UM.PageMove(0);
    }
    public void MoveMainHasVedio()//���� ���� ����� ���� ���
    {
        BeforePage = 1;
        UM.PageMove(1);
    }
    
    public void MoveMainAll()//������ ������� ����
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
