using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    private Game game;

    // 1 This is an attribute.
    [UnityTest]
    public IEnumerator AsteroidsMoveDown()
    {
        // 2 Creates an instance of the Game.
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();


        // 3 Here you are creating an asteroid so you can keep track of whether it moves.
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();


        // 4 Keeping track of the initial position is required for the assertion
        // where you verify if the asteroid has moved down.
        float initialYPos = asteroid.transform.position.y;


        // 5 All Unity unit tests are coroutines, so you need to add a yield return.
        // You’re also adding a time-step of 0.1 seconds to simulate the passage of
        // time that the asteroid should be moving down.
        yield return new WaitForSeconds(0.1f);


        // 6 This is the assertion step where you are asserting that the position of
        // the asteroid is less than the initial position (which means it moved down).
        Assert.Less(asteroid.transform.position.y, initialYPos);


        // 7 It’s always critical that you clean up (delete or reset) your code after
        // a unit test so that when the next test runs there are no artifacts that
        // can affect that test.
        Object.Destroy(game.gameObject);
    }

}
