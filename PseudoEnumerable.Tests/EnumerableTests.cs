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

        [TestCase(arg: new[] { 7, 150, -28, 17 }, ExpectedResult = false)]
        [TestCase(arg: new[] { 7, 150, 28, 17 }, ExpectedResult = true)]
        public bool ForAll_SetOfInteger_FilteredSet(IEnumerable<int> source)
            => source.ForAll((i => i > 0));

        [TestCase(arg: new[] {7, 150, 28, 17}, ExpectedResult = new[] { 7, 150, 28, 17 })]
        public IEnumerable<int> CastTo_SetOfInteger_FilteredSet(IEnumerable<int> source)
            => Enumerable.CastTo<int>(source);


        [Test]
        public void CastTo_ArrayIsEmpty_ThrowArgumentNullException() =>
            Assert.Throws<InvalidCastException>(() => Enumerable.CastTo<int>(new object[]{  "njcd", 28}));

    }
}