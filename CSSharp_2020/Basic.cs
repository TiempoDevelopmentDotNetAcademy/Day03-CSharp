using System;
using System.Dynamic;
using CSSharp_2020.Shapes;
using NUnit.Framework;
using static NUnit.Framework.Assert; //static imports
using static System.Console; //static imports

namespace CSSharp_2020 {
    
    [TestFixture]
    
    class Basic {
        [Test]
        public void a_variables () {
            //int age = 18;
            // decimal weight = 80.0m;
            // float height = 33.33f;
            // string firstname = string.Empty;
            // string lastname = null;
            // char grade = 'A';
            //int bankFounds = 10_000;
            // bool areYouHappy = true;
            //int? thisIsNullable = null;

            // var thisWillResolveAtCompileTime = "";

            // dynamic thisWillBeEvaluatedAtRuntime = new ExpandoObject ();
            // thisWillBeEvaluatedAtRuntime.new_attribute = 33;
        }

        [Test]
        public void string_interpolation_and_concat () {
            int year = 2020;

            var message = $"{year} is the current year";
            Console.WriteLine (message);

            string greetings = string.Concat ("Hello", " ", "Year");
            Console.WriteLine (greetings);
        }

        [Test]
        public void name_of () {
            int number = 1;
            Assert.AreEqual ("number", nameof (number));
        }

        [Test]
        public void out_variables () {
            string stringNumber = "15";

            if (int.TryParse (stringNumber, out int number)) // declaration inline
            {
                AreEqual (number, 15);
            }
        }

        [Test]
        public void null_conditional_operators () {
            string userName = "José";
            string defaultUserName = "John Doe";
            string selectedUserName = userName ?? defaultUserName;
            Assert.AreEqual ("José", selectedUserName);
        }

        public void b_arrays () {
            string[] textArray1 = new string[2];
            textArray1[0] = "hello";
            textArray1[1] = "world";

            string[] textArray = new string[] {
                "hello",
                "world"
            };
        }

        [Test]
        public void control_structures_if_else () {

            bool doYouLikeMovies = true;

            if (doYouLikeMovies) {
                Console.WriteLine ("Yes!");
            } else {
                Console.WriteLine ("Nope!");
            }
        }

        [Test]
        public void control_structures_if_ternary () {
            var number1 = 1;
            var number2 = 2;
            var evaluation = number1 == number2 ? "numbers are equal" : "numbers are different";

            Console.WriteLine (evaluation);
        }

        [Test]
        public void control_structures_switch () {
            var option = 1;

            switch (option) {
                case 1:
                    Console.WriteLine ("first option");
                    break;
                case 2:
                    Console.WriteLine ("second option");
                    break;
                case 3:
                    Console.WriteLine ("third option");
                    break;
                case 4:
                    Console.WriteLine ("forth option");
                    break;
                default:
                    Console.WriteLine ("unknown option");
                    break;

            }
        }

        [Test]
        public void control_structures_switch_improved () {
            var selectedOption = improveSwitchOnMethod (1);
            Console.WriteLine (selectedOption);
        }

        private string improveSwitchOnMethod (int option) => (option) switch {
            1 => "first option.",
            2 => "second option.",
            3 => "third option.",
            4 => "forth option.",
            _ => "unknown option"
        };

        [Test]
        public void iteration_structures_for () {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int total = 0;

            for (int i = 0; i < nums.Length; i++) {
                total += nums[i];
            }
        }

        [Test]
        public void iteration_structures_foreach () {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int total = 0;

            foreach (int num in nums) {
                total += num;
            }
        }

        [Test]
        public void iteration_structures_while () {

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int total = 0;
            int i = 0;

            while (i < nums.Length) {
                total += nums[i];
                i++;
            }
        }

        [Test]
        public void iteration_structures_do_while () {

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int total = 0;
            int i = 0;

            do {
                total += nums[i];
                i++;
            }
            while (i < nums.Length);
        }

        [Test]
        public void exceptions () {
            try {
                throw new Exception ("Exception filtered");
            } catch (ArgumentException ex) {
                Console.WriteLine ($"Exception caught {ex.GetType().Name}");
                Pass ();
            } catch (Exception ex) {
                Console.WriteLine ($"Exception caught {ex.GetType().Name}");
                Pass ();
            }
        }

        [Test]
        public void exception_filter () {
            try {
                throw new Exception ("Exception filtered");
            } catch (Exception ex) when (ex.Message == "Exception filtered") {
                Pass ();
            }
            catch (Exception) {
                Fail ();
            }
        }

        [Test]
        public void Exceptions_On_ternary_operations () {
            try {
                string r = 1 == 2 ? "ok" : throw new Exception ();
                Fail ();
            } catch (Exception ex) {
                Pass ();
            }
        }

        [Test]
        public void pattern_matching () {
            object shape = new Circle (1);

            //--------------------------------- class pattern matching on if
            if (shape is Circle circle) {
                Write (circle.Radius);
            }

            //--------------------------------- class pattern matching on switch

            switch (shape) {
                case Circle c when c.Radius == 1:
                    Write (c.Radius);
                    Pass ();
                    break;
                case Square s:
                case Rectangle r:
                default:
                    Fail ();
                    break;
            }

            //--------------------------------- tuple pattern matching

            var isRaining = true;
            var doINeedToGoOut = true;

            switch ((isRaining, doINeedToGoOut)) {
                case (true, true):
                    WriteLine ("I need to take my umbrella.");
                    break;
                case (true, false):
                    WriteLine ("I will take a tea cup.");
                    break;
                case (false, true):
                    WriteLine ("I leave the umbrella at home");
                    break;
                case (false, false):
                    WriteLine ("I'm boring, nothing is happening.");
                    break;
            }
        }

        private string improveSwitchOnMethod (bool isRaining, bool doINeedToGoOut) => (isRaining, doINeedToGoOut) switch {
            (true, true) => "I need to take my umbrella.",
            (true, false) => "I will take a tea cup.",
            (false, true) => "I leave the umbrella at home",
            (false, false) => "I'm boring, nothing is happening."
        };

        [Test]
        public void pattern_local_functions () {
            int x = 0;
            localFunction1 ();
            localFunction1 ();

            AreEqual (2, x);

            void localFunction1 () {
                Write ($"call from {nameof(localFunction1)} {x}");
                x++;
            }
        }

        [Test]
        public void new_tuples () {
            //------------------------------------unnamed tuples
            (string, string) unnamedTuple1 = ("one", "two");
            (string, string) unnamedTuple2 = ("one", "two");
            AreEqual (unnamedTuple1, unnamedTuple2);

            //------------------------------------named tuples
            var namedTuple = (first: "one", second: "two");
            AreEqual ("one", namedTuple.first);
            AreEqual ("two", namedTuple.second);

            //------------------------------------from variables
            var number1 = 12;
            var number2 = 5;
            var accumulation = (number1, number2);
            //number2 = 8;
            AreEqual (number1, accumulation.number1);
            AreEqual (number2, accumulation.number2);

            //------------------------------------switch values
            var switchValue1 = 10;
            var switchValue2 = 20;
            (switchValue1, switchValue2) = (switchValue2, switchValue1);
            AreEqual (20, switchValue1);
            AreEqual (10, switchValue2);

            //------------------------------------Tuples for reducing types (classes, interfaces, structs)
            var credentials = getAuthenticationCredentials (100);
            AreEqual ("Admin", credentials.user);
            AreEqual ("12345", credentials.password);

            //------------------------------------Tuples deconstruction

            var (userVariable, passwordVariable) = credentials;
            AreEqual ("Admin", userVariable);
            AreEqual ("12345", passwordVariable);
        }

        private (string user, string password) getAuthenticationCredentials (int id) {
            //Here we should get the values
            return ("Admin", "12345");
        }
    }
}