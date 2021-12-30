using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Splash : MonoBehaviour  //Splash �����ؼ� ȭ�� �̵� �� UI�� ó���ϴ� ��ũ��Ʈ
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
    private int firstLogin;        //0 => ó���ƴ� 1 => ó��
    private string registePassword; //��� ��й�ȣ
    private string registerID;      //��� ���̵�
    private string userName;        //���� �̸�
    private float? height, heightFT;//Ű
    private bool sex;               //���� true == male
    private float handycap;         //�ڵ�ĸ
    private string phoneNumber;     //�ڵ��� ��ȣ

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

    IEnumerator Splash_term_on() //���� �ִϸ��̼�
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
        StartCoroutine(Splash_term_on()); //���� �ִϸ��̼�
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

    // #�ܼ� ȭ�� �̵� ���� �޼���   
    public void MoveLogin() => UM.PageMove(3);
    public void MoveRegister() => UM.PageMove(4);
    public void MoveRegisterDetail() => UM.PageMove(5);
    public void MoveFindPassword() => UM.PageMove(6);
    public void MoveCertify() => UM.PageMove(7);
    public void MoveAfterCertify() => UM.PageMove(8);  
    public void CheckBox() => UM.CheckBox();
    public void MoveHome() => SceneManager.LoadScene("home");




    //  #ù �α��� ȭ�� - 3
    public void CheckLogin()//�α��ι�ư
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
                Debug.Log("�α��� ����");
                Debug.Log(NM.Login.message);
                //���̵� ��й�ȣ�� �ٽ� Ȯ�� ���ּ���
            }
        }
    }

    public bool CheckCanLogin()//�̸��� ���� ��й�ȣ �� �ּ� ���� Ȯ��
    {
        foreach (GameObject warn in login_3_warn)
        {
            if (warn.activeSelf) return false;
        }
        return true;
    }

    public void EndEmailEdit(Text text)//�α��� �̸��� �Է�
    {
        if (UM.EndEditInput(text)) login_3_warn[0].SetActive(false);
        else login_3_warn[0].SetActive(true);
    }

    public void EndPasswordEdit(InputField text)//�α��� ��й�ȣ �Է�
    {
        //if (!UM.IsValidPassword(text.text)) login_3_warn[1].SetActive(false); //test �� !��������
        //else login_3_warn[1].SetActive(true);
        login_3_warn[1].SetActive(false);//test
    }

    public void CheckPssswordFind(Text text)//��й�ȣ ã�� �������� �̵��ϱ�
    {
        if (UM.IsValidPhone(text.text)) UM.PageMove(3);
    }




    // #ȸ�� ���� ȸ�� - 4
    public void EndEmialRegister(Text text)//ȸ�����Կ��� �̸����� �ùٸ� �������� Ȯ��
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

    public void EndPasswordRegister(InputField text)//ȸ�����Կ��� ��й�ȣ�� �ùٸ� �������� Ȯ��
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

    public void EndPasswordRegisterAgain(InputField text)//ȸ�����Կ��� ��й�ȣ�� �� �� �� �Է��� �� ù �Է°� ��ġ�ϴ��� Ȯ��
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

    public void PopUp_service()//������ �̿����� �˾��ϴ� ����
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

    public void PopUp_information()//���� �������� ó�� ��ħ �˾�
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

    public bool CheckRegisterNext()//ȸ������ ȭ�鿡�� �������� �Ѿ �� �ִ��� üũ
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




    // #ȸ������ ���� ���� - 5
    public bool CheckRegisterDetailNext()//ȸ������ ���� �������� �������� �Ѿ�� ���� üũ
    {
        foreach (bool warn in RegisterDetailInput)
        {
            if (!warn) return false;
        }
        return true;
    }

    public void EndRegisterDetailName(Text text)//�г��� ���
    {
        if (!(text.text == ""))
        {
            userName = text.text;
            RegisterDetailInput[0] = true;
        }
        else RegisterDetailInput[0] = false;
    }

    public void EndRegisterDetailHeight(Text text)//Ű ���
    {
        if (!(text.text == ""))
        {
            if (unit) height = float.Parse(text.text);
            else heightFT = float.Parse(text.text);
            if (height != null || heightFT != null)RegisterDetailInput[1] = true;
        }
        else RegisterDetailInput[1] = false;
    }

    public void EndRegisterDetailHandy(Text text)//�ڵ�ĸ ���
    {
        if (!(text.text == ""))
        {
            handycap = float.Parse(text.text);
            RegisterDetailInput[2] = true;
        }
        else RegisterDetailInput[2] = false;
    }

    public void ChangeSex()//���� ��� �� ����Ǵ� ����
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>().isOn) sex = true;
        else sex = false;
    }

    public void ChangeHeight(InputField text) //ft �� cm ��ȯ ��ư //true => cm false => ft
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
        if (!float.TryParse(text.text, out temp))//���ڰ� �ƴ� ���� �Է����� ���
        {
            height = null;
            heightFT = null;
            unit = !unit;
            return;
        }
        temp = float.Parse(text.text);
        if (height != heightFT && heightFT != null)//�̹� �Է��� ���ڰ� �����ϴ� ���
        {
            Debug.Log(height);
            Debug.Log(heightFT);
            if ((System.Math.Abs((double)(height - temp)) > 1f && unit) || (System.Math.Abs((double)heightFT - temp) > 0.1f && !unit))
            {//������ �����ϴ� ���ڿ� �ٸ� ���ڸ� �Է����� ���
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
        else//�̹� �Է��� ���ڰ� ���� ���
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




    // #��й�ȣ ã�� ȭ�� - 6
    public void ChangeButtonImage(Text text)//��ư�� �̹����� �ٲ۴�<��й�ȣ>
    {
        if(UM.IsValidEmail(text.text))
        {
            UM.ChangeImage(redButton_password, passwordButton);
        }
    }




    // #�ڵ��� ���� - 7
    public void ChangeButtonImage_phone(Text text)//��ư�� �̹����� �ٲ۴�<�����>
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

    public void CheckCertify(Text text)//�������� �ڵ��� ��ȣ �������� Ȯ��
    {
        //�ڵ��� ���� ��ȣ�� ������ ����
        if (UM.IsValidPhone(text.text))
        {
            MoveAfterCertify();
        }
    }




    // #�ڵ��� ���� �߼� �� ȭ�� - 8
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

        //���� ���� �ʱ�ȭ
        firstLogin = PlayerPrefs.GetInt("FirstEnter", 1);
        height = null;
        heightFT = null;
        unit = true;
        sex = true;
        registerID = null;
        registePassword = null;

        RegisterInput = new bool[3]; 
        RegisterDetailInput = new bool[3];

        //ȭ�� �ʱ�ȭ
        foreach (GameObject _ in login_3_warn) _.SetActive(false);
        foreach (GameObject _ in register_4_warn) _.SetActive(false);

        
    }

    //??
    public void ClickLogin()
    {
        string userEmal = registerID;
        Debug.Log(UM.IsValidEmail(userEmal));
        //�̸��� �Է� ���� ��ġ
        if (!UM.IsValidEmail(userEmal))
        {
            //���� ����
        }
        else
        {
            //��й�ȣ�� �̸��� ��ġ => ������ ���� �� ���� ��ġ�ϴ��� Ȯ��
            //�α��� ���� ȭ������ �̵�
            //if(��й�ȣ�� �̸����� ��ġ)            
        }
    }
    public void ClickPasswordConfirm()
    {
        //�̸��� �������� Ȯ�� + ���Ե� �̸������� Ȯ�� ��
        //�Ƹ� �˾� ���� �ɷ� ���� ����
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
