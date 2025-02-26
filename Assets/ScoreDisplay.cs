using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshPro text;

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Game.instance.player.transform.position.x;

        text.text = $"DISTANCE: {currentDistance}";
    }

}
