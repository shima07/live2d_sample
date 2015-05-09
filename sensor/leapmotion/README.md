# TestScript.cs

## 概要
Live2D SDKに入っているSampleApp1にLeapMotionをつないで機能を追加してみます  

## 機能
Leap Motionの値を利用してキャラにタッチできるようにする


## 使い方
LeapMotionのsetupをする  
LeapMotion_CoreAsset_2_2_4.unitypackageをインポート(Unity4.6とかだとエラーがでる,Unity5以上で  
Projectに追加されたLeapMotion/Prefabs/HandControllerをHierarchyに追加

HandControllerのPositionをX=0,Y=-10,Z=-7に設定  
Hand Movement Scale X=5,Y=3,Z=3に設定

実行してモデルの前に手が表示されていることを確認

TestScript.csをプロジェクトにコピー  
MainCameraとかにアタッチして実行
