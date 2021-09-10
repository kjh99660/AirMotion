using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Splash : MonoBehaviour  //Splash �����ؼ� ȭ�� �̵� �� UI�� ó���ϴ� ��ũ��Ʈ
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

        if (!float.TryParse(text.text, out temp))//���ڰ� �ƴ� ���� �Է����� ���
        {
            Debug.Log(text.text);
            height = null;
            heightFT = null;
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
    public void AfterLoginTouchView() => SceneManager.LoadScene("sceneMyVedio");
    public void FindPasswordTouchConfirm()
    {
        //�̸��� �ּҸ� ������ ���� - server

        //Ȯ�� â ���� + �� �� �� ����     
        StartCoroutine(WaitSendMail());        
    }
    public void FindPasswordTouchBack() => SplashOnAndOff(6,7);
    public void LoginTouchBack() => SplashOnAndOff(3, 6);
    public void LoginTouchFindPassword() => SplashOnAndOff(7, 6);
    public void LoginTouchLogin()
    {
        string userEmal = "kdh4021200@naver.com";
        Debug.Log(IsValidEmail(userEmal));
        //�̸��� �Է� ���� ��ġ
        if (!IsValidEmail(userEmal))
        {
            ErrorOnOff(4);
        }
        else
        {
            SplashOnAndOff(8, 6);
            //��й�ȣ�� �̸��� ��ġ => ������ ���� �� ���� ��ġ�ϴ��� Ȯ��
            //if(��й�ȣ�� �̸����� ��ġ)
            if(firstLogin)
            {
                //�˾�â ����
            }
        }
    }

    public void RegisterTouchBack() => SplashOnAndOff(4, 5);
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
        //UI �ʱ�ȭ�ϴ� �ڵ尡 �߰��� �ʿ��ϴ�
    }
    private void UIOff(GameObject UI) => UI.SetActive(false);
    private void UIOn(GameObject UI) => UI.SetActive(true);

    private void InitValue()
    {
        firstLogin = true; //���� ������ ����
        height = null;
        heightFT = null;
        unit = true;
        wait = new WaitForSeconds(3f);
        foreach (GameObject panel in splash)panel.SetActive(false);
        //foreach (GameObject error in errors) error.SetActive(false);
        splash[0].SetActive(true);
    }
}
