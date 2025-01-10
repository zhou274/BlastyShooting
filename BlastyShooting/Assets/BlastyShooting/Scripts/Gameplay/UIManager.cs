using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using OnefallGames;
using UnityEngine.UI;
using TMPro;
<<<<<<< HEAD
using TTSDK.UNBridgeLib.LitJson;
using TTSDK;
using StarkSDKSpace;
using System.Collections.Generic;
=======
>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c

public class UIManager : MonoBehaviour {
    public static UIManager Instance { private set; get; }


    //Gameplay UI
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI coinsTxt;
    [SerializeField] private TextMeshProUGUI missileTxt;
    [SerializeField] private TextMeshProUGUI bombTxt;
    [SerializeField] private TextMeshProUGUI laserTxt;

    //Revive UI
    [SerializeField] private GameObject reviveUI;
    [SerializeField] private Image reviveCoverImg;

    //Game over UI
    [SerializeField]private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI bestScoreTxt;
    [SerializeField] private GameObject gameName;
    [SerializeField] private RawImage shareImage;
    [SerializeField] private Button dailyRewardBtn;
    [SerializeField] private Text dailyRewardTxt;
    [SerializeField] private GameObject watchAdForCoinsBtn;
    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject restartBtn;
    //[SerializeField] private GameObject shareBtn;
    [SerializeField] private GameObject soundOnBtn;
    [SerializeField] private GameObject soundOffBtn;
    [SerializeField] private Animator servicesUIAnim;
    [SerializeField] private Animator settingUIAnim;
    [SerializeField] private AnimationClip servicesUI_Show;
    [SerializeField] private AnimationClip servicesUI_Hide;
    [SerializeField] private AnimationClip settingUI_Show;
    [SerializeField] private AnimationClip settingUi_Hide;
    [SerializeField] private RewardedCoinsController rewardCoinsControl;
    [SerializeField] private RectTransform coinImgTrans;
    [SerializeField] private GameObject shop;
<<<<<<< HEAD

    public string clickid;
    private StarkAdManager starkAdManager;
=======
>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c
    private void OnEnable()
    {
        GameManager.GameStateChanged += GameManager_GameStateChanged;
    }


    private void OnDisable()
    {
        GameManager.GameStateChanged -= GameManager_GameStateChanged;
    }

    private void GameManager_GameStateChanged(GameState obj)
    {
        if (obj == GameState.Revive)
        {
            reviveUI.SetActive(true);
            StartCoroutine(ReviveCountDown());
        }
        else if (obj == GameState.GameOver)
        {
            Invoke("ShowGameOverUI", 0.5f);
        }
        else if (obj == GameState.Playing)
        {
            gameplayUI.SetActive(true);
            gameOverUI.SetActive(false);
            reviveUI.SetActive(false);
            rewardCoinsControl.gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(Instance.gameObject);
            Instance = this;
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }




    // Use this for initialization
    void Start () {

    
        if (!GameManager.isRestart) //This is the first load
        {
            gameplayUI.SetActive(false);
            reviveUI.SetActive(false);
            rewardCoinsControl.gameObject.SetActive(false);

            shareImage.gameObject.SetActive(false);
            bestScoreTxt.gameObject.SetActive(false);
            restartBtn.SetActive(false);
            watchAdForCoinsBtn.SetActive(false);
            dailyRewardBtn.gameObject.SetActive(false);
            //shareBtn.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        UpdateMuteButtons();

        scoreTxt.text = ScoreManager.Instance.Score.ToString();
        bestScoreTxt.text = "Best: " + ScoreManager.Instance.BestScore.ToString();
        coinsTxt.text = CoinManager.Instance.Coins.ToString();

        missileTxt.text = ItemsManager.Instance.Missiles.ToString();
        bombTxt.text = ItemsManager.Instance.Bombs.ToString();
        laserTxt.text = ItemsManager.Instance.Lasers.ToString();

        if(DailyRewardManager.Instance.CanRewardNow())
        {
            dailyRewardTxt.text = "Grap";
            dailyRewardBtn.interactable = true;
        }
        else
        {
            string hours = DailyRewardManager.Instance.TimeUntilNextReward.Hours.ToString();
            string minutes = DailyRewardManager.Instance.TimeUntilNextReward.Minutes.ToString();
            string seconds = DailyRewardManager.Instance.TimeUntilNextReward.Seconds.ToString();
            dailyRewardTxt.text = hours + ":" + minutes + ":" + seconds;
            dailyRewardBtn.interactable = false;
        }

	}


    ////////////////////////////Publish functions

    public void PlayButtonSound()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
    }

    public void MissileBtn()
    {
        GameManager.Instance.CreateMissile(PlayerController.Instance.transform.position);
    }

    public void BombBtn()
    {
        GameManager.Instance.CreateBomb(PlayerController.Instance.transform.position);
    }
    
    public void LaserBtn()
    {
        GameManager.Instance.CreateLaser(PlayerController.Instance.transform.position);
    }
  
    public void ToggleSound()
    {
        SoundManager.Instance.ToggleMute();
    }

    public void ShareBtn()
    {
        ShareManager.Instance.ShareScreenshotWithText();
    }

    public void RateAppBtn()
    {
        Application.OpenURL(ShareManager.Instance.AppUrl);
    }

    //public void FacebookBtn()
    //{
    //    FacebookManager.Instance.FacebookShare();
    //}
    public void ShowShop()
    {
        shop.SetActive(true);
    }
    public void AddCoins()
    {
<<<<<<< HEAD
        ShowVideoAd("5oca3adamfl13gulps",
            (bol) => {
                if (bol)
                {

                    CoinManager.Instance.AddCoins(50);


                    clickid = "";
                    getClickid();
                    apiSend("game_addiction", clickid);
                    apiSend("lt_roi", clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });
        
=======
        CoinManager.Instance.AddCoins(50);
>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c
    }
    public void PlayBtn()
    {
        playBtn.SetActive(false);
        gameOverUI.SetActive(false);

        gameplayUI.SetActive(true);

        GameManager.Instance.PlayingGame();
    }

    public void RestartBtn(float delay)
    {
        GameManager.Instance.LoadScene(SceneManager.GetActiveScene().name, delay);
    }

    public void SettingBtn()
    {
        settingUIAnim.Play(settingUI_Show.name);
        servicesUIAnim.Play(servicesUI_Hide.name);
    }

    public void BackBtn()
    {
        settingUIAnim.Play(settingUi_Hide.name);
        servicesUIAnim.Play(servicesUI_Show.name);
    }

    public void DailyRewardBtn()
    {
        DailyRewardManager.Instance.ResetNextRewardTime();
        StartReward(0.5f, DailyRewardManager.Instance.GetRandomReward());
    }


    public void WatchAdForCoinsBtn()
    {
        watchAdForCoinsBtn.SetActive(false);
        AdManager.Instance.ShowRewardedVideoAd();
    }

    public void ReviveBtn()
    {
        reviveUI.SetActive(false);
        AdManager.Instance.ShowRewardedVideoAd();
    }

    //继续游戏
    public void Continue()
    {
        //清空小球

        //关闭UI
<<<<<<< HEAD
        ShowVideoAd("5oca3adamfl13gulps",
            (bol) => {
                if (bol)
                {

                    GameManager.isRestart = true;
                    GameManager.Instance.PrepareGame();


                    clickid = "";
                    getClickid();
                    apiSend("game_addiction", clickid);
                    apiSend("lt_roi", clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });
        //返回游戏状态
        
=======

        //返回游戏状态
        GameManager.isRestart = true;
        GameManager.Instance.PrepareGame();
>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c
    }

    public void SkipBtn()
    {
        GameManager.Instance.GameOver();
    }

    public void UpgradeBtn()
    {
        GameManager.Instance.LoadScene("Upgrade", 0.5f);
    }

    public void CharacterBtn()
    {
        GameManager.Instance.LoadScene("Character", 0.5f);
    }


    /////////////////////////////Private functions
    void UpdateMuteButtons()
    {
        if (SoundManager.Instance.IsMuted())
        {
            soundOnBtn.gameObject.SetActive(false);
            soundOffBtn.gameObject.SetActive(true);
        }
        else
        {
            soundOnBtn.gameObject.SetActive(true);
            soundOffBtn.gameObject.SetActive(false);
        }
    }

    void ShowGameOverUI()
    {
<<<<<<< HEAD

        Debug.Log("--ShowGameOverUI--");

=======
>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c
        gameplayUI.SetActive(false);
        reviveUI.SetActive(false);
        rewardCoinsControl.gameObject.SetActive(false);
        gameOverUI.SetActive(true);

        bestScoreTxt.gameObject.SetActive(true);
        gameName.SetActive(false);
        //shareImage.gameObject.SetActive(true);
<<<<<<< HEAD
        //shareImage.texture = GameManager.Instance.LoadedScrenshot();
=======
        shareImage.texture = GameManager.Instance.LoadedScrenshot();
>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c

        playBtn.SetActive(false);
        restartBtn.SetActive(true);

        dailyRewardBtn.gameObject.SetActive(true);
        watchAdForCoinsBtn.SetActive(AdManager.Instance.IsRewardedVideoAdReady());

        //shareBtn.SetActive(true);
<<<<<<< HEAD


        Debug.Log("--显示插屏--");

        ShowInterstitialAd("236doicfenh32awv3h",
            () => {

            },
            (it, str) => {
                Debug.LogError("Error->" + str);
            });
    }
    
=======
    }

>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c
    IEnumerator ReviveCountDown()
    {
        float t = 0;
        while (t < GameManager.Instance.reviveCountDownTime)
        {
            if (!reviveUI.activeInHierarchy)
                yield break;
            t += Time.deltaTime;
            float factor = t / GameManager.Instance.reviveCountDownTime;
            reviveCoverImg.fillAmount = Mathf.Lerp(1, 0, factor);
            yield return null;
        }
        reviveUI.SetActive(false);
        GameManager.Instance.GameOver();
    }




    public void StartReward(float delay, int coins)
    {
        StartCoroutine(RewardingCoins(delay, coins));
    }
    IEnumerator RewardingCoins(float delay, int coins)
    {
        yield return new WaitForSeconds(delay);
        rewardCoinsControl.gameObject.SetActive(true);
        rewardCoinsControl.StartReward(coins);
    }


    public Vector2 GetCoinImgWorldPos()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(coinImgTrans.position);
        return worldPos;
    }
<<<<<<< HEAD



    public void getClickid()
    {
        var launchOpt = StarkSDK.API.GetLaunchOptionsSync();
        if (launchOpt.Query != null)
        {
            foreach (KeyValuePair<string, string> kv in launchOpt.Query)
                if (kv.Value != null)
                {
                    Debug.Log(kv.Key + "<-参数-> " + kv.Value);
                    if (kv.Key.ToString() == "clickid")
                    {
                        clickid = kv.Value.ToString();
                    }
                }
                else
                {
                    Debug.Log(kv.Key + "<-参数-> " + "null ");
                }
        }
    }

    public void apiSend(string eventname, string clickid)
    {
        TTRequest.InnerOptions options = new TTRequest.InnerOptions();
        options.Header["content-type"] = "application/json";
        options.Method = "POST";

        JsonData data1 = new JsonData();

        data1["event_type"] = eventname;
        data1["context"] = new JsonData();
        data1["context"]["ad"] = new JsonData();
        data1["context"]["ad"]["callback"] = clickid;

        Debug.Log("<-data1-> " + data1.ToJson());

        options.Data = data1.ToJson();

        TT.Request("https://analytics.oceanengine.com/api/v2/conversion", options,
           response => { Debug.Log(response); },
           response => { Debug.Log(response); });
    }


    /// <summary>
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="closeCallBack"></param>
    /// <param name="errorCallBack"></param>
    public void ShowVideoAd(string adId, System.Action<bool> closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            starkAdManager.ShowVideoAdWithId(adId, closeCallBack, errorCallBack);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="adId"></param>
    /// <param name="errorCallBack"></param>
    /// <param name="closeCallBack"></param>
    public void ShowInterstitialAd(string adId, System.Action closeCallBack, System.Action<int, string> errorCallBack)
    {
        starkAdManager = StarkSDK.API.GetStarkAdManager();
        if (starkAdManager != null)
        {
            var mInterstitialAd = starkAdManager.CreateInterstitialAd(adId, errorCallBack, closeCallBack);
            mInterstitialAd.Load();
            mInterstitialAd.Show();
        }
    }
=======
>>>>>>> 2d72c77c35b5ee768af4b6106720787f61d47c4c
}
