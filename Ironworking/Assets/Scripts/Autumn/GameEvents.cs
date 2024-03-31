using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake() 
    {
        instance = this;
    }

    public event UnityAction<int> onObjectPickup;
    public void ObjectPickupEvent(int id) 
    {
        if (onObjectPickup != null)
        {
            onObjectPickup(id);
        }
    }
}


//https://www.youtube.com/watch?v=gx0Lt4tCDE0 << main one used
//https://www.youtube.com/watch?v=SHeSM0zFx_c << more up to date version