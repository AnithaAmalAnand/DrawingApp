using System.Collections.Generic;
using DrawingApp.Services;

namespace DrawingApp.Interfaces
{
    public interface IShape
    {
        void Draw();
        void Initialize(string[] input);
    }
}