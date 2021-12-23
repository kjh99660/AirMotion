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

    public void AddCourutine(string Scene,string Courutine)//스택에 코루틴을 입력하는 함수
    {
        //코루틴이 실행되야하는 씬의 이름과 코루틴의 이름이 들어간다
        CourutineList.Add(Scene, Courutine);
    }

    public void CheckCourutine() //스택에 해당하는 코루틴이 있는지 확인하는 함수
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




    private void InitValue() //초기화
    {
        if (UM == null) UM = UIManager.Instance;
        CourutineList = new Dictionary<string, string>();
       

    }
}
