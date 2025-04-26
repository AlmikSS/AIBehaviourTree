using UnityEngine;

public class AIBrain : MonoBehaviour
{
    private IAILocomotion _locomotion;

    private void Start()
    {
        _locomotion = GetComponent<NavMeshAILocomotion>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main != null)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                    _locomotion.Move(hit.point);
            }
        }
    }
}