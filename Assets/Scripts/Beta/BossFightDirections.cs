/*
 * Zachary Speckan
 * 04/01/24
 * Makes the boss perform a random attack
 * 
 * player - The player
 * queen - The queen
 * 
 * fireAndMove - The FireAndMove script
 * teleport - The Teleport script
 * random - The IceSpikesRandom script
 * wave - The IceSpikes script
 * melee - The MeleeAttack script
 * whichAttack - A number that decides which attack will be performed
 * numOfSpikes - The number of spikes that will be summoned during the IceSpikesRandom attack
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightDirections : MonoBehaviour
{
    private GameObject player;
    private GameObject queen;

    FireAndMove fireAndMove;
    Teleport teleport;
    IceSpikesRandom random;
    IceSpikes wave;
    MeleeAttack melee;
    int whichAttack;
    int numOfSpikes;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        queen = GameObject.FindGameObjectWithTag("Boss");

        fireAndMove = GetComponent<FireAndMove>();
        teleport = GetComponent<Teleport>();
        random = GetComponent<IceSpikesRandom>();
        wave = GetComponent<IceSpikes>();
        melee = GetComponent<MeleeAttack>();

        yield return new WaitForSeconds(2.0f);

        StartCoroutine(LetsStartTheFight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LetsStartTheFight()
    {
        whichAttack = Random.Range(1, 5);

        if (whichAttack == 1)
        {
            StartCoroutine(fireAndMove.TeleSpam());
            yield return new WaitForSeconds(8.0f);
        }

        if (whichAttack == 2)
        {
            teleport.MoveIt();
            yield return new WaitForSeconds(1.5f);
            numOfSpikes = Random.Range(15, 25);
            StartCoroutine(random.PrepareWarnings(numOfSpikes));
            yield return new WaitForSeconds(4.0f);
        }

        if (whichAttack == 3)
        {
            teleport.MoveIt();
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(wave.SendTheSpikes());
            yield return new WaitForSeconds(4.0f);
        }

        if (whichAttack == 4)
        {
            if (Mathf.Abs(player.transform.position.x - queen.transform.position.x) < 2 && Mathf.Abs(player.transform.position.y - queen.transform.position.y) < 2)
            {
                yield return new WaitForSeconds(1.5f);
                melee.BlastIt();
                Debug.Log("Melee");
                yield return new WaitForSeconds(3.0f);
            }
        }

        StartCoroutine(LetsStartTheFight());
    }
}
