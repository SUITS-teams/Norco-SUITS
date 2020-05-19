using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Microsoft.CognitiveServices.Speech;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class AzureSpeechCommands : MonoBehaviour {
    // Hook up the two properties below with a Text and Button object in your UI.
    public Text outputText;
    public GameObject settingsPanel;
    public GameObject telemetryPanel;

    private object threadLocker = new object();
    private bool waitingForReco;
    private string message;

    private bool micPermissionGranted = false;

    private bool isListening = false;
    private bool isSettingsOpen = false;
    private bool isTelemetryOpen = false;
    private AudioSource audio;

#if PLATFORM_ANDROID
    // Required to manifest microphone permission, cf.
    // https://docs.unity3d.com/Manual/android-manifest.html
    private Microphone mic;
#endif

    public async void ButtonClick () {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        //Austin old key: 54e0eef1e76c4a289d8e55ed7826b5f0
        var config = SpeechConfig.FromSubscription ("5e8ed8bd7bab471aa4f8ea96c4ef902a", "westus");

        // Make sure to dispose the recognizer after use!
        using (var recognizer = new SpeechRecognizer (config)) {
            lock (threadLocker) {
                waitingForReco = true;
            }

            // Starts speech recognition, and returns after a single utterance is recognized. The end of a
            // single utterance is determined by listening for silence at the end or until a maximum of 15
            // seconds of audio is processed.  The task returns the recognition text as result.
            // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
            // shot recognition like command or query.
            // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
            var result = await recognizer.RecognizeOnceAsync ().ConfigureAwait (false);

            // Checks result.
            string newMessage = string.Empty;
            if (result.Reason == ResultReason.RecognizedSpeech) {
                newMessage = result.Text;
            } else if (result.Reason == ResultReason.NoMatch) {
                newMessage = "NOMATCH: Speech could not be recognized.";
            } else if (result.Reason == ResultReason.Canceled) {
                var cancellation = CancellationDetails.FromResult (result);
                newMessage = $"CANCELED: Reason={cancellation.Reason} ErrorDetails={cancellation.ErrorDetails}";
            }

            lock (threadLocker) {
                message = newMessage;
                waitingForReco = false;
            }
        }
    }

    void Start () {
        audio = gameObject.AddComponent <AudioSource> ();
            // Continue with normal initialization, Text and Button objects are present.
#if PLATFORM_ANDROID
            // Request to use the microphone, cf.
            // https://docs.unity3d.com/Manual/android-RequestingPermissions.html
            message = "Waiting for mic permission";
            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                Permission.RequestUserPermission(Permission.Microphone);
            }
#endif
/*#else
            micPermissionGranted = true;
            message = "Click button to recognize speech";
#endif
            startRecoButton.onClick.AddListener(ButtonClick);*/
        micPermissionGranted = true;
        StartCoroutine (DetectSpeech ());
    }

    void Update () {
/*#if PLATFORM_ANDROID
        if (!micPermissionGranted && Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            micPermissionGranted = true;
            message = "Click button to recognize speech";
        }
#endif*/
        if (outputText != null) {
            outputText.text = message;
            if (message.ToLower ().Contains ("jarvis") && isListening == false) {
                isListening = true;
                ActivateJarvis ();
            }
            if (message.ToLower ().Contains ("settings") && isSettingsOpen == false && !message.ToLower ().Contains ("close") && isListening == true) {
                settingsPanel.SetActive (true);
                isSettingsOpen = true;
                audio.PlayOneShot ((AudioClip) Resources.Load ("settingsAvailable"));
            }
            if (message.ToLower ().Contains ("close") && isSettingsOpen == true) {
                settingsPanel.SetActive (false);
                CompletedAction ();
                isListening = false;
                isSettingsOpen = false;
            }
            if (message.ToLower ().Contains ("telemetry") && isTelemetryOpen == false && !message.ToLower ().Contains ("close") && isListening == true) {
                telemetryPanel.SetActive (true);
                isTelemetryOpen = true;
                CompletedAction ();
            }
            if (message.ToLower ().Contains ("close") && isTelemetryOpen == true) {
                telemetryPanel.SetActive (false);
                CompletedAction ();
                isListening = false;
                isTelemetryOpen = false;
            }
            if (message.ToLower ().Contains ("oxygen") && isListening == true) {
                int ranOxy = Random.Range (1, 101);
                Debug.Log (ranOxy);
                JarvisPercentage (ranOxy);
                isListening = false;
            }
        }
    }

    void ActivateJarvis () {
        int rannum = Random.Range (0, 3);
        if (rannum == 0) {
            audio.PlayOneShot ((AudioClip) Resources.Load ("atYourService"));
        }
        if (rannum == 1) {
            audio.PlayOneShot ((AudioClip) Resources.Load ("greetingsSir"));
        }
        if (rannum == 2) {
            audio.PlayOneShot ((AudioClip) Resources.Load ("ifYouNeedAnything"));
        }
    }

    void CompletedAction () {
        int rannum = Random.Range (0, 4);
        if (rannum == 0) {
            audio.PlayOneShot ((AudioClip) Resources.Load ("done"));
        }
        if (rannum == 1) {
            audio.PlayOneShot ((AudioClip) Resources.Load ("enjoy"));
        }
        if (rannum == 2) {
            audio.PlayOneShot ((AudioClip) Resources.Load ("myPleasure"));
        }
        if (rannum == 3) {
            audio.PlayOneShot ((AudioClip) Resources.Load ("asYouWish"));
        }
    }

    void JarvisPercentage (int numberToSay) {
        string number = numberToSay.ToString ();

        //1 Digit
        if (number.Length == 1) {
            JarvisSaySingleDigit (System.Convert.ToInt32 (number));
        }

        //2 Digits
        if (number.Length == 2) {
            //Tens place
            if (number == "10") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("10"));
            }
            if (number == "11") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("11"));
            }
            if (number == "12") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("12"));
            }
            if (number == "13") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("13"));
            }
            if (number == "14") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("14"));
            }
            if (number == "15") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("15"));
            }
            if (number == "16") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("16"));
            }
            if (number == "17") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("17"));
            }
            if (number == "18") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("18"));
            }
            if (number == "19") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("19"));
            }
            if (number[0].ToString () == "2") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("20"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
            if (number[0].ToString () == "3") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("30"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
            if (number[0].ToString () == "4") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("40"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
            if (number[0].ToString () == "5") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("50"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
            if (number[0].ToString () == "6") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("60"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
            if (number[0].ToString () == "7") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("70"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
            if (number[0].ToString () == "8") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("80"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
            if (number[0].ToString () == "9") {
                audio.PlayOneShot ((AudioClip) Resources.Load ("90"));
                JarvisSaySingleDigit (System.Convert.ToInt32 (number[1]));
            }
        }

        //3 Digitd
        if (number == "100") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("100"));
        }

        StartCoroutine (SayPercent ());
    }

    void JarvisSaySingleDigit (int digit) {
        Debug.Log (digit);
        if (digit.ToString () == "1") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("1"));
        } else if (digit.ToString () == "2") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("2"));
        } else if (digit.ToString () == "3") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("3"));
        } else if (digit.ToString () == "4") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("4"));
        } else if (digit.ToString () == "5") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("5"));
        } else if (digit.ToString () == "6") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("6"));
        } else if (digit.ToString () == "7") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("7"));
        } else if (digit.ToString () == "8") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("8"));
        } else if (digit.ToString () == "9") {
            audio.PlayOneShot ((AudioClip) Resources.Load ("9"));
        }
    }

    IEnumerator SayPercent () {
        yield return new WaitForSeconds (1f);
        audio.PlayOneShot ((AudioClip) Resources.Load ("percent"));
    }

    IEnumerator DetectSpeech () {
        yield return new WaitForSeconds (1f);
        ButtonClick ();
        StartCoroutine (DetectSpeech ());
    }
}