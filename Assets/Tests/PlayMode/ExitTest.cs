using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ExitTest
{
    [UnityTest]
    // Tests that the LoadConclusion() works properly
    public IEnumerator LoadConclusionTest()
    {
        // Instantiate test objects
        var gameObject = new GameObject();
        var exit = gameObject.AddComponent<Exit>();
        exit.LoadConclusion();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: "Conclusion", actual: SceneManager.GetActiveScene().name);
    }
}
