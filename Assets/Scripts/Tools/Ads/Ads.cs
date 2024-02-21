//using System;
//using System.Collections;
//using System.Collections.Generic;
//using GoogleMobileAds.Api;
//using UnityEngine;

//namespace AdsUtils
//{
//    enum ShowResult
//    {
//        Finished,
//        Failed
//    }

//    /// <summary>
//    /// 广告管理类，已做好Android平台与iOS平台的广告id区分，只需要填写好AdsIdUtils中各项id即可。
//    /// </summary>
//    public class Ads : MonoBehaviour
//    {
//        private static Ads _instance = null;

//        public static Ads Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    GameObject go = new GameObject();
//                    go.name = "Ads";
//                    go.AddComponent<Ads>();
//                    Debug.LogError("Ads Instance  is null，already created..");
//                }

//                return _instance;
//            }
//        }


//        [Header("Admob")] public AdPosition bannerPosition;


//        // 广告的所有ID
//        private string admobAndroidBannerId;
//        private string admobAndroidInterId;
//        private string admobAndroidVideoId;

//        private string admobIosBannerId;
//        private string admobIosInterId;
//        private string admobIosVideoId;

//        // 是否是调试模式
//        public bool admobTestMode;
//        public string admobTestDevice = "B2DA0DD5650B5EF1ABB2674444A1F5F2";


//        // 是否使用测试id
//        [Header("Use Test ID")] public bool UseAdmobTestID;


//        [Header("InterAdConfig")] public InterAdConfig interConfig;
//        [Header("VideoAdWeights")] public int admobWeight = 1;

//        // 视频播放成功后的回调函数
//        private Action<bool> onVideoResult;

//        // 插页广告关闭后的回调
//        private Action onInterClose;

//        private readonly Dictionary<AdType, int> weightTypes = new Dictionary<AdType, int>(5);

//        //admob
//        private AdRequest admobBannerOptions, admobInterOptions, admobVideoOptions;
//        private BannerView banner;
//        private InterstitialAd inter;
//        private RewardBasedVideoAd reward;
//        private string admobVideoId, admobInterId;
//        private bool admobVideoFinished, admobVideoFailed, admobVideoLoadFailed, admobInterClose, admobInterLoadFailed;

//        //public bool AdsRemoved {
//        //    get { return PlayerPrefs.GetInt("AyoAds_Removed", 0) != 0; }
//        //    set {
//        //        PlayerPrefs.SetInt("AyoAds_Removed", value ? 1 : 0);
//        //        if (value) {
//        //            ShowAdmobBanner(false);
//        //            DestroyAdmobBanner();
//        //            if (inter != null) inter.Destroy();
//        //        }
//        //    }
//        //}

//        private void Awake()
//        {
//            _instance = this;
//            DontDestroyOnLoad(gameObject);

//            if (Application.platform == RuntimePlatform.WindowsEditor ||
//                Application.platform == RuntimePlatform.OSXEditor)
//                return;

//            //初始化广告id
//            InitAdsId();

//            //初始化admob
//            InitAdmob();

//            interConfig.Reset();
//        }

//        // 
//        private void InitAdsId()
//        {
//            if (UseAdmobTestID)
//            {
//                if (Application.platform == RuntimePlatform.Android)
//                {
//                    admobAndroidBannerId = AdsIdUtils.Banner_Id_Test_Android;
//                    admobAndroidInterId = AdsIdUtils.Inter_Id_Test_Android;
//                    admobAndroidVideoId = AdsIdUtils.Video_Id_Test_Android;
//                }

//                if (Application.platform == RuntimePlatform.IPhonePlayer)
//                {
//                    admobIosBannerId = AdsIdUtils.Banner_Id_Test_iOS;
//                    admobIosInterId = AdsIdUtils.Inter_Id_Test_iOS;
//                    admobIosVideoId = AdsIdUtils.Video_Id_Test_iOS;
//                }
//            }
//            else
//            {
//                if (Application.platform == RuntimePlatform.Android)
//                {
//                    //admobAndroidBannerId = AdsIdUtils.Banner_Android_Id;
//                    admobAndroidInterId = AdsIdUtils.Inter_Android_Id;
//                    admobAndroidVideoId = AdsIdUtils.Video_Android_Id;
//                }

//                if (Application.platform == RuntimePlatform.IPhonePlayer)
//                {
//                    //admobIosBannerId = AdsIdUtils.Banner_iOS_Id;
//                    admobIosInterId = AdsIdUtils.Inter_iOS_Id;
//                    admobIosVideoId = AdsIdUtils.Video_iOS_Id;
//                }
//            }
//        }

//        private void InitAdmob()
//        {
//            if (Application.platform == RuntimePlatform.Android)
//            {
//                // if (!string.IsNullOrEmpty(admobAndroidBannerID) && !AdsRemoved)

//                // 初始化广告的AppId
//                MobileAds.Initialize(AdsIdUtils.Android_App_Id);

//                if (!string.IsNullOrEmpty(admobAndroidBannerId))
//                {
//                    banner = new BannerView(admobAndroidBannerId, AdSize.Banner, bannerPosition);
//                    banner.Hide();
//                    banner.OnAdFailedToLoad += delegate (object sender, AdFailedToLoadEventArgs args)
//                    {
//                        Debug.LogWarning("Admob banner load failed: " + args.Message);
//                    };
//                }

//                // if (!string.IsNullOrEmpty(admobAndroidInterID) && !AdsRemoved) admobInterId = admobAndroidInterID;


//                if (!string.IsNullOrEmpty(admobAndroidInterId))
//                {
//                    admobInterId = admobAndroidInterId;
//                }

//                // 视频广告初始化
//                if (!string.IsNullOrEmpty(admobAndroidVideoId))
//                {
//                    reward = RewardBasedVideoAd.Instance;
//                    admobVideoId = admobAndroidVideoId;
//                }
//            }


//            // iOS平台
//            if (Application.platform == RuntimePlatform.IPhonePlayer)
//            {
//                // 初始化广告的AppId
//                MobileAds.Initialize(AdsIdUtils.iOS_App_Id);


//                // if (!string.IsNullOrEmpty(admobIosBannerID) && !AdsRemoved)
//                if (!string.IsNullOrEmpty(admobIosBannerId))
//                {
//                    banner = new BannerView(admobIosBannerId, AdSize.Banner, bannerPosition);
//                    // 初始化Banner不显示
//                    banner.Hide();
//                    banner.OnAdFailedToLoad += delegate (object sender, AdFailedToLoadEventArgs args)
//                    {
//                        Debug.LogWarning("Admob banner load failed: " + args.Message);
//                    };
//                }

//                if (!string.IsNullOrEmpty(admobIosInterId))
//                {
//                    admobInterId = admobIosInterId;
//                }

//                if (!string.IsNullOrEmpty(admobIosVideoId))
//                {
//                    reward = RewardBasedVideoAd.Instance;
//                    admobVideoId = admobIosVideoId;
//                }
//            }

//            var builder = new AdRequest.Builder();
//            if (admobTestMode)
//            {
//                builder.AddTestDevice(admobTestDevice);
//            }

//            admobBannerOptions = builder.Build();
//            admobInterOptions = builder.Build();
//            admobVideoOptions = builder.Build();
//            if (banner != null)
//            {
//                banner.LoadAd(admobBannerOptions);
//            }

//            // if (!AdsRemoved) LoadAdmobInter();
//            LoadAdmobInter();


//            // 激励视频广告，实例化几种委托的处理
//            if (reward != null)
//            {
//                // 广告视频关闭的委托
//                reward.OnAdClosed += delegate { admobVideoFailed = !admobVideoFinished; };

//                // 广告视频加载失败的原因的委托
//                reward.OnAdFailedToLoad += delegate (object sender, AdFailedToLoadEventArgs args)
//                {
//                    admobVideoLoadFailed = true;
//                    Debug.LogWarning("Admob reward load failed: " + args.Message);
//                };

//                // 广告视频播放完成后的委托 
//                reward.OnAdRewarded += delegate { admobVideoFinished = true; };
//                LoadAdmobVideo();
//            }
//        }

//        // 在Update方法中，处理每一个广告的不同状态的委托
//        private void Update()
//        {
//            // 插页广告加载失败的委托处理
//            if (admobInterLoadFailed)
//            {
//                this.RunDelay(LoadAdmobInter, 15);
//                admobInterLoadFailed = false;
//            }
//            // 插页广告关闭的委托。
//            else if (admobInterClose)
//            {
//                if (onInterClose != null) onInterClose();
//                interConfig.Reset();
//                this.RunDelay(LoadAdmobInter, 3);
//                admobInterClose = false;
//            }
//            // 视频广告加载失败，继续重新加载广告
//            else if (admobVideoLoadFailed)
//            {
//                this.RunDelay(LoadAdmobVideo, 20);
//                admobVideoLoadFailed = false;
//            }
//            // 视频广告播放成功后，执行的委托
//            else if (admobVideoFinished)
//            {
//                HandleShowResult(ShowResult.Finished);
//                this.RunDelay(LoadAdmobVideo, 5);
//                admobVideoFinished = false;
//            }
//            else if (admobVideoFailed)
//            {
//                this.RunDelay(LoadAdmobVideo, 5);
//                HandleShowResult(ShowResult.Failed);
//                admobVideoFailed = false;
//            }
//        }

//        private void HandleShowResult(ShowResult result)
//        {
//            switch (result)
//            {
//                case ShowResult.Finished:
//                    StartCoroutine(ResultCoroutine(onVideoResult, true));
//                    break;
//                default:
//                    StartCoroutine(ResultCoroutine(onVideoResult, false));
//                    break;
//            }
//        }

//        public bool VideoPrepared
//        {
//            get { return AdmobVideoEnable; }
//        }

//        // 参数内部传入的委托需要带1个bool类型的参数，该参数自动赋值的，如果为true则是播放成功，如果为false则是失败，这里只需要判断这个参数即可获得成功与失败
//        public void ShowVideo(Action<bool> callback)
//        {
//            onVideoResult = callback;
//            ShowAdmobVideo();
//        }

//        private IEnumerator ResultCoroutine(Action<bool> result, bool param)
//        {
//            yield return this.WaitForEndOfFrame();
//            if (result != null) result(param);
//        }

//        //Load Inter
//        private void LoadAdmobInter()
//        {
//            if (inter != null)
//            {
//                inter.Destroy();
//                inter = null;
//            }

//            if (!admobInterId.IsEmptyOrNull()) inter = new InterstitialAd(admobInterId);
//            if (inter != null)
//            {
//                inter.OnAdClosed += delegate { admobInterClose = true; };
//                inter.OnAdFailedToLoad += delegate (object sender, AdFailedToLoadEventArgs args)
//                {
//                    admobInterLoadFailed = true;
//                    Debug.LogWarning("Admob InterstitialAd load failed: " + args.Message);
//                };
//                inter.LoadAd(admobInterOptions);
//            }
//        }

//        private void LoadAdmobVideo()
//        {
//            reward.LoadAd(admobVideoOptions, admobVideoId);
//        }

//        //Enable
//        public bool InterAdEnable(bool addRound = true)
//        {
//            if (addRound) interConfig.AddRound();
//            return interConfig.Enable() && inter != null && inter.IsLoaded();
//        }

//        public bool AdmobVideoEnable
//        {
//            get
//            {
//                var enable = reward != null && reward.IsLoaded();
//                weightTypes[AdType.admob] = enable ? admobWeight : 0;
//                return enable;
//            }
//        }

//        public void ShowInterAd(Action onResult = null)
//        {
//            if (Application.platform == RuntimePlatform.WindowsEditor ||
//                Application.platform == RuntimePlatform.OSXEditor)
//                return;

//            // if (AdsRemoved && onResult != null) {
//            //if (onResult != null)
//            //{
//            //    onResult();
//            //    return;
//            //}
//            onInterClose = onResult;
//            if (inter.IsLoaded())
//            {
//                AudioController.Instance.BGMPause();
//                inter.Show();
//            }
//        }

//        public void ShowAdmobBanner(bool show)
//        {
//            if (Application.platform == RuntimePlatform.WindowsEditor ||
//                Application.platform == RuntimePlatform.OSXEditor)
//                return;

//            if (banner != null)
//            {
//                if (show) banner.Show();
//                else banner.Hide();
//            }
//        }

//        private void ShowAdmobVideo()
//        {
//            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
//                return;

//            if (reward != null && reward.IsLoaded())
//            {
//                reward.Show();
//                AudioController.Instance.BGMPause();
//            }
//        }

//        //Destroy
//        public void DestroyAdmobBanner()
//        {
//            if (banner != null) banner.Destroy();
//            banner = null;
//        }

//        /// <summary>
//        ///展示广告，如果有视频广告就展示视频广告，如果没有视频广告就展示插页广告。播放广告"成功"时，背景音乐暂停，播放成功后回调可以选择恢复背景音乐播放。 
//        /// </summary>
//        /// <param name="VideoFinshedCallback"> 视频广告播放完成的回调函数，其参数布尔类型变量是用来判断是否播放完成视频的，用来做判断的</param>
//        /// <param name="InnerFinshedCallback"> 插页广告播放完成的回调函数</param>
//        public void AutoShowAds(Action<bool> VideoFinshedCallback, Action InnerFinshedCallback = null)
//        {
//            if (VideoPrepared)
//            {
//                ShowVideo(VideoFinshedCallback);
//            }
//            else
//            {
//                ShowInterAd(InnerFinshedCallback);
//            }
//        }
//    }

//    public enum AdType
//    {
//        admob
//    }

//    [Serializable]
//    public class InterAdConfig
//    {
//        public int roundInterval;
//        public float timeInterval;

//        public int Round { get; private set; }

//        public float LastTime { get; private set; }

//        public void AddRound()
//        {
//            Round++;
//        }

//        public void Reset()
//        {
//            Round = 0;
//            LastTime = Time.realtimeSinceStartup;
//        }

//        public bool Enable()
//        {
//            return Round >= roundInterval && Time.realtimeSinceStartup - LastTime >= timeInterval;
//        }
//    }
//}