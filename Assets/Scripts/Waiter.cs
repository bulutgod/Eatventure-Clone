using UnityEngine;


public class Waiter : MonoBehaviour
{
   public CookStation cookStation;
    public Transform foodDropPoint;
    public float moveSpeed = 5.0f;
    

    private enum WaiterState
    {
        CheckingForFood,
        GettingFood,
        DeliveringFood,
    }
    private WaiterState currentState;
    private GameObject heldFood = null;

    void Start()
    {
        currentState = WaiterState.CheckingForFood;
    }

    private void Update()
    {
        switch (currentState)
        {
            case WaiterState.CheckingForFood:
                HandleCheckingForFood(); break;
            case WaiterState.GettingFood:
                HandleGettingFood(); break;
            case WaiterState.DeliveringFood:
                HandleDeliveringFood(); break;
        }
    }

    private void HandleCheckingForFood()
    {
        GameObject food = cookStation.TakeFood();

        if (food != null)
        {
            heldFood = food;
            heldFood.transform.SetParent(this.transform);
            heldFood.transform.localPosition = new Vector3(0, 1f, 0);
            currentState = WaiterState.DeliveringFood;
        }
        else
        {

        }
    }
    private void HandleGettingFood()
    {

    }

    private void HandleDeliveringFood()
    {
     Transform targetpoint = foodDropPoint;
        float distance = Vector3.Distance(transform.position, targetpoint.position);
        if(distance < 0.1f)
        {
            Destroy(heldFood);
            heldFood = null;

            currentState = WaiterState.CheckingForFood;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpoint.position, moveSpeed*Time.deltaTime);
        }
    }
}
