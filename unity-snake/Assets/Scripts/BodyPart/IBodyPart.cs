using System;
using UnityEngine;

public interface IBodyPart {
    IBodyPart Previous { get; set; }
    Transform Transform { get; }
    void SpawnPart();
}
