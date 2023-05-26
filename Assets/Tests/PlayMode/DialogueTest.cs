using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DialogueTest
{
    [UnityTest]
    // Tests that the dialogue object starts with no speaker
    public IEnumerator SpeakerStartingValueTest()
    {
        // Instantiate test objects
        var gameObject = ScriptableObject.CreateInstance<Dialogue>();

        yield return null;

        Assert.AreEqual(expected: null, actual: gameObject.speaker);
    }
    
    [UnityTest]
    // Tests that the dialogue object starts with no lines
    public IEnumerator LinesStartingValueTest()
    {
        // Instantiate test objects
        var gameObject = ScriptableObject.CreateInstance<Dialogue>();
        gameObject.sentences = new List<string>();

        yield return null;

        Assert.AreEqual(expected: 0, actual: gameObject.sentences.Count);
    }

    [UnityTest]
    // Tests that the dialogue manager starts with no lines
    public IEnumerator ManagerStartingValueTest()
    {
        // Instantiate test objects
        var gameObject = new GameObject();
        var dialogueManager = gameObject.AddComponent<DialogueManager>();

        yield return null;

        Assert.AreEqual(expected: 0, actual: dialogueManager.GetSentences().Count);
    }
}
