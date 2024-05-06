using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AndroidShowAd : MonoBehaviour
{
    [SerializeField] GameObject attention;
    void OnEnable()
    {
            StartCoroutine(ShowAd());
    }
    IEnumerator ShowAd()
    {
        yield return new WaitForSeconds(0.5f);
        attention.SetActive(true);
        yield return new WaitForSeconds(2);
        if (!Appodeal.IsLoaded(AppodealAdType.Interstitial))
            yield return null;
        Appodeal.Show(AppodealAdType.Interstitial);
        yield return new WaitForSeconds(1);
        attention.SetActive(false);
        gameObject.SetActive(false);
    }
}
