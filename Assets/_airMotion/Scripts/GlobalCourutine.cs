using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalCourutine : MonoBehaviour
{
    private static GlobalCourutine instance = null;
    private Dictionary<string, string> CourutineList = new Dictionary<string, string>();
    public static GlobalCourutine Instance
    {
        get
        {
            if (!instance)
            {
                return null;
            }
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
    public void StartCourutine() //���ÿ� �ش��ϴ� �ڷ�ƾ�� �ִ��� Ȯ���ϴ� �Լ�
    {
        if (CourutineList.Count != 0)
        {
            foreach (KeyValuePair<string, string> stack in CourutineList)
            {
                if (SceneManager.GetActiveScene().name == stack.Key)
                {
                    string temp = stack.Value;
                    StartCoroutine(temp);
                }
            }
        }
    }

    private void InitValue()
    {
        //�ʱ�ȭ

    }
}
