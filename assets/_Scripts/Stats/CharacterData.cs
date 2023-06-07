using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Stats/Character Data")]
public class CharacterData : ScriptableObject
{

    // list of stats; see if you can maybe change this to a "stats" Dictionary with enum values for better stat handling
    public string characterName;
    public string description;
    public GameObject characterModel;
    public int health = 20;
    public float speed = 2f; // tie this into the movement speed somehow
    public float detectRange = 10;
    public int damage = 1;


}
