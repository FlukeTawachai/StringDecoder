// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using QuickType;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

class Demo
{
    static void Main()
    {
        string val;
        Console.WriteLine("Input: ");
        val = Console.ReadLine();
        int num = stringToNumber(val.Replace(" ", ""));
        Console.WriteLine("Input: S = {0}", val);
        Console.WriteLine("Output = {0}", num);
    }
    static List<string> stringToList(string text)
    {
        char[] textList = text.ToCharArray();
        List<string> srtList = new List<string>();
        foreach (var item in textList)
        {
            srtList.Add(item.ToString());
        }
        return srtList;
    }

    static DecodeModel decoderText(string text)
    {
        //if (text.Contains("AAAA"))
        //{

        //}
        DecodeModel response = new DecodeModel();
        List<string> tempList = new List<string>();
        List<string> finalList = new List<string>();
        List<string> textList = stringToList(text);
        for (int i = 0; i < textList.Count(); i++)
        {
            int nextIndex = i + 1;
            string str = textList[i];
            string strNext = "";
            if (nextIndex < textList.Count())
            {
                strNext = textList[nextIndex];
            }

            string tempStr = str + strNext;
            if (chexkText(tempStr) == true)
            {
                finalList.Add(tempStr);
                if (nextIndex < textList.Count())
                {
                    textList[nextIndex] = "";
                }
            }
            else
            {
                finalList.Add(str);
            }
        }
        response.SplitBy = "";
        response.Input = textList;
        response.Output = finalList;
        response.Result = tempList;
        return response;
    }
    static bool chexkText(string text)
    {
        bool response = false;
        switch (text)
        {
            case "AB":
                response = true;
                break;
            case "AZ":
                response = true;
                break;
            case "ZL":
                response = true;
                break;
            case "ZC":
                response = true;
                break;
            case "CD":
                response = true;
                break;
            case "CR":
                response = true;
                break;
        }
        return response;
    }

    static int stringToNumber(string text)
    {
        int value = 0;
        List<string> srtList = new List<string>();

        DecodeModel listFinal = decoderText(text);
        //Console.WriteLine("Last = {0}", listFinal.ToJson().ToString());
        srtList.AddRange(listFinal.Output);

        for (int i = 0; i < srtList.Count; i++)
        {
            //Console.WriteLine("srtList[{0}]: {1}", i, srtList[i]);
            int number = 0;
            string str = srtList[i];
            switch (str)
            {
                case "A":
                    number = 1;
                    break;
                case "B":
                    number = 5;
                    break;
                case "Z":
                    number = 10;
                    break;
                case "L":
                    number = 50;
                    break;
                case "C":
                    number = 100;
                    break;
                case "D":
                    number = 500;
                    break;
                case "R":
                    number = 1000;
                    break;
                case "AB":
                    number = 4;
                    break;
                case "AZ":
                    number = 9;
                    break;
                case "ZL":
                    number = 40;
                    break;
                case "ZC":
                    number = 90;
                    break;
                case "CD":
                    number = 400;
                    break;
                case "CR":
                    number = 900;
                    break;
            }
            value += number;
        }
        return value;
    }
}