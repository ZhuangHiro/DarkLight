﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
 * 使用方法
class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("开始读取文件");
        var bt = MSCL.ByteHelper.ReadFileToByte("C:\\111.jpg");
        Console.WriteLine("开始保存文件");
        MSCL.ByteHelper.WriteByteToFile(bt, "C:\\111_1.jpg");
        Console.WriteLine("完成");
        Console.ReadLine();
    }

*/


public class ByteHelper
{
    /// <summary>
    /// 读文件到byte[]
    /// </summary>
    /// <param name="fileName">硬盘文件路径</param>
    /// <returns></returns>
    public static byte[] ReadFileToByte(string fileName)
    {
        FileStream pFileStream = null;
        byte[] pReadByte = new byte[0];
        try
        {
            pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(pFileStream);
            r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开
            pReadByte = r.ReadBytes((int)r.BaseStream.Length);
            return pReadByte;
        }
        catch
        {
            return pReadByte;
        }
        finally
        {
            if (pFileStream != null)
                pFileStream.Close();
        }
    }

    /// <summary>
    /// 写byte[]到fileName
    /// </summary>
    /// <param name="pReadByte">byte[]</param>
    /// <param name="fileName">保存至硬盘路径</param>
    /// <returns></returns>
    public static bool WriteByteToFile(byte[] pReadByte, string fileName)
    {
        FileStream pFileStream = null;
        try
        {
            pFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            pFileStream.Write(pReadByte, 0, pReadByte.Length);
        }
        catch
        {
            return false;
        }
        finally
        {
            if (pFileStream != null)
                pFileStream.Close();
        }
        return true;
    }
}
