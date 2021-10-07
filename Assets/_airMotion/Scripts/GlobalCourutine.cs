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
    public void AddCourutine(string Scene,string Courutine)//스택에 코루틴을 입력하는 함수
    {
        //코루틴이 실행되야하는 씬의 이름과 코루틴의 이름이 들어간다
        CourutineList.Add(Scene, Courutine);
    }
    public void StartCourutine() //스택에 해당하는 코루틴이 있는지 확인하는 함수
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
        //초기화

    }
}
