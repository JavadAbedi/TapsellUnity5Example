using UnityEngine;
using System;
using System.Collections.Generic;

public class DeveloperCtaInterface{
	public static int ALL_AD = 0;
	public static int PAY_PER_INSTALL = 1;
	public static int PAY_PER_CHARGE = 2;
	public static int VIDEO_PLAY = 3;
	public static int WEB_VIEW = 4;
	Dictionary<int, Action<Boolean, Boolean>> actionPool = new Dictionary<int, Action<Boolean, Boolean>>();
	Action<Boolean, Boolean, int> directAdAction;
	Action<int> getUserInfoAction;
	int MAX_TYPE_COUNT = 100;
	static DeveloperCtaInterface instance;
	AndroidJavaObject developerCtaInterface;

	public static DeveloperCtaInterface getInstance(){
		if (instance == null) {
			instance = new DeveloperCtaInterface ();
			instance.setJavaObject();
		}
		return instance;
	}
	
	public void setJavaObject(){
		AndroidJavaClass jc = new AndroidJavaClass("ir.tapsell.tapselldevelopersdk.developer.DeveloperCtaInterface");
		developerCtaInterface = jc.CallStatic<AndroidJavaObject>("getInstance");
	}

	public void checkCtaAvailability(int type, int minimumAward, Boolean isDirect, Action<Boolean, Boolean> action){
		developerCtaInterface.Call("checkCtaAvailability", type, minimumAward, isDirect);
		if (actionPool.ContainsKey (minimumAward * MAX_TYPE_COUNT + type))
			actionPool.Remove (minimumAward * MAX_TYPE_COUNT + type);
		actionPool.Add (minimumAward * MAX_TYPE_COUNT + type, action);
	}

	public void getUserInfo(Action<int> action){
		developerCtaInterface.Call("getUserInfo");
		getUserInfoAction = action;
	}

	public void showNewCta(int type, int minimumAward, Action<Boolean, Boolean, int> action){
		developerCtaInterface.Call("showNewCta", type, minimumAward);
		directAdAction = action;
	}

	public void notifyGetUserInfo(String userTapCoinAmountStr){
		Int32 userTapCoinAmount = Int32.Parse(userTapCoinAmountStr);
		getUserInfoAction (userTapCoinAmount);
	}

	public void notifyCtaAvailability(String ans){
		Boolean first, second;
		if (ans.Length == 0) {
			return;
		}
		first = setBoolState (ans [0]);
		second = setBoolState (ans [1]);
		String str = ans.Substring (2);
		Int32 key = Int32.Parse(str);
		if (actionPool.ContainsKey(key)){
			actionPool[key](first, second);
		}
	}

	public void notifyDirectAd(String ans){
		Boolean first, second;
		if (ans.Length == 0) {
			directAdAction(false, false, 0);
			return;
		}
		first = setBoolState (ans [0]);
		second = setBoolState (ans [1]);
		String str = ans.Substring (2);
		Int32 award = Int32.Parse(str);
		directAdAction(first, second, award);
	}

	private Boolean setBoolState(Char chr){
		return (chr == 't');
	}
}
