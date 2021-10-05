using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Splash : MonoBehaviour  //Splash �����ؼ� ȭ�� �̵� �� UI�� ó���ϴ� ��ũ��Ʈ
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

    
    public void SetAfterCerity()//�ڵ��� ������û 
    {
        time = 180f;
        MoveAfterCertify();
    }
    public void ChangeButtonImage(Text text)//��ư�� �̹����� �ٲ۴�<��й�ȣ>
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
    public void ChangeButtonImage_phone(Text text)//��ư�� �̹����� �ٲ۴�<�����>
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
    public void EndEmailEdit(Text text)//�α��� �̸��� �Է�
    {
        if (UM.EndEditInput(text, 1)) login_3_warn[0].SetActive(false);
        else login_3_warn[0].SetActive(true);
        login_email = text.text;
    }
    public void EndPasswordEdit(Text text)//�α��� ��й�ȣ �Է�
    {
        if (UM.EndEditInput(text, 2)) login_3_warn[1].SetActive(false);
        else login_3_warn[1].SetActive(true);
        login_password = text.text;
    }
    public void EndEmialRegister(Text text)//ȸ������
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
    public void EndPasswordRegister(InputField inputField)//ȸ������ ��й�ȣ ���� Ȯ��
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
    public void EndPasswordRegisterAgain(InputField inputField)//ȸ������ ��й�ȣ 2�� üũ
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
      
        //�̸��� �Է� ���� ��ġ
        //���� ����
        //��й�ȣ�� �̸��� ��ġ => ������ ���� �� ���� ��ġ�ϴ��� Ȯ��
        //�α��� ���� ȭ������ �̵�
        //if(��й�ȣ�� �̸����� ��ġ)            
        
    }
    public void ClickPasswordConfirm()
    {
        //�̸��� �������� Ȯ�� + ���Ե� �̸������� Ȯ�� ��
        //�Ƹ� �˾� ���� �ɷ� ���� ����
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
        if (!float.TryParse(text.text, out temp))//���ڰ� �ƴ� ���� �Է����� ���
        {
            Debug.Log(text.text);
            height = null;
            heightFT = null;
            unit = !unit;
            return;
        }
        temp = float.Parse(text.text);       
        if (height != heightFT)//�̹� �Է��� ���ڰ� �����ϴ� ���
        {
            if ((System.Math.Abs((double)(height - temp)) > 1f && unit) || (System.Math.Abs((double)heightFT - temp) > 0.1f && !unit))
            {//������ �����ϴ� ���ڿ� �ٸ� ���ڸ� �Է����� ���
                if (unit)//cm
                {
                    height = temp;
                    temp /= 30.48f;
                    heightFT = temp;
                    text.text = string.Format("{0:F1}", heightFT);
                    unit = !unit;
                    Debug.Log("���� �Է�:");
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
                    Debug.Log("���� �Է�:");
                    Debug.Log(height);
                    Debug.Log(heightFT);
                    return;
                }
            }
            if (unit) text.text = string.Format("{0:F1}", heightFT);
            else text.text = string.Format("{0:F1}", height);
            Debug.Log("�ܼ� ��ȯ:");
            Debug.Log(height);
            Debug.Log(heightFT);

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
                Debug.Log("ó�� �Է�:");
                Debug.Log(height);
                Debug.Log(heightFT);
            }
            else
            {
                heightFT = temp;
                temp *= 30.48f;
                height = temp;
                text.text = string.Format("{0:F1}", temp);
                Debug.Log("ó�� �Է�:");
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
        firstLogin = true; //���� ������ ����
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
