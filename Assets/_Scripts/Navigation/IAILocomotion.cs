using UnityEngine;

public interface IAILocomotion
{
    void Move(Vector3 point);
    void Stop();
}