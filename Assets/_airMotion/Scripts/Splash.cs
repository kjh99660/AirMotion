using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Splash : MonoBehaviour  //Splash 관련해서 화면 이동 및 UI를 처리하는 스크립트
{
    private WaitForSeconds wait;
    private string login_email, login_password;
    private string user_password;
    private bool Name, Height, Handycap;
    private bool firstLogin;
    private bool unit;
    private bool Service, Infromation, Over14;
    private bool RegisterEmail, RegisgerPasswrod, RegisterPasswordTwo;   
    private float? height,heightFT;
    private float time;
    /// <summary>
    /// 
    /// </summary>
    private UIManager UM;    
    public Sprite checkBox;
    [Header ("Warning Object")]
    public GameObject[] login_3_warn;
    public GameObject[] register_4_warn;
    [Space(8)]
    public GameObject registerButtonDetail;
    public GameObject registerButtonNext;
    public GameObject passwordButton;
    public GameObject phoneButton;
    [Space(8)]
    public Sprite redButton_password;
    public Sprite redButton_phone;
    public Sprite redButton_register;
    [Space(8)]
    public Sprite grayButton_password;
    public Sprite grayButton_phone;
    public Sprite grayButton_register;
    [Space(8)]
    public Text Timer;

    public void Start()
    {
        time = 180f;
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

    
    public void SetAfterCerity()//핸드폰 인증요청 
    {
        time = 180f;
        MoveAfterCertify();
    }
    public void ChangeButtonImage(Text text)//버튼의 이미지를 바꾼다<비밀번호>
    {
        if (UM.IsValidEmail(text.text))
        {
            passwordButton.GetComponent<Button>().interactable = true;
            UM.ChangeImage(redButton_password, passwordButton);
        }
        else
        {
            UM.ChangeImage(grayButton_password, passwordButton);
            passwordButton.GetComponent<Button>().interactable = false;
        }
    }
    public void ChangeButtonImage_phone(Text text)//버튼의 이미지를 바꾼다<헨드폰>
    {
        if (UM.IsValidPhone(text.text))
        {
            phoneButton.GetComponent<Button>().interactable = true;
            UM.ChangeImage(redButton_phone, phoneButton);
        }
        else
        {
            phoneButton.GetComponent<Button>().interactable = false;
            UM.ChangeImage(grayButton_phone, phoneButton);
        }
    }
    public void EndEmailEdit(Text text)//로그인 이메일 입력
    {
        if (UM.EndEditInput(text, 1)) login_3_warn[0].SetActive(false);
        else login_3_warn[0].SetActive(true);
        login_email = text.text;
    }
    public void EndPasswordEdit(Text text)//로그인 비밀번호 입력
    {
        if (UM.EndEditInput(text, 2)) login_3_warn[1].SetActive(false);
        else login_3_warn[1].SetActive(true);
        login_password = text.text;
    }
    public void EndEmialRegister(Text text)//회원가입
    {
        if (UM.EndEditInput(text, 1))
        {
            register_4_warn[0].SetActive(false);
            RegisterEmail = true;
        }
        else
        {
            register_4_warn[0].SetActive(true);
            RegisterEmail = false;
        }
    }
    public void EndPasswordRegister(InputField inputField)//회원가입 비밀번호 형식 확인
    {
        if (UM.IsValidPassword(inputField.text))
        {
            register_4_warn[1].SetActive(false);
            RegisgerPasswrod = true;
        }
        else
        {
            register_4_warn[1].SetActive(true);
            RegisgerPasswrod = false;
        }
        user_password = inputField.text;
    }
    public void EndPasswordRegisterAgain(InputField inputField)//회원가입 비밀번호 2번 체크
    {
        if (user_password == inputField.text)
        {
            register_4_warn[2].SetActive(false);
            RegisterPasswordTwo = true;
        }
        else
        {
            register_4_warn[2].SetActive(true);
            RegisterPasswordTwo = false;
        }
    }
    public void ClickLogin()
    {
        string userEmail = login_email;
        string userPassword = login_password;
      
        //이메일 입력 형식 일치
        //에러 띄우기
        //비밀번호와 이메일 일치 => 서버로 보낸 뒤 둘이 일치하는지 확인
        //로그인 이후 화면으로 이동
        //if(비밀번호와 이메일이 일치)            
        
    }
    public void ClickPasswordConfirm()
    {
        //이메일 형식인지 확인 + 가입된 이메일인지 확인 후
        //아마 팝업 띄우는 걸로 나올 예정
        MoveLogin();
    }
    public void RegisterNext()
    {
        if (OkToMoveRegisterNext())MoveRegisterDetail();
    }
    public void RegisterDetailNext()
    {
        if (OkToMoveRegisterDetailNext()) MoveCertify();
    }
    private bool OkToMoveRegisterNext()
    {
        if (Service && Infromation && Over14){
            if (RegisterPasswordTwo && RegisgerPasswrod && RegisterEmail){
                UM.ChangeImage(redButton_register,registerButtonNext);
                registerButtonNext.GetComponent<Button>().interactable = true;
                return true;
            }
        }
        registerButtonNext.GetComponent<Button>().interactable = false;
        UM.ChangeImage(grayButton_register, registerButtonNext);
        return false;
    }
    private bool OkToMoveRegisterDetailNext()
    {
        if (Name && Height && Handycap)
        {
            if (RegisterPasswordTwo && RegisgerPasswrod && RegisterEmail)
            {
                UM.ChangeImage(redButton_register, registerButtonDetail);
                registerButtonDetail.GetComponent<Button>().interactable = true;
                return true;
            }
        }
        registerButtonDetail.GetComponent<Button>().interactable = false;
        UM.ChangeImage(grayButton_register, registerButtonDetail);
        return false;
    }
    public void ServiceCheck()
    {
        Service = !Service;
        CheckBox();
    }
    public void InformationCheck()
    {
        Infromation = !Infromation;
        CheckBox();
    }
    public void Over14Check()
    {
        Over14 = !Over14;
        CheckBox();
    }
    public void CheckNameBlank(Text text)
    {
        if (text.text == "") Name = false;
        else Name = true;
    }
    public void CheckHeightBlank(Text text)
    {
        if (text.text == "") Height = false;
        else Height = true;
    }
    public void CheckHandyBlank(Text text)
    {
        if (text.text == "") Handycap = false;
        else Handycap = true;
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
    
    public void Update()
    {
        OkToMoveRegisterNext();
        OkToMoveRegisterDetailNext();
        time -= Time.deltaTime;
        Timer.text = string.Format("{0:0}", System.Math.Truncate((time / 60))) + ":" + string.Format("{0:00}", System.Math.Truncate((time % 60)));
        Debug.Log(time / 60);
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
        unit = true;
        Service = false; Infromation = false; Over14 = false;
        RegisterEmail = false; RegisgerPasswrod = false; RegisterPasswordTwo = false;
        Name = false; Height = false; Handycap = false;
        height = null;
        heightFT = null;
        wait = new WaitForSeconds(3f);
        foreach (GameObject _ in login_3_warn) _.SetActive(false);
        foreach (GameObject _ in register_4_warn) _.SetActive(false);
    }
}
