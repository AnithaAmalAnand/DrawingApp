namespace DrawingApp.Interfaces
{
    public interface IConsoleBuffer
    {
        int CanvasLength { get; set; }
        int CanvasWidth { get; set; }
        char ReadCharAtLocation(int x, int y);
        void WriteCharAtLocation(int x, int y, char c);
        void WriteToScreen();
    }
}