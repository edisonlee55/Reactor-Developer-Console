﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Console
{
    public class ConsoleOutput
    {
        public string output;
        public OutputType outputType;

        public int lines;

        public enum OutputType
        {
            Log,
            Error,
            Warning,
            Network
        }
        public ConsoleOutput(string entry, OutputType type)
        {
            var src = DateTime.Now;
            string dateTimeInformation = "(" + src.Hour + ":" + src.Minute + ":" + src.Second + ") ";
            output = dateTimeInformation + entry;
            outputType = type;
        }

        public ConsoleOutput(string entry, OutputType type,bool startsWithTime)
        {
            var src = DateTime.Now;
            if (startsWithTime)
            {
                string dateTimeInformation = "(" + src.Hour + ":" + src.Minute + ":" + src.Second + ") ";
                output = dateTimeInformation + entry;
            }
            else
            {

                output = entry;
            }

            outputType = type;
        }

      
    }
    public static class Utility
    {
        public static bool GetVector3FromString(string data, out Vector3 result)
        {

            List<float> vectorCrenditicals = new List<float>();
            string crenditical = "";
            char[] _chars = data.ToCharArray();

            for (int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] != ',')
                {
                    crenditical += _chars[i];
                }
                if (_chars[i] == ',')
                {
                    float parseResult = 0;
                    if (float.TryParse(crenditical, out parseResult))
                    {
                        vectorCrenditicals.Add(parseResult);
                        crenditical = "";
                    }
                    else
                    {
                        result = Vector3.zero;
                        return false;
                    }
                }
                if (i == _chars.Length - 1)
                {
                    float parseResult = 0;
                    if (float.TryParse(crenditical, out parseResult))
                    {

                        vectorCrenditicals.Add(parseResult);
                        crenditical = "";
                    }
                }
            }
            if (vectorCrenditicals.Count == 3)
            {
                result = new Vector3(vectorCrenditicals[0], vectorCrenditicals[1], vectorCrenditicals[2]);
                return true;
            }
            else
            {

                result = Vector3.zero;
                return false;
            }
        }

        public static bool GetQuaternionFromString(string data, out Quaternion result)
        {
            List<float> vectorCrenditicals = new List<float>();
            string crenditical = "";
            char[] _chars = data.ToCharArray();

            for (int i = 0; i < _chars.Length; i++)
            {
                if (_chars[i] != ',')
                {
                    crenditical += _chars[i];
                }
                if (_chars[i] == ',')
                {
                    float parseResult = 0;
                    if (float.TryParse(crenditical, out parseResult))
                    {
                        vectorCrenditicals.Add(parseResult);
                        crenditical = "";
                    }
                    else
                    {
                        result = Quaternion.identity;
                        return false;
                    }
                }
                if (i == _chars.Length - 1)
                {
                    float parseResult = 0;
                    if (float.TryParse(crenditical, out parseResult))
                    {

                        vectorCrenditicals.Add(parseResult);
                        crenditical = "";
                    }
                }
            }
            if (vectorCrenditicals.Count ==4)
            {
                result = new Quaternion(vectorCrenditicals[0], vectorCrenditicals[1], vectorCrenditicals[2], vectorCrenditicals[2]);
                return true;
            }
            else
            {

                result = Quaternion.identity;
                return false;
            }
        }

        public static string ParamsGivenWrong(object _objOfType)
        {
            return ("Paramaters for "+ _objOfType.GetType()+" given wrong!");
        }


       public static IEnumerable<Command> GetTypesWithCommandAttribute(System.Reflection.Assembly[] assemblies)
        {

            foreach (System.Reflection.Assembly assembly in assemblies)
            {

                foreach (System.Type type in assembly.GetTypes())
                {

                    if (type.GetCustomAttributes(typeof(ConsoleCommandAttribute), false).Length > 0 && type.BaseType == typeof(Command))
                    {
                        Command instance = (Command)Activator.CreateInstance(type);
                        yield return instance;
                    }
                }
            }

        }


    }

}