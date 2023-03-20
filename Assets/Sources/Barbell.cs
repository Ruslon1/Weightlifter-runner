using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Model.Barbell;
using Sources.Model.Player;
using Sources.View;
using UnityEngine;

namespace Sources
{
    public class Barbell : MonoBehaviour
    {
        private const float RotationStep = 5;
        [SerializeField] private List<SpawnPoint> _barbellDiskPoints;

        private readonly Queue<BarbellDisk> _barbellDisks = new();
        private int _disksAmountInLeft;
        private int _disksAmountInRight;
        private Player _player;

        public void Init(Player player)
        {
            _player = player;
        }

        public SpawnPoint GetSpawnPointForNewDisk(BarbellDisk model)
        {
            if (_barbellDiskPoints.Count < _barbellDisks.Count + 1)
                throw new InvalidOperationException("Barbell disk count raised its maximum value");

            _barbellDisks.Enqueue(model);
            return GetFreeSpawnPoint();
        }

        public void LoseHalfOfDisks()
        {
            var halfAmountOfBarbellDisks = _barbellDisks.Count / 2;

            for (var i = 0; i < halfAmountOfBarbellDisks; i++)
            {
                var disk = _barbellDisks.Dequeue();
                disk.LoseDisk();
                TakeAwayDisk(disk);
                CheckForRoll();
            }
        }

        private SpawnPoint GetFreeSpawnPoint()
        {
            foreach (var point in _barbellDiskPoints.Where(point =>
                         point.GetComponentInChildren<BarbellDiskTransformableView>() is null))
            {
                SetDiskSide(point.Side);
                CheckForRoll();
                return point;
            }

            return null;
        }

        private void SetDiskSide(Side side)
        {
            if (side is Side.Left)
                _disksAmountInLeft++;
            else if (side is Side.Right)
                _disksAmountInRight++;
        }

        private void TakeAwayDisk(BarbellDisk disk)
        {
            if (disk.SpawnPoint.Side == Side.Left)
                _disksAmountInLeft--;
            else if (disk.SpawnPoint.Side == Side.Right)
                _disksAmountInRight--;
        }

        private void CheckForRoll()
        {
            var rotation = (_disksAmountInLeft - _disksAmountInRight) * RotationStep;
            _player.Roll(rotation);
        }
    }
}