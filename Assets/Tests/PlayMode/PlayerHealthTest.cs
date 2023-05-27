using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerHealthTest
{
    [UnityTest]
    // Tests that the Restart() reloads the scene
    public IEnumerator PlayerRestartSceneTest()
    {
        // Instantiate test objects
        var gameObject = new GameObject();
        var playerHealth = gameObject.AddComponent<PlayerHealth>();
        playerHealth.playerData = ScriptableObject.CreateInstance<PlayerData>();
        playerHealth.Restart();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: "Level", actual: SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    // Tests that the Restart() reloads the scene
    public IEnumerator PlayerRestartCounterTest()
    {
        // Instantiate test objects
        var gameObject = new GameObject();
        var playerHealth = gameObject.AddComponent<PlayerHealth>();
        playerHealth.playerData = ScriptableObject.CreateInstance<PlayerData>();
        playerHealth.Restart();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: 1, actual: playerHealth.playerData.death_counter);
    }
}
