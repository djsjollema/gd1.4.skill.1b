using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTest : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button StopButton;
    [SerializeField] Button ContinueButton;

    [SerializeField] TextMeshProUGUI stopwatch;

    enum State { idle, wait, start, stop };
    State myState = State.idle;

    float time;
    float timeTreshold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClick);
        StopButton.onClick.AddListener(onStopButtonClick);
        ContinueButton.onClick.AddListener(OnContinueButtonClick);
        upDateUI();

        stopwatch.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(myState == State.wait)
        {
            time += Time.deltaTime;
            stopwatch.text = time.ToString("F2");
            if(time > timeTreshold)
            {
                myState = State.start;
                time = 0;
                upDateUI();
            }
        }

        if(myState == State.start) 
        {
            time += Time.deltaTime;
            stopwatch.text = time.ToString("F2");
            
        }
        
    }

    void OnStartButtonClick()
    {
        myState = State.wait;
        timeTreshold = Random.Range(2, 5);
    }

    void onStopButtonClick()
    {
        myState = State.stop;
        
    }

    void OnContinueButtonClick()
    {
        myState = State.idle;
    }

    void upDateUI()
    {
        StartButton.gameObject.SetActive(myState == State.idle);
        StopButton.gameObject.SetActive(myState == State.start);
        ContinueButton.gameObject.SetActive(myState == State.stop);
    }

}
