using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for passing player global data between scenes
[System.Serializable]
[CreateAssetMenu(fileName="PlayerData", menuName="PlayerData")]
public class PlayerData : ScriptableObject
{
    public int coin_counter;
}
