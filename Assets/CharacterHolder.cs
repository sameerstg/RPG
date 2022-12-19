using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{
    internal List<GameObject> charactersGameobjects = new List<GameObject>();
    internal List<Player> players = new List<Player>();
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            charactersGameobjects.Add(transform.GetChild(i).gameObject);
            players.Add(charactersGameobjects[0].GetComponent<Player>());
        }
        
    }
}
