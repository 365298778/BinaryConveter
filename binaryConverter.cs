using System;
using System.Collections;

namespace testBinary
{
    static class binaryConverter
    {
        #region 二分密码加密
        public static void ENCRYPT(string context, string key1, string key2, char limitChar)
        {
            limitChar = Char.ToUpper(limitChar);
            int limitCode = limitChar - 66;
            context = context.ToUpper();
            key1 = delStringSame(key1).ToUpper();
            key2 = delStringSame(key2).ToUpper();
            context = context.Replace(" ", "");
            key1 = key1.Replace(" ", "");
            key2 = key2.Replace(" ", "");
            ArrayList[] key1Matrix = new ArrayList[5];
            ArrayList[] key2Matrix = new ArrayList[5];
            ArrayList infoMatrix = new ArrayList();
            ArrayList encryptInfoMatrix = new ArrayList();

            int code = 0;
            //获得KEY1矩阵
            for (int i = 0; i < (int)(key1.Length % 5 == 0 ? key1.Length / 5 : key1.Length / 5 + 1); i++)
            {
                key1Matrix[i] = new ArrayList();
                int nextCount = 5;
                if ((i + 1) * 5 > key1.Length)
                {
                    nextCount = key1.Length % 5;
                }
                for (int j = 0; j < nextCount; j++)
                {
                    if (key1[j + i * 5] != (char)65+limitCode)
                    {
                        key1Matrix[i].Add(key1[j + i * 5]);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (key1Matrix[i] == null)
                {
                    key1Matrix[i] = new ArrayList();
                }
                int tempKey1Index = 0;
                if (key1Matrix[i].Count < 5 && key1Matrix[i].Count > 0)
                {
                    tempKey1Index = key1Matrix[i].Count % 5;
                }
                else if (key1Matrix[i].Count == 5)
                {
                    continue;
                }
                for (int j = tempKey1Index; j < 5; j++)
                {
                    char tempchr = (char)(65 + code);
                    bool exists = false;
                    foreach (var list in key1Matrix)
                    {
                        if (list != null && list.Contains(tempchr) == true)
                        {
                            exists = true;
                        }
                    }
                    if (exists == false)
                    {
                        key1Matrix[i].Add(tempchr);
                    }
                    else
                    {
                        while (true)
                        {
                            if (code != limitCode)
                            {
                                code++;
                            }
                            else
                            {
                                code += 2;
                            }

                            tempchr = (char)(65 + code);
                            exists = false;
                            foreach (var list in key1Matrix)
                            {
                                if (list != null && list.Contains(tempchr) == true)
                                {
                                    exists = true;
                                }
                            }
                            if (exists == false)
                            {
                                tempchr = (char)(65 + code);
                                key1Matrix[i].Add(tempchr);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (code != limitCode)
                    {
                        code++;
                    }
                    else
                    {
                        code += 2;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                foreach (char e in key1Matrix[i])
                {
                    Console.Write("{0}", e.ToString());
                }
                Console.WriteLine();
            }
            code = 0;

            Console.WriteLine();
            //获得KEY2矩阵
            for (int i = 0; i < (int)(key2.Length % 5 == 0 ? key2.Length / 5 : key2.Length / 5 + 1); i++)
            {
                key2Matrix[i] = new ArrayList();
                int nextCount = 5;
                if ((i + 1) * 5 > key2.Length)
                {
                    nextCount = key2.Length % 5;
                }
                for (int j = 0; j < nextCount; j++)
                {
                    if (key2[j + i * 5] != (char)65+limitCode)
                    {
                        key2Matrix[i].Add(key2[j + i * 5]);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (key2Matrix[i] == null)
                {
                    key2Matrix[i] = new ArrayList();
                }
                int tempKey2Index = 0;
                if (key2Matrix[i].Count < 5 && key2Matrix[i].Count > 0)
                {
                    tempKey2Index = key2Matrix[i].Count % 5;
                }
                else if (key2Matrix[i].Count == 5)
                {
                    continue;
                }
                for (int j = tempKey2Index; j < 5; j++)
                {
                    char tempchr = (char)(65 + code);
                    bool exists = false;
                    foreach (var list in key2Matrix)
                    {
                        if (list != null && list.Contains(tempchr) == true)
                        {
                            exists = true;
                        }
                    }
                    if (exists == false)
                    {
                        key2Matrix[i].Add(tempchr);
                    }
                    else
                    {
                        while (true)
                        {
                            if (code != limitCode)
                            {
                                code++;
                            }
                            else
                            {
                                code += 2;
                            }

                            tempchr = (char)(65 + code);
                            exists = false;
                            foreach (var list in key2Matrix)
                            {
                                if (list != null && list.Contains(tempchr) == true)
                                {
                                    exists = true;
                                }
                            }
                            if (exists == false)
                            {
                                tempchr = (char)(65 + code);
                                key2Matrix[i].Add(tempchr);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (code != limitCode)
                    {
                        code++;
                    }
                    else
                    {
                        code += 2;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                foreach (char e in key2Matrix[i])
                {
                    Console.Write("{0}", e.ToString());
                }
                Console.WriteLine();
            }
            code = 0;
            Console.WriteLine();

            //获得加密内容矩阵
            int infoTemp = 0;
            for (int i = 0; i < context.Length / 2; i++)
            {
                ArrayList list = new ArrayList();
                for (int j = 0; j < 2; j++)
                {
                    list.Add(context[infoTemp]);
                    infoTemp++;
                }
                infoMatrix.Add(list);
            }

            //获得加密后内容
            int key1Row = 0;
            int key1Column = 0;
            int key2Row = 0;
            int key2Column = 0;
            foreach (var item in infoMatrix)
            {
                int infoCount = 1;
                foreach (var infoLetter in (ArrayList)item)
                {
                    if (infoCount == 1)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (key1Matrix[i][j].ToString().Equals(infoLetter.ToString()))
                                {
                                    key1Row = i;
                                    key1Column = j;
                                    infoCount = 2;
                                }
                            }
                        }
                    }
                    else if (infoCount==2)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (key2Matrix[i][j].ToString().Equals(infoLetter.ToString()))
                                {
                                    key2Row = i;
                                    key2Column = j;
                                    infoCount = 0;
                                    ArrayList resultList = new ArrayList();
                                    ArrayList key1List = (ArrayList)key1Matrix[key1Row];
                                    ArrayList key2List = (ArrayList)key2Matrix[key2Row];
                                    resultList.Add(key1List[key2Column]);
                                    resultList.Add(key2List[key1Column]);
                                    encryptInfoMatrix.Add(resultList);
                                }
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("encryptResult:");
            foreach (ArrayList arr in encryptInfoMatrix)
            {
                foreach (var item in arr)
                {
                    Console.Write("{0}", item.ToString());
                }
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Read();
        }
        #endregion

        #region 二分密码解密
        public static void DECRYPT(string cipherText, string key1, string key2, char limitChar)
        {
            limitChar = char.ToUpper(limitChar);
            int limitCode = limitChar - 66;
            cipherText = cipherText.ToUpper();
            key1 = delStringSame(key1).ToUpper();
            key2 = delStringSame(key2).ToUpper();
            cipherText = cipherText.Replace(" ", "");
            key1 = key1.Replace(" ", "");
            key2 = key2.Replace(" ", "");
            ArrayList[] key1Matrix = new ArrayList[5];
            ArrayList[] key2Matrix = new ArrayList[5];
            ArrayList cipherTextMatrix = new ArrayList();
            ArrayList decryptInfoMatrix = new ArrayList();

            int code = 0;
            //获得KEY1矩阵
            for (int i = 0; i < (int)(key1.Length % 5 == 0 ? key1.Length / 5 : key1.Length / 5 + 1); i++)
            {
                key1Matrix[i] = new ArrayList();
                int nextCount = 5;
                if ((i + 1) * 5 > key1.Length)
                {
                    nextCount = key1.Length % 5;
                }
                for (int j = 0; j < nextCount; j++)
                {
                    if (key1[j + i * 5] != (char)65 + limitCode)
                    {
                        key1Matrix[i].Add(key1[j + i * 5]);
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (key1Matrix[i] == null)
                {
                    key1Matrix[i] = new ArrayList();
                }
                int tempKey1Index = 0;
                if (key1Matrix[i].Count < 5 && key1Matrix[i].Count > 0)
                {
                    tempKey1Index = key1Matrix[i].Count % 5;
                }
                else if (key1Matrix[i].Count == 5)
                {
                    continue;
                }
                for (int j = tempKey1Index; j < 5; j++)
                {
                    char tempchr = (char)(65 + code);
                    bool exists = false;
                    foreach (var list in key1Matrix)
                    {
                        if (list != null && list.Contains(tempchr) == true)
                        {
                            exists = true;
                        }
                    }
                    if (exists == false)
                    {
                        key1Matrix[i].Add(tempchr);
                    }
                    else
                    {
                        while (true)
                        {
                            if (code != limitCode)
                            {
                                code++;
                            }
                            else
                            {
                                code += 2;
                            }

                            tempchr = (char)(65 + code);
                            exists = false;
                            foreach (var list in key1Matrix)
                            {
                                if (list != null && list.Contains(tempchr) == true)
                                {
                                    exists = true;
                                }
                            }
                            if (exists == false)
                            {
                                tempchr = (char)(65 + code);
                                key1Matrix[i].Add(tempchr);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (code != limitCode)
                    {
                        code++;
                    }
                    else
                    {
                        code += 2;
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                foreach (char e in key1Matrix[i])
                {
                    Console.Write("{0}", e.ToString());
                }
                Console.WriteLine();
            }
            code = 0;

            Console.WriteLine();
            //获得KEY2矩阵
            for (int i = 0; i < (int)(key2.Length % 5 == 0 ? key2.Length / 5 : key2.Length / 5 + 1); i++)
            {
                key2Matrix[i] = new ArrayList();
                int nextCount = 5;
                if ((i + 1) * 5 > key2.Length)
                {
                    nextCount = key2.Length % 5;
                }
                for (int j = 0; j < nextCount; j++)
                {
                    if (key2[j + i * 5] != (char)65 + limitCode)
                    {
                        key2Matrix[i].Add(key2[j + i * 5]);
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (key2Matrix[i] == null)
                {
                    key2Matrix[i] = new ArrayList();
                }
                int tempKey2Index = 0;
                if (key2Matrix[i].Count < 5 && key2Matrix[i].Count > 0)
                {
                    tempKey2Index = key2Matrix[i].Count % 5;
                }
                else if (key2Matrix[i].Count == 5)
                {
                    continue;
                }
                for (int j = tempKey2Index; j < 5; j++)
                {
                    char tempchr = (char)(65 + code);
                    bool exists = false;
                    foreach (var list in key2Matrix)
                    {
                        if (list != null && list.Contains(tempchr) == true)
                        {
                            exists = true;
                        }
                    }
                    if (exists == false)
                    {
                        key2Matrix[i].Add(tempchr);
                    }
                    else
                    {
                        while (true)
                        {
                            if (code != limitCode)
                            {
                                code++;
                            }
                            else
                            {
                                code += 2;
                            }

                            tempchr = (char)(65 + code);
                            exists = false;
                            foreach (var list in key2Matrix)
                            {
                                if (list != null && list.Contains(tempchr) == true)
                                {
                                    exists = true;
                                }
                            }
                            if (exists == false)
                            {
                                tempchr = (char)(65 + code);
                                key2Matrix[i].Add(tempchr);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (code != limitCode)
                    {
                        code++;
                    }
                    else
                    {
                        code += 2;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                foreach (char e in key2Matrix[i])
                {
                    Console.Write("{0}", e.ToString());
                }
                Console.WriteLine();
            }
            code = 0;
            Console.WriteLine();

            //获得密文内容矩阵
            int infoTemp = 0;
            for (int i = 0; i < cipherText.Length / 2; i++)
            {
                ArrayList list = new ArrayList();
                for (int j = 0; j < 2; j++)
                {
                    list.Add(cipherText[infoTemp]);
                    infoTemp++;
                }
                cipherTextMatrix.Add(list);
            }

            //获得解密后内容
            int key1Row = 0;
            int key1Column = 0;
            int key2Row = 0;
            int key2Column = 0;
            foreach (var item in cipherTextMatrix)
            {
                int infoCount = 1;
                foreach (var infoLetter in (ArrayList)item)
                {
                    if (infoCount == 1)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (key1Matrix[i][j].ToString().Equals(infoLetter.ToString()))
                                {
                                    key1Row = i;
                                    key1Column = j;
                                    infoCount = 2;
                                }
                            }
                        }
                    }
                    else if (infoCount == 2)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (key2Matrix[i][j].ToString().Equals(infoLetter.ToString()))
                                {
                                    key2Row = i;
                                    key2Column = j;
                                    infoCount = 0;
                                    ArrayList resultList = new ArrayList();
                                    ArrayList key1List = (ArrayList)key1Matrix[key1Row];
                                    ArrayList key2List = (ArrayList)key2Matrix[key2Row];
                                    resultList.Add(key1List[key2Column]);
                                    resultList.Add(key2List[key1Column]);
                                    decryptInfoMatrix.Add(resultList);
                                }
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("decryptResult:");
            foreach (ArrayList arr in decryptInfoMatrix)
            {
                foreach (var item in arr)
                {
                    Console.Write("{0}", item.ToString());
                }
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Read();
        }
        #endregion

        #region 删除字符串中重复的元素
        /// 方法名：DelStringSame     
        /// 功能：   删除字符串中重复的元素
        /// </summary>    
        /// <param name="TempArray">所要删除的字符串</param>
        /// <returns>返回字符串</returns>   
        public static string delStringSame(string TempStr)
        {
            char[] TempArray = (char[])TempStr.ToCharArray();
            ArrayList nStr = new ArrayList();
            for (int i = 0; i < TempArray.Length; i++)
            {
                if (!nStr.Contains(TempArray[i]))
                {
                    nStr.Add(TempArray[i]);
                }
            }
            string newStr = "";
            foreach (object a in nStr)
            {
                newStr = newStr + a.ToString();

            }
            return newStr;
        }
        #endregion
    }
}
