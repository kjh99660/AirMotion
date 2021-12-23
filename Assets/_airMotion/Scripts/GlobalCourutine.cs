using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalCourutine : MonoBehaviour
{
    private static GlobalCourutine instance = null;
    private static UIManager UM;
    private Dictionary<string, string> CourutineList;


    public static GlobalCourutine Instance
    {
        get
        {
            if (!instance)
            {
                Debug.Log("return null instance");
                return null;
            }
            Debug.Log("return GC instance");
            return instance;
        }
    }




    private void Awake()
    {
        //GameObject game = gameObject.transform.Find("CourutineManager").gameObject;
        //if(game == null)
        //{
        //    GameObject CourutineManager = new GameObject("CourutineManager");
        //    CourutineManager.AddComponent<GlobalCourutine>();
        //}
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        InitValue();
    }

    public void AddCourutine(string Scene,string Courutine)//���ÿ� �ڷ�ƾ�� �Է��ϴ� �Լ�
    {
        //�ڷ�ƾ�� ����Ǿ��ϴ� ���� �̸��� �ڷ�ƾ�� �̸��� ����
        CourutineList.Add(Scene, Courutine);
    }

    public void CheckCourutine() //���ÿ� �ش��ϴ� �ڷ�ƾ�� �ִ��� Ȯ���ϴ� �Լ�
    {
        if (CourutineList.Count != 0)
        {
            foreach (KeyValuePair<string, string> stack in CourutineList)
            {
                if (SceneManager.GetActiveScene().name == stack.Key)
                {
                    Debug.Log(stack.Key);
                    string temp = stack.Value;
                    Home home = GameObject.Find("HomeManager").GetComponent<Home>();
                    if (stack.Value == "DirectSearch") StartCoroutine(home.DirectSearch());
                    if (stack.Value == "BackToVedio") StartCoroutine(home.BackToVedio());
                }
            }
            CourutineList.Remove(SceneManager.GetActiveScene().name);
        }
    }




    private void InitValue() //�ʱ�ȭ
    {
        if (UM == null) UM = UIManager.Instance;
        CourutineList = new Dictionary<string, string>();
       

    }
}
