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
    public Sprite[] ConfirmSprite; //���� ��������Ʈ ã�ƾ���
    [Space(16)]
    public GameObject[] Toggle_height;
    public GameObject[] PasswordChange;
    [Header("Profile")]
    public GameObject profileImage;//�������� �̹��� ���߿� �����Ϳ��� �Ѳ����� �����;���
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

    IEnumerator LoadMore()//������ ������ �ε� �ڷ�ƾ
    {
        yield return new WaitForSeconds(1f);
        MoveMain();
    }
   

    //# More 1 and More 0
    public void ClickNotice() //��������
    {
        MoveNotice();
    }

    public void ClickPay() //���� ����
    {
        if (IsPaied) MovePaied();
        else MoveNotPaied();
    }

    public void ToggleButton()//�˸� ���
    {
        foreach (GameObject gameObject in Toggle)
        {
            if (gameObject.activeSelf) gameObject.SetActive(false);
            else gameObject.SetActive(true);
            PushAlram = !PushAlram;
        }
    }

    public void ClickSearchVedio()//�����Ī ��ư
    {
        UM.ChildActiveOnOff();
    }

    public void ClickDirecctSearch()//�����˻� ���� �˻� Ȯ�� ��ư
    {

        GC.AddCourutine("home", "DirectSearch");
        MoveHome();
    }

    public void AutoSearch()//�ڵ� �˻�
    {
        GC.AddCourutine("home", "CheckNewVedio");
        MoveHome();
    }

    public void ClickProfile()//������ ������
    {
        //���� ���� �޾ƿͼ� �ֱ�
        MoveProfile();
    }

    public void ClickNoticeDetail() //����
    {
        //������ ������ �޴� ����
        MoveNoticeDetail();
    }



    //# More_profile_2
    public void OpenGallery()//������ ���� �ҷ�����
    {
        Texture2D texture = null;//�̹���
        Rect rect;

        //ī�޶� ������ ȣ��
        //�̹��� ��� ��������
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
            // �ؽ��Ŀ� ����ϱ�
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

    public void Profile_ClickResign() //���� �����ϱ�
    {
        if (IsPremium) PopUp_NoSubscribe();
        else PopUp_membership();
    }

    public void Profile_ChangePassword() //��й�ȣ ����
    {
        MovePassword();
    }

    public void Profile_Logout() //�α� �ƿ�
    {
        //�α� �ƿ�
    }

    public void Profile_Phone()//�ڵ��� ��ȣ ���� �������� �̵�
    {
        MovePhone();
    }

    public void Profile_back()//�������� ���ư���
    {
        //�����ϱ�
        MoveFirstpage();
    }

    public void Profile_height(InputField text)//������ Ű ��� ��ư
    {
        Toggleheight();
        ChangeHeight(text);
    }

    public void Toggleheight()//������ Ű ��� ��ư_
    {
        foreach (GameObject _ in Toggle_height)
        {
            if (_.activeSelf) _.SetActive(false);
            else _.SetActive(true);
            Debug.Log(_.name + " :" + _.activeSelf);
        }
    }




    //# More_phone_3 and More_phone_4
    public void CheckIsPhoneNumber(Text text)//��ư ���������� �ٲٱ�
    {
        if (UM.IsValidPhone(text.text))
        {
            //��ư ���������� �ٲٱ�
        }       
    }

    public void ClickConfirmPhoneNumber()//���� ��ȣ ������ ����
    {
        //���� ��ȣ ������ ����
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
        //��� �˸°� �ԷµǾ����� ó���ϴ� ����
        //�ٲ� ��й�ȣ�� ó���ϴ� ����
        ClickProfile();
    }





    //Not use _ �ϴ��� ��� ����
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
        //������Ʈ ��ư
    }




    //# �ܼ� �̵�
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
        if (!float.TryParse(text.text, out temp))//���ڰ� �ƴ� ���� �Է����� ���
        {
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

    void Update()
    {
        if (canChangePassword)//�佺���� �̹��� �� ���
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
        //���� ������ �޾ƿͼ� ���� ����ĭ�� ������Ʈ �ؾ���
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
