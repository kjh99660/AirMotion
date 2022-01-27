using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_search : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Off());
    }
    IEnumerator Off()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        gameObject.SetActive(false);
    }
}
