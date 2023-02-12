namespace Sources.View
{
    public class BarbellDiskTransformableView : TransformableView
    {
        private void Update()
        {
            transform.position = Model.Position;
        }
    }
}