using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

public class ChineseDate
{
    public static string Baodate2Chinese(string strDate)
    {
        char[] strChinese = new char[] {
                 '��','һ','��','��','��','��','��','��','��','��','ʮ'
             };
        StringBuilder result = new StringBuilder();

        //// ����������ʽ�жϲ����Ƿ���ȷ
        //Regex theReg = new Regex(@"(d{2}|d{4})(/|-)(d{1,2})(/|-)(d{1,2})");

        if (!string.IsNullOrEmpty(strDate))
        {
            // ���������ڵ������մ浽�ַ�����str��
            string[] str = null;
            if (strDate.Contains("-"))
            {
                str = strDate.Split('-');
            }
            else if (strDate.Contains("/"))
            {
                str = strDate.Split('/');
            }
            // str[0]��Ϊ�꣬��������ַ�ת��Ϊ��Ӧ�ĺ���
            for (int i = 0; i < str[0].Length; i++)
            {
                result.Append(strChinese[int.Parse(str[0][i].ToString())]);
            }
            result.Append("��");

            // ת����
            int month = int.Parse(str[1]);
            int MN1 = month / 10;
            int MN2 = month % 10;

            if (MN1 > 1)
            {
                result.Append(strChinese[MN1]);
            }
            if (MN1 > 0)
            {
                result.Append(strChinese[10]);
            }
            if (MN2 != 0)
            {
                result.Append(strChinese[MN2]);
            }
            result.Append("��");

            // ת����
            int day = int.Parse(str[2]);
            int DN1 = day / 10;
            int DN2 = day % 10;

            if (DN1 > 1)
            {
                result.Append(strChinese[DN1]);
            }
            if (DN1 > 0)
            {
                result.Append(strChinese[10]);
            }
            if (DN2 != 0)
            {
                result.Append(strChinese[DN2]);
            }
            result.Append("��");
        }
        else
        {
            throw new ArgumentException();
        }

        return result.ToString();
    }
}
