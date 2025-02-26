using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomMapGenerator : MonoBehaviour
{
    public GameObject[] chunks;

    public GameObject[] enemies;

    private Tilemap map;
    int Maplength = 24;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //var Plat1 = Instantiate(chunks[UnityEngine.Random.Range(1, 13)], new Vector3(0, 0, 0), quaternion.identity);
        GameObject Plat1 = Instantiate(chunks[8], new Vector3(0, 0, 0), quaternion.identity);
        Plat1.transform.parent = GameObject.Find("Grid").transform;
        //Instantiate(chunks[9], new Vector3(0, 0, 0), quaternion.identity);

        //var ChosenPiece = UnityEngine.Random.Range(0, 10);
        for(int PlatGen = 0; PlatGen < 100; PlatGen++){
            var ChosenPiece = UnityEngine.Random.Range(0, 10);
            var NextPlats = Instantiate(chunks[ChosenPiece], new Vector3(Maplength, 0, 0), quaternion.identity);
            NextPlats.transform.parent = GameObject.Find("Grid").transform;
            map = NextPlats.GetComponent<Tilemap>();
            Maplength += map.cellBounds.size.x;
            // Debug.Log($"Map is {Maplength} tiles long, part is {map.cellBounds.size.x} long, piece {map.name} chosen");
        }

        GenerateEnemies();
    }

    void GenerateEnemies() {
        float x = 20;
        while (x < Maplength) {
            x += UnityEngine.Random.Range(0f, 10f);

            int ChosenPiece = UnityEngine.Random.Range(0, enemies.Length);
            var NextEnemy = Instantiate(enemies[ChosenPiece]);

            NextEnemy.transform.position = new Vector3(x, UnityEngine.Random.Range(-5, 5), -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // var PlayerPosition = GameObject.
        // if  = 
    }
}
