using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingApp.Tests
{
    public static class TestDataFactory
    {
        public static string[] CanvasLargeInput = { "C", "200", "100" };
        public static string[] CanvasInvalidInput = { "C", "20" };

        public static string[] LineInput = { "L", "1","2","6","2" };
        public static string[] LineInputNotStraight = { "L", "1", "2", "5", "5" };
        public static string[] LineOutsideCanvas = { "L", "30", "21", "30", "24" };
        public static string[] LineInvalidInput = { "L", "1", "2", "6" };

        public static string[] RectangleInput = { "R", "14", "2", "18", "3" };
        public static string[] RectangleOutsideCanvas = { "L", "30", "21", "32", "24" };
        public static string[] RectangleInvalidInput = { "L", "14", "2", "18" };

        public static string[] ColorFillInput = { "B", "10", "3", "o" };
        public static string[] ColorFillOutsideCanvas = { "B", "25", "10", "o" };
        public static string[] ColorFillInvalidInput = { "B", "10", "3" };

            
    }
}
