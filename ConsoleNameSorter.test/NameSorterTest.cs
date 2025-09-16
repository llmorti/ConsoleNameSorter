using System.Collections.Generic;
using Xunit;
using ConsoleNameSorter;

namespace ConsoleNameSorter.Tests
{
    public class NameSorterTests
    {
        [Fact]
        public void SortNames_ShouldSortByLastName_ThenByGivenNames()
        {
            var unsorted = new List<string>
            {
                "Janet Parsons",
                "Adonis Julius Archer",
                "Hunter Uriah Mathew Clarke",
                "Marin Alvarez",
                "Frankie Conner Ritter"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Hunter Uriah Mathew Clarke",
                "Janet Parsons",
                "Frankie Conner Ritter"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleSingleName()
        {
            var unsorted = new List<string> { "Zoe Zebra" };
            var sorted = NameSorter.SortNames(unsorted);

            Assert.Single(sorted);
            Assert.Equal("Zoe Zebra", sorted[0]);
        }

        [Fact]
        public void SortNames_ShouldHandleEmptyList()
        {
            var unsorted = new List<string>();
            var sorted = NameSorter.SortNames(unsorted);

            Assert.Empty(sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleDuplicateNames()
        {
            var unsorted = new List<string>
            {
                "John Smith",
                "Alice Brown",
                "John Smith"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Alice Brown",
                "John Smith",
                "John Smith"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleDifferingMiddleNames()
        {
            var unsorted = new List<string>
            {
                "John Adam Smith",
                "Alice Brown",
                "John Zack Smith"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Alice Brown",
                "John Adam Smith",
                "John Zack Smith"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldSortMissingMiddleNames()
        {
            var unsorted = new List<string>
            {
                "John Adam Smith",
                "Alice Brown",
                "John Smith"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Alice Brown",
                "John Smith",
                "John Adam Smith"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleNamesWithExtraSpaces()
        {
            var unsorted = new List<string>
            {
                "  John   Smith  ",
                "Alice   Brown",
                "  Bob Marley "
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Alice   Brown",
                "  Bob Marley ",
                "  John   Smith  "
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleSingleWordNames()
        {
            var unsorted = new List<string> { "Madonna", "Prince", "Beyonce" };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string> { "Beyonce", "Madonna", "Prince" };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleHyphenatedLastNames()
        {
            var unsorted = new List<string>
            {
                "Anna-Marie Smith-Jones",
                "John Smith",
                "Zoe Adams"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Zoe Adams",
                "John Smith",
                "Anna-Marie Smith-Jones"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleApostrophesInNames()
        {
            var unsorted = new List<string>
            {
                "O'Connor John",
                "Anne-Marie O'Neill",
                "John Smith"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "O'Connor John",
                "Anne-Marie O'Neill",
                "John Smith"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleAllUppercaseOrLowercase()
        {
            var unsorted = new List<string>
            {
                "john smith",
                "Alice Brown",
                "BOB MARLEY"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Alice Brown",
                "BOB MARLEY",
                "john smith"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleVeryLongNames()
        {
            var unsorted = new List<string>
            {
                "Jonathan Livingston Seagull The Third",
                "Alice Brown",
                "Bob Marley"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "Alice Brown",
                "Bob Marley",
                "Jonathan Livingston Seagull The Third"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleEmptyStringsInList()
        {
            var unsorted = new List<string>
            {
                "",
                "John Smith",
                "Alice Brown",
                "   "
            };

            // Remove empty strings before sorting (mimicking your Main method)
            var filtered = unsorted.FindAll(s => !string.IsNullOrWhiteSpace(s));
            var sorted = NameSorter.SortNames(filtered);

            var expected = new List<string>
            {
                "Alice Brown",
                "John Smith"
            };

            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void SortNames_ShouldHandleNonAsciiCharacters()
        {
            var unsorted = new List<string>
            {
                "José Álvarez",
                "Zoë Smith",
                "Åsa Björn"
            };

            var sorted = NameSorter.SortNames(unsorted);

            var expected = new List<string>
            {
                "José Álvarez",
                "Åsa Björn",
                "Zoë Smith"
            };

            Assert.Equal(expected, sorted);
        }
    }
}

