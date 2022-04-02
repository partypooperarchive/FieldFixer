#define DDEBUG
/*
 * Created by SharpDevelop.
 * User: User
 * Date: 01.04.2022
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FieldFixer
{
	class Program
	{
		public static void Main(string[] args)
		{
			#if DDEBUG
			var config_path = @"Z:\config_2.7.0.ini";
			#else
			var config_path = args[0];
			#endif
			
			var config = new IniReader(config_path);
			
			var obf_base_class = config.GetValue("ObfuscatedProtobufBaseClassName", "Settings");
			var obf_cmd_id = config.GetValue("ObfuscatedCmdIdName", "Settings");
			var obf_dll_path = config.GetValue("ObfuscatedDllPath", "Settings");
			
			var de_dll_path = config.GetValue("DeobfuscatedDllPath", "Settings");
			
			var mapping_path = config.GetValue("MappingCsvPath", "Settings");
			
			var out_dll_path = config.GetValue("OutputDllPath", "Settings");
			
			var f = new Fixer();
			
			f.load_cmdid_mapping(mapping_path);
			
			f.load_obf_assembly(obf_dll_path, obf_base_class, obf_cmd_id);
			
			f.load_de_assembly(de_dll_path);
			
			f.perform_fixup();
			
			f.save(out_dll_path);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}