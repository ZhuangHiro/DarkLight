using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTools  {


    private static NetworkTools instance = null;
    public static NetworkTools GetInstance()
    {
        if (instance == null)
        {
            instance = new NetworkTools();
        }

        return instance;
    }

    /// <summary>
    /// 有网络的时候返回true，无网络返回false
    /// </summary>
    /// <returns></returns>
    public bool isConnectNewwork()
    {
        //当网络不可用时              
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        //当用户有网
        if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork 
            || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            return true;
        }                 
        return false;
    }
}
