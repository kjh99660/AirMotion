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
                GameObject.Find("GlobalCourutineManager").GetComponent<GlobalCourutine>().Awake();
            }
            return instance;
        }
    }

    // Update is called once per frame
    private void Awake()
    {
        InitValue();
    }
    public void AddCourutine(string Scene,string Courutine)
    {
        CourutineList.Add(Scene, Courutine);
    }

    private void InitValue()
    {
        if(CourutineList.Count != 0)
        {
            foreach(KeyValuePair<string, string> stack in CourutineList)
            {
                if(SceneManager.GetActiveScene().name == stack.Key)
                {
                    string temp = stack.Value;
                    StartCoroutine(temp);
                }
            }    
        }
       

    }
}
