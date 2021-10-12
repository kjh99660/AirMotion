using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Splash : MonoBehaviour  //Splash 관련해서 화면 이동 및 UI를 처리하는 스크립트
{
    private WaitForSeconds wait;
    private bool unit;
    private bool firstLogin;
    private float? height,heightFT;
    /// <summary>
    /// 
    /// </summary>
    private UIManager UM;    
    public Sprite checkBox;
    [Header ("Warning Object")]
    public GameObject[] login_3_warn;
    public GameObject[] register_4_warn;
    [Space (8)]
    public GameObject passwordButton;
    public GameObject phoneButton;
    public Sprite redButton_password;
    public Sprite redButton_phone;
    
    void Start()
    {
        InitValue();
        StartCoroutine(Splash_term_on());
    }
    public void MoveMain() => UM.PageMove(2);
    public void MoveLogin() => UM.PageMove(3);
    public void MoveRegister() => UM.PageMove(4);
    public void MoveRegisterDetail() => UM.PageMove(5);
    public void MoveFindPassword() => UM.PageMove(6);
    public void MoveCertify() => UM.PageMove(7);
    public void MoveAfterCertify() => UM.PageMove(8);
    public void PopUp_service() => UM.PopUp(0);
    public void PopUp_information() => UM.PopUp(1);
    public void CheckBox() => UM.CheckBox();
    public void MoveHome() => SceneManager.LoadScene("home");


    public void ChangeButtonImage(Text text)//버튼의 이미지를 바꾼다<비밀번호>
    {
        if(UM.IsValidEmail(text.text))
        {
            UM.ChangeImage(redButton_password, passwordButton);
        }
    }
    public void ChangeButtonImage_phone(Text text)//버튼의 이미지를 바꾼다<헨드폰>
    {
        if (UM.IsValidPhone(text.text))
        {
            UM.ChangeImage(redButton_phone, phoneButton);
        }
    }
    public void EndEmailEdit(Text text)//로그인 이메일 입력
    {
        if (UM.EndEditInput(text, 1)) login_3_warn[0].SetActive(false);
        else login_3_warn[0].SetActive(true);
    }
    public void EndPasswordEdit(Text text)//로그인 비밀번호 입력
    {
        if (UM.EndEditInput(text, 2)) login_3_warn[1].SetActive(false);
        else login_3_warn[1].SetActive(true);
    }
    public void EndEmialRegister(Text text)
    {
        if (UM.EndEditInput(text, 1)) login_3_warn[0].SetActive(false);
        else register_4_warn[0].SetActive(true);
    }
    public void EndPasswordRegister(Text text)
    {
        if (UM.EndEditInput(text, 2)) login_3_warn[0].SetActive(false);
        else register_4_warn[1].SetActive(true);
    }
    public void EndPasswordRegisterAgain(Text text)
    {
        if (UM.EndEditInput(text, 2)) login_3_warn[0].SetActive(false);
        else register_4_warn[2].SetActive(true);
    }
    public void ClickLogin()
    {
        string userEmal = "kdh4021200@naver.com";
        Debug.Log(UM.IsValidEmail(userEmal));
        //이메일 입력 형식 일치
        if (!UM.IsValidEmail(userEmal))
        {
            //에러 띄우기
        }       
        else
        {
            //비밀번호와 이메일 일치 => 서버로 보낸 뒤 둘이 일치하는지 확인
            //로그인 이후 화면으로 이동
            //if(비밀번호와 이메일이 일치)            
        }
    }
    public void ClickPasswordConfirm()
    {
        //이메일 형식인지 확인 + 가입된 이메일인지 확인 후
        //아마 팝업 띄우는 걸로 나올 예정
        MoveLogin();
    }
    public void RegisterNext()
    {
        //모든 이용 약관에 동의 했는지 체크
        //이메일 형식이 일치하는지 체크
        //비밀번호 형식이 일치하는지 체크
        //비밀번호끼리 일치하는지 체크
        MoveRegisterDetail();
    }
    public void RegisterDetailNext()
    {
        //닉네임이 중복인지 확인하기
        //키가 입력되었는지 확인하기
        //핸디캡이 입력되었는지 확인하기
        MoveCertify();
    }
    
    public void ChangeHeight(InputField text) //true => cm false => ft
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
            Debug.Log(text.text);
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
                    Debug.Log("새로 입력:");
                    Debug.Log(height);
                    Debug.Log(heightFT);
                    return;
                }
                else//ft
                {
                    heightFT = temp;
                    temp *= 30.48f;
                    height = temp;
                    text.text = string.Format("{0:F1}", height);
                    unit = !unit;
                    Debug.Log("새로 입력:");
                    Debug.Log(height);
                    Debug.Log(heightFT);
                    return;
                }
            }
            if (unit) text.text = string.Format("{0:F1}", heightFT);
            else text.text = string.Format("{0:F1}", height);
            Debug.Log("단순 변환:");
            Debug.Log(height);
            Debug.Log(heightFT);

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
                Debug.Log("처음 입력:");
                Debug.Log(height);
                Debug.Log(heightFT);
            }
            else
            {
                heightFT = temp;
                temp *= 30.48f;
                height = temp;
                text.text = string.Format("{0:F1}", temp);
                Debug.Log("처음 입력:");
                Debug.Log(height);
                Debug.Log(heightFT);
            }
            unit = !unit;
        }
        
    }

    IEnumerator Splash_term_on()
    {
        UM.PageMove(0);
        yield return wait;
        UM.PageMove(1);
    }
    private void InitValue()
    {
        UM = UIManager.Instance;
        firstLogin = true; //서버 나오면 수정
        height = null;
        heightFT = null;
        unit = true;
        wait = new WaitForSeconds(3f);
        foreach (GameObject _ in login_3_warn) _.SetActive(false);
        foreach (GameObject _ in register_4_warn) _.SetActive(false);
    }
}
