using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{

    static float HighScore;

    public TextMeshPro text;

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Game.instance.player.transform.position.x;

        if (currentDistance > HighScore) {
            HighScore = currentDistance;
        }

        text.text = $"HI: {HighScore}";
    }
}
