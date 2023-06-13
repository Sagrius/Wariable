//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Advertisements;

//public class AdsInitializer : MonoBehaviour
//    //IUnityAdsLoadListener,IUnityAdsInitializationListener
//{
//    private const string AndroidAdsID = "5310432";
//    private const string UnityConnectedAndroidAdsID = "Rewarded_Android";


//    private const string UnityConnectedIOSAdsID = "Rewarded_Android";
//    private const string IOSAdsID = "5310433";
//    // Start is called before the first frame update
//    void Start()
//    {
//        Advertisement.Initialize(GetPlatformGameCode(),false, this);
//        Advertisement.Load(GetAdCode(),this);

//    }
//    public void OnInitializationComplete()
//    {

//        Debug.Log("Ads Working Muahahahhahahah");
//    }

//    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
//    {
//        throw new System.NotImplementedException();
//    }


//    public void OnUnityAdsAdLoaded(string placementId)
//    {
//        throw new System.NotImplementedException();
//    }

//    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
//    {
//        throw new System.NotImplementedException();
//    }

//    string GetPlatformGameCode()
//    {
//#if Unity_IOS
//    return IOSAdsID;

//#elif Unity_Android
//    return AndroidAdsID;
//#endif
//        return AndroidAdsID;
//    }
//    string GetAdCode()
//    {
//#if Unity_IOS
//    return UnityConnectedIOSAdsID; 

//#elif Unity_Android
//    return UnityConnectedAndroidAdsID;
//#endif
//        return UnityConnectedAndroidAdsID;
//    }
    

//}
