using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionSubsitution
{
    internal static class Core
    {
        [DllImport("FunctionSubstitutionCore.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int init_python(
            [MarshalAs(UnmanagedType.LPStr)] string cwd,
            [MarshalAs(UnmanagedType.LPStr)] string python_path
            );

        [DllImport("FunctionSubstitutionCore.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void deinit_python();

        [StructLayout(LayoutKind.Sequential)]
        public struct processing_info
        {
            [MarshalAs(UnmanagedType.LPStr)] public string profile_path;
            [MarshalAs(UnmanagedType.LPStr)] public string csv_path;
            [MarshalAs(UnmanagedType.LPStr)] public string output_col_name;
            [MarshalAs(UnmanagedType.LPStr)] public string output_file_name;
            [MarshalAs(UnmanagedType.LPStr)] public string mapping_table;
        }

        [DllImport("FunctionSubstitutionCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int process_data(ref processing_info info);

        [DllImport("FunctionSubstitutionCore.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int make_funcImg(
            [MarshalAs(UnmanagedType.LPStr)] string funcStr,
            [MarshalAs(UnmanagedType.LPStr)] string fileName,
            [MarshalAs(UnmanagedType.U4)] int fontsize,
            [MarshalAs(UnmanagedType.U4)] int dpi
            );
    }
}
