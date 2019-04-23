using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace PseudoEnumerable.Tests
{
    [TestFixture]
    public class EnumerableTests
    {
        [TestCase(new[] {7, 7, 70, 17}, ExpectedResult = new[] {7, 7, 70, 17})]
        public IEnumerable<int> Filter_SetOfInteger_FilteredSetGreaterZero(IEnumerable<int> source)
            => source.Filter(new Func<int, bool>(i => i > 0));

        [TestCase(new[] { 7, -7, -70, 17 }, ExpectedResult = new[] { -7, -70})]
        public IEnumerable<int> Filter_SetOfInteger_FilteredSetLessZero(IEnumerable<int> source)
            => source.Filter(new Func<int, bool>(i => i < 0));

        [TestCase( arg:new[] { "7", "150", "-28", "17" }, ExpectedResult = new[] { "7", "17" })]
        public IEnumerable<string> Filter_SetOfInteger_FilteredSetString(IEnumerable<string> source)
            => source.Filter(new Func<string, bool>(i => i.Contains('7')));


    }
}