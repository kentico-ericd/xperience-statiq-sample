//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Statiq;

[assembly: RegisterDocumentType(Book.CLASS_NAME, typeof(Book))]

namespace CMS.DocumentEngine.Types.Statiq
{
	/// <summary>
	/// Represents a content item of type Book.
	/// </summary>
	public partial class Book : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "Statiq.Book";


		/// <summary>
		/// The instance of the class that provides extended API for working with Book fields.
		/// </summary>
		private readonly BookFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// BookID.
		/// </summary>
		[DatabaseIDField]
		public int BookID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("BookID"), 0);
			}
			set
			{
				SetValue("BookID", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Category.
		/// </summary>
		[DatabaseField]
		public string Category
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Category"), @"");
			}
			set
			{
				SetValue("Category", value);
			}
		}


		/// <summary>
		/// Cover.
		/// </summary>
		[DatabaseField]
		public string Cover
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Cover"), "");
			}
			set
			{
				SetValue("Cover", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Book fields.
		/// </summary>
		[RegisterProperty]
		public BookFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Book fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class BookFields : AbstractHierarchicalObject<BookFields>
		{
			/// <summary>
			/// The content item of type Book that is a target of the extended API.
			/// </summary>
			private readonly Book mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="BookFields" /> class with the specified content item of type Book.
			/// </summary>
			/// <param name="instance">The content item of type Book that is a target of the extended API.</param>
			public BookFields(Book instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// BookID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.BookID;
				}
				set
				{
					mInstance.BookID = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.Title;
				}
				set
				{
					mInstance.Title = value;
				}
			}


			/// <summary>
			/// Author.
			/// </summary>
			public IEnumerable<TreeNode> Author
			{
				get
				{
					return mInstance.GetRelatedDocuments("Author");
				}
			}


			/// <summary>
			/// Category.
			/// </summary>
			public string Category
			{
				get
				{
					return mInstance.Category;
				}
				set
				{
					mInstance.Category = value;
				}
			}


			/// <summary>
			/// Cover.
			/// </summary>
			public IEnumerable<DocumentAttachment> Cover
			{
				get
				{
					return mInstance.GetFieldDocumentAttachments("Cover");
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Book" /> class.
		/// </summary>
		public Book() : base(CLASS_NAME)
		{
			mFields = new BookFields(this);
		}

		#endregion
	}
}