using UnityEngine.EventSystems;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    TowerButton towerBtnPressed;

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero); 
            if(hit.collider.tag  == "TowerSide")
            {
                PlaceTower(hit);
            }
        }
    }
    public void SelectedTower(TowerButton towerSelected)
    {
        towerBtnPressed = towerSelected;
        Debug.Log("twr_" + towerBtnPressed.gameObject);
    }
    public void PlaceTower(RaycastHit2D hit)
    {
        if(!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
        }
    }
}
