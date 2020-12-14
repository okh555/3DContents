using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private static ItemController instance = null;
    List<Item> items;

    void Start()
    {
        items = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && items.Count != 0)
        {
            items[0].UsingItem();
            items.RemoveAt(0);

        }
        if (Input.GetKeyDown(KeyCode.X) && items.Count > 1)
        {
            items[1].UsingItem();
            items.RemoveAt(1);
        }
        if (Input.GetKeyDown(KeyCode.C) && items.Count == 3)
        {
            items[2].UsingItem();
            items.RemoveAt(2);
        }
    }

    public int[] GetItem()
    {
        int[] result = new int[3];
        for (int i = 0; i < 3; i++)
            result[i] = 0;
            
        if(items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].code == 1)
                    result[i] = 1;
                if (items[i].code == 2)
                    result[i] = 2;
                if (items[i].code == 3)
                    result[i] = 3;
            }
        }
        return result;
    }
    
    public void PushItem(Item item)
    {
        if (items.Count > 3)
        {
            items.RemoveAt(0);
            items[0] = item;
        }
        else
            items.Add(item);
    }


}
