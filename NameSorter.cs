using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleNameSorter
{
    public static class NameSorter
    {
        public static List<string> SortNames(List<string> names)
        {
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            // compare by last name then by given names considering non-ascii characters
            // remove null entries
            return names
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .OrderBy(
                    name => name.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).Last(),
                    Comparer<string>.Create((x, y) => compareInfo.Compare(x, y, CompareOptions.None))
                )
                .ThenBy(
                    name => string.Join(" ",
                        name.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries)
                            .Take(name.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).Length - 1)
                    ),
                    Comparer<string>.Create((x, y) => compareInfo.Compare(x, y, CompareOptions.None))
                )
                .ToList();
        }
    }
}
