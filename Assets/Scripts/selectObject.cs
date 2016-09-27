using UnityEngine;
using System.Collections;

public class selectObject : MonoBehaviour {
	private GameObject selectedUnit;

	void  Start (){
		
	}

	void  Update (){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.transform.tag == "Trash" && Input.GetMouseButtonDown(0))
			{
				selectedUnit = hit.transform.gameObject;
				selectedUnit.SendMessage("Select", 1);
			}
			if (hit.transform.tag == "Table" && Input.GetMouseButtonDown(1))
			{
				selectedUnit.SendMessage("Destination", hit.point);
			}
			if (hit.transform.tag == "Table" && Input.GetMouseButtonDown(0))
			{
				selectedUnit.SendMessage("Deselect", 1);
			}
		}
	}


}
