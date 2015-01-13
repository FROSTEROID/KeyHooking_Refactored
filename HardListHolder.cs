//using System;
using System.Collections.Generic;

namespace System.IO{
/// <summary>
/// Просто класс, инкапсулирующий работу с листом(List), члены которого хранятся на жёстком диске в текстовом файле.
/// Для создания экземпляра придётся указать путь к файлу. Если он не существует, то будет создан.
/// В процессе работы можно добавлять и удалять члены списка, брать их поиндексу и находить индекс по содержимому.
/// Для сохранения результатов нужно вызвать метод Save() или Dispose() - делают одно и то же.
/// Также есть метод Reload() - забыть внесённые изменения и считать данные заново.
/// </summary>
	class HardListHolder{
		#region objects
			#region Reader
			private StreamReader _reader;
			private void SpawnReader()
			{
				if (_reader != null)
					KillReader();
				_reader = new StreamReader(new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read));
			}
			private void KillReader()
			{
				if (_reader != null)
				{
					_reader.BaseStream.Close();
					_reader.Close();
					_reader.Dispose();
					_reader = null;
				}
			}
			#endregion
			#region Writer
			StreamWriter _writer;
			private void SpawnWriter()
			{
				if (_writer != null)
					KillWriter();
				_writer = new StreamWriter(new FileStream(_filePath, FileMode.Create, FileAccess.Write));
			}
			private void KillWriter()
			{
				if (_writer != null)
				{
					_writer.Flush();
					_writer.BaseStream.Close();
					//_writer.Close();
					//_writer.Dispose();
					_writer = null;
				}
			}
			#endregion
			private List<String> _list;
		#endregion

		#region parameters
		private string _filePath;
		#endregion

		#region read/write file
		/// <summary>
		/// Считать всё из файлища
		/// </summary>
		private void ReadTehShit()
		{
			_list.Clear();
			SpawnReader();
			while (!_reader.EndOfStream){
				_list.Add(_reader.ReadLine());
			}
			KillReader();

			if (_list.Count == 0){ // Если это первый запуск
				//throw(new Exception("NottinToRead! An empty file is ready. Shall eat Your strings. ;)"));
			}
		}
		/// <summary>
		/// Вписать всё в файлище
		/// </summary>
		private void WriteTehShit()
		{
			KillReader();
			SpawnWriter();
			foreach(string str in _list){
				_writer.WriteLine(str);
			}
			KillWriter();
		}
		#endregion

		#region Structing
		public HardListHolder(string pathToListFile){
			_list = new List<string>();
			_filePath = pathToListFile;
			ReadTehShit();
		}
		public void Dispose(){
			Save();
		}
		#endregion

		#region Public commands
		public void Reload(){
			ReadTehShit();
		}
		public void Save(){
			WriteTehShit();
		}

		public void Add(string str){
			_list.Add(str);
		}
		public void ReplaceAt(int index, string newStr){
			_list[index] = newStr;
		}
		public void RemoveAt(int index){
			_list.RemoveAt(index);
		}
		#endregion

		#region Settings
		public void SetFilePath(string pathToListFile, bool reloadList){
			_filePath = pathToListFile;
			if(reloadList) ReadTehShit();
		}
		#endregion

		#region gettings
		public string[] GetArray(){
			return _list.ToArray();
		}
		public int GetCount(){
			return _list.Count;
		}
		public List<string> GetList(){
			return new List<string>(_list.ToArray());
		}
		public int FindIndex(string str){
			return _list.IndexOf(str);
		}
		#endregion
	}
}
