using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IconRecruitmentTest.Tests.Extensions
{
    public static class TestExtensions
    {

        /// <summary>
        /// Compare if two objects are equal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static T ShouldEqual<T>(this T actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }


        /// <summary>
        /// Compare if two objects are not equal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static T ShouldNotEqual<T>(this T actual, object expected)
        {
            Assert.AreNotEqual(expected, actual);
            return actual;
        }

        /// <summary>
        /// ShouldNull
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ShouldNull<T>(this T obj)
        {
            Assert.IsNull(obj);
            return obj;
        }

        /// <summary>
        /// ShouldBeTrue
        /// </summary>
        /// <param name="source"></param>
        public static void ShouldBeTrue(this bool source)
        {
            Assert.IsTrue(source);
        }

        /// <summary>
        /// ShouldBeFalse
        /// </summary>
        /// <param name="source"></param>
        public static void ShouldBeFalse(this bool source)
        {
            Assert.IsFalse(source);
        }
    }
}
