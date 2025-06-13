using UnityEngine;
using TMPro;

public class ToAndFro : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform player;

    Vector3 differenceVector;
    float distance;
    Vector3 direction;
    [SerializeField] TextMeshProUGUI stopwatch;

    float time = 0;
    float duration;
    bool FromAToB = true;

    void Start()
    {
        player.position = A.position;
    }

    void Update()
    {
        if (FromAToB)
        {
            differenceVector = B.position - A.position;
        }
        else
        {
            differenceVector = A.position - B.position;
        }
        
        distance = differenceVector.magnitude;
        duration = distance / 1;
        direction = differenceVector.normalized;

        player.position += direction * Time.deltaTime ; 
        time += Time.deltaTime;
        stopwatch.text = time.ToString("F3");

        if(time > duration)
        {
            FromAToB = !FromAToB;
            time = 0;
        }
    }
}
