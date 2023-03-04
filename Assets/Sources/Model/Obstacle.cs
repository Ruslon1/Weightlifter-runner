using UnityEngine;

namespace Sources.Model
{
    public class Obstacle : Transformable
    {
        private readonly Sources.Barbell _barbell;

        public Obstacle(Quaternion rotation, Vector3 position, Sources.Barbell
            barbell) : base(rotation, position)
        {
            _barbell = barbell;
        }

        public override void TriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(nameof(Player.Player))) _barbell.LoseHalfOfDisks();
        }
    }
}