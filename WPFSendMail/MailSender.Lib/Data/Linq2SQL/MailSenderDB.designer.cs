﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MailSender.Lib.Data.Linq2SQL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MailSenderDB")]
	public partial class MailSenderDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSender(Sender instance);
    partial void UpdateSender(Sender instance);
    partial void DeleteSender(Sender instance);
    partial void InsertServer_smtp(Server_smtp instance);
    partial void UpdateServer_smtp(Server_smtp instance);
    partial void DeleteServer_smtp(Server_smtp instance);
    partial void InsertRecipientsList(RecipientsList instance);
    partial void UpdateRecipientsList(RecipientsList instance);
    partial void DeleteRecipientsList(RecipientsList instance);
    partial void InsertRecipient(Recipient instance);
    partial void UpdateRecipient(Recipient instance);
    partial void DeleteRecipient(Recipient instance);
    partial void InsertTask(Task instance);
    partial void UpdateTask(Task instance);
    partial void DeleteTask(Task instance);
    partial void Insertmail(mail instance);
    partial void Updatemail(mail instance);
    partial void Deletemail(mail instance);
    #endregion
		
		public MailSenderDBDataContext() : 
				base(global::MailSender.Lib.Properties.Settings.Default.MailSenderDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Sender> Senders
		{
			get
			{
				return this.GetTable<Sender>();
			}
		}
		
		public System.Data.Linq.Table<Server_smtp> Server_smtps
		{
			get
			{
				return this.GetTable<Server_smtp>();
			}
		}
		
		public System.Data.Linq.Table<RecipientsList> RecipientsLists
		{
			get
			{
				return this.GetTable<RecipientsList>();
			}
		}
		
		public System.Data.Linq.Table<Recipient> Recipients
		{
			get
			{
				return this.GetTable<Recipient>();
			}
		}
		
		public System.Data.Linq.Table<Task> Tasks
		{
			get
			{
				return this.GetTable<Task>();
			}
		}
		
		public System.Data.Linq.Table<mail> mails
		{
			get
			{
				return this.GetTable<mail>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sender")]
	public partial class Sender : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _sender_id;
		
		private string _name;
		
		private string _login;
		
		private string _password;
		
		private string _email;
		
		private System.Nullable<int> _server_server_id;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onsender_idChanging(int value);
    partial void Onsender_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnloginChanging(string value);
    partial void OnloginChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void Onserver_server_idChanging(System.Nullable<int> value);
    partial void Onserver_server_idChanged();
    #endregion
		
		public Sender()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sender_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int sender_id
		{
			get
			{
				return this._sender_id;
			}
			set
			{
				if ((this._sender_id != value))
				{
					this.Onsender_idChanging(value);
					this.SendPropertyChanging();
					this._sender_id = value;
					this.SendPropertyChanged("sender_id");
					this.Onsender_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_login", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string login
		{
			get
			{
				return this._login;
			}
			set
			{
				if ((this._login != value))
				{
					this.OnloginChanging(value);
					this.SendPropertyChanging();
					this._login = value;
					this.SendPropertyChanged("login");
					this.OnloginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_server_server_id", DbType="Int")]
		public System.Nullable<int> server_server_id
		{
			get
			{
				return this._server_server_id;
			}
			set
			{
				if ((this._server_server_id != value))
				{
					this.Onserver_server_idChanging(value);
					this.SendPropertyChanging();
					this._server_server_id = value;
					this.SendPropertyChanged("server_server_id");
					this.Onserver_server_idChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Server_smtp")]
	public partial class Server_smtp : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _server_id;
		
		private string _address;
		
		private int _port;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onserver_idChanging(int value);
    partial void Onserver_idChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnportChanging(int value);
    partial void OnportChanged();
    #endregion
		
		public Server_smtp()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_server_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int server_id
		{
			get
			{
				return this._server_id;
			}
			set
			{
				if ((this._server_id != value))
				{
					this.Onserver_idChanging(value);
					this.SendPropertyChanging();
					this._server_id = value;
					this.SendPropertyChanged("server_id");
					this.Onserver_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_port", DbType="Int NOT NULL")]
		public int port
		{
			get
			{
				return this._port;
			}
			set
			{
				if ((this._port != value))
				{
					this.OnportChanging(value);
					this.SendPropertyChanging();
					this._port = value;
					this.SendPropertyChanged("port");
					this.OnportChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.RecipientsList")]
	public partial class RecipientsList : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _list_id;
		
		private string _name;
		
		private string _description;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onlist_idChanging(int value);
    partial void Onlist_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    #endregion
		
		public RecipientsList()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_list_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int list_id
		{
			get
			{
				return this._list_id;
			}
			set
			{
				if ((this._list_id != value))
				{
					this.Onlist_idChanging(value);
					this.SendPropertyChanging();
					this._list_id = value;
					this.SendPropertyChanged("list_id");
					this.Onlist_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(255)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Recipient")]
	public partial class Recipient : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _recipient_id;
		
		private string _name;
		
		private string _email;
		
		private string _description;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onrecipient_idChanging(int value);
    partial void Onrecipient_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    #endregion
		
		public Recipient()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_recipient_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int recipient_id
		{
			get
			{
				return this._recipient_id;
			}
			set
			{
				if ((this._recipient_id != value))
				{
					this.Onrecipient_idChanging(value);
					this.SendPropertyChanging();
					this._recipient_id = value;
					this.SendPropertyChanged("recipient_id");
					this.Onrecipient_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(255)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Task")]
	public partial class Task : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _task_id;
		
		private string _name;
		
		private System.Nullable<int> _sender_sender_id;
		
		private System.Nullable<int> _list_list_id;
		
		private System.Nullable<int> _mail_mail_id;
		
		private System.Nullable<int> _shdedule_shedule_id;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ontask_idChanging(int value);
    partial void Ontask_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void Onsender_sender_idChanging(System.Nullable<int> value);
    partial void Onsender_sender_idChanged();
    partial void Onlist_list_idChanging(System.Nullable<int> value);
    partial void Onlist_list_idChanged();
    partial void Onmail_mail_idChanging(System.Nullable<int> value);
    partial void Onmail_mail_idChanged();
    partial void Onshdedule_shedule_idChanging(System.Nullable<int> value);
    partial void Onshdedule_shedule_idChanged();
    #endregion
		
		public Task()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_task_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int task_id
		{
			get
			{
				return this._task_id;
			}
			set
			{
				if ((this._task_id != value))
				{
					this.Ontask_idChanging(value);
					this.SendPropertyChanging();
					this._task_id = value;
					this.SendPropertyChanged("task_id");
					this.Ontask_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(60)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sender_sender_id", DbType="Int")]
		public System.Nullable<int> sender_sender_id
		{
			get
			{
				return this._sender_sender_id;
			}
			set
			{
				if ((this._sender_sender_id != value))
				{
					this.Onsender_sender_idChanging(value);
					this.SendPropertyChanging();
					this._sender_sender_id = value;
					this.SendPropertyChanged("sender_sender_id");
					this.Onsender_sender_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_list_list_id", DbType="Int")]
		public System.Nullable<int> list_list_id
		{
			get
			{
				return this._list_list_id;
			}
			set
			{
				if ((this._list_list_id != value))
				{
					this.Onlist_list_idChanging(value);
					this.SendPropertyChanging();
					this._list_list_id = value;
					this.SendPropertyChanged("list_list_id");
					this.Onlist_list_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mail_mail_id", DbType="Int")]
		public System.Nullable<int> mail_mail_id
		{
			get
			{
				return this._mail_mail_id;
			}
			set
			{
				if ((this._mail_mail_id != value))
				{
					this.Onmail_mail_idChanging(value);
					this.SendPropertyChanging();
					this._mail_mail_id = value;
					this.SendPropertyChanged("mail_mail_id");
					this.Onmail_mail_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shdedule_shedule_id", DbType="Int")]
		public System.Nullable<int> shdedule_shedule_id
		{
			get
			{
				return this._shdedule_shedule_id;
			}
			set
			{
				if ((this._shdedule_shedule_id != value))
				{
					this.Onshdedule_shedule_idChanging(value);
					this.SendPropertyChanging();
					this._shdedule_shedule_id = value;
					this.SendPropertyChanged("shdedule_shedule_id");
					this.Onshdedule_shedule_idChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.mails")]
	public partial class mail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _subject;
		
		private string _message;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnsubjectChanging(string value);
    partial void OnsubjectChanged();
    partial void OnmessageChanging(string value);
    partial void OnmessageChanged();
    #endregion
		
		public mail()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_subject", DbType="NVarChar(4000)")]
		public string subject
		{
			get
			{
				return this._subject;
			}
			set
			{
				if ((this._subject != value))
				{
					this.OnsubjectChanging(value);
					this.SendPropertyChanging();
					this._subject = value;
					this.SendPropertyChanged("subject");
					this.OnsubjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_message", DbType="NVarChar(4000)")]
		public string message
		{
			get
			{
				return this._message;
			}
			set
			{
				if ((this._message != value))
				{
					this.OnmessageChanging(value);
					this.SendPropertyChanging();
					this._message = value;
					this.SendPropertyChanged("message");
					this.OnmessageChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
