using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application
{
	public class FileNameProvider : IFileName
	{
		public FileNameProvider()
		{
			
		}

		private string _fileName;

		public string GetFileName()
		{
			return _fileName;
		}

		public void setFileName(string fileName)
		{
			_fileName = fileName;
		}
	}
}
