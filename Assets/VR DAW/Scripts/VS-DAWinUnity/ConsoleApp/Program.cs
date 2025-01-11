// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;
using VS_DAWinUnity;


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Program Initalised...");
        MainHeader main = new MainHeader();
        main.Initalise();
    }
}