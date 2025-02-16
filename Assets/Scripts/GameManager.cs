using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private BallController ball;

    [SerializeField] TMP_Text scoreText;

    [SerializeField] private int score;

    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;


    void Start() {
        inputManager.OnResetPressed.AddListener(HandleReset);
        setPins();
    }
    private void HandleReset() {
        ball.ResetBall();
        setPins();
    }
    private void setPins() {
        if (pinObjects) {
            foreach (Transform child in pinObjects.transform) {
                Destroy(child.gameObject);
            }

            Destroy(pinObjects);
        }

        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, pinCollection.transform.rotation, transform);

        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in fallTriggers) {
            pin.OnPinFall.AddListener(IncrementScore);
        } 
    }
    public void IncrementScore() {
        score++;
        scoreText.text = $"Score: {score:0000}";
    }
        
}
