using System;
using Mono.Cecil.Cil;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomMapGenerator : MonoBehaviour
{
    public GameObject[] chunks;
    private Tilemap map;
    int Maplength = 24;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //var Plat1 = Instantiate(chunks[UnityEngine.Random.Range(1, 13)], new Vector3(0, 0, 0), quaternion.identity);
        GameObject Plat1 = Instantiate(chunks[8], new Vector3(0, 0, 0), quaternion.identity);
        Plat1.transform.parent = GameObject.Find("Grid").transform;
        //Instantiate(chunks[9], new Vector3(0, 0, 0), quaternion.identity);

        var ChosenPiece = UnityEngine.Random.Range(0, 10);
        for(int PlatGen = 0; PlatGen < 10; PlatGen++){
            var NextPlats = Instantiate(chunks[PlatGen], new Vector3(Maplength, 0, 0), quaternion.identity);
            NextPlats.transform.parent = GameObject.Find("Grid").transform;
            map = NextPlats.GetComponent<Tilemap>();
            Maplength += map.cellBounds.size.x;
            Debug.Log($"Map is {Maplength} tiles long, part is {map.cellBounds.size.x} long, piece {map.name} chosen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // var PlayerPosition = GameObject.
        // if  = 
    }
}
