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
    private float? height,heightFT;
    /// <summary>
    /// 
    /// </summary>
    private UIManager UM;    
    public Sprite checkBox;
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
        //��� �̿� ����� ���� �ߴ��� üũ
        //�̸��� ������ ��ġ�ϴ��� üũ
        //��й�ȣ ������ ��ġ�ϴ��� üũ
        //��й�ȣ���� ��ġ�ϴ��� üũ
        MoveRegisterDetail();
    }
    public void RegisterDetailNext()
    {
        //�г����� �ߺ����� Ȯ���ϱ�
        //Ű�� �ԷµǾ����� Ȯ���ϱ�
        //�ڵ�ĸ�� �ԷµǾ����� Ȯ���ϱ�
        MoveCertify();
    }
    public void PopUpSercvice() => UM.PopUp(0);
    public void PopUpInformation() => UM.PopUp(1);
    public void PopUpUpdate() => UM.PopUp(2);
    public void CheckBox() => UM.CheckBox();
    public void MoveHome() => SceneManager.LoadScene("home");

    /// <summary>
    /// //////////////////////////////////////////////////////////
    /// </summary>
    /// 
    /*
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
    public void FindPasswordTouchConfirm()
    {
        //�̸��� �ּҸ� ������ ���� - server

        //Ȯ�� â ���� + �� �� �� ����     
        StartCoroutine(WaitSendMail());        
    }
    public void RegisterTouchConfirm()
    {
        //�г��� �ߺ� Ȯ��
        //���� üũ
        //Ű �Է� �Ϸ�
        //����� ���� �Ϸ�
        SplashOnAndOff(6, 5);
    }
    public void CheckEmail(Text text)//�̸��� ���̵� üũ��
    {
        
    }
    public void TwoTouchNext()
    {
        //if(email �Է� Ȯ��, ���� ��ġ, �̵�� �̸���)
        //�̸��� ���� Ȱ��ȭ
        //return
        //if(��й�ȣ ���� ����, �� ��й�ȣ�� ��ġ)
        //��й�ȣ ���� Ȱ��ȭ
        //return
        SplashOnAndOff(5, 4);
    }
    public void TwoTouchBack() => SplashOnAndOff(3, 4);
    public void LoadTouchRegister() => SplashOnAndOff(4, 3);
    public void LoadTouchLogin() => SplashOnAndOff(6, 3);
    public void OneTouchStart() => SplashOnAndOff(3, 2);
    public void TermTouchYes() => SplashOnAndOff(2, 1);
    public void TermTouchNo() => Application.Quit();

    

    
    private void PopUpOnOff(GameObject PopUp)
    {
        if (PopUp.activeSelf) PopUp.SetActive(false);
        else PopUp.SetActive(true);
    }
    private void ChangeImage(GameObject gameObject,Image image)
    {
        Image temp = gameObject.transform.GetComponent<Image>();
        temp = image;
    }
    private void UIOff(GameObject UI) => UI.SetActive(false);
    private void UIOn(GameObject UI) => UI.SetActive(true);
    */
    /// <summary>
    /// 
    /// </summary>

    IEnumerator Splash_term_on()
    {
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
        wait = new WaitForSeconds(3f);
       
    }
}
