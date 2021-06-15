using System;
using Xunit;
using NameSorter;

namespace NameSorterTests
{
    public class SortingTests
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(5, 2 + 3);
        }
        
        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, 2 + 2);
        }
        
        [Fact]
        public void Pass_Unsorted_Simple()
        {
            //Arrange
            string expected = "Zoe Curry\rBilly Zao";
            
            //Actual
            string actual = Program.TestSort("Billy Zao\rZoe Curry");

            //Assert
            Assert.Equal(expected,actual);
        }
        [Fact]
        public void Pass_Similar_Names()
        {
            //Arrange
            string expected = "leo gardner\rlEo gardner\rLeo Gardner\rLeon Gardner";
            
            //Actual
            string actual = Program.TestSort("Leo Gardner\rleo gardner\rlEo gardner\rLeon Gardner");

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Pass_Single_Word_Names_Only()
        {
            //Arrange
            string expected = "Cher\rPrince\rSeal";

            //Actual
            string actual = Program.TestSort("Prince\rCher\rSeal");

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Pass_Single_Word_Names_Mixin()
        {
            //Arrange
            string expected = "Cher\rPrince\rBen Prince\rSeal\rSean Seal";

            //Actual
            string actual = Program.TestSort("Prince\rCher\rSeal\rBen Prince\rSean Seal");

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Pass_Numbers_Only()
        {
            //Arrange
            string expected = "1\r6 4 2\r20 21\r3 9 9\r99";

            //Actual
            string actual = Program.TestSort("6 4 2\r99\r3 9 9\r1\r20 21");

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Pass_Original_Test_Input()
        {
            //Arrange
            string expected = "Marin Alvarez\rAdonis Julius Archer\rBeau Tristan Bentley\rHunter Uriah Mathew Clarke\rLeo Gardner\rVaughn Lewis" +
                              "\rLondon Lindsey\rMikayla Lopz\rJanet Parsons\rFrankie Conner Ritter\rShelby Nathan Yoder"; 

            //Actual
            string actual = Program.TestSort("Janet Parsons\rVaughn Lewis\rAdonis Julius Archer\rShelby Nathan Yoder\rMarin Alvarez\rLondon Lindsey" +
                                             "\rBeau Tristan Bentley\rLeo Gardner\rHunter Uriah Mathew Clarke\rMikayla Lopz\rFrankie Conner Ritter");

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Pass_Altered_Test_Input()
        {
            //Arrange
            string expected = "Maric Alvarez\rMarin Alvarez\rAdonis Julius Archer\rAdonis Julius A-rcher\rbeau tristan bentley\rBeau Tristan Bentley" +
                              "\rHunter Uriah Clarke\rHunter Uriah Maa Clarke\rHunter Uriah Mathew Clarke\rHunter Uriah Mathew Clarke\rBlck dja" +
                              "\rLeo Gardner\rVaughn Lewis\rL*ndon Lindsey\rLondon Lindsey\rMikayla Lopz\rJanet Parsons\rFrankie Conner Ritter" +
                              "\rShelby Nathan Yoder\rShelby-Nathan Yoder";

            //Actual
            string actual = Program.TestSort("Janet Parsons\rVaughn Lewis\rAdonis Julius Archer\rShelby Nathan Yoder\rMarin Alvarez\rLondon Lindsey" +
                                             "\rBeau Tristan Bentley\rLeo Gardner\rHunter Uriah Mathew Clarke\rMikayla Lopz\rFrankie Conner Ritter" +
                                             "\rHunter Uriah Mathew Clarke\rHunter Uriah Maa Clarke\rMaric Alvarez\rbeau tristan bentley\rHunter Uriah Clarke" +
                                             "\rL*ndon Lindsey\rAdonis Julius A-rcher\rShelby-Nathan Yoder\rBlck dja");

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
