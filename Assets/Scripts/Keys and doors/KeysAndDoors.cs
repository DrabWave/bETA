using UnityEngine;

public class KeysAndDoors : MonoBehaviour
{
    public PlayerStats pS;
    public TagDefinition tg;

    void Start()
    {
        for (int i = 0; i < 2000; i++) { pS.Door[i] = false; }
        for (int i = 0; i < 2000; i++) { pS.DoorCards[i] = false; }
    }

    void Update()
    {

    }
    public void OpenDoor(int indexDoor)
    {
        if (pS.Door.ContainsKey(indexDoor))
        {
            if (pS.Door[indexDoor])
            {
                Debug.Log("PORNO");
            }
            else if (pS.Keys.Contains(indexDoor))
            {
                pS.Door[indexDoor] = true;
                Destroy(tg.currentObject);
                Debug.Log("Дверь открыта");
            }
            else { Debug.Log("Не удалось открыть дверь - нет ключа"); }
        }
    }

    public void TakeKey(int indexKey)
    {
        if (tg.currentObject != null)
        {
            pS.Keys.Add(indexKey);
            Destroy(tg.currentObject);
        }
    }

    public void TakeKeyCard(int indexKeyCard)
    {
        if (tg.currentObject != null)
        {
            pS.KeyCards.Add(indexKeyCard);
            Destroy(tg.currentObject);
        }
    }

    public void OpenDoorCard(int indexDoorCard)
    {
        int countCards = 0;
        foreach (var i in pS.KeyCards)
        {
            if (i == indexDoorCard)
            {
                countCards++;
            }
        }
        if (pS.DoorCards.ContainsKey(indexDoorCard))
        {
            if (pS.DoorCards[indexDoorCard])
            {
                Debug.Log("PORNO");
            }
            else if (pS.KeyCards.Contains(indexDoorCard) && countCards == 5)
            {
                pS.DoorCards[indexDoorCard] = true;
                Destroy(tg.currentObject);
                Debug.Log("Дверь открыта");
            }
            else { Debug.Log("Не удалось открыть дверь - нет собранной ключ-карты"); }
        }
    }




    


    }
