using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayMenuTest
{
    [UnityTest]
    // Tests that the play menu toggles player movement off when instantiated
    public IEnumerator PlayMenuInstantiatedTest()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();

        var gameObject2 = new GameObject();
        var playMenu = gameObject2.AddComponent<StartMenuController>();

        yield return null;

        Assert.AreEqual(expected: false, actual: playerMovement.CanPlayerMove);
    }
}
