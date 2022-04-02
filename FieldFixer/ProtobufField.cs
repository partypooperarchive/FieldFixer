/*
 * Created by SharpDevelop.
 * User: User
 * Date: 02.04.2022
 * Time: 15:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace FieldFixer
{
	/// <summary>
	/// Description of ProtobufField.
	/// </summary>
	public abstract class ProtobufField
	{
		public string name;
		
		public ProtobufField(string name)
		{
			this.name = name;
		}
	}
	
	public class RegularField: ProtobufField 
	{
		public FieldDefinition field_number = null;
		public TypeReference field_type = null;
		
		public RegularField(FieldDefinition field_number, TypeReference field_type) : base(field_number.Name)
		{
			this.field_number = field_number;
			this.field_type = field_type;
		}
	}
	
	public class OneofField: ProtobufField
	{
		public Dictionary<int, RegularField> variants = null;
		
		public OneofField(string name) : base(name)
		{
			variants = new Dictionary<int, RegularField>();
		}
		
		public void AddRecord(FieldDefinition field_number, TypeReference field_type)
		{
			int index = variants.Count;
			var tuple = new RegularField(field_number, field_type);
			variants.Add(index, tuple);
		}
	}
}
