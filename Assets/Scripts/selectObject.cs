using UnityEngine;
using System.Collections;

public class selectObject : MonoBehaviour
{
    private GameObject selectedUnit;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //if the user left clicked, select or deselect
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.tag == "Trash")
                    {
                        selectedUnit = hit.transform.gameObject;
                        selectedUnit.SendMessage("Select", 1);
                    }
                    else
                    {
                        if (selectedUnit != null)
                        {
                            selectedUnit.SendMessage("Deselect", 1);
                        }
                        selectedUnit = null;
                    }
                }

                //if the player right clicked, tell the selected unit to move
                else if (Input.GetMouseButtonDown(1))
                {
                    if (selectedUnit != null)
                    {
                        selectedUnit.SendMessage("Destination", hit.point);
                    }
                }
            }
        }
    }
}
