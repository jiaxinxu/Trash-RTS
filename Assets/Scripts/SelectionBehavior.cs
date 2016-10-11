using UnityEngine;
using System.Collections;

public class SelectionBehavior : MonoBehaviour
{
    private GameObject SelectedUnit;

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
                        SelectedUnit = hit.transform.gameObject;
                        SelectedUnit.SendMessage("Select", 1);
                        SelectedUnit.SendMessage("ThisSelected", 1);
                        Debug.Log(SelectedUnit);
                    }
                    else
                    {
                        if (SelectedUnit != null)
                        {
                            SelectedUnit.SendMessage("Deselect", 1);
                            SelectedUnit.SendMessage("Unselected", 1);
                        }
                        SelectedUnit = null;
                    }
                }

                //if the player right clicked, tell the selected unit to move
                else if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("right click");
                    if (SelectedUnit != null)
                    {
                        SelectedUnit.SendMessage("RightClick", hit);
                    }
                }
            }
        }
    }
}
