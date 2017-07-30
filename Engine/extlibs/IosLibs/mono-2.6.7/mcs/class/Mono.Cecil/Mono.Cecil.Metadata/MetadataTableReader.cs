//
// MetadataTableReader.cs
//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Generated by /CodeGen/cecil-gen.rb do not edit
// Tue Jul 17 00:22:32 +0200 2007
//
// (C) 2005 Jb Evain
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace Mono.Cecil.Metadata {

	using System;
	using System.Collections;
	using System.IO;

	sealed class MetadataTableReader : BaseMetadataTableVisitor {

		MetadataRoot m_metadataRoot;
		TablesHeap m_heap;
		MetadataRowReader m_mrrv;
		BinaryReader m_binaryReader;

		int [] m_rows = new int [TablesHeap.MaxTableCount];

		public MetadataTableReader (MetadataReader mrv)
		{
			m_metadataRoot = mrv.GetMetadataRoot ();
			m_heap = m_metadataRoot.Streams.TablesHeap;
			m_binaryReader = new BinaryReader (new MemoryStream (m_heap.Data));
			m_binaryReader.BaseStream.Position = 24;
			m_mrrv = new MetadataRowReader (this);
		}

		public MetadataRoot GetMetadataRoot ()
		{
			return m_metadataRoot;
		}

		public BinaryReader GetReader ()
		{
			return m_binaryReader;
		}

		public override IMetadataRowVisitor GetRowVisitor ()
		{
			return m_mrrv;
		}

		public int GetNumberOfRows (int rid)
		{
			return m_rows [rid];
		}

		public AssemblyTable GetAssemblyTable ()
		{
			return (AssemblyTable) m_heap [AssemblyTable.RId];
		}

		public AssemblyOSTable GetAssemblyOSTable ()
		{
			return (AssemblyOSTable) m_heap [AssemblyOSTable.RId];
		}

		public AssemblyProcessorTable GetAssemblyProcessorTable ()
		{
			return (AssemblyProcessorTable) m_heap [AssemblyProcessorTable.RId];
		}

		public AssemblyRefTable GetAssemblyRefTable ()
		{
			return (AssemblyRefTable) m_heap [AssemblyRefTable.RId];
		}

		public AssemblyRefOSTable GetAssemblyRefOSTable ()
		{
			return (AssemblyRefOSTable) m_heap [AssemblyRefOSTable.RId];
		}

		public AssemblyRefProcessorTable GetAssemblyRefProcessorTable ()
		{
			return (AssemblyRefProcessorTable) m_heap [AssemblyRefProcessorTable.RId];
		}

		public ClassLayoutTable GetClassLayoutTable ()
		{
			return (ClassLayoutTable) m_heap [ClassLayoutTable.RId];
		}

		public ConstantTable GetConstantTable ()
		{
			return (ConstantTable) m_heap [ConstantTable.RId];
		}

		public CustomAttributeTable GetCustomAttributeTable ()
		{
			return (CustomAttributeTable) m_heap [CustomAttributeTable.RId];
		}

		public DeclSecurityTable GetDeclSecurityTable ()
		{
			return (DeclSecurityTable) m_heap [DeclSecurityTable.RId];
		}

		public EventTable GetEventTable ()
		{
			return (EventTable) m_heap [EventTable.RId];
		}

		public EventMapTable GetEventMapTable ()
		{
			return (EventMapTable) m_heap [EventMapTable.RId];
		}

		public EventPtrTable GetEventPtrTable ()
		{
			return (EventPtrTable) m_heap [EventPtrTable.RId];
		}

		public ExportedTypeTable GetExportedTypeTable ()
		{
			return (ExportedTypeTable) m_heap [ExportedTypeTable.RId];
		}

		public FieldTable GetFieldTable ()
		{
			return (FieldTable) m_heap [FieldTable.RId];
		}

		public FieldLayoutTable GetFieldLayoutTable ()
		{
			return (FieldLayoutTable) m_heap [FieldLayoutTable.RId];
		}

		public FieldMarshalTable GetFieldMarshalTable ()
		{
			return (FieldMarshalTable) m_heap [FieldMarshalTable.RId];
		}

		public FieldPtrTable GetFieldPtrTable ()
		{
			return (FieldPtrTable) m_heap [FieldPtrTable.RId];
		}

		public FieldRVATable GetFieldRVATable ()
		{
			return (FieldRVATable) m_heap [FieldRVATable.RId];
		}

		public FileTable GetFileTable ()
		{
			return (FileTable) m_heap [FileTable.RId];
		}

		public GenericParamTable GetGenericParamTable ()
		{
			return (GenericParamTable) m_heap [GenericParamTable.RId];
		}

		public GenericParamConstraintTable GetGenericParamConstraintTable ()
		{
			return (GenericParamConstraintTable) m_heap [GenericParamConstraintTable.RId];
		}

		public ImplMapTable GetImplMapTable ()
		{
			return (ImplMapTable) m_heap [ImplMapTable.RId];
		}

		public InterfaceImplTable GetInterfaceImplTable ()
		{
			return (InterfaceImplTable) m_heap [InterfaceImplTable.RId];
		}

		public ManifestResourceTable GetManifestResourceTable ()
		{
			return (ManifestResourceTable) m_heap [ManifestResourceTable.RId];
		}

		public MemberRefTable GetMemberRefTable ()
		{
			return (MemberRefTable) m_heap [MemberRefTable.RId];
		}

		public MethodTable GetMethodTable ()
		{
			return (MethodTable) m_heap [MethodTable.RId];
		}

		public MethodImplTable GetMethodImplTable ()
		{
			return (MethodImplTable) m_heap [MethodImplTable.RId];
		}

		public MethodPtrTable GetMethodPtrTable ()
		{
			return (MethodPtrTable) m_heap [MethodPtrTable.RId];
		}

		public MethodSemanticsTable GetMethodSemanticsTable ()
		{
			return (MethodSemanticsTable) m_heap [MethodSemanticsTable.RId];
		}

		public MethodSpecTable GetMethodSpecTable ()
		{
			return (MethodSpecTable) m_heap [MethodSpecTable.RId];
		}

		public ModuleTable GetModuleTable ()
		{
			return (ModuleTable) m_heap [ModuleTable.RId];
		}

		public ModuleRefTable GetModuleRefTable ()
		{
			return (ModuleRefTable) m_heap [ModuleRefTable.RId];
		}

		public NestedClassTable GetNestedClassTable ()
		{
			return (NestedClassTable) m_heap [NestedClassTable.RId];
		}

		public ParamTable GetParamTable ()
		{
			return (ParamTable) m_heap [ParamTable.RId];
		}

		public ParamPtrTable GetParamPtrTable ()
		{
			return (ParamPtrTable) m_heap [ParamPtrTable.RId];
		}

		public PropertyTable GetPropertyTable ()
		{
			return (PropertyTable) m_heap [PropertyTable.RId];
		}

		public PropertyMapTable GetPropertyMapTable ()
		{
			return (PropertyMapTable) m_heap [PropertyMapTable.RId];
		}

		public PropertyPtrTable GetPropertyPtrTable ()
		{
			return (PropertyPtrTable) m_heap [PropertyPtrTable.RId];
		}

		public StandAloneSigTable GetStandAloneSigTable ()
		{
			return (StandAloneSigTable) m_heap [StandAloneSigTable.RId];
		}

		public TypeDefTable GetTypeDefTable ()
		{
			return (TypeDefTable) m_heap [TypeDefTable.RId];
		}

		public TypeRefTable GetTypeRefTable ()
		{
			return (TypeRefTable) m_heap [TypeRefTable.RId];
		}

		public TypeSpecTable GetTypeSpecTable ()
		{
			return (TypeSpecTable) m_heap [TypeSpecTable.RId];
		}

		public override void VisitTableCollection (TableCollection coll)
		{
			if (m_heap.HasTable (ModuleTable.RId)) {
				coll.Add (new ModuleTable ());
				m_rows [ModuleTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (TypeRefTable.RId)) {
				coll.Add (new TypeRefTable ());
				m_rows [TypeRefTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (TypeDefTable.RId)) {
				coll.Add (new TypeDefTable ());
				m_rows [TypeDefTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (FieldPtrTable.RId)) {
				coll.Add (new FieldPtrTable ());
				m_rows [FieldPtrTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (FieldTable.RId)) {
				coll.Add (new FieldTable ());
				m_rows [FieldTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (MethodPtrTable.RId)) {
				coll.Add (new MethodPtrTable ());
				m_rows [MethodPtrTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (MethodTable.RId)) {
				coll.Add (new MethodTable ());
				m_rows [MethodTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ParamPtrTable.RId)) {
				coll.Add (new ParamPtrTable ());
				m_rows [ParamPtrTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ParamTable.RId)) {
				coll.Add (new ParamTable ());
				m_rows [ParamTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (InterfaceImplTable.RId)) {
				coll.Add (new InterfaceImplTable ());
				m_rows [InterfaceImplTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (MemberRefTable.RId)) {
				coll.Add (new MemberRefTable ());
				m_rows [MemberRefTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ConstantTable.RId)) {
				coll.Add (new ConstantTable ());
				m_rows [ConstantTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (CustomAttributeTable.RId)) {
				coll.Add (new CustomAttributeTable ());
				m_rows [CustomAttributeTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (FieldMarshalTable.RId)) {
				coll.Add (new FieldMarshalTable ());
				m_rows [FieldMarshalTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (DeclSecurityTable.RId)) {
				coll.Add (new DeclSecurityTable ());
				m_rows [DeclSecurityTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ClassLayoutTable.RId)) {
				coll.Add (new ClassLayoutTable ());
				m_rows [ClassLayoutTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (FieldLayoutTable.RId)) {
				coll.Add (new FieldLayoutTable ());
				m_rows [FieldLayoutTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (StandAloneSigTable.RId)) {
				coll.Add (new StandAloneSigTable ());
				m_rows [StandAloneSigTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (EventMapTable.RId)) {
				coll.Add (new EventMapTable ());
				m_rows [EventMapTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (EventPtrTable.RId)) {
				coll.Add (new EventPtrTable ());
				m_rows [EventPtrTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (EventTable.RId)) {
				coll.Add (new EventTable ());
				m_rows [EventTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (PropertyMapTable.RId)) {
				coll.Add (new PropertyMapTable ());
				m_rows [PropertyMapTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (PropertyPtrTable.RId)) {
				coll.Add (new PropertyPtrTable ());
				m_rows [PropertyPtrTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (PropertyTable.RId)) {
				coll.Add (new PropertyTable ());
				m_rows [PropertyTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (MethodSemanticsTable.RId)) {
				coll.Add (new MethodSemanticsTable ());
				m_rows [MethodSemanticsTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (MethodImplTable.RId)) {
				coll.Add (new MethodImplTable ());
				m_rows [MethodImplTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ModuleRefTable.RId)) {
				coll.Add (new ModuleRefTable ());
				m_rows [ModuleRefTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (TypeSpecTable.RId)) {
				coll.Add (new TypeSpecTable ());
				m_rows [TypeSpecTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ImplMapTable.RId)) {
				coll.Add (new ImplMapTable ());
				m_rows [ImplMapTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (FieldRVATable.RId)) {
				coll.Add (new FieldRVATable ());
				m_rows [FieldRVATable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (AssemblyTable.RId)) {
				coll.Add (new AssemblyTable ());
				m_rows [AssemblyTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (AssemblyProcessorTable.RId)) {
				coll.Add (new AssemblyProcessorTable ());
				m_rows [AssemblyProcessorTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (AssemblyOSTable.RId)) {
				coll.Add (new AssemblyOSTable ());
				m_rows [AssemblyOSTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (AssemblyRefTable.RId)) {
				coll.Add (new AssemblyRefTable ());
				m_rows [AssemblyRefTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (AssemblyRefProcessorTable.RId)) {
				coll.Add (new AssemblyRefProcessorTable ());
				m_rows [AssemblyRefProcessorTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (AssemblyRefOSTable.RId)) {
				coll.Add (new AssemblyRefOSTable ());
				m_rows [AssemblyRefOSTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (FileTable.RId)) {
				coll.Add (new FileTable ());
				m_rows [FileTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ExportedTypeTable.RId)) {
				coll.Add (new ExportedTypeTable ());
				m_rows [ExportedTypeTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (ManifestResourceTable.RId)) {
				coll.Add (new ManifestResourceTable ());
				m_rows [ManifestResourceTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (NestedClassTable.RId)) {
				coll.Add (new NestedClassTable ());
				m_rows [NestedClassTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (GenericParamTable.RId)) {
				coll.Add (new GenericParamTable ());
				m_rows [GenericParamTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (MethodSpecTable.RId)) {
				coll.Add (new MethodSpecTable ());
				m_rows [MethodSpecTable.RId] = m_binaryReader.ReadInt32 ();
			}
			if (m_heap.HasTable (GenericParamConstraintTable.RId)) {
				coll.Add (new GenericParamConstraintTable ());
				m_rows [GenericParamConstraintTable.RId] = m_binaryReader.ReadInt32 ();
			}
		}

		public override void VisitAssemblyTable (AssemblyTable table)
		{
			int number = m_rows [AssemblyTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new AssemblyRow ());
		}
		public override void VisitAssemblyOSTable (AssemblyOSTable table)
		{
			int number = m_rows [AssemblyOSTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new AssemblyOSRow ());
		}
		public override void VisitAssemblyProcessorTable (AssemblyProcessorTable table)
		{
			int number = m_rows [AssemblyProcessorTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new AssemblyProcessorRow ());
		}
		public override void VisitAssemblyRefTable (AssemblyRefTable table)
		{
			int number = m_rows [AssemblyRefTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new AssemblyRefRow ());
		}
		public override void VisitAssemblyRefOSTable (AssemblyRefOSTable table)
		{
			int number = m_rows [AssemblyRefOSTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new AssemblyRefOSRow ());
		}
		public override void VisitAssemblyRefProcessorTable (AssemblyRefProcessorTable table)
		{
			int number = m_rows [AssemblyRefProcessorTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new AssemblyRefProcessorRow ());
		}
		public override void VisitClassLayoutTable (ClassLayoutTable table)
		{
			int number = m_rows [ClassLayoutTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ClassLayoutRow ());
		}
		public override void VisitConstantTable (ConstantTable table)
		{
			int number = m_rows [ConstantTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ConstantRow ());
		}
		public override void VisitCustomAttributeTable (CustomAttributeTable table)
		{
			int number = m_rows [CustomAttributeTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new CustomAttributeRow ());
		}
		public override void VisitDeclSecurityTable (DeclSecurityTable table)
		{
			int number = m_rows [DeclSecurityTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new DeclSecurityRow ());
		}
		public override void VisitEventTable (EventTable table)
		{
			int number = m_rows [EventTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new EventRow ());
		}
		public override void VisitEventMapTable (EventMapTable table)
		{
			int number = m_rows [EventMapTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new EventMapRow ());
		}
		public override void VisitEventPtrTable (EventPtrTable table)
		{
			int number = m_rows [EventPtrTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new EventPtrRow ());
		}
		public override void VisitExportedTypeTable (ExportedTypeTable table)
		{
			int number = m_rows [ExportedTypeTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ExportedTypeRow ());
		}
		public override void VisitFieldTable (FieldTable table)
		{
			int number = m_rows [FieldTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new FieldRow ());
		}
		public override void VisitFieldLayoutTable (FieldLayoutTable table)
		{
			int number = m_rows [FieldLayoutTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new FieldLayoutRow ());
		}
		public override void VisitFieldMarshalTable (FieldMarshalTable table)
		{
			int number = m_rows [FieldMarshalTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new FieldMarshalRow ());
		}
		public override void VisitFieldPtrTable (FieldPtrTable table)
		{
			int number = m_rows [FieldPtrTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new FieldPtrRow ());
		}
		public override void VisitFieldRVATable (FieldRVATable table)
		{
			int number = m_rows [FieldRVATable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new FieldRVARow ());
		}
		public override void VisitFileTable (FileTable table)
		{
			int number = m_rows [FileTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new FileRow ());
		}
		public override void VisitGenericParamTable (GenericParamTable table)
		{
			int number = m_rows [GenericParamTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new GenericParamRow ());
		}
		public override void VisitGenericParamConstraintTable (GenericParamConstraintTable table)
		{
			int number = m_rows [GenericParamConstraintTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new GenericParamConstraintRow ());
		}
		public override void VisitImplMapTable (ImplMapTable table)
		{
			int number = m_rows [ImplMapTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ImplMapRow ());
		}
		public override void VisitInterfaceImplTable (InterfaceImplTable table)
		{
			int number = m_rows [InterfaceImplTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new InterfaceImplRow ());
		}
		public override void VisitManifestResourceTable (ManifestResourceTable table)
		{
			int number = m_rows [ManifestResourceTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ManifestResourceRow ());
		}
		public override void VisitMemberRefTable (MemberRefTable table)
		{
			int number = m_rows [MemberRefTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new MemberRefRow ());
		}
		public override void VisitMethodTable (MethodTable table)
		{
			int number = m_rows [MethodTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new MethodRow ());
		}
		public override void VisitMethodImplTable (MethodImplTable table)
		{
			int number = m_rows [MethodImplTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new MethodImplRow ());
		}
		public override void VisitMethodPtrTable (MethodPtrTable table)
		{
			int number = m_rows [MethodPtrTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new MethodPtrRow ());
		}
		public override void VisitMethodSemanticsTable (MethodSemanticsTable table)
		{
			int number = m_rows [MethodSemanticsTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new MethodSemanticsRow ());
		}
		public override void VisitMethodSpecTable (MethodSpecTable table)
		{
			int number = m_rows [MethodSpecTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new MethodSpecRow ());
		}
		public override void VisitModuleTable (ModuleTable table)
		{
			int number = m_rows [ModuleTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ModuleRow ());
		}
		public override void VisitModuleRefTable (ModuleRefTable table)
		{
			int number = m_rows [ModuleRefTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ModuleRefRow ());
		}
		public override void VisitNestedClassTable (NestedClassTable table)
		{
			int number = m_rows [NestedClassTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new NestedClassRow ());
		}
		public override void VisitParamTable (ParamTable table)
		{
			int number = m_rows [ParamTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ParamRow ());
		}
		public override void VisitParamPtrTable (ParamPtrTable table)
		{
			int number = m_rows [ParamPtrTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new ParamPtrRow ());
		}
		public override void VisitPropertyTable (PropertyTable table)
		{
			int number = m_rows [PropertyTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new PropertyRow ());
		}
		public override void VisitPropertyMapTable (PropertyMapTable table)
		{
			int number = m_rows [PropertyMapTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new PropertyMapRow ());
		}
		public override void VisitPropertyPtrTable (PropertyPtrTable table)
		{
			int number = m_rows [PropertyPtrTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new PropertyPtrRow ());
		}
		public override void VisitStandAloneSigTable (StandAloneSigTable table)
		{
			int number = m_rows [StandAloneSigTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new StandAloneSigRow ());
		}
		public override void VisitTypeDefTable (TypeDefTable table)
		{
			int number = m_rows [TypeDefTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new TypeDefRow ());
		}
		public override void VisitTypeRefTable (TypeRefTable table)
		{
			int number = m_rows [TypeRefTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new TypeRefRow ());
		}
		public override void VisitTypeSpecTable (TypeSpecTable table)
		{
			int number = m_rows [TypeSpecTable.RId];
			table.Rows = new RowCollection (number);
			for (int i = 0; i < number; i++)
				table.Rows.Add (new TypeSpecRow ());
		}
	}
}
