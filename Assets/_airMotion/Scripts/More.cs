using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class More : MonoBehaviour
{
    public GameObject[] Toggle;
    public GameObject NoticeContent;
    public GameObject PasswordConfirm;
    public Sprite[] ConfirmSprite; //빨강 스프라이트 찾아야함
    [Space(16)]
    public GameObject[] Toggle_height;
    public GameObject[] PasswordChange;
    [Header("Profile")]
    public GameObject profileImage;//프로파일 이미지 나중에 데이터에서 한꺼번에 가져와야함
    private UIManager UM;
    private GlobalCourutine GC;

    private Color red;
    private Color white;

    private bool PushAlram, IsPremium, IsPaied;

    private bool unit;
    private float? height, heightFT;
    private bool canChangePassword;
    private void OnEnable()
    {
        InitValue();
        Debug.Log("More OnEnable");
        StartCoroutine(LoadMore());
    }

    IEnumerator LoadMore()//더보기 페이지 로딩 코루틴
    {
        yield return new WaitForSeconds(1f);
        MoveMain();
    }
   

    //# More 1 and More 0
    public void ClickNotice() //공지사항
    {
        MoveNotice();
    }

    public void ClickPay() //결제 관리
    {
        if (IsPaied) MovePaied();
        else MoveNotPaied();
    }

    public void ToggleButton()//알림 토글
    {
        foreach (GameObject gameObject in Toggle)
        {
            if (gameObject.activeSelf) gameObject.SetActive(false);
            else gameObject.SetActive(true);
            PushAlram = !PushAlram;
        }
    }

    public void ClickSearchVedio()//영상매칭 버튼
    {
        UM.ChildActiveOnOff();
    }

    public void ClickDirecctSearch()//수동검색 영상 검색 확인 버튼
    {

        GC.AddCourutine("home", "DirectSearch");
        MoveHome();
    }

    public void AutoSearch()//자동 검색
    {
        GC.AddCourutine("home", "CheckNewVedio");
        MoveHome();
    }

    public void ClickProfile()//프로필 누르기
    {
        //개인 정보 받아와서 넣기
        MoveProfile();
    }

    public void ClickNoticeDetail() //공지
    {
        //공지의 내용을 받는 내용
        MoveNoticeDetail();
    }



    //# More_profile_2
    public void OpenGallery()//프로필 사진 불러오기
    {
        Texture2D texture = null;//이미지
        Rect rect;

        //카메라 갤러리 호출
        //이미지 경로 가져오기
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                texture = NativeGallery.LoadImageAtPath(path, 1920);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
            }
            // 텍스쳐에 등록하기
            if (System.IO.File.Exists(path))
            {
                byte[] byteTexture = System.IO.File.ReadAllBytes(path);
                if (byteTexture.Length > 0)
                {
                    texture.LoadImage(byteTexture);
                }
            }
        });
        rect = new Rect(0, 0, texture.width, texture.height);
        profileImage.GetComponent<Image>().sprite = Sprite.Create(texture, rect, new Vector2(0f, 0f));
    }

    public void Profile_ClickResign() //계정 삭제하기
    {
        if (IsPremium) PopUp_NoSubscribe();
        else PopUp_membership();
    }

    public void Profile_ChangePassword() //비밀번호 변경
    {
        MovePassword();
    }

    public void Profile_Logout() //로그 아웃
    {
        //로그 아웃
    }

    public void Profile_Phone()//핸드폰 번호 변경 페이지로 이동
    {
        MovePhone();
    }

    public void Profile_back()//메인으로 돌아가기
    {
        //저장하기
        MoveFirstpage();
    }

    public void Profile_height(InputField text)//프로필 키 토글 버튼
    {
        Toggleheight();
        ChangeHeight(text);
    }

    public void Toggleheight()//프로필 키 토글 버튼_
    {
        foreach (GameObject _ in Toggle_height)
        {
            if (_.activeSelf) _.SetActive(false);
            else _.SetActive(true);
            Debug.Log(_.name + " :" + _.activeSelf);
        }
    }




    //# More_phone_3 and More_phone_4
    public void CheckIsPhoneNumber(Text text)//버튼 빨간색으로 바꾸기
    {
        if (UM.IsValidPhone(text.text))
        {
            //버튼 빨간색으로 바꾸기
        }       
    }

    public void ClickConfirmPhoneNumber()//인증 번호 보내는 내용
    {
        //인증 번호 보내는 내용
        MovePhone_2();
    }




    //# More_password_5 
    public void CheckPasswrod()
    {
        foreach (GameObject _ in PasswordChange)
        {
            if (!UM.IsValidPassword(_.GetComponent<InputField>().text))
            {
                canChangePassword = false;
                Debug.Log("IS not Valid");
                return;
            }           
        }
        if (PasswordChange[1].GetComponent<InputField>().text == PasswordChange[2].GetComponent<InputField>().text) canChangePassword = true;
        else canChangePassword = false;
        Debug.Log(canChangePassword);
    }
    public void ClickConfirmPasswordChange()
    {
        //모두 알맞게 입력되었는지 처리하는 내용
        //바뀐 비밀번호를 처리하는 내용
        ClickProfile();
    }





    //Not use _ 일단은 사용 안함
    public void ClickFAQButton()
    {
        GameObject Button = UM.CurrentSelectedGameObject().transform.parent.gameObject;
        Transform Notice = NoticeContent.transform;

        for (int i = 0; i< Notice.childCount;i++)
        {
            if (Notice.GetChild(i).gameObject == Button)
            {
                if (i != Notice.childCount - 1 && Notice.GetChild(i+1).gameObject.tag == "FAQ")
                {
                    if (Notice.GetChild(i + 1).gameObject.activeSelf) Notice.GetChild(i + 1).gameObject.SetActive(false);
                    else Notice.GetChild(i + 1).gameObject.SetActive(true);
                }               
            }
        }
    }
    public void ClickFAQ()
    {
        MoveFAQ();
    }
    public void CheckUpdate()
    {
        //업데이트 버튼
    }




    //# 단순 이동
    public void MoveFirstpage()
    {
        if (IsPremium) MoveMainPremium();
        else MoveMain();
    }   
    private void MoveMain() => UM.PageMove(0);
    private void MoveMainPremium() => UM.PageMove(1);
    private void MoveProfile() => UM.PageMove(2);
    private void MovePhone() => UM.PageMove(3);
    private void MovePhone_2() => UM.PageMove(4);
    private void MovePassword() => UM.PageMove(5);
    private void MovePaied() => UM.PageMove(6);
    private void MoveNotPaied() => UM.PageMove(7);
    private void MoveNotice() => UM.PageMove(8);
    private void MoveNoticeDetail() => UM.PageMove(9);
    private void MoveFAQ() => UM.PageMove(10);
    private void MoveTerm() => UM.PageMove(11);
    public void MoveHome() => SceneManager.LoadScene("home");
    public void MoveBest() => SceneManager.LoadScene("best");
    public void MoveMore() => SceneManager.LoadScene("more");
    public void MoveGolfCourse() => SceneManager.LoadScene("golfCourse");
    public void PopUp_NoSubscribe() => UM.PopUp(0);
    public void PopUp_ProfilePhoto() => UM.PopUp(1);
    public void PopUp_Resign() => UM.PopUp(2);
    public void PopUp_membership() => UM.PopUp(3);

    private void ChangeHeight(InputField text) //true => cm false => ft
    {
        float temp = 0f;
        GameObject left = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject;
        GameObject right = EventSystem.current.currentSelectedGameObject.transform.GetChild(1).gameObject;
        if (unit)
        {
            left.SetActive(false);
            right.SetActive(true);
        }
        else
        {
            left.SetActive(true);
            right.SetActive(false);
        }
        if (!float.TryParse(text.text, out temp))//숫자가 아닌 값을 입력했을 경우
        {
            height = null;
            heightFT = null;
            unit = !unit;
            return;
        }
        temp = float.Parse(text.text);
        if (height != heightFT)//이미 입력한 숫자가 존재하는 경우
        {
            if ((System.Math.Abs((double)(height - temp)) > 1f && unit) || (System.Math.Abs((double)heightFT - temp) > 0.1f && !unit))
            {//이전에 존재하던 숫자와 다른 숫자를 입력했을 경우
                if (unit)//cm
                {
                    height = temp;
                    temp /= 30.48f;
                    heightFT = temp;
                    text.text = string.Format("{0:F1}", heightFT);
                    unit = !unit;
                    return;
                }
                else//ft
                {
                    heightFT = temp;
                    temp *= 30.48f;
                    height = temp;
                    text.text = string.Format("{0:F1}", height);
                    unit = !unit;
                    return;
                }
            }
            if (unit) text.text = string.Format("{0:F1}", heightFT);
            else text.text = string.Format("{0:F1}", height);
            unit = !unit;
            return;
        }
        else//이미 입력한 숫자가 없는 경우
        {
            if (unit)
            {
                height = temp;
                temp /= 30.48f;
                heightFT = temp;
                text.text = string.Format("{0:F1}", temp);
            }
            else
            {
                heightFT = temp;
                temp *= 30.48f;
                height = temp;
                text.text = string.Format("{0:F1}", temp);
            }
            unit = !unit;
        }
    }

    void Update()
    {
        if (canChangePassword)//페스워드 이미지 색 토글
        {
            PasswordConfirm.GetComponent<Image>().sprite = ConfirmSprite[1];
            PasswordConfirm.GetComponent<Button>().interactable = true;
        }
        else
        {
            PasswordConfirm.GetComponent<Button>().interactable = false;
            PasswordConfirm.GetComponent<Image>().sprite = ConfirmSprite[0];
        }
    }

    private void InitValue()
    {
        //유저 정보를 받아와서 개인 정보칸을 업데이트 해야함
        if (UM == null) UM = UIManager.Instance;
        if (GC == null) GC = GlobalCourutine.Instance;
        UM.ResetUIManager();
        MoveFirstpage();

        unit = true;
        PushAlram = true;
        IsPaied = false;
        canChangePassword = false;
        white = new Color(1f, 1f, 1f, 1f);
        red = new Color(1f, 0.1921569f, 0.2941177f, 1f);
    }
}
