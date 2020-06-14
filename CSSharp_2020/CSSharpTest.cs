using CSSharp_2020.Shapes;
using NUnit.Framework;
using System;
using static NUnit.Framework.Assert; //static imports
using static System.Console; //static imports

namespace CSSharp_2020
{
    [TestFixture]
    public class CSSharpTest
    {
        [Test]
        public void string_interpolation()
        {
            int year = 2019;
            AreEqual($"Happy New Year {year}", $"Happy New Year 2019");
        }

        [Test]
        public void name_of()
        {
            int number = 1;
            AreEqual("number", nameof(number));
        }

        [Test]
        public void exception_filter()
        {
            try
            {
                throw new Exception("Exception filtered");
            }
            catch (Exception ex) when (ex.Message == "Exception filtered")
            {
                Pass();
            }
            catch (Exception)
            {
                Fail();
            }
        }

        [Test]
        public void null_conditional_operators()
        {
            Square square = null;
            double value = square?.Side ?? 0;
            AreEqual(0, value);
        }

        [Test]
        public void CSharp7_out_variables()
        {
            string stringNumber = "15";

            if (int.TryParse(stringNumber, out int number))// declaration inline
            {
                AreEqual(number, 15);
            }
        }

        [Test]
        public void pattern_matching()
        {
            object shape = new Circle(1);

            //--------------------------------- class pattern matching on if
            if (shape is Circle circle)
            {
                Write(circle.Radius);
            }

            //--------------------------------- class pattern matching on switch

            switch (shape)
            {
                case Circle c when c.Radius == 1:
                    Write(c.Radius);
                    Pass();
                    break;
                case Square s:
                case Rectangle r:
                default:
                    Fail();
                    break;
            }

            //--------------------------------- tuple pattern matching

            var isRainning = true;
            var doIneedToGoOut = true;

            switch ((isRainning, doIneedToGoOut))
            {
                case (true, true): WriteLine("I need to take my umbrella."); break;
                case (true, false): WriteLine("I will take a tea cup."); break;
                case (false, true): WriteLine("I leave the ubrella at home"); break;
                case (false, false): WriteLine("I'm boring, nothing is happening."); break;
            }
        }

        private string improveSwitchOnMethod(bool isRainning, bool doIneedToGoOut)
            => (isRainning, doIneedToGoOut) switch
            {
                (true, true) => "I need to take my umbrella.",
                (true, false) => "I will take a tea cup.",
                (false, true) => "I leave the ubrella at home",
                (false, false) => "I'm boring, nothing is happening."
            };

        [Test]
        public void _pattern_local_functions()
        {
            int x = 0;
            localFunction1();
            localFunction1();

            AreEqual(2, x);

            void localFunction1()
            {
                Write($"call from {nameof(localFunction1)} {x}");
                x++;
            }
        }

        [Test]
        public void leading_underscores_in_numeric_literals()
        {
            AreEqual(10000, 10_000);
        }

        [Test]
        public void new_tuples()
        {
            //------------------------------------unnamed tuples
            (string, string) unnamedTuple1 = ("one", "two");
            (string, string) unnamedTuple2 = ("one", "two");
            AreEqual(unnamedTuple1, unnamedTuple2);

            //------------------------------------named tuples
            var namedTuple = (first: "one", second: "two");
            AreEqual("one", namedTuple.first);
            AreEqual("two", namedTuple.second);

            //------------------------------------from variables
            var number1 = 12;
            var number2 = 5;
            var accumulation = (number1, number2);
            //number2 = 8;
            AreEqual(number1, accumulation.number1);
            AreEqual(number2, accumulation.number2);

            //------------------------------------switch values
            var switchValue1 = 10;
            var switchValue2 = 20;
            (switchValue1, switchValue2) = (switchValue2, switchValue1);
            AreEqual(20, switchValue1);
            AreEqual(10, switchValue2);

            //------------------------------------Tuples for reducing types (classes, interfaces, structs)
            var crendetials = getAuthenticationCredentials(100);
            AreEqual("Admin", crendetials.user);
            AreEqual("12345", crendetials.password);

            //------------------------------------Tuples deconstruction

            var (userVariable, passwordVariable) = crendetials;
            AreEqual("Admin", userVariable);
            AreEqual("12345", passwordVariable);
        }

        private (string user, string password) getAuthenticationCredentials(int id)
        {
            //Here we should get the values
            return ("Admin", "12345");
        }

        [Test]
        public void Exceptions_On_ternary_operations()
        {
            Catch<Exception>(() =>
            {
                string r = 1 == 2 ? "ok" : throw new Exception();
            });
        }
    }
}
