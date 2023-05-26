using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerDataTest
{
    [UnityTest]
    // Tests that the coin counter starts at 0
    public IEnumerator CoinStartingValueTest()
    {
        // Instantiate test objects
        var gameObject = ScriptableObject.CreateInstance<PlayerData>();

        yield return null;

        Assert.AreEqual(expected: 0, actual: gameObject.coin_counter);
    }
}
