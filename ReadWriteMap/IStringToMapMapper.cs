using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ReadWriteMap
{
    public interface IStringToMapMapper
    {
        int[][] ReadMap(IEnumerable<string> mapLines);
    }

    public class StringToMapMapper : IStringToMapMapper
    {
        public int[][] ReadMap(IEnumerable<string> mapLines)
        {
            var intMap = new List<List<int>>();
            foreach (var line in mapLines)
            {
                var currentIntLine = new List<int>();
                foreach (var cell in line)
                {
                    if (int.TryParse(cell.ToString(), out var cellValue))
                    {
                        currentIntLine.Add(cellValue);
                    }
                }

                if (intMap.Any(x => x.Count != currentIntLine.Count))
                {
                    throw new InvalidRowInMapException();
                }
                intMap.Add(currentIntLine);
            }

            return intMap.Select(x => x.ToArray()).ToArray();
        }
    }

    public class MapParserException : Exception
    {
    }
    
    public class InvalidRowInMapException : MapParserException
    {
        public InvalidRowInMapException() : base()
        { }
    }
}