using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] TMP_Text scoreText;
    private FallTrigger[] pins;

    void Start() {
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in pins) {
            pin.OnPinFall.AddListener(IncrementScore);
        } 
    }
    public void IncrementScore() {
        score++;
        scoreText.text = $"Score: {score:0000}";
    }
        
}
