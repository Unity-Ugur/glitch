using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        SpawnDefender();
    }

    private void SpawnDefender()
    {
        Defender defender = Instantiate(defender, GetSquareClicked(), transform.rotation) as Defender;
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