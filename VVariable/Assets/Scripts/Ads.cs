using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Ads : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    #region Variables

    private const string ANDROID_GAME_ID = "5333552";
    private const string ANDROID_REWARD_AD_ID = "Rewarded_Android";
    private const string IOS_GAME_ID = "5333553";
    private const string IOS_REWARD_AD_ID = "Rewarded_iOS";
    [SerializeField] private Button activateAdButton;
    private string currentTargetAdid;
    [SerializeField] private GameObject deathPanel;
    public static bool watchedAd = false;

    #endregion

    #region Show Ad
    public void ShowAd()
    {
        Advertisement.Show(currentTargetAdid, this);
    }

    #endregion

    #region Initialization

    public void OnInitializationComplete()
    {
        Debug.Log("Ads are ready!");
        currentTargetAdid = GetRewardedAdId();
        Advertisement.Load(currentTargetAdid, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError(error.ToString() + Environment.NewLine + message);
    }

    #endregion

    #region AdLoad

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad " + placementId + " is ready");
        activateAdButton.interactable = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError("Ad " + placementId + " did not load successfully " + Environment.NewLine + error + Environment.NewLine + message);
    }

    #endregion

    #region AdShow

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError("Ad " + placementId + " did not show successfully " + Environment.NewLine + error + Environment.NewLine + message);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("I Do something");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ad " + placementId + " finished " + showCompletionState);
        deathPanel.SetActive(false);
        watchedAd = true;
    }

    #endregion

    #region Get Region
    void Start()
    {
        Advertisement.Initialize(GetPlatformGameCode(), false, this);
    }

    #endregion

    #region GetPlatform
    string GetPlatformGameCode()
    {
#if UNITY_IOS
        return IOS_GAME_ID;
#elif UNITY_ANDROID
        return ANDROID_GAME_ID;
#endif
    }
    string GetRewardedAdId()
    {
#if UNITY_IOS
        return IOS_REWARD_AD_ID;
#elif UNITY_ANDROID
        return ANDROID_REWARD_AD_ID;
#endif
    }

    #endregion

}