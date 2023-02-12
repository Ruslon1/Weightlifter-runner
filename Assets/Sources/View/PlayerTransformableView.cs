namespace Sources.View
{
    public class PlayerTransformableView : TransformableView
    {
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Model.Position;
            transform.rotation = Model.Rotation;
        }
    }
}