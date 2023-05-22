using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for the organization of a dialogue
[System.Serializable]
[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string speaker;

    public List<string> sentences;
}
