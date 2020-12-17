using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        AttemptToSpawnDefender();
    }

    private void SpawnDefender()
    {
        Defender defenderIns = Instantiate(defender, GetSquareClicked(), transform.rotation) as Defender;
    }

    public void AttemptToSpawnDefender()
    {
        var starToDecr = defender.GetStarCost();
        var starDisplay = FindObjectOfType<StarDisplay>();
        if (starDisplay.HaveEnoughStars(starToDecr))
        {
            SpawnDefender();
            starDisplay.SpendStars(starToDecr);
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.Round(rawWorldPos.x);
        float newY = Mathf.Round(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 trans = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(trans);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
}