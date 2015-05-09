using UnityEngine;
using System.Collections;
using Leap;

public class TestScript : MonoBehaviour {
	Controller controller;

	void Start ()
	{
		controller = new Controller();
		//gesture
		controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
		controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
		controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
		controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
	}
	
	void Update ()
	{
		Frame frame = controller.Frame();
		// do something with the tracking data in the frame...
		if (! frame.Hands.IsEmpty) {
			var hand = frame.Hands[0];
			var gestures = frame.Gestures();

			for (int i = 0; i < hand.Fingers.Count; i++) {
				//人差し指
				if (hand.Fingers[i].Type() == Finger.FingerType.TYPE_INDEX){
					//Debug.Log (hand.Fingers[i].TipPosition.x);
					var fingerPosition = hand.Fingers[i].TipPosition;

					for ( int gi = 0 ; gi < gestures.Count ; gi++ ) {
						// ジェスチャー結果取得＆表示
						Gesture gesture = gestures[gi];
						switch ( gesture.Type ) {
						case Gesture.GestureType.TYPECIRCLE:
							var circleGesture = new CircleGesture(gesture);
							Debug.Log("Circle");
							if(circleGesture.State == Gesture.GestureState.STATEUPDATE){
								//そっちを向かせる（ドラッグと同じ
								LAppLive2DManager.Instance.TouchesMoved(new Vector3((fingerPosition.x-20.0f+(UnityEngine.Screen.width/2)),(fingerPosition.y*2 - (UnityEngine.Screen.height)/2),0));
							}
							break;
						case Gesture.GestureType.TYPEKEYTAP:
							var keytapGesture = new KeyTapGesture(gesture);
							Debug.Log("KeyTap");
							if(keytapGesture.State == Gesture.GestureState.STATESTOP){
								//Debug.Log (fingerPosition.x+","+fingerPosition.y+","+fingerPosition.z);
								//20.0fはx軸に対するずれ軽減用
								LAppLive2DManager.Instance.TouchesEnded(new Vector3((fingerPosition.x-20.0f+(UnityEngine.Screen.width/2)),(fingerPosition.y*2 - (UnityEngine.Screen.height)/2),0));
							}
							break;
						case Gesture.GestureType.TYPESCREENTAP:
							var screenTapGesture = new ScreenTapGesture(gesture);
							Debug.Log("ScreenTap");
							break;
						case Gesture.GestureType.TYPE_SWIPE:
							var swipeGesture = new SwipeGesture(gesture);
							Debug.Log("Swipe");
							//LAppLive2DManager.Instance.ChangeModel(); //モデル変更
							break;
						default:
							break;
						}
					}

				}
			}

		}
	}
}