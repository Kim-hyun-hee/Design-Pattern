using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class PlayerController : MonoBehaviour, IReceiver
    {
        [SerializeField] private LayerMask obstacleLayer;

        private const float boardSpacing = 1f;

        public void Move(Vector3 moveVec)
        {
            transform.position += moveVec;
        }

        public bool IsValidMove(Vector3 moveVec)
        {
            return !Physics.Raycast(transform.position, moveVec, boardSpacing, obstacleLayer);
        }
    }
}
