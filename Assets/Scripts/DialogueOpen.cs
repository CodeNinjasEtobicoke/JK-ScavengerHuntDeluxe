using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOpen : MonoBehaviour
{

    public string dialogue;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        //collectibles = new string[] { " film so I can watch my movie", "balloons for my birthday party", "life saver so I don't drown", "bull's eye so I can play darts", "pipe so I can smoke", "key for my house", "fish so I can cook it and eat dinner", "birdhouse so I can see the birds", "red airhorn so I can scare my friend", "magic hat so I can do some magic tricks" };
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };

        createClue();
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialougue();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialogue, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialogue = "You found my " + collectibles[clue] + "! Hooray!";
            end = true;
        }
        else
        {
            dialogue = "No that's not my " + collectibles[clue] + ".";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }
    public void searchDialougue()
    {
        //dialogue = "Hi! Can you help me find my " + collectibles[clue] + "?";

        switch (collectibles[clue])
        {
            case "film":
                dialogue = "Hi! Can you help me find my film so I can watch a movie?";
                break;
            case "balloons":
                dialogue = "Hi! Can you help me find my balloons for my birthday party";
                break;
            case "life saver":
                dialogue = "Hi! Can you help me find my life saver so I can go swimming";
                break;
            case "bull's eye ":
                dialogue = "Hi! Can you help me find my bull's eye so I can play darts";
                break;
            case "pipe":
                dialogue = "Hi! Can you help me find my pipe so I can smoke";
                break;
            case "key":
                dialogue = "Hi! Can you help me find my key so I can get into my house";
                break;
            case "fish":
                dialogue = "Hi! Can you help me find my pet fish so I can feed it";
                break;
            case "birdhouse":
                dialogue = "Hi! Can you help me find my birdhouse so I can see the birds";
                break;
            case "red airhorn":
                dialogue = "Hi! Can you help me find my red airhorn so I can scare my friend";
                break;
            case "magic hat":
                dialogue = "Hi! Can you help me find my magic hat so I can do some magic tricks";
                break;
        }
    }
    
}
