/*
 * Created by SharpDevelop.
 * User: User
 * Date: 02.04.2022
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Mono.Cecil;
using System.Linq;

namespace FieldFixer
{
	/// <summary>
	/// Description of Extensions.
	/// </summary>
	public static class Extensions
	{
		public static uint GetConstant(this FieldDefinition f) {
			return UInt32.Parse(f.Constant.ToString());
		}
		
		public static bool IsBeeObfuscated(this string name) {
			// TODO: very simple but should work
			return name.All(char.IsUpper) && (name.Length >= 10 && name.Length <= 15);
		}
	}
}
