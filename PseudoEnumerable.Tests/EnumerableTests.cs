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

        private static IEnumerable<TestCaseData> Filter_SetOfElements_FilteredSetDataCases()
        {
            yield return new TestCaseData(
                arg1: new[] { 7, 7, 70, 17 },
                arg2: new Func<int, bool>(i => i > 0),
                arg3: new[] { 7, 7, 70, 17 });
            yield return new TestCaseData(
                arg1: new[] { 7, -7, -70, 17 },
                arg2: new Func<int, bool>(i => i < 0),
                arg3: new[] { -7, -70 });
            yield return new TestCaseData(
                arg1: new[] { "7", "150", "-28", "17" },
                arg2: new Func<string, bool>(i => i.Contains('7')),
                arg3: new[] { "7", "17" });
        }

        [TestCaseSource(nameof(Filter_SetOfElements_FilteredSetDataCases))]
        public void Filter_SetOfElements_FilteredSet<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, IEnumerable<TSource> expected)
        {
            var result = source.Filter(predicate);
            Assert.AreEqual(result, expected);
        }


        private static IEnumerable<TestCaseData> ForAll_SetOfElements_FilteredSetDataCases()
        {
            yield return new TestCaseData(
                arg1: new[] { 7, 150, -28, 17 },
                arg2: new Func<int, bool>(i => i > 0),
                arg3: false);
            yield return new TestCaseData(
                arg1: new[] { 7, 150, 28, 17 },
                arg2: new Func<int, bool>(i => i > 0),
                arg3: true);
            yield return new TestCaseData(
                arg1: new int[] {  },
                arg2: new Func<int, bool>(i => i > 0),
                arg3: true);
        }

        [TestCaseSource(nameof(ForAll_SetOfElements_FilteredSetDataCases))]
        public void ForAll_SetOfElements_FilteredSet<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate, bool expected)
        {
            var result = source.ForAll(predicate);
            Assert.AreEqual(result, expected);
        }

        [TestCase(arg: new[] {7, 150, 28, 17}, ExpectedResult = new[] { 7, 150, 28, 17 })]
        public IEnumerable<int> CastTo_SetOfInteger_FilteredSet(IEnumerable<int> source)
            => Enumerable.CastTo<int>(source);

        [Test]
        public void CastTo_ArrayIsEmpty_ThrowArgumentNullException() =>
            Assert.Throws<InvalidCastException>(() => Enumerable.CastTo<int>(new object[]{  "njcd", 28}));

        private static IEnumerable<TestCaseData> SortBy_Source_SortedSourceDataCases()
        {
            yield return new TestCaseData(
                arg1: new[] { 7, -15, 28, 17 },
                arg2: new Func<int, int>(Math.Abs),
                arg3: new[] { 7, -15, 17, 28 });
            yield return new TestCaseData(
                arg1: new[] { 7, -15, 28, 17 },
                arg2: new Func<int, int>(i => i),
                arg3: new[] { -15, 7, 17, 28 });
            yield return new TestCaseData(
                arg1: new[] { "aaa", "aaa", "aa", "a", "aaa" },
                arg2: new Func<string, int>(i => i.Length),
                arg3: new[] { "a", "aa", "aaa", "aaa", "aaa" });
            yield return new TestCaseData(
                arg1: new string[] {  },
                arg2: new Func<string, int>(i => i.Length),
                arg3: new string[] {  });
        }

        [TestCaseSource(nameof(SortBy_Source_SortedSourceDataCases))]
        public void SortBy_Source_SortedSource<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> key, IEnumerable<TSource> expected)
        {
            var result = source.SortBy(key);
            Assert.AreEqual(result, expected);
        }

        [TestCase(arg: new[] { 7, 150, 28, 17 }, ExpectedResult = new[] { "7", "150", "28", "17" })]
        public IEnumerable<string> Transform_SetOfInteger_FilteredSet(IEnumerable<int> source)
            => source.Transform(i => i.ToString());
    }
}