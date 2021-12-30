using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Splash : MonoBehaviour  //Splash 관련해서 화면 이동 및 UI를 처리하는 스크립트
{
    private WaitForSeconds wait;
    private NetworkManager NM;
    private UIManager UM;

    public Sprite checkBox;
    public GameObject[] checkBoxes;

    private bool[] RegisterInput;
    private bool[] RegisterDetailInput;

    [Header ("UserInformaition")]
    private bool unit;              //true => cm false => ft
    private int firstLogin;        //0 => 처음아님 1 => 처음
    private string registePassword; //등록 비밀번호
    private string registerID;      //등록 아이디
    private string userName;        //유저 이름
    private float? height, heightFT;//키
    private bool sex;               //성별 true == male
    private float handycap;         //핸디캡
    private string phoneNumber;     //핸드폰 번호

    [Header("Warning Object")]
    public GameObject[] login_3_warn;
    public GameObject[] register_4_warn;

    [Space(8)]
    public GameObject passwordButton;
    public GameObject phoneButton;
    public Sprite redButton_password;
    public Sprite redButton_phone;

    [Header("Register")]
    public GameObject RegisterButton;
    public GameObject RegisterButtonDetail;
    public Sprite redButtom_register;
    public Sprite grayButton_register;

    [Header("Policy")]
    public GameObject policyTittle;
    public GameObject policyContent;
    
    [Header("Information")]
    public GameObject informationTittle;
    public GameObject informationContent;

    [Header("Login")]
    public InputField ID;
    public InputField PW;

    IEnumerator Splash_term_on() //시작 애니메이션
    {
        UM.PageMove(0);
        yield return wait;
        if (firstLogin == 1) UM.PageMove(1);
        else UM.PageMove(2);
        PlayerPrefs.SetInt("FirstEnter", 0);
        PlayerPrefs.Save();
    }

    void Start()
    {
        Screen.fullScreen = false;
        InitValue();
        StartCoroutine(Splash_term_on()); //시작 애니메이션
    }
    private void Update()
    {
        if (CheckRegisterNext())// register_4
        {
            UM.ChangeImage(redButtom_register, RegisterButton);
            RegisterButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            UM.ChangeImage(grayButton_register, RegisterButton);
            RegisterButton.GetComponent<Button>().interactable = false;
        }
        if (CheckRegisterDetailNext())// register_detail_5
        {
            UM.ChangeImage(redButtom_register, RegisterButtonDetail);
            RegisterButtonDetail.GetComponent<Button>().interactable = true;
        }
        else
        {
            UM.ChangeImage(grayButton_register, RegisterButtonDetail);
            RegisterButtonDetail.GetComponent<Button>().interactable = false;
        }
    }

    // #단순 화면 이동 관련 메서드   
    public void MoveLogin() => UM.PageMove(3);
    public void MoveRegister() => UM.PageMove(4);
    public void MoveRegisterDetail() => UM.PageMove(5);
    public void MoveFindPassword() => UM.PageMove(6);
    public void MoveCertify() => UM.PageMove(7);
    public void MoveAfterCertify() => UM.PageMove(8);  
    public void CheckBox() => UM.CheckBox();
    public void MoveHome() => SceneManager.LoadScene("home");




    //  #첫 로그인 화면 - 3
    public void CheckLogin()//로그인버튼
    {
        StartCoroutine(CheckLogin_());
    }
    private IEnumerator CheckLogin_()
    {
        if (CheckCanLogin())
        {
            NM.GetLoginData(ID.text, PW.text);

            while (!NM.isLoaded)
            {
                yield return null;
            }
            if (NM.Login.message.Equals("SUCCESS"))
            {
               
                MoveHome();
            }
            else
            {
                Debug.Log("로그인 오류");
                Debug.Log(NM.Login.message);
                //아이디나 비밀번호를 다시 확인 해주세요
            }
        }
    }

    public bool CheckCanLogin()//이메일 형식 비밀번호 등 최소 조건 확인
    {
        foreach (GameObject warn in login_3_warn)
        {
            if (warn.activeSelf) return false;
        }
        return true;
    }

    public void EndEmailEdit(Text text)//로그인 이메일 입력
    {
        if (UM.EndEditInput(text)) login_3_warn[0].SetActive(false);
        else login_3_warn[0].SetActive(true);
    }

    public void EndPasswordEdit(InputField text)//로그인 비밀번호 입력
    {
        //if (!UM.IsValidPassword(text.text)) login_3_warn[1].SetActive(false); //test 중 !지워야함
        //else login_3_warn[1].SetActive(true);
        login_3_warn[1].SetActive(false);//test
    }

    public void CheckPssswordFind(Text text)//비밀번호 찾기 페이지로 이동하기
    {
        if (UM.IsValidPhone(text.text)) UM.PageMove(3);
    }




    // #회원 가입 회면 - 4
    public void EndEmialRegister(Text text)//회원가입에서 이메일이 올바른 형식인지 확인
    {
        if (UM.EndEditInput(text))
        {
            register_4_warn[0].SetActive(false);
            RegisterInput[0] = true;
        }
        else
        {
            register_4_warn[0].SetActive(true);
            RegisterInput[0] = false;
        }
        registerID = text.text;
    }

    public void EndPasswordRegister(InputField text)//회원가입에서 비밀번호가 올바른 형식인지 확인
    {
        if (UM.IsValidPassword(text.text))
        {
            register_4_warn[1].SetActive(false);
            RegisterInput[1] = true;
        }
        else
        {
            register_4_warn[1].SetActive(true);
            RegisterInput[1] = false;
        }
        registePassword = text.text;
    }

    public void EndPasswordRegisterAgain(InputField text)//회원가입에서 비밀번호를 한 번 더 입력할 때 첫 입력과 일치하는지 확인
    {
        if (registePassword == text.text)
        {
            register_4_warn[2].SetActive(false);
            RegisterInput[2] = true;
        }
        else
        {
            register_4_warn[2].SetActive(true);
            RegisterInput[2] = false;
        }
    }

    public void PopUp_service()//서버스 이용약관을 팝업하는 내용
    {
        StartCoroutine(PopUpService());              
    }
    private IEnumerator PopUpService()
    {
        NM.GetPolicyData("A");

        while(!NM.isLoaded)
        {
            yield return null;
        }
        
        policyTittle.GetComponent<Text>().text = NetworkManager.Instance.Policy.data.policyTitle;
        policyContent.GetComponent<Text>().text = NetworkManager.Instance.Policy.data.policyContent;

        UM.PopUp(0);
    }

    public void PopUp_information()//서비스 개인정보 처리 방침 팝업
    {
        StartCoroutine(PopUpInformation());        
    }
    private IEnumerator PopUpInformation()
    {
        NM.GetPolicyData("B");

        while (!NM.isLoaded)
        {
            yield return null;
        }

        informationTittle.GetComponent<Text>().text = NetworkManager.Instance.Policy.data.policyTitle;
        informationContent.GetComponent<Text>().text = NetworkManager.Instance.Policy.data.policyContent;

        UM.PopUp(1);
    }

    public bool CheckRegisterNext()//회원가입 화면에서 다음으로 넘어갈 수 있는지 체크
    {
        foreach (GameObject warn in register_4_warn)
        {
            if (warn.activeSelf) return false;
        }
        foreach (GameObject checkBox in checkBoxes)
        {
            if (!checkBox.GetComponent<Toggle>().isOn) return false;
        }
        foreach(bool value in RegisterInput)
        {
            if (value == false) return false;
        }
        return true;
    }




    // #회원가입 세부 정보 - 5
    public bool CheckRegisterDetailNext()//회원가입 세부 정보에서 다음으로 넘어가는 조건 체크
    {
        foreach (bool warn in RegisterDetailInput)
        {
            if (!warn) return false;
        }
        return true;
    }

    public void EndRegisterDetailName(Text text)//닉네임 등록
    {
        if (!(text.text == ""))
        {
            userName = text.text;
            RegisterDetailInput[0] = true;
        }
        else RegisterDetailInput[0] = false;
    }

    public void EndRegisterDetailHeight(Text text)//키 등록
    {
        if (!(text.text == ""))
        {
            if (unit) height = float.Parse(text.text);
            else heightFT = float.Parse(text.text);
            if (height != null || heightFT != null)RegisterDetailInput[1] = true;
        }
        else RegisterDetailInput[1] = false;
    }

    public void EndRegisterDetailHandy(Text text)//핸디캡 등록
    {
        if (!(text.text == ""))
        {
            handycap = float.Parse(text.text);
            RegisterDetailInput[2] = true;
        }
        else RegisterDetailInput[2] = false;
    }

    public void ChangeSex()//성별 토글 시 실행되는 내용
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>().isOn) sex = true;
        else sex = false;
    }

    public void ChangeHeight(InputField text) //ft 와 cm 교환 버튼 //true => cm false => ft
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
        if (height != heightFT && heightFT != null)//이미 입력한 숫자가 존재하는 경우
        {
            Debug.Log(height);
            Debug.Log(heightFT);
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




    // #비밀번호 찾기 화면 - 6
    public void ChangeButtonImage(Text text)//버튼의 이미지를 바꾼다<비밀번호>
    {
        if(UM.IsValidEmail(text.text))
        {
            UM.ChangeImage(redButton_password, passwordButton);
        }
    }




    // #핸드폰 인증 - 7
    public void ChangeButtonImage_phone(Text text)//버튼의 이미지를 바꾼다<헨드폰>
    {
        
        if (UM.IsValidPhone(text.text))
        {
            string temp;
            temp = text.text;
            temp = temp.Trim();
            temp.Replace("-", "");
            phoneNumber = temp;
            UM.ChangeImage(redButton_phone, phoneButton);
        }
    }

    public void CheckCertify(Text text)//정상적인 핸드폰 번호 형식인지 확인
    {
        //핸드폰 인증 번호를 보내는 내용
        if (UM.IsValidPhone(text.text))
        {
            MoveAfterCertify();
        }
    }




    // #핸드폰 메일 발송 후 화면 - 8
    public void MoveMain()
    {
        NM.SignIn.memberFirstName = userName;
        NM.SignIn.memberLastName = userName;
        NM.SignIn.memberBirth = "20211216";
        NM.SignIn.memberEmailAddr = registerID;
        //NM.SignIn.memberName = userName;
        //NM.SignIn.memberHpNo = phoneNumber;
        NM.SignIn.memberHandDrctCd = "RIGHT";
        NM.SignIn.memberHandicapCd = handycap.ToString();
        NM.SignIn.memberPs = registePassword;
        NM.SignIn.memberUsePolicyYn = "Y";
        NM.SignIn.memberPsnInfoClctUseYn = "Y";
        NM.SignIn.memberLocationUsePolicyYn = "Y";
        NM.SignIn.memberMarketingReceptYn = "Y";
        if (sex) NM.SignIn.memberGenderCd = "MALE";
        else NM.SignIn.memberGenderCd = "FEMALE";

        NM.SignInSend();
        UM.PageMove(2);
    }



    private void InitValue()
    {
        NM = NetworkManager.Instance;
        UM = UIManager.Instance;
        wait = new WaitForSeconds(3f);

        //유저 정보 초기화
        firstLogin = PlayerPrefs.GetInt("FirstEnter", 1);
        height = null;
        heightFT = null;
        unit = true;
        sex = true;
        registerID = null;
        registePassword = null;

        RegisterInput = new bool[3]; 
        RegisterDetailInput = new bool[3];

        //화면 초기화
        foreach (GameObject _ in login_3_warn) _.SetActive(false);
        foreach (GameObject _ in register_4_warn) _.SetActive(false);

        
    }

    //??
    public void ClickLogin()
    {
        string userEmal = registerID;
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
    //Not Use
    /*
   public void RegisterNext()
   {
       foreach(bool register in RegisterInput)
       {
           if (!register) return;
       }
       if (!CheckRegisterNext()) return;
       MoveRegisterDetail();
   }
   */
}
