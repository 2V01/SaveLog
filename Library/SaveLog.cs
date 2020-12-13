using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library
{
    public delegate void Message(string mes);
    public class SaveLog
    {
        string way;
        public event Message mes;
        public SaveLog()
        {
        }
        public SaveLog(string way)
        {
            this.way = way;
        }

        public async void AddLog(string text)
        {
            if (way != null)
            {
                using (FileStream fstream = new FileStream(@$"{way}\log.txt", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    await fstream.WriteAsync(array, 0, array.Length);
                    mes?.Invoke("Запись по заданному пути произошла успешно!");
                }
            }
            else
            {
                using (FileStream fstream = new FileStream(@$"log.txt", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    await fstream.WriteAsync(array, 0, array.Length);
                    mes?.Invoke("Запись по стандартному пути!");
                }
            }

        }
    }
}
