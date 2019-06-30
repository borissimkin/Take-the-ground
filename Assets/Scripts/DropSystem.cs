using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour {
    
    [System.Serializable]
    public class DropCurrency
    {
        public string name;
        public GameObject item;
        public int dropRarity;
    }

    public List<DropCurrency> LootTable = new List<DropCurrency>();
    /// <summary>
    /// выпадет ли вообще какой то предмет
    /// </summary>
    public int dropChance;

    public void CalculateLoot()
    {
        int calcDropChance = Random.Range(0, 101);
        if (calcDropChance > dropChance)
        {
            print("No Loot For ME");
            return;
        }

        if (calcDropChance <= dropChance)
        {
            int itemWeight = 0;
            for (int i = 0; i < LootTable.Count; i++)
            {
                itemWeight += LootTable[i].dropRarity;
            }
            int randomValue = Random.Range(0, itemWeight);
            for (int i = 0; i < LootTable.Count; i++)
            {
                if (randomValue <= LootTable[i].dropRarity)
                {
                    Instantiate(LootTable[i].item, transform.position, Quaternion.identity);
                }
                randomValue -= LootTable[i].dropRarity;
            }
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
