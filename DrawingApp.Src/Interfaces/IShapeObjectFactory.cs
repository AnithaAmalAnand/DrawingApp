namespace DrawingApp.Interfaces
{
    public interface IShapeObjectFactory
    {
        IShape GetShapeObject(string shapeCommand);
    }
}