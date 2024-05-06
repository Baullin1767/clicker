using UnityEngine;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
public class AppodealInit : MonoBehaviour
{
    [SerializeField] string appKey = "574f63e24e413cb1b9080907ca4db2074f75c49ad6985e3c";
    private void Start()
    {
        int adTypes = AppodealAdType.Interstitial;
        AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
        Appodeal.Initialize(appKey, adTypes);
    }

    public void OnInitializationFinished(object sender, SdkInitializedEventArgs e) { }
}
