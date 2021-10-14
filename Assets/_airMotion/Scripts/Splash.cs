using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Splash : MonoBehaviour  //Splash �����ؼ� ȭ�� �̵� �� UI�� ó���ϴ� ��ũ��Ʈ
{
    private WaitForSeconds wait;

    private bool unit;
    private bool firstLogin;
    private string registePassword;

    private bool[] RegisterInput;
    private bool[] RegisterDetailInput;

    private float? height,heightFT;
    private bool sex;//true == male

    /// @@@@

    private UIManager UM;    
    public Sprite checkBox;
    public GameObject[] checkBoxes;
    [Header ("Warning Object")]
    public GameObject[] login_3_warn;
    public GameObject[] register_4_warn;
    [Space (8)]
    public GameObject passwordButton;
    public GameObject phoneButton;
    public Sprite redButton_password;
    public Sprite redButton_phone;
    [Header("Register")]
    public GameObject RegisterButton;
    public GameObject RegisterButtonDetail;
    public Sprite redButtom_register;
    public Sprite grayButton_register;
    
    
    
    void Start()
    {
        InitValue();
        StartCoroutine(Splash_term_on());
    }
    private void Update()
    {
        if (CheckRegisterNext()) UM.ChangeImage(redButtom_register, RegisterButton);
        else UM.ChangeImage(grayButton_register, RegisterButton);

        if (CheckRegisterDetailNext()) UM.ChangeImage(redButtom_register, RegisterButtonDetail);
        else UM.ChangeImage(grayButton_register, RegisterButtonDetail);
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

    public bool CheckRegisterNext()
    {
        foreach(GameObject warn in register_4_warn)
        {
            if (warn.activeSelf) return false;
        }
        foreach (GameObject checkBox in checkBoxes)
        {
            if (!checkBox.GetComponent<Toggle>().isOn) return false;
        }
        return true;
    }
    public bool CheckRegisterDetailNext()
    {
        foreach (bool warn in RegisterDetailInput)
        {
            if (!warn) return false;
        }
        return true;
    }
    public bool CheckCanLogin()
    {
        foreach (GameObject warn in login_3_warn)
        {
            if (warn.activeSelf) return false;
        }
        return true;
    }
    public void CheckCertify(Text text)
    {
        if (UM.IsValidPhone(text.text))
        {
            MoveAfterCertify();
        }
    }
    public void CheckLogin()//�α��ι�ư
    {
        if (CheckCanLogin()) MoveHome();
    }
    public void CheckPssswordFind(Text text)
    {
        if (UM.IsValidPhone(text.text)) UM.PageMove(3);
    }
    
    public void ChangeButtonImage(Text text)//��ư�� �̹����� �ٲ۴�<��й�ȣ>
    {
        if(UM.IsValidEmail(text.text))
        {
            UM.ChangeImage(redButton_password, passwordButton);
        }
    }
    public void ChangeButtonImage_phone(Text text)//��ư�� �̹����� �ٲ۴�<�����>
    {
        if (UM.IsValidPhone(text.text))
        {
            UM.ChangeImage(redButton_phone, phoneButton);
        }
    }
    public void EndEmailEdit(Text text)//�α��� �̸��� �Է�
    {
        if (UM.EndEditInput(text)) login_3_warn[0].SetActive(false);
        else login_3_warn[0].SetActive(true);
    }
    public void EndPasswordEdit(InputField text)//�α��� ��й�ȣ �Է�
    {
        if (UM.IsValidPassword(text.text)) login_3_warn[1].SetActive(false);
        else login_3_warn[1].SetActive(true);
    }
    public void EndRegisterDetailName(Text text)
    {
        if (!(text.text == "")) RegisterDetailInput[0] = true;
    }
    public void EndRegisterDetailHeight(Text text)
    {
        if (!(text.text == "")) RegisterDetailInput[1] = true;
    }
    public void EndRegisterDetailHandy(Text text)
    {
        if (!(text.text == "")) RegisterDetailInput[2] = true;
    }
    public void EndEmialRegister(Text text)
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

    }
    public void EndPasswordRegister(InputField text)
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
    public void EndPasswordRegisterAgain(InputField text)
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
    public void ClickLogin()
    {
        string userEmal = "kdh4021200@naver.com";
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
    public void RegisterNext()
    {
        foreach(bool register in RegisterInput)
        {
            if (!register) return;
        }
        if (!CheckRegisterNext()) return;
        MoveRegisterDetail();
    }
    public void RegisterDetailNext()
    {
        //�г����� �ߺ����� Ȯ���ϱ�
        //Ű�� �ԷµǾ����� Ȯ���ϱ�
        //�ڵ�ĸ�� �ԷµǾ����� Ȯ���ϱ�
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
        height = null;
        heightFT = null;
        unit = true;
        sex = true;//defult
        RegisterInput = new bool[3]; RegisterDetailInput = new bool[3];
         wait = new WaitForSeconds(3f);
        foreach (GameObject _ in login_3_warn) _.SetActive(false);
        foreach (GameObject _ in register_4_warn) _.SetActive(false);
    }
}
