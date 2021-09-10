using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Splash : MonoBehaviour  //Splash 관련해서 화면 이동 및 UI를 처리하는 스크립트
{
    public GameObject[] splash = new GameObject[9];
    public Sprite[] images = new Sprite[2];
    public GameObject[] errors = new GameObject[15];
    public GameObject confirm;
    private WaitForSeconds wait;
    private bool unit;
    private bool firstLogin;
    private float? height,heightFT;

    void Start()
    {
        InitValue();
        StartCoroutine(Splash_term_on());
    }
    public void RadioButton(Image choose, Image another)
    {
        choose.sprite = images[0];
        another.sprite = images[1];
    }
    public void ChangeHeight(InputField text) //true => cm false => ft
    {
        float temp = 0f;

        if (!float.TryParse(text.text, out temp))//숫자가 아닌 값을 입력했을 경우
        {
            Debug.Log(text.text);
            height = null;
            heightFT = null;
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
    public void AfterLoginTouchView() => SceneManager.LoadScene("sceneMyVedio");
    public void FindPasswordTouchConfirm()
    {
        //이메일 주소를 서버로 전송 - server

        //확인 창 띄우기 + 몇 초 후 삭제     
        StartCoroutine(WaitSendMail());        
    }
    public void FindPasswordTouchBack() => SplashOnAndOff(6,7);
    public void LoginTouchBack() => SplashOnAndOff(3, 6);
    public void LoginTouchFindPassword() => SplashOnAndOff(7, 6);
    public void LoginTouchLogin()
    {
        string userEmal = "kdh4021200@naver.com";
        Debug.Log(IsValidEmail(userEmal));
        //이메일 입력 형식 일치
        if (!IsValidEmail(userEmal))
        {
            ErrorOnOff(4);
        }
        else
        {
            SplashOnAndOff(8, 6);
            //비밀번호와 이메일 일치 => 서버로 보낸 뒤 둘이 일치하는지 확인
            //if(비밀번호와 이메일이 일치)
            if(firstLogin)
            {
                //팝업창 띄우기
            }
        }
    }

    public void RegisterTouchBack() => SplashOnAndOff(4, 5);
    public void RegisterTouchConfirm()
    {
        //닉네임 중복 확인
        //성별 체크
        //키 입력 완료
        //헨디켑 선택 완료
        SplashOnAndOff(6, 5);
    }
    public void CheckEmail(Text text)//이메일 아이디 체크용
    {
        
    }
    public void TwoTouchNext()
    {
        //if(email 입력 확인, 형식 일치, 미등록 이메일)
        //이메일 오류 활성화
        //return
        //if(비밀번호 조건 만족, 두 비밀번호가 일치)
        //비밀번호 오류 활성화
        //return
        SplashOnAndOff(5, 4);
    }
    public void TwoTouchBack() => SplashOnAndOff(3, 4);
    public void LoadTouchRegister() => SplashOnAndOff(4, 3);
    public void LoadTouchLogin() => SplashOnAndOff(6, 3);

    public void OneTouchStart() => SplashOnAndOff(3, 2);

    public void TermTouchYes() => SplashOnAndOff(2, 1);
    public void TermTouchNo() => Application.Quit();

    /************/

    IEnumerator Splash_term_on()
    {
        yield return wait;
        UIOn(splash[1]);
    }
    IEnumerator WaitSendMail()
    {
        confirm.SetActive(true);
        yield return wait;
        confirm.SetActive(false);
        SplashOnAndOff(6, 7);
    }
    private void ChangeImage(GameObject gameObject,Image image)
    {
        Image temp = gameObject.transform.GetComponent<Image>();
        temp = image;
    }
    private void ErrorOnOff(int errorpos)
    {
        if (errors[errorpos].activeSelf) errors[errorpos].SetActive(false);
        else errors[errorpos].SetActive(true);
    }
    private bool IsValidEmail(string email)
    {
        bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=
?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        return valid;
    }
    private void SplashOnAndOff(int on, int off)
    {
        UIOn(splash[on]);
        UIOff(splash[off]);
        //UI 초기화하는 코드가 추가로 필요하다
    }
    private void UIOff(GameObject UI) => UI.SetActive(false);
    private void UIOn(GameObject UI) => UI.SetActive(true);

    private void InitValue()
    {
        firstLogin = true; //서버 나오면 수정
        height = null;
        heightFT = null;
        unit = true;
        wait = new WaitForSeconds(3f);
        foreach (GameObject panel in splash)panel.SetActive(false);
        //foreach (GameObject error in errors) error.SetActive(false);
        splash[0].SetActive(true);
    }
}
