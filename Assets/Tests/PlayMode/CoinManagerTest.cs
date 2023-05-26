using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoinManagerTest
{
    [UnityTest]
    // Tests that the coin counter starts at 0
    public IEnumerator StartingValueTest()
    {
        // Instantiate test objects
        var gameObject = new GameObject();
        var coinManager = gameObject.AddComponent<CoinManager>();

        yield return null;

        Assert.AreEqual(expected: 0, actual: coinManager.GetInternalCounter());
    }

    [UnityTest]
    // Tests that IncrementCounter() works properly
    public IEnumerator IncrementTest()
    {
        // Instantiate test objects
        var gameObject = new GameObject();
        var coinManager = gameObject.AddComponent<CoinManager>();

        // Increment counter
        coinManager.IncrementCounter();

        yield return null;

        Assert.AreEqual(expected: 1, actual: coinManager.GetInternalCounter());
    }
}
