# SDK-Dev-Demo
## About
* All advertisement system is under Assets/AdvertisementSystem folder(Except for AppLovin Meditation settings SO).

* By injecting the IAdvertisementSystem interface through Zenject, the user can perform simple advertisement display functions without mastering the internal structure of the meditation tool.

* In order to add new Meditation platforms, the user should write a System script inherited from IAdvertisementSystem and different format scripts inherited from IAdFormat for different Ad types.
Then it should bind the new Scripts in AdvertisementSystemInstaller.
For the Editor window side, the scripts under the AdvertisementSyste/Editor folder and the AdvertisementSystem/Core/Installers/ folder can be examined.

* There is a sample scene under Assets/AdvertisementSystem/Sample.
Ad units such as banner, interstitial, rewarded can be tested in the sample scene.

* The Build APK file does not work without a VPN, and the Test Ad network must be selected through the AppLovin Max Meditation Debugger at the first launch of the application.

* If someone wants to set settings like SDK key or Ad Unit Id's they can use MenuItem Called MeditationSettings/ApplovinSettings.

* This project heavily relies on Zenject, and some parts of it uses UniTask.
