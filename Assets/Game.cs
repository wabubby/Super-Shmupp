
using UnityEngine;

public class Game : MonoBehaviour {

    public static Game instance;

    public Transform player;

    void Awake() {
        instance = this;
    }

}
