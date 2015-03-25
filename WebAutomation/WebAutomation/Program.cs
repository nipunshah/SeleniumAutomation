// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="Program.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Automation test cases using Selenium
// </summary>
//
// Disclaimers:
// - The test should run without user touching the keyboard or mouse since it launches browsers
// - Sleeps are added in place so that user can see the progress of actions 
// - Kept it a console application in the interest of time
// - Ideal scenario would be to have a scheduling framework that knows about the list of tests along with parameters and kicks off automation based on certain criterias
//
// How to run the test:
// - Open in Visual Studio (2013 used for development)
// - Get NUnit framework and add reference (Necessary file has been copied to Drivers folder)
// - Download Selenium on machine and point to right path (Necessary file has been copied to Drivers folder)
// - Get the path to ChromeDriver correct (Find in TestClass.cs: "// TODO: Modify this path to point to right location")
//
// - Compile
// - Right click project -> Properties -> Debug -> Command Line Arguments
//   > Enter one of the following: "/buy", "/remove", "/change"
// 
// - Run (PLEASE DO NOT TOUCH KEYBOARD OR MOUSE WHEN TESTS ARE RUNNING)
// --------------------------------------------------------------------------------------------------------------------
namespace WebAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;    

    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            { 
                case "/buy":
                    //
                    // Test case to buy iPhone
                    //
                    TestClass buyPhone = new TestClass();
                    buyPhone.Setup();
                    buyPhone.BuyIPhone();
                    buyPhone.Teardown();
                    break;

                case "/remove":
                    //
                    // Test case to empty cart
                    //
                    TestClass emptyCart = new TestClass();
                    emptyCart.Setup();
                    emptyCart.RemoveCartItem();
                    emptyCart.Teardown();
                    break;

                case "/change":
                    //
                    // Test case to change account information
                    //
                    TestClass accountInfo = new TestClass();
                    accountInfo.Setup();
                    accountInfo.AccountDetails();
                    accountInfo.Teardown();
                    break;

                default:
                    Console.WriteLine("Please specify one of the below options in command line argument:");
                    Console.WriteLine("/buy");
                    Console.WriteLine("/remove");
                    Console.WriteLine("/change");
                    break;
            }

            //Console.WriteLine("Press any key to exit...");
            //Console.ReadLine();
        }
    }
}
